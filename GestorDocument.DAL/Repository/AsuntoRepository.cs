using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Objects;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;

namespace GestorDocument.DAL.Repository
{
    public class AsuntoRepository : IAsunto ,ISync
    {
        public ITurno _TurnoRepository = new TurnoRepository();

        public void InsertAsunto(Model.AsuntoModel asunto)
        {
            using (var entity = new GestorDocumentEntities())

                if (asunto != null)
                {
                    //Validar si el elemento ya existe
                    GET_ASUNTO result = null;
                    try
                    {
                        result = (from o in entity.GET_ASUNTO
                                  where o.IdAsunto == asunto.IdAsunto
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }

                    if (result == null)
                    {
                        entity.GET_ASUNTO.AddObject(
                            new GET_ASUNTO()
                            {
                                IdAsunto = asunto.IdAsunto,
                                FechaCreacion = asunto.FechaCreacion,
                                FechaRecibido = asunto.FechaRecibido,
                                FechaDocumento = asunto.FechaDocumento,
                                ReferenciaDocumento= (!string.IsNullOrWhiteSpace(asunto.ReferenciaDocumento)) ? asunto.ReferenciaDocumento.Trim():null,
                                Titulo = (!string.IsNullOrWhiteSpace( asunto.Titulo)) ?asunto.Titulo.Trim():null,
                                Descripcion =(!string.IsNullOrWhiteSpace(asunto.Descripcion))? asunto.Descripcion.Trim():null,
                                Alcance = (!string.IsNullOrWhiteSpace(asunto.Alcance))? asunto.Alcance.Trim():null,
                                IdUbicacion = (asunto.Ubicacion != null) ? (Nullable<long>)asunto.Ubicacion.IdUbicacion : null,
                                IdInstruccion = (asunto.Instruccion != null) ? (Nullable<long>)asunto.Instruccion.IdInstruccion : null,
                                IdPrioridad = (asunto.Prioridad != null) ? (Nullable<long>)asunto.Prioridad.IdPrioridad : null,
                                IdStatusAsunto = asunto.StatusAsunto.IdStatusAsunto,
                                FechaVencimiento = asunto.FechaVencimiento,
                                Folio = (!string.IsNullOrWhiteSpace(asunto.Folio)) ? asunto.Folio.Trim() : null,
                                IsActive = asunto.IsActive,
                                IsModified =true,
                                LastModifiedDate = new  UNID().getNewUNID(),
                                Ubicacion = (!string.IsNullOrWhiteSpace(asunto.UbicacionText)) ? asunto.UbicacionText.Trim() : null,
                                IsBorrador = asunto.IsBorrador,
                                Contacto = (!string.IsNullOrWhiteSpace(asunto.Contacto)) ? asunto.Contacto.Trim() :"" ,
                                Anexos = (!string.IsNullOrWhiteSpace(asunto.Anexos)) ? asunto.Anexos.Trim() : null,
                            }
                        );

                        entity.SaveChanges();
                        UpdateSyncLocal("GET_ASUNTO", entity);
                    }

                }
        }

        public IEnumerable<Model.AsuntoModel> GetBusqueda(string prioridad, string statusAsunto, string destinatario, string signatario, DateTime? rangofechadesde, DateTime? rangofechahasta, string folio, string tituloAsunto, string descripcionAsunto,string nombreDocumento ,Model.RolModel rol)
        {
            ObservableCollection<Model.AsuntoModel> Busqueda = new ObservableCollection<Model.AsuntoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {

                    var result = entity.GetAsuntos(prioridad, statusAsunto,
                                                   destinatario, signatario,
                                                   rangofechadesde,rangofechahasta,
                                                   folio,tituloAsunto,descripcionAsunto,
                                                   nombreDocumento).ToList();

                    (from o in result
                     join t in entity.GET_TURNO
                     on o.IdAsunto equals t.IdAsunto
                     join e in entity.GET_EXPEDIENTE
                     on o.IdAsunto equals e.IdAsunto
                     where t.IdRol == rol.IdRol
                     select new
                     {
                         o,t,e,
                         signatario = o.REL_SIGNATARIO.Select(s => new Model.SignatarioModel()
                         {
                             IdAsunto = s.IdAsunto,
                             IdDeterminante = s.IdDeterminante,
                             IdSignatario = s.IdSignatario,
                             Fecha = s.Fecha,
                             IsActive = s.IsActive,
                             Determinante = new Model.DeterminanteModel()
                             {
                                 IdDeterminante = s.CAT_DETERMINANTE.IdDeterminante,
                                 DeterminanteName = s.CAT_DETERMINANTE.DeterminanteName,
                                 IdTipoDeterminante = s.CAT_DETERMINANTE.IdTipoDeterminante,
                                 CveDeterminante = s.CAT_DETERMINANTE.CveDeterminante,
                                 Area = s.CAT_DETERMINANTE.Area,
                                 PrefijoFolio = s.CAT_DETERMINANTE.PrefijoFolio,
                                 TipoDeterminante = new Model.TipoDeterminanteModel() 
                                 {
                                     TipoDeterminanteName = s.CAT_DETERMINANTE.CAT_TIPO_DETERMINANTE.TipoDeterminanteName
                                 }
                             }
                         }).Where(w => w.IsActive),
                         signatarioExterno = o.REL_SIGNATARIO_EXTERNO.Select(s => new Model.SignatarioExternoModel()
                         {
                             IdAsunto = s.IdAsunto,
                             IdDeterminante = s.IdDeterminante,
                             IdSignatarioExterno = s.IdSignatarioExterno,
                             Fecha = s.Fecha,
                             IsActive = s.IsActive,
                             Determinante = new Model.DeterminanteModel()
                             {
                                 IdDeterminante = s.CAT_DETERMINANTE.IdDeterminante,
                                 DeterminanteName = s.CAT_DETERMINANTE.DeterminanteName,
                                 IdTipoDeterminante = s.CAT_DETERMINANTE.IdTipoDeterminante,
                                 CveDeterminante = s.CAT_DETERMINANTE.CveDeterminante,
                                 Area = s.CAT_DETERMINANTE.Area,
                                 PrefijoFolio = s.CAT_DETERMINANTE.PrefijoFolio,
                                 TipoDeterminante = new Model.TipoDeterminanteModel()
                                 {
                                     TipoDeterminanteName = s.CAT_DETERMINANTE.CAT_TIPO_DETERMINANTE.TipoDeterminanteName
                                 }
                             }
                         }).Where(w => w.IsActive)
                     }).Where(wA => wA.o.IsActive).ToList().ForEach(p =>
                     {
                         Busqueda.Add(new Model.AsuntoModel()
                         {
                             IdAsunto = p.o.IdAsunto,
                             FechaCreacion = p.o.FechaCreacion,
                             FechaRecibido = p.o.FechaRecibido,
                             FechaDocumento = p.o.FechaDocumento,
                             Titulo = p.o.Titulo,
                             Descripcion = p.o.Descripcion,
                             Alcance = p.o.Alcance,
                             IdUbicacion = p.o.IdUbicacion,
                             ReferenciaDocumento = p.o.ReferenciaDocumento,
                             Ubicacion = (p.o.CAT_UBICACION != null) ? new Model.UbicacionModel()
                             {
                                 UbicacionName = p.o.CAT_UBICACION.UbicacionName
                             } : null,
                             IdInstruccion = p.o.IdInstruccion,
                             Instruccion = (p.o.CAT_INSTRUCCION != null) ? new Model.InstruccionModel()
                             {
                                 InstruccionName = p.o.CAT_INSTRUCCION.InstruccionName
                             } : null,
                             IdPrioridad = p.o.IdPrioridad,
                             Prioridad = (p.o.CAT_PRIORIDAD != null) ? new Model.PrioridadModel()
                             {
                                 PrioridadName = p.o.CAT_PRIORIDAD.PrioridadName,
                                 IdPrioridad = p.o.CAT_PRIORIDAD.IdPrioridad,
                                 PathImagen = p.o.CAT_PRIORIDAD.PathImagen
                             } : null,
                             IdStatusAsunto = p.o.IdStatusAsunto,
                             StatusAsunto = new Model.StatusAsuntoModel()
                             {
                                 StatusName = p.o.CAT_STATUS_ASUNTO.StatusName,
                                 IdStatusAsunto = p.o.CAT_STATUS_ASUNTO.IdStatusAsunto
                             },
                             FechaVencimiento = p.o.FechaVencimiento,
                             FechaAtendido = p.o.FechaAtendido,
                             Folio = p.o.Folio,
                             UbicacionText = p.o.Ubicacion,
                             IsActive = p.o.IsActive,
                             IsBorrador = p.o.IsBorrador,
                             Contacto = p.o.Contacto,
                             Anexos = p.o.Anexos,
                             Turno = new Model.TurnoModel()
                             {
                                 IdTurno = p.t.IdTurno,
                                 IdTurnoAnt = p.t.IdTurnoAnt,
                                 FechaCreacion = p.t.FechaCreacion,
                                 FechaEnvio = p.t.FechaEnvio,
                                 IsActive = p.t.IsActive,
                                 LastModifiedDate = p.t.LastModifiedDate,
                                 IdAsunto = p.t.IdAsunto,
                                 IdStatusTurno = p.t.IdStatusTurno,
                                 StatusTurno = new Model.StatusTurnoModel()
                                 {
                                     StatusName = p.t.CAT_STATUS_TURNO.StatusName
                                 },
                                 IdRol = p.t.IdRol,
                                 IdUsuario = p.t.IdUsuario,
                                 Comentario = p.t.Comentario,
                                 Respuesta = p.t.Respuesta,
                                 Rol = new Model.RolModel()
                                 {
                                     IdRol = p.t.APP_ROL.IdRol,
                                     RolName = p.t.APP_ROL.RolName
                                 },
                                 IsAtendido = p.t.IsAtendido,
                                 IsTurnado = p.t.IsTurnado,
                                 IsBorrador = p.t.IsBorrador
                             },
                             Expediente = new Model.ExpedienteModel()
                             {
                                 IdExpediente = p.e.IdExpediente,
                                 IdAsunto = p.e.IdAsunto,
                                 LastModifiedDate = p.e.LastModifiedDate,
                                 IsActive = p.e.IsActive,
                                 IsModified = p.e.IsModified
                             },
                             Signatario = p.signatario,
                             SignatarioExterno =p.signatarioExterno 
                         });
                     });
                }
                catch (Exception)
                {

                }
            }
            return Busqueda;
        }

        public IEnumerable<Model.AsuntoModel> GetBusquedaAsunto(string tituloAsunto, string folioAsunto, string descripcionAsunto, Model.RolModel rol)
        {
            ObservableCollection<Model.AsuntoModel> Busqueda = new ObservableCollection<Model.AsuntoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {

                    var result = entity.GetBusquedaAsuntos(tituloAsunto, folioAsunto,descripcionAsunto).ToList();

                    (from o in result
                     join t in entity.GET_TURNO
                     on o.IdAsunto equals t.IdAsunto
                     join e in entity.GET_EXPEDIENTE
                     on o.IdAsunto equals e.IdAsunto
                     where t.IdRol == rol.IdRol
                     select new
                     {
                         o,t,e,
                         signatario = o.REL_SIGNATARIO.Select(s => new Model.SignatarioModel()
                         {
                             IdAsunto = s.IdAsunto,
                             IdDeterminante = s.IdDeterminante,
                             IdSignatario = s.IdSignatario,
                             Fecha = s.Fecha,
                             IsActive = s.IsActive,
                             Determinante = new Model.DeterminanteModel()
                             {
                                 IdDeterminante = s.CAT_DETERMINANTE.IdDeterminante,
                                 DeterminanteName = s.CAT_DETERMINANTE.DeterminanteName,
                                 IdTipoDeterminante = s.CAT_DETERMINANTE.IdTipoDeterminante,
                                 CveDeterminante = s.CAT_DETERMINANTE.CveDeterminante,
                                 Area = s.CAT_DETERMINANTE.Area,
                                 PrefijoFolio = s.CAT_DETERMINANTE.PrefijoFolio,
                                 TipoDeterminante = new Model.TipoDeterminanteModel() 
                                 {
                                     TipoDeterminanteName = s.CAT_DETERMINANTE.CAT_TIPO_DETERMINANTE.TipoDeterminanteName
                                 }
                             }
                         }).Where(w => w.IsActive),
                         signatarioExterno = o.REL_SIGNATARIO_EXTERNO.Select(s => new Model.SignatarioExternoModel()
                         {
                             IdAsunto = s.IdAsunto,
                             IdDeterminante = s.IdDeterminante,
                             IdSignatarioExterno = s.IdSignatarioExterno,
                             Fecha = s.Fecha,
                             IsActive = s.IsActive,
                             Determinante = new Model.DeterminanteModel()
                             {
                                 IdDeterminante = s.CAT_DETERMINANTE.IdDeterminante,
                                 DeterminanteName = s.CAT_DETERMINANTE.DeterminanteName,
                                 IdTipoDeterminante = s.CAT_DETERMINANTE.IdTipoDeterminante,
                                 CveDeterminante = s.CAT_DETERMINANTE.CveDeterminante,
                                 Area = s.CAT_DETERMINANTE.Area,
                                 PrefijoFolio = s.CAT_DETERMINANTE.PrefijoFolio,
                                 TipoDeterminante = new Model.TipoDeterminanteModel()
                                 {
                                     TipoDeterminanteName = s.CAT_DETERMINANTE.CAT_TIPO_DETERMINANTE.TipoDeterminanteName
                                 }
                             }
                         }).Where(w => w.IsActive)
                     }).Where(wa => wa.o.IsActive).ToList().ForEach(p =>
                     {
                         Busqueda.Add(new Model.AsuntoModel()
                         {
                             IdAsunto = p.o.IdAsunto,
                             FechaCreacion = p.o.FechaCreacion,
                             FechaRecibido = p.o.FechaRecibido,
                             FechaDocumento = p.o.FechaDocumento,
                             Titulo = p.o.Titulo,
                             Descripcion = p.o.Descripcion,
                             Alcance = p.o.Alcance,
                             IdUbicacion = p.o.IdUbicacion,
                             ReferenciaDocumento = p.o.ReferenciaDocumento,
                             Ubicacion = (p.o.CAT_UBICACION != null) ? new Model.UbicacionModel()
                             {
                                 UbicacionName = p.o.CAT_UBICACION.UbicacionName
                             } : null,
                             IdInstruccion = p.o.IdInstruccion,
                             Instruccion = (p.o.CAT_INSTRUCCION != null) ? new Model.InstruccionModel()
                             {
                                 InstruccionName = p.o.CAT_INSTRUCCION.InstruccionName
                             } : null,
                             IdPrioridad = p.o.IdPrioridad,
                             Prioridad = (p.o.CAT_PRIORIDAD != null) ? new Model.PrioridadModel()
                             {
                                 PrioridadName = p.o.CAT_PRIORIDAD.PrioridadName,
                                 IdPrioridad = p.o.CAT_PRIORIDAD.IdPrioridad,
                                 PathImagen = p.o.CAT_PRIORIDAD.PathImagen
                             } : null,
                             IdStatusAsunto = p.o.IdStatusAsunto,
                             StatusAsunto = new Model.StatusAsuntoModel()
                             {
                                 StatusName = p.o.CAT_STATUS_ASUNTO.StatusName,
                                 IdStatusAsunto = p.o.CAT_STATUS_ASUNTO.IdStatusAsunto
                             },
                             FechaVencimiento = p.o.FechaVencimiento,
                             FechaAtendido = p.o.FechaAtendido,
                             Folio = p.o.Folio,
                             UbicacionText = p.o.Ubicacion,
                             IsActive = p.o.IsActive,
                             IsBorrador = p.o.IsBorrador,
                             Contacto = p.o.Contacto,
                             Anexos = p.o.Anexos,
                             Turno = new Model.TurnoModel()
                             {
                                 IdTurno = p.t.IdTurno,
                                 IdTurnoAnt = p.t.IdTurnoAnt,
                                 FechaCreacion = p.t.FechaCreacion,
                                 FechaEnvio = p.t.FechaEnvio,
                                 IsActive = p.t.IsActive,
                                 LastModifiedDate = p.t.LastModifiedDate,
                                 IdAsunto = p.t.IdAsunto,
                                 IdStatusTurno = p.t.IdStatusTurno,
                                 StatusTurno = new Model.StatusTurnoModel()
                                 {
                                     StatusName = p.t.CAT_STATUS_TURNO.StatusName
                                 },
                                 IdRol = p.t.IdRol,
                                 IdUsuario = p.t.IdUsuario,
                                 Comentario = p.t.Comentario,
                                 Respuesta = p.t.Respuesta,
                                 Rol = new Model.RolModel()
                                 {
                                     IdRol = p.t.APP_ROL.IdRol,
                                     RolName = p.t.APP_ROL.RolName
                                 },
                                 IsAtendido = p.t.IsAtendido,
                                 IsTurnado = p.t.IsTurnado,
                                 IsBorrador = p.t.IsBorrador
                             },
                             Expediente = new Model.ExpedienteModel()
                             {
                                 IdExpediente = p.e.IdExpediente,
                                 IdAsunto = p.e.IdAsunto,
                                 LastModifiedDate = p.e.LastModifiedDate,
                                 IsActive = p.e.IsActive,
                                 IsModified = p.e.IsModified
                             },
                             Signatario = p.signatario,
                             SignatarioExterno = p.signatarioExterno 
                         });
                     });
                }
                catch (Exception)
                {

                }
            }
            return Busqueda;
        }

        public IEnumerable<Model.AsuntoModel> GetAsuntos()
        {
            ObservableCollection<Model.AsuntoModel> Asuntos = new ObservableCollection<Model.AsuntoModel>();
            
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.GET_ASUNTO
                     join t in entity.GET_TURNO
                     on o.IdAsunto equals t.IdAsunto
                     join e in entity.GET_EXPEDIENTE
                     on o.IdAsunto equals e.IdAsunto
                     where t.IdRol ==2
                     select new {o,t,e}).ToList().ForEach(p =>
                     {
                         Asuntos.Add(new Model.AsuntoModel()
                         {
                             IdAsunto = p.o.IdAsunto,
                             FechaCreacion = p.o.FechaCreacion,
                             FechaRecibido = p.o.FechaRecibido,
                             FechaDocumento = p.o.FechaDocumento,
                             Titulo = p.o.Titulo,
                             Descripcion = p.o.Descripcion,
                             Alcance = p.o.Alcance,
                             IdUbicacion = p.o.IdUbicacion,
                             ReferenciaDocumento = p.o.ReferenciaDocumento,
                             Ubicacion = (p.o.CAT_UBICACION!=null)? new Model.UbicacionModel()
                             {
                                 UbicacionName = p.o.CAT_UBICACION.UbicacionName
                             } : null,
                             IdInstruccion = p.o.IdInstruccion,
                             Instruccion = (p.o.CAT_INSTRUCCION !=null) ?new Model.InstruccionModel()
                             {
                                 InstruccionName = p.o.CAT_INSTRUCCION.InstruccionName
                             } : null,
                             IdPrioridad = p.o.IdPrioridad,
                             Prioridad = (p.o.CAT_PRIORIDAD !=null) ? new Model.PrioridadModel()
                             {
                                 PrioridadName = p.o.CAT_PRIORIDAD.PrioridadName,
                                 IdPrioridad = p.o.CAT_PRIORIDAD.IdPrioridad,
                                 PathImagen = p.o.CAT_PRIORIDAD.PathImagen
                             } : null,
                             IdStatusAsunto = p.o.IdStatusAsunto,
                             StatusAsunto = new Model.StatusAsuntoModel()
                             {
                                 StatusName = p.o.CAT_STATUS_ASUNTO.StatusName
                             },
                             FechaVencimiento = p.o.FechaVencimiento,
                             FechaAtendido =p.o.FechaAtendido,
                             Folio = p.o.Folio,
                             UbicacionText = p.o.Ubicacion,
                             IsBorrador = p.o.IsBorrador,
                             Contacto =p.o.Contacto,
                             Anexos =p.o.Anexos,
                             IsActive = p.o.IsActive,
                             Turno = new Model.TurnoModel()
                             {
                                 IdTurno = p.t.IdTurno,
                                 IdTurnoAnt = p.t.IdTurnoAnt,
                                 FechaCreacion = p.t.FechaCreacion,
                                 FechaEnvio = p.t.FechaEnvio,
                                 IsActive = p.t.IsActive,
                                 LastModifiedDate = p.t.LastModifiedDate,
                                 IdAsunto = p.t.IdAsunto,
                                 IdStatusTurno = p.t.IdStatusTurno,
                                 StatusTurno = new Model.StatusTurnoModel()
                                 {
                                     StatusName = p.t.CAT_STATUS_TURNO.StatusName
                                 },
                                 IdRol = p.t.IdRol,
                                 IdUsuario = p.t.IdUsuario,
                                 Comentario = p.t.Comentario,
                                 Respuesta = p.t.Respuesta,
                                 Rol = new Model.RolModel()
                                 {
                                     IdRol = p.t.APP_ROL.IdRol,
                                     RolName = p.t.APP_ROL.RolName
                                 },
                                 IsAtendido = p.t.IsAtendido,
                                 IsTurnado = p.t.IsTurnado,
                                 IsBorrador =p.t.IsBorrador
                             },
                             Expediente = new Model.ExpedienteModel() 
                             {
                                 IdExpediente = p.e.IdExpediente,
                                 IdAsunto = p.e.IdAsunto,
                                 LastModifiedDate = p.e.LastModifiedDate,
                                 IsActive = p.e.IsActive,
                                 IsModified = p.e.IsModified
                             }
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return Asuntos;
        }

        /// <summary>
        /// WTF! Creo que trae toda la informacion del asunto.
        /// </summary>
        /// <param name="rol">Rol de usuario logeado.</param>
        /// <returns></returns>
        public IEnumerable<Model.AsuntoModel> GetAsuntos(Model.RolModel rol)
        {
            ObservableCollection<Model.AsuntoModel> Asuntos = new ObservableCollection<Model.AsuntoModel>();

            using (var entity = new GestorDocumentEntities())
            {

                try
                { 
                    //SE MANDA A LLAMAR AL PRODECIMIENTO ALMACENADO QUE TRAE LOS ASUNTOS TURNADOS Y LOS DE CON COPIA PARA
                    var result = entity.GetAsuntosTurnadosCcp(rol.IdRol).ToList();

                    (from o in result
                     select new
                     {
                         o,
                         t = o.GET_TURNO.Join(entity.GET_ASUNTO, turno => turno.IdAsunto, asunto => asunto.IdAsunto, (turno, asunto)
                             =>
                         new { tt = turno }).Select(s => new Model.TurnoModel()
                         {
                             IdTurno = s.tt.IdTurno,
                             IdTurnoAnt = s.tt.IdTurnoAnt,
                             FechaCreacion = s.tt.FechaCreacion,
                             FechaEnvio = s.tt.FechaEnvio,
                             IsActive = s.tt.IsActive,
                             LastModifiedDate = s.tt.LastModifiedDate,
                             IdAsunto = s.tt.IdAsunto,
                             IdStatusTurno = s.tt.IdStatusTurno,
                             StatusTurno = new Model.StatusTurnoModel()
                             {
                                StatusName = s.tt.CAT_STATUS_TURNO.StatusName
                             },
                             IdRol = s.tt.IdRol,
                             IdUsuario = s.tt.IdUsuario,
                             Comentario = s.tt.Comentario,
                             Respuesta = s.tt.Respuesta,
                             Rol = new Model.RolModel()
                             {
                                 IdRol = s.tt.APP_ROL.IdRol,
                                 RolName = s.tt.APP_ROL.RolName
                             },
                             IsAtendido = s.tt.IsAtendido,
                             IsTurnado = s.tt.IsTurnado,
                             IsBorrador = s.tt.IsBorrador
                         }),
                         e = o.GET_EXPEDIENTE.Join(entity.GET_EXPEDIENTE, expediente => expediente.IdAsunto, asunto => asunto.IdAsunto, (expedinete, asunto) 
                             =>
                         new { Expediente = expedinete }).First().Expediente,
                         signatario = o.REL_SIGNATARIO.Select(s => new Model.SignatarioModel()
                         {
                             IdAsunto = s.IdAsunto,
                             IdDeterminante = s.IdDeterminante,
                             IdSignatario = s.IdSignatario,
                             Fecha = s.Fecha,
                             IsActive = s.IsActive,
                             Determinante = new Model.DeterminanteModel()
                             {
                                 IdDeterminante = s.CAT_DETERMINANTE.IdDeterminante,
                                 DeterminanteName = s.CAT_DETERMINANTE.DeterminanteName,
                                 IdTipoDeterminante = s.CAT_DETERMINANTE.IdTipoDeterminante,
                                 CveDeterminante = s.CAT_DETERMINANTE.CveDeterminante,
                                 Area = s.CAT_DETERMINANTE.Area,
                                 PrefijoFolio = s.CAT_DETERMINANTE.PrefijoFolio,
                                 TipoDeterminante = new Model.TipoDeterminanteModel()
                                 {
                                     TipoDeterminanteName = s.CAT_DETERMINANTE.CAT_TIPO_DETERMINANTE.TipoDeterminanteName
                                 }
                             }
                         }).Where(w => w.IsActive),
                         signatarioExterno = o.REL_SIGNATARIO_EXTERNO.Select(s => new Model.SignatarioExternoModel()
                         {
                             IdAsunto = s.IdAsunto,
                             IdDeterminante = s.IdDeterminante,
                             IdSignatarioExterno = s.IdSignatarioExterno,
                             Fecha = s.Fecha,
                             IsActive = s.IsActive,
                             Determinante = new Model.DeterminanteModel()
                             {
                                 IdDeterminante = s.CAT_DETERMINANTE.IdDeterminante,
                                 DeterminanteName = s.CAT_DETERMINANTE.DeterminanteName,
                                 IdTipoDeterminante = s.CAT_DETERMINANTE.IdTipoDeterminante,
                                 CveDeterminante = s.CAT_DETERMINANTE.CveDeterminante,
                                 Area = s.CAT_DETERMINANTE.Area,
                                 PrefijoFolio = s.CAT_DETERMINANTE.PrefijoFolio,
                                 TipoDeterminante = new Model.TipoDeterminanteModel()
                                 {
                                     TipoDeterminanteName = s.CAT_DETERMINANTE.CAT_TIPO_DETERMINANTE.TipoDeterminanteName
                                 }
                             }
                         }).Where(w => w.IsActive),
                         destinatarioCcp = o.REL_DESTINATARIO_CCP.Join
                         (entity.CAT_ORGANIGRAMA, post => post.IdRol, meta => meta.IdRol, (post, meta) =>
                             new { Post = post, Meta = meta }).Select(s => new Model.DestinatarioCcpModel()
                             {
                                 IdAsunto = s.Post.IdAsunto,
                                 IdDestinatarioCcp = s.Post.IdDestinatarioCcp,
                                 IdRol = s.Post.IdRol,
                                 IsActive = s.Post.IsActive,
                                 Rol = new Model.RolModel()
                                 {
                                     IdRol = s.Post.APP_ROL.IdRol,
                                     RolName = s.Post.APP_ROL.RolName,
                                     Organigrama = new Model.OrganigramaModel()
                                     {
                                         IdJerarquia = s.Meta.IdJerarquia,
                                         JerarquiaName = s.Meta.JerarquiaName,
                                         JerarquiaTitular = s.Meta.JerarquiaTitular
                                     }
                                 }
                             }).Where(w => w.IsActive)
                     }).Where(wa => wa.o.IsActive).ToList().ForEach(p =>
                     {
                         Asuntos.Add(new Model.AsuntoModel()
                         {
                             IdAsunto = p.o.IdAsunto,
                             FechaCreacion = p.o.FechaCreacion,
                             FechaRecibido = p.o.FechaRecibido,
                             FechaDocumento = p.o.FechaDocumento,
                             Titulo = p.o.Titulo,
                             Descripcion = p.o.Descripcion,
                             Alcance = p.o.Alcance,
                             IdUbicacion = p.o.IdUbicacion,
                             ReferenciaDocumento = p.o.ReferenciaDocumento,
                             Ubicacion = (p.o.CAT_UBICACION != null) ? new Model.UbicacionModel()
                             {
                                 UbicacionName = p.o.CAT_UBICACION.UbicacionName
                             } : null,
                             IdInstruccion = p.o.IdInstruccion,
                             Instruccion = (p.o.CAT_INSTRUCCION != null) ? new Model.InstruccionModel()
                             {
                                 InstruccionName = p.o.CAT_INSTRUCCION.InstruccionName
                             } : null,
                             IdPrioridad = p.o.IdPrioridad,
                             Prioridad = (p.o.CAT_PRIORIDAD != null) ? new Model.PrioridadModel()
                             {
                                 PrioridadName = p.o.CAT_PRIORIDAD.PrioridadName,
                                 IdPrioridad = p.o.CAT_PRIORIDAD.IdPrioridad,
                                 PathImagen = p.o.CAT_PRIORIDAD.PathImagen
                             } : null,
                             IdStatusAsunto = p.o.IdStatusAsunto,
                             StatusAsunto = new Model.StatusAsuntoModel()
                             {
                                 StatusName = p.o.CAT_STATUS_ASUNTO.StatusName,
                                 IdStatusAsunto = p.o.CAT_STATUS_ASUNTO.IdStatusAsunto
                             },
                             FechaVencimiento = p.o.FechaVencimiento,
                             FechaAtendido = p.o.FechaAtendido,
                             Folio = p.o.Folio,
                             UbicacionText = p.o.Ubicacion,
                             IsBorrador = p.o.IsBorrador,
                             Contacto = p.o.Contacto,
                             Anexos = p.o.Anexos,
                             ConRespuesta = this._TurnoRepository.GetRespuestaTurnos(p.o.IdAsunto),
                             IsActive = p.o.IsActive,
                             Turnos = p.t,
                             Expediente = new Model.ExpedienteModel()
                             {
                                 IdExpediente = p.e.IdExpediente,
                                 IdAsunto = p.e.IdAsunto,
                                 LastModifiedDate = p.e.LastModifiedDate,
                                 IsActive = p.e.IsActive,
                                 IsModified = p.e.IsModified
                             },
                             Signatario = p.signatario,
                             SignatarioExterno = p.signatarioExterno,
                             DestinatarioCcp = p.destinatarioCcp
                         });
                     });

                    (from p in  Asuntos 
                     select p).ToList()
                              .ForEach
                              (o => o.Turnos
                                  .ToList()
                                  .Where(tt => tt.IdRol == rol.IdRol)
                                  .ToList()
                                  .ForEach(t => 
                                  {
                                      if (!t.IsAtendido && !t.IsTurnado)
                                          o.Turno = t;
                                      else
                                          o.Turno = t;
                                  })
                              );

                }
                catch (Exception)
                {
                    ;
                }
            }
            return Asuntos;
        }

        public Model.AsuntoModel GetAsuntoID(Model.AsuntoModel asunto)
        {
            throw new NotImplementedException();
        }

        public Model.AsuntoModel GetAsuntoAdd(Model.AsuntoModel asunto)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (asunto != null)
                {
                    //Validar si el elemento ya existe
                    GET_ASUNTO result = null;
                    try
                    {
                        result = (from o in entity.GET_ASUNTO
                                  where o.IdAsunto == asunto.IdAsunto
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        asunto = null;
                    }

                }
            }
            return asunto;
        }

        public Model.AsuntoModel GetAsuntoMod(Model.AsuntoModel asunto)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (asunto != null)
                {
                    //Validar si el elemento ya existe
                    GET_ASUNTO result = null;
                    try
                    {
                        result = (from o in entity.GET_ASUNTO
                                  where o.IdAsunto == asunto.IdAsunto &&
                                  o.Titulo == asunto.Titulo
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        asunto = null;
                    }

                }
            }
            return asunto;
        }        

        /// <summary>
        /// Actualiza los valores del asunto en la Tabla GET_ASUNTO.
        /// </summary>
        /// <param name="asunto">AsuntoModel()</param>
        public void UpdateAsunto(Model.AsuntoModel asunto)
        {
            using (var entity = new GestorDocumentEntities())
            {
                GET_ASUNTO result = null;
                try
                {
                    result = (from o in entity.GET_ASUNTO
                              where o.IdAsunto == asunto.IdAsunto
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IdAsunto = asunto.IdAsunto;
                    result.FechaCreacion = asunto.FechaCreacion;
                    result.FechaRecibido = asunto.FechaRecibido;
                    result.FechaDocumento = asunto.FechaDocumento;
                    result.ReferenciaDocumento =(!string.IsNullOrWhiteSpace(asunto.ReferenciaDocumento)) ? asunto.ReferenciaDocumento.Trim():null;
                    result.Titulo = (!string.IsNullOrWhiteSpace(asunto.Titulo)) ? asunto.Titulo.Trim():null;
                    result.Descripcion = (!string.IsNullOrWhiteSpace(asunto.Descripcion)) ? asunto.Descripcion.Trim() :null;
                    result.Alcance = (!string.IsNullOrWhiteSpace(asunto.Alcance)) ? asunto.Alcance.Trim() :null;
                    result.IdUbicacion = (asunto.Ubicacion != null) ? (Nullable<long>)asunto.Ubicacion.IdUbicacion : null;
                    result.IdInstruccion = (asunto.Instruccion != null) ? (Nullable<long>)asunto.Instruccion.IdInstruccion : null;
                    result.IdPrioridad = (asunto.Prioridad != null) ? (Nullable<long>)asunto.Prioridad.IdPrioridad : null;
                    result.IdStatusAsunto = asunto.StatusAsunto.IdStatusAsunto;
                    result.FechaVencimiento = asunto.FechaVencimiento;
                    result.Folio = (!string.IsNullOrWhiteSpace(asunto.Folio)) ? asunto.Folio.Trim() : null;
                    result.IsActive = asunto.IsActive;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();
                    result.Ubicacion =(!string.IsNullOrWhiteSpace(asunto.UbicacionText)) ? asunto.UbicacionText.Trim():null;
                    result.Contacto = (!string.IsNullOrWhiteSpace(asunto.Contacto)) ? asunto.Contacto.Trim() : "";
                    result.Anexos = (!string.IsNullOrWhiteSpace(asunto.Anexos)) ? asunto.Anexos.Trim() : null;
                    entity.SaveChanges();

                    UpdateSyncLocal("GET_ASUNTO", entity);
                }
            }
        }

        public void UpdateCloseAsunto(Model.AsuntoModel asunto)
        {
            using (var entity = new GestorDocumentEntities())
            {
                GET_ASUNTO result = null;
                try
                {
                    result = (from o in entity.GET_ASUNTO
                              where o.IdAsunto == asunto.IdAsunto
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IdStatusAsunto = asunto.IdStatusAsunto;
                    result.FechaAtendido = asunto.FechaAtendido;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();
                    entity.SaveChanges();

                    UpdateSyncLocal("GET_ASUNTO", entity);
                }
            }
        }

        public void UpdateBorradorAsunto(Model.AsuntoModel asunto)
        {
            using (var entity = new GestorDocumentEntities())
            {
                GET_ASUNTO result = null;
                try
                {
                    result = (from o in entity.GET_ASUNTO
                              where o.IdAsunto == asunto.IdAsunto
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IsBorrador = asunto.IsBorrador;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();
                    entity.SaveChanges();

                    UpdateSyncLocal("GET_ASUNTO", entity);
                }
            }
        }

        public void DeleteAsunto(IEnumerable<Model.AsuntoModel> asuntos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.AsuntoModel p in asuntos)
                {
                    GET_ASUNTO result = null;
                    try
                    {
                        result = (from o in entity.GET_ASUNTO
                                  where o.IdAsunto == p.IdAsunto
                                  select o).First();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    if (result != null)
                    {
                        //result.IsActive = false;
                        //result.IsModified = true;
                        //result.LastModifiedDate = new UNID().getNewUNID();
                    }
                }
                entity.SaveChanges();
                UpdateSyncLocal("GET_ASUNTO", entity);
            }
        }

        /// <summary>
        /// Actualiza el campo IsModified de un registro de la tabla MODIFIEDDATA segun nameTable.
        /// </summary>
        /// <param name="nameTable">Nombre de la tabla.</param>
        /// <param name="context">Context(Entity).</param>
        public void UpdateSyncLocal(string nameTable, ObjectContext context)
        {
            if (!String.IsNullOrEmpty(nameTable) && context != null)
            {
                GestorDocumentEntities entity = context as GestorDocumentEntities;
                if (entity != null)
                {
                    MODIFIEDDATA result = null;
                    try
                    {
                        result = (from o in entity.SYNCTABLEs
                                  join r in entity.MODIFIEDDATAs
                                  on o.IdSincTable equals r.IdSincTable
                                  where o.SincTableName == nameTable
                                  select r).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    if (result != null)
                    {
                        result.IsModified = true;
                        entity.SaveChanges();
                    }
                }
            }
        }

    }
}