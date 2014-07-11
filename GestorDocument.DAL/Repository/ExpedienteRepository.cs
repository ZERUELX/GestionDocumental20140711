using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class ExpedienteRepository : IExpediente ,ISync
    {
        public void InsertExpediente(Model.ExpedienteModel expediente)
        {
            using (var entity = new GestorDocumentEntities())

                if (expediente != null)
                {
                    //Validar si el elemento ya existe
                    GET_EXPEDIENTE result = null;
                    try
                    {
                        result = (from o in entity.GET_EXPEDIENTE
                                  where o.IdExpediente == expediente.IdExpediente
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.GET_EXPEDIENTE.AddObject(
                            new GET_EXPEDIENTE()
                            {
                                IdExpediente = expediente.IdExpediente,
                                IdAsunto = expediente.Asunto.IdAsunto,
                                IsActive = true,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );

                        entity.SaveChanges();
                        UpdateSyncLocal("GET_EXPEDIENTE", entity);
                    }

                }
        }

        public IEnumerable<Model.ExpedienteModel> GetExpedientes()
        {
            ObservableCollection<Model.ExpedienteModel> expedientes = new ObservableCollection<Model.ExpedienteModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.GET_EXPEDIENTE
                     where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         expedientes.Add(new Model.ExpedienteModel()
                         {
                             IdExpediente = p.IdExpediente,
                             IdAsunto = (long)p.IdAsunto,
                             Asunto = new Model.AsuntoModel()
                             {
                                 Titulo = p.GET_ASUNTO.Titulo
                             },
                             IsActive = p.IsActive,
                             LastModifiedDate = p.LastModifiedDate,
                             IsModified = p.IsModified
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return expedientes;
        }

        /// <summary>
        /// Obtiene el expediente del asunto(Documento que fueron adjuntados.)
        /// </summary>
        /// <param name="IdExpediente">IdExpediente</param>
        /// <returns></returns>
        public IEnumerable<Model.ExpedienteModel> GetExpediente(long IdExpediente)
        {
            ObservableCollection<Model.ExpedienteModel> expedientes = new ObservableCollection<Model.ExpedienteModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.GET_EXPEDIENTE
                     join d in entity.GET_DOCUMENTOS
                     on o.IdExpediente equals d.IdExpediente
                     join e in entity.CAT_TIPO_EXTENCION
                     on d.Extencion equals e.Extencion
                     join t in entity.GET_TURNO
                     on d.IdTurno equals t.IdTurno
                     join or in entity.CAT_ORGANIGRAMA
                     on t.IdRol equals or.IdRol
                     where d.IsActive == true && o.IdExpediente == IdExpediente
                     select new
                     {
                         o,
                         d,
                         e,
                         t,
                         or,
                         sd = d.SYNC_DOC
                     }).ToList().ForEach(p =>
                     {
                         expedientes.Add(new Model.ExpedienteModel()
                         {
                             IdExpediente = p.o.IdExpediente
                             ,
                             IdAsunto = (long)p.o.IdAsunto
                             ,
                             Asunto = new Model.AsuntoModel()
                             {
                                 IdAsunto = p.o.GET_ASUNTO.IdAsunto
                                 ,
                                 Titulo = p.o.GET_ASUNTO.Titulo
                                 ,
                                 Descripcion = p.o.GET_ASUNTO.Descripcion
                             }
                             ,
                             IsActive = p.o.IsActive
                             ,
                             LastModifiedDate = p.o.LastModifiedDate
                             ,
                             IsModified = p.o.IsModified
                             ,
                             Documento = new Model.DocumentosModel()
                             {
                                 IdDocumento = p.d.IdDocumento
                                 ,
                                 IdExpediente = p.d.IdExpediente
                                 ,
                                 IdTipoDocumento = p.d.IdTipoDocumento
                                 ,
                                 IdTurno = p.d.IdTurno
                                 ,
                                 Turno = new Model.TurnoModel() 
                                 {
                                     IdTurno = p.t.IdTurno,
                                     Rol = new Model.RolModel()
                                     {
                                         IdRol = p.t.APP_ROL.IdRol
                                         ,
                                         RolName = p.t.APP_ROL.RolName
                                         ,
                                         Organigrama = new Model.OrganigramaModel()
                                         {
                                             IdJerarquia = p.or.IdJerarquia
                                             ,
                                             JerarquiaName = p.or.JerarquiaName
                                         }
                                     }

                                 }
                                 ,
                                 DocumentoName = p.d.DocumentoName
                                 ,
                                 DocumentoPath = p.d.DocumentoPath
                                 ,
                                 Fecha = p.d.Fecha
                                 ,
                                 Extencion = p.d.Extencion
                                 ,
                                 TipoDocumento = new Model.TipoDocumentoModel()
                                 {
                                     IdTipoDocumento = p.d.CAT_TIPO_DOCUMENTO.IdTipoDocumento
                                     ,
                                     TipoDocumentoName = p.d.CAT_TIPO_DOCUMENTO.TipoDocumentoName
                                 }
                                 ,
                                 TipoExtencion = new Model.TipoExtencionModel()
                                 {
                                     IdTipoExtencion = p.e.IdTipoExtencion
                                     ,
                                     Extencion = p.e.Extencion
                                     ,
                                     Path = p.e.Path
                                 }
                             }
                             ,
                             SyncDocs = (p.sd != null) ? new Model.SyncDocsModel()
                             {
                                 IdDocumento = p.sd.IdDocumento
                                 ,
                                 BanderaStatus = p.sd.BanderaStatus
                                 ,
                                 Extencion = p.sd.Extencion
                                 ,
                                 Exception = p.sd.Exception
                                 ,
                                 FechaCarga = p.sd.FechaCarga
                                 ,
                                 StatusDoc = p.sd.StatusDoc
                                 ,
                                 LastModifiedDate = p.sd.LastModifiedDate
                             } : null
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return expedientes;
        }

        public Model.ExpedienteModel GetExpedienteID(Model.ExpedienteModel expediente)
        {
            throw new NotImplementedException();
        }

        public Model.ExpedienteModel GetExpedienteAdd(Model.ExpedienteModel expediente)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (expediente != null)
                {
                    //Validar si el elemento ya existe
                    GET_EXPEDIENTE result = null;
                    try
                    {
                        result = (from o in entity.GET_EXPEDIENTE
                                  where
                                  o.IdExpediente == expediente.IdExpediente
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        expediente = null;
                    }

                }
            }
            return expediente;
        }

        public Model.ExpedienteModel GetExpedienteMod(Model.ExpedienteModel expediente)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (expediente != null)
                {
                    //Validar si el elemento ya existe
                    GET_EXPEDIENTE result = null;
                    try
                    {
                        result = (from o in entity.GET_EXPEDIENTE
                                  where
                                  o.IdExpediente == expediente.IdExpediente && 
                                  o.IsActive == true &&
                                  o.IdAsunto == expediente.IdAsunto
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        expediente = null;
                    }

                }
            }
            return expediente;
        }

        public void UpdateExpediente(Model.ExpedienteModel expediente)
        {
            using (var entity = new GestorDocumentEntities())
            {
                GET_EXPEDIENTE result = null;
                try
                {
                    result = (from o in entity.GET_EXPEDIENTE
                              where o.IdExpediente == expediente.IdExpediente
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IdAsunto = expediente.Asunto.IdAsunto;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();

                    entity.SaveChanges();
                    UpdateSyncLocal("GET_EXPEDIENTE", entity);
                }
            }
        }

        public void DeleteExpediente(IEnumerable<Model.ExpedienteModel> expedientes)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.ExpedienteModel p in expedientes)
                {
                    GET_EXPEDIENTE result = null;
                    try
                    {
                        result = (from o in entity.GET_EXPEDIENTE
                                  where o.IdExpediente == p.IdExpediente
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
                UpdateSyncLocal("GET_EXPEDIENTE", entity);
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
