using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class TurnoRepository : ITurno , ISync
    {
        public void InsertTurno(Model.TurnoModel turno)
        {
            using (var entity = new GestorDocumentEntities())

                if (turno != null)
                {
                    //Validar si el elemento ya existe
                    GET_TURNO result = null;
                    try
                    {
                        result = (from o in entity.GET_TURNO
                                  where o.IdTurno == turno.IdTurno
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.GET_TURNO.AddObject(
                            new GET_TURNO()
                            {
                                IdTurno = turno.IdTurno,
                                IdTurnoAnt = turno.IdTurnoAnt,
                                FechaCreacion = turno.FechaCreacion,
                                FechaEnvio = turno.FechaEnvio,
                                IsActive = turno.IsActive,
                                IsModified =true,
                                LastModifiedDate = new UNID().getNewUNID(),
                                IdAsunto = turno.IdAsunto,
                                IdStatusTurno = turno.IdStatusTurno,
                                IdRol = turno.IdRol,
                                IdUsuario = turno.IdUsuario,
                                Comentario =(!string.IsNullOrWhiteSpace(turno.Comentario)) ? turno.Comentario.Trim() : null,
                                Respuesta = (!string.IsNullOrWhiteSpace(turno.Respuesta)) ? turno.Respuesta.Trim() : null,
                                IsAtendido =turno.IsAtendido,
                                IsTurnado = turno.IsTurnado,
                                IsBorrador = turno.IsBorrador,
                                ServerLastModifiedDate = 0
                            }
                        );

                        entity.SaveChanges();
                        UpdateSyncLocal("GET_TURNO", entity);
                    }

                }
        }

        public void InsertTurno(IEnumerable<Model.TurnoModel> turnos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.TurnoModel p in turnos)
                {
                    GET_TURNO result = null;
                    try
                    {
                        result = (from o in entity.GET_TURNO
                                  where o.IdTurno == p.IdTurno
                                  select o).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    if (result == null)
                    {
                        entity.GET_TURNO.AddObject(
                            new GET_TURNO()
                            {
                                IdTurno = p.IdTurno,
                                IdTurnoAnt = p.IdTurnoAnt,
                                FechaCreacion = p.FechaCreacion,
                                FechaEnvio = p.FechaEnvio,
                                IsActive = p.IsActive,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID(),
                                IdAsunto = p.IdAsunto,
                                IdStatusTurno = p.IdStatusTurno,
                                IdRol = p.IdRol,
                                IdUsuario = p.IdUsuario,
                                Comentario = (!string.IsNullOrWhiteSpace(p.Comentario)) ? p.Comentario.Trim() : null,
                                Respuesta = (!string.IsNullOrWhiteSpace(p.Respuesta)) ? p.Respuesta.Trim() : null,
                                IsAtendido = p.IsAtendido,
                                IsTurnado = p.IsTurnado,
                                IsBorrador = p.IsBorrador,
                                ServerLastModifiedDate = 0
                                
                            }
                        );
                    }
                }
                entity.SaveChanges();
                UpdateSyncLocal("GET_TURNO", entity);
            }
        }

        public IEnumerable<Model.TurnoModel> GetTurnos()
        {
            ObservableCollection<Model.TurnoModel> Turnos = new ObservableCollection<Model.TurnoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.GET_TURNO
                     where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         Turnos.Add(new Model.TurnoModel()
                         {
                             IdTurno = p.IdTurno,
                             IdTurnoAnt = p.IdTurnoAnt,
                             FechaCreacion = p.FechaCreacion,
                             FechaEnvio = p.FechaEnvio,
                             IsActive = p.IsActive,
                             LastModifiedDate = p.LastModifiedDate,
                             IdAsunto = p.IdAsunto,
                             Asunto = new Model.AsuntoModel()
                             {
                                 IdAsunto = p.IdAsunto,
                                 FechaCreacion = (DateTime)p.GET_ASUNTO.FechaCreacion,
                                 FechaRecibido = (DateTime)p.GET_ASUNTO.FechaRecibido,
                                 FechaDocumento = (DateTime)p.GET_ASUNTO.FechaDocumento,
                                 Titulo = p.GET_ASUNTO.Titulo,
                                 Descripcion = p.GET_ASUNTO.Descripcion,
                                 Alcance = p.GET_ASUNTO.Alcance,
                                 IdUbicacion = (long)p.GET_ASUNTO.IdUbicacion,
                                 ReferenciaDocumento = p.GET_ASUNTO.ReferenciaDocumento,
                                 Ubicacion = (p.GET_ASUNTO.CAT_UBICACION != null) ? new Model.UbicacionModel()
                                 {
                                     UbicacionName = p.GET_ASUNTO.CAT_UBICACION.UbicacionName
                                 } : null,
                                 IdInstruccion = (long)p.GET_ASUNTO.IdInstruccion,
                                 Instruccion = new Model.InstruccionModel()
                                 {
                                     InstruccionName = p.GET_ASUNTO.CAT_INSTRUCCION.InstruccionName
                                 },
                                 IdPrioridad = (long)p.GET_ASUNTO.IdPrioridad,
                                 Prioridad = new Model.PrioridadModel()
                                 {
                                     PrioridadName = p.GET_ASUNTO.CAT_PRIORIDAD.PrioridadName
                                     ,
                                     IdPrioridad = p.GET_ASUNTO.CAT_PRIORIDAD.IdPrioridad
                                     ,
                                     PathImagen = p.GET_ASUNTO.CAT_PRIORIDAD.PathImagen
                                 },
                                 IdStatusAsunto = p.GET_ASUNTO.IdStatusAsunto,
                                 StatusAsunto = new Model.StatusAsuntoModel()
                                 {
                                     StatusName = p.GET_ASUNTO.CAT_STATUS_ASUNTO.StatusName
                                 },
                                 FechaVencimiento = p.GET_ASUNTO.FechaVencimiento,
                                 Folio = p.GET_ASUNTO.Folio
                             },
                             IdStatusTurno = p.IdStatusTurno,
                             StatusTurno = new Model.StatusTurnoModel()
                             {
                                 StatusName = p.CAT_STATUS_TURNO.StatusName
                             },
                             IdRol = p.IdRol,
                             IdUsuario = p.IdUsuario,
                             Comentario = p.Comentario,
                             Respuesta = p.Respuesta,
                             Rol = new Model.RolModel() 
                             {
                                 IdRol = p.APP_ROL.IdRol
                                 ,
                                 RolName = p.APP_ROL.RolName
                             },
                             IsAtendido = p.IsAtendido,
                             IsTurnado = p.IsTurnado,
                             IsBorrador = p.IsBorrador
                         }
                         );
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return Turnos;
        }

        public IEnumerable<Model.TurnoModel> GetTurnosTrancing(Model.TurnoModel turno)
        {
            ObservableCollection<Model.TurnoModel> turnoTrancing = new ObservableCollection<Model.TurnoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.GET_TURNO
                     where o.IdTurnoAnt == turno.IdTurno
                     select o).ToList().ForEach(p =>
                     {
                         turnoTrancing.Add(new Model.TurnoModel()
                         {
                             IdTurno = p.IdTurno,
                             IdTurnoAnt = p.IdTurnoAnt,
                             FechaCreacion = p.FechaCreacion,
                             FechaEnvio = p.FechaEnvio,
                             IsActive = p.IsActive,
                             LastModifiedDate = p.LastModifiedDate,
                             IsModified = p.IsModified,
                             IdAsunto = p.IdAsunto,
                             IdStatusTurno = p.IdStatusTurno,
                             IdRol = p.IdRol,
                             IdUsuario = p.IdUsuario,
                             Comentario = p.Comentario,
                             Respuesta = p.Respuesta,
                             ServerLastModifiedDate = p.ServerLastModifiedDate,
                             IsTurnado = p.IsTurnado,
                             IsAtendido = p.IsAtendido,
                             IsBorrador =p.IsBorrador,
                             Rol = new Model.RolModel() 
                             {  
                                 IdRol = p.APP_ROL.IdRol
                                 ,
                                 RolName = p.APP_ROL.RolName
                             }
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return turnoTrancing;
        }

        /// <summary>
        /// WTF! Creo que es el tracking del Asunto.
        /// </summary>
        /// <param name="IdAsunto"></param>
        /// <returns></returns>
        public IEnumerable<Model.TurnoModel> GetTurnosTrancing(long IdAsunto)
        {
            ObservableCollection<Model.TurnoModel> turnoTrancing = new ObservableCollection<Model.TurnoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.GET_TURNO
                     join or in entity.CAT_ORGANIGRAMA
                     on o.IdRol equals or.IdRol
                     where o.IdAsunto == IdAsunto
                     select new
                     {
                         o,
                         or,
                         doctos = o.GET_DOCUMENTOS.Select
                             (d => new Model.DocumentosModel
                             {
                                 IdDocumento = d.IdDocumento
                                 ,
                                 IdExpediente = d.IdExpediente
                                 ,
                                 IdTipoDocumento = d.IdTipoDocumento
                                 ,
                                 IdTurno = d.IdTurno
                                 ,
                                 DocumentoName = d.DocumentoName
                                 ,
                                 DocumentoPath = d.DocumentoPath
                                 ,
                                 Extencion = d.Extencion
                                 ,
                                 Fecha = d.Fecha
                                 ,
                                 IsActive = d.IsActive
                                 ,
                                 TipoDocumento = new Model.TipoDocumentoModel()
                                 {
                                     IdTipoDocumento = d.CAT_TIPO_DOCUMENTO.IdTipoDocumento
                                     ,
                                     TipoDocumentoName = d.CAT_TIPO_DOCUMENTO.TipoDocumentoName
                                 }
                             }
                             ).Where(w => w.IsActive)
                             ,
                         destinatario = o.REL_DESTINATARIO.Join
                         (entity.CAT_ORGANIGRAMA, post => post.IdRol, meta => meta.IdRol, (post, meta) => 
                             new { Post =post,Meta=meta }).Select(des => new Model.DestinatarioModel
                          {
                              IdDestinatario = des.Post.IdDestinatario
                              ,
                              IdRol = des.Post.IdRol
                              ,
                              IdTurno = des.Post.IdTurno
                              ,
                              IsPrincipal = des.Post.IsPrincipal
                              ,
                              Rol = new Model.RolModel()
                              {
                                  RolName = des.Post.APP_ROL.RolName
                                  ,
                                  IdRol = des.Post.APP_ROL.IdRol
                                  ,
                                  Organigrama = new Model.OrganigramaModel()
                                  {
                                      IdJerarquia = des.Meta.IdJerarquia
                                      ,
                                      JerarquiaName = des.Meta.JerarquiaName,
                                      JerarquiaTitular = des.Meta.JerarquiaTitular,
                                  }
                              }
                              ,
                              IsActive = des.Post.IsActive
                          }).Where(w => w.IsActive)
                     }).ToList().ForEach(p =>
                      {
                          turnoTrancing.Add(new Model.TurnoModel()
                          {

                              IdTurno = p.o.IdTurno,
                              IdTurnoAnt = p.o.IdTurnoAnt,
                              FechaCreacion = p.o.FechaCreacion,
                              FechaEnvio = p.o.FechaEnvio,
                              IsActive = p.o.IsActive,
                              LastModifiedDate = p.o.LastModifiedDate,
                              IsModified = p.o.IsModified,
                              IdAsunto = p.o.IdAsunto,
                              IdStatusTurno = p.o.IdStatusTurno,
                              IdRol = p.o.IdRol,
                              IdUsuario = p.o.IdUsuario,
                              Comentario = p.o.Comentario,
                              Respuesta = p.o.Respuesta,
                              ServerLastModifiedDate = p.o.ServerLastModifiedDate,
                              IsTurnado = p.o.IsTurnado,
                              IsAtendido = p.o.IsAtendido,
                              IsBorrador = p.o.IsBorrador,
                              CanCheck = true,
                              Rol = new Model.RolModel()
                              {
                                  IdRol = p.o.APP_ROL.IdRol
                                  ,
                                  RolName = p.o.APP_ROL.RolName
                                  ,
                                  Organigrama = new Model.OrganigramaModel()
                                  {
                                      IdJerarquia = p.or.IdJerarquia
                                      ,
                                      JerarquiaName = p.or.JerarquiaName
                                  }
                              }
                              ,
                              Documento = p.doctos
                              ,
                              Destinatario = p.destinatario
                          });
                      });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return turnoTrancing;

                    
        }

        public IEnumerable<Model.TurnoModel> GetTurnoSeguimiento(Model.TurnoModel turno)
        {
            ObservableCollection<Model.TurnoModel> turnos = new ObservableCollection<Model.TurnoModel>();

            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    

                    (from o in entity.GET_TURNO
                     join or in entity.CAT_ORGANIGRAMA
                     on o.IdRol equals or.IdRol
                     where o.IdTurnoAnt == null && o.IdAsunto==turno.IdAsunto && o.IsActive
                     select new
                     {
                         o
                         ,
                         or
                     }).ToList().ForEach(p =>
                     {
                         turnos.Add(new Model.TurnoModel()
                         {
                             IdTurno = p.o.IdTurno,
                             IdTurnoAnt = p.o.IdTurnoAnt,
                             FechaCreacion = p.o.FechaCreacion,
                             FechaEnvio = p.o.FechaEnvio,
                             IsActive = p.o.IsActive,
                             LastModifiedDate = p.o.LastModifiedDate,
                             IsModified = p.o.IsModified,
                             IdAsunto = p.o.IdAsunto,
                             IdStatusTurno = p.o.IdStatusTurno,
                             IdRol = p.o.IdRol,
                             IdUsuario = p.o.IdUsuario,
                             Comentario = p.o.Comentario,
                             Respuesta = p.o.Respuesta,
                             ServerLastModifiedDate = p.o.ServerLastModifiedDate,
                             IsTurnado = p.o.IsTurnado,
                             IsAtendido = p.o.IsAtendido,
                             IsBorrador = p.o.IsBorrador,
                             CanCheck = true,
                             Rol = new Model.RolModel()
                             {
                                 IdRol = p.o.APP_ROL.IdRol,
                                 RolName = p.o.APP_ROL.RolName,
                                 Organigrama = new Model.OrganigramaModel()
                                 {
                                     IdJerarquia = p.or.IdJerarquia,
                                     JerarquiaName = p.or.JerarquiaName,
                                     JerarquiaTitular =p.or.JerarquiaTitular
                                 }
                             }

                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return turnos;
        }

        public IEnumerable<Model.TurnoModel> GetTurnoSeguimiento(long IdAsunto)
        {
            ObservableCollection<Model.TurnoModel> turnos = new ObservableCollection<Model.TurnoModel>();

            using (var entity = new GestorDocumentEntities())
            {
                try
                {


                    (from o in entity.GET_TURNO
                     join or in entity.CAT_ORGANIGRAMA
                     on o.IdRol equals or.IdRol
                     where o.IdTurnoAnt == null && o.IdAsunto == IdAsunto && o.IsActive
                     select new
                     {
                         o
                         ,
                         or
                     }).ToList().ForEach(p =>
                     {
                         turnos.Add(new Model.TurnoModel()
                         {
                             IdTurno = p.o.IdTurno,
                             IdTurnoAnt = p.o.IdTurnoAnt,
                             FechaCreacion = p.o.FechaCreacion,
                             FechaEnvio = p.o.FechaEnvio,
                             IsActive = p.o.IsActive,
                             LastModifiedDate = p.o.LastModifiedDate,
                             IsModified = p.o.IsModified,
                             IdAsunto = p.o.IdAsunto,
                             IdStatusTurno = p.o.IdStatusTurno,
                             IdRol = p.o.IdRol,
                             IdUsuario = p.o.IdUsuario,
                             Comentario = p.o.Comentario,
                             Respuesta = p.o.Respuesta,
                             ServerLastModifiedDate = p.o.ServerLastModifiedDate,
                             IsTurnado = p.o.IsTurnado,
                             IsAtendido = p.o.IsAtendido,
                             IsBorrador = p.o.IsBorrador,
                             CanCheck = true,
                             Rol = new Model.RolModel()
                             {
                                 IdRol = p.o.APP_ROL.IdRol,
                                 RolName = p.o.APP_ROL.RolName,
                                 Organigrama = new Model.OrganigramaModel()
                                 {
                                     IdJerarquia = p.or.IdJerarquia,
                                     JerarquiaName = p.or.JerarquiaName,
                                     JerarquiaTitular =p.or.JerarquiaTitular
                                 }
                             }

                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return turnos;
        }

        public int GetTurnoCloseAsunto(long IdAsunto)
        {
            int result = 1;
            using (var entity = new GestorDocumentEntities())
            {
                
                try
                {


                    result = (from t in entity.GET_TURNO
                              where t.IdAsunto == IdAsunto
                                    && !t.IsTurnado
                                    && !t.IsAtendido 
                              select t).Count();
                }
                catch (Exception)
                {
                    ;
                }
                
            }

            return result;
        }

        public int GetRespuestaTurnos(long IdAsunto)
        {
            int result = 0;
            using (var entity = new GestorDocumentEntities())
            {

                try
                {
                    result = (from t in entity.GET_TURNO
                              where t.IdAsunto == IdAsunto
                                    && !t.IsTurnado
                                    && !t.IsAtendido
                              select t).Count();
                }
                catch (Exception)
                {
                    ;
                }
            }

            return result;
        }

        public Model.TurnoModel GetTurnoID(Model.TurnoModel turno)
        {
            Model.TurnoModel t = new Model.TurnoModel();

            using (var entity = new GestorDocumentEntities())
            {
                GET_TURNO result = null;
                try
                {
                    result = (from o in entity.GET_TURNO
                              where o.IdTurnoAnt == null && o.IsActive == true && o.IdTurno == turno.IdTurno
                              select o).First();
                }
                catch (Exception)
                {
                    ;
                }
                if (result != null)
                {
                    t.IdTurno = result.IdTurno;
                    t.IdTurnoAnt = result.IdTurnoAnt;
                    t.FechaCreacion = result.FechaCreacion;
                    t.FechaEnvio = result.FechaEnvio;
                    t.IsActive = result.IsActive;
                    t.LastModifiedDate = result.LastModifiedDate;
                    t.IsModified = result.IsModified;
                    t.IdAsunto = result.IdAsunto;
                    t.Asunto = new Model.AsuntoModel()
                             {
                                 IdAsunto = result.IdAsunto,
                                 FechaCreacion = result.GET_ASUNTO.FechaCreacion,
                                 FechaRecibido = result.GET_ASUNTO.FechaRecibido,
                                 FechaDocumento = result.GET_ASUNTO.FechaDocumento,
                                 Titulo = result.GET_ASUNTO.Titulo,
                                 Descripcion = result.GET_ASUNTO.Descripcion,
                                 Alcance = result.GET_ASUNTO.Alcance,
                                 IdUbicacion = result.GET_ASUNTO.IdUbicacion,
                                 ReferenciaDocumento = result.GET_ASUNTO.ReferenciaDocumento,
                                 Ubicacion = (result.GET_ASUNTO.CAT_UBICACION != null) ? new Model.UbicacionModel()
                                 {
                                     UbicacionName = result.GET_ASUNTO.CAT_UBICACION.UbicacionName
                                 } :null,
                                 IdInstruccion = result.GET_ASUNTO.IdInstruccion,
                                 Instruccion = new Model.InstruccionModel()
                                 {
                                     InstruccionName = result.GET_ASUNTO.CAT_INSTRUCCION.InstruccionName
                                 },
                                 IdPrioridad = result.GET_ASUNTO.IdPrioridad,
                                 Prioridad = new Model.PrioridadModel()
                                 {
                                     PrioridadName = result.GET_ASUNTO.CAT_PRIORIDAD.PrioridadName
                                     ,
                                     IdPrioridad = result.GET_ASUNTO.CAT_PRIORIDAD.IdPrioridad
                                     ,
                                     PathImagen = result.GET_ASUNTO.CAT_PRIORIDAD.PathImagen
                                 },
                                 IdStatusAsunto = result.GET_ASUNTO.IdStatusAsunto,
                                 StatusAsunto = new Model.StatusAsuntoModel()
                                 {
                                     StatusName = result.GET_ASUNTO.CAT_STATUS_ASUNTO.StatusName
                                 },
                                 FechaVencimiento = result.GET_ASUNTO.FechaVencimiento,
                                 Folio = result.GET_ASUNTO.Folio
                             };
                    t.IdStatusTurno = result.IdStatusTurno;
                    t.IdRol = result.IdRol;
                    t.IdUsuario = result.IdUsuario;
                    t.Comentario = result.Comentario;
                    t.Respuesta = result.Respuesta;
                    t.ServerLastModifiedDate = result.ServerLastModifiedDate;
                    t.IsTurnado = result.IsTurnado;
                    t.IsAtendido = result.IsAtendido;
                    t.IsBorrador = result.IsBorrador;
                    t.Rol = new Model.RolModel()
                    {
                        IdRol = result.APP_ROL.IdRol
                        ,
                        RolName = result.APP_ROL.RolName
                    };
                }
            }
            return t;
        }

        public Model.TurnoModel GetTurnoID()
        {
            Model.TurnoModel turno = new Model.TurnoModel();

            using (var entity = new GestorDocumentEntities())
            {
                GET_TURNO result = null;
                try
                {
                    result = (from o in entity.GET_TURNO
                              where o.IdTurnoAnt == null && o.IsActive == true
                              select o).First();
                }
                catch (Exception)
                {
                    ;
                }
                if (result != null)
                {
                    turno.IdTurno = result.IdTurno;
                    turno.IdTurnoAnt = result.IdTurnoAnt;
                    turno.FechaCreacion = result.FechaCreacion;
                    turno.FechaEnvio = result.FechaEnvio;
                    turno.IsActive = result.IsActive;
                    turno.LastModifiedDate = result.LastModifiedDate;
                    turno.IsModified = result.IsModified;
                    turno.IdAsunto = result.IdAsunto;
                    turno.IdStatusTurno = result.IdStatusTurno;
                    turno.IdRol = result.IdRol;
                    turno.IdUsuario = result.IdUsuario;
                    turno.Comentario = result.Comentario;
                    turno.Respuesta = result.Respuesta;
                    turno.ServerLastModifiedDate = result.ServerLastModifiedDate;
                    turno.IsTurnado = result.IsTurnado;
                    turno.IsAtendido = result.IsAtendido;
                    turno.IsBorrador = result.IsBorrador;
                    turno.Rol = new Model.RolModel() 
                    { 
                        IdRol = result.APP_ROL.IdRol
                        ,
                        RolName=result.APP_ROL.RolName 
                    };
                }
            }
            return turno;
        }

        public Model.TurnoModel GetTurnoByID(Model.TurnoModel turno)
        {
            Model.TurnoModel t = new Model.TurnoModel();

            using (var entity = new GestorDocumentEntities())
            {
                GET_TURNO result = null;
                try
                {
                    result = (from o in entity.GET_TURNO
                              where o.IsActive == true && o.IdAsunto == turno.IdAsunto
                              select o).First();
                }
                catch (Exception)
                {
                    ;
                }
                if (result != null)
                {
                    t.IdTurno = result.IdTurno;
                    t.IdTurnoAnt = result.IdTurnoAnt;
                    t.FechaCreacion = result.FechaCreacion;
                    t.FechaEnvio = result.FechaEnvio;
                    t.IsActive = result.IsActive;
                    t.LastModifiedDate = result.LastModifiedDate;
                    t.IsModified = result.IsModified;
                    t.IdAsunto = result.IdAsunto;
                    t.Asunto = new Model.AsuntoModel()
                    {
                        IdAsunto = result.IdAsunto,
                        FechaCreacion = result.GET_ASUNTO.FechaCreacion,
                        FechaRecibido = result.GET_ASUNTO.FechaRecibido,
                        FechaDocumento = result.GET_ASUNTO.FechaDocumento,
                        Titulo = result.GET_ASUNTO.Titulo,
                        Descripcion = result.GET_ASUNTO.Descripcion,
                        Alcance = result.GET_ASUNTO.Alcance,
                        IdUbicacion = result.GET_ASUNTO.IdUbicacion,
                        ReferenciaDocumento = result.GET_ASUNTO.ReferenciaDocumento,
                        Ubicacion = (result.GET_ASUNTO.CAT_UBICACION != null) ? new Model.UbicacionModel()
                        {
                            UbicacionName = result.GET_ASUNTO.CAT_UBICACION.UbicacionName
                        } :null,
                        IdInstruccion = result.GET_ASUNTO.IdInstruccion,
                        Instruccion =(result.GET_ASUNTO.CAT_INSTRUCCION != null) ? new Model.InstruccionModel()
                        {
                            InstruccionName = result.GET_ASUNTO.CAT_INSTRUCCION.InstruccionName
                        }:null,
                        IdPrioridad = result.GET_ASUNTO.IdPrioridad,
                        Prioridad = new Model.PrioridadModel()
                        {
                            PrioridadName = result.GET_ASUNTO.CAT_PRIORIDAD.PrioridadName
                            ,
                            IdPrioridad = result.GET_ASUNTO.CAT_PRIORIDAD.IdPrioridad
                            ,
                            PathImagen = result.GET_ASUNTO.CAT_PRIORIDAD.PathImagen
                        },
                        IdStatusAsunto = result.GET_ASUNTO.IdStatusAsunto,
                        StatusAsunto = new Model.StatusAsuntoModel()
                        {
                            StatusName = result.GET_ASUNTO.CAT_STATUS_ASUNTO.StatusName
                        },
                        FechaVencimiento = result.GET_ASUNTO.FechaVencimiento,
                        Folio = result.GET_ASUNTO.Folio,
                        UbicacionText = result.GET_ASUNTO.Ubicacion,
                        IsBorrador = result.GET_ASUNTO.IsBorrador
                        
                    };
                    t.IdStatusTurno = result.IdStatusTurno;
                    t.IdRol = result.IdRol;
                    t.IdUsuario = result.IdUsuario;
                    t.Comentario = result.Comentario;
                    t.Respuesta = result.Respuesta;
                    t.ServerLastModifiedDate = result.ServerLastModifiedDate;
                    t.IsTurnado = result.IsTurnado;
                    t.IsAtendido = result.IsAtendido;
                    t.IsBorrador = result.IsBorrador;
                    t.Rol = new Model.RolModel()
                    {
                        IdRol = result.APP_ROL.IdRol
                        ,
                        RolName = result.APP_ROL.RolName
                    };
                }
            }
            return t;
        }

        public Model.TurnoModel GetTurnoAdd(Model.TurnoModel turno)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (turno != null)
                {
                    //Validar si el elemento ya existe
                    GET_TURNO result = null;
                    try
                    {
                        result = (from o in entity.GET_TURNO
                                  where o.IdTurno == turno.IdTurno
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        turno = null;
                    }

                }
            }
            return turno;
        }

        public Model.TurnoModel GetTurnoMod(Model.TurnoModel turno)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (turno != null)
                {
                    //Validar si el elemento ya existe
                    GET_TURNO result = null;
                    try
                    {
                        result = (from o in entity.GET_TURNO
                                  where o.IdTurno == turno.IdTurno &&
                                  o.Comentario == turno.Comentario
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        turno = null;
                    }

                }
            }
            return turno;
        }

        public void UpdateTurno(Model.TurnoModel turno)
        {
            using (var entity = new GestorDocumentEntities())
            {
                GET_TURNO result = null;
                try
                {
                    result = (from o in entity.GET_TURNO
                              where o.IdTurno == turno.IdTurno
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IdTurnoAnt = turno.IdTurnoAnt;
                    result.FechaCreacion = turno.FechaCreacion;
                    result.FechaEnvio = turno.FechaEnvio;
                    result.IsActive = turno.IsActive;
                    result.LastModifiedDate = new UNID().getNewUNID();
                    result.IsModified = true;
                    result.IdAsunto = turno.IdAsunto;
                    result.IdStatusTurno = turno.IdStatusTurno;
                    result.IdRol = turno.IdRol;
                    result.IdUsuario = turno.IdUsuario;
                    result.Comentario =  (!string.IsNullOrWhiteSpace(turno.Comentario)) ? turno.Comentario.Trim():null;
                    result.Respuesta = (!string.IsNullOrWhiteSpace(turno.Respuesta)) ? turno.Respuesta.Trim() : null;
                    result.IsAtendido =turno.IsAtendido;
                    result.IsTurnado = turno.IsTurnado;
                    result.IsBorrador = turno.IsBorrador;
                    entity.SaveChanges();
                    UpdateSyncLocal("GET_TURNO", entity);
                }
            }
        }

        public void DeleteTurno(IEnumerable<Model.TurnoModel> turnos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.TurnoModel p in turnos)
                {
                    GET_TURNO result = null;
                    try
                    {
                        result = (from o in entity.GET_TURNO
                                  where o.IdTurno == p.IdTurno
                                  select o).First();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    if (result != null)
                    {
                        result.IsActive = false;
                        result.IsModified = true;
                        result.LastModifiedDate = new UNID().getNewUNID();
                    }
                }
                entity.SaveChanges();
                UpdateSyncLocal("GET_TURNO", entity);
            }
        }

        public void UpdateSyncLocal(string nameTable, System.Data.Objects.ObjectContext context)
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
