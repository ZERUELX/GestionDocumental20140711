using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class DocumentosRepository : IDocumentos ,ISync
    {
        public void InsertDocumentos(Model.DocumentosModel documento)
        {
            using (var entity = new GestorDocumentEntities())

                if (documento != null)
                {
                    //Validar si el elemento ya existe
                    GET_DOCUMENTOS result = null;
                    try
                    {
                        result = (from o in entity.GET_DOCUMENTOS
                                  where o.IdDocumento == documento.IdDocumento
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.GET_DOCUMENTOS.AddObject(
                            new GET_DOCUMENTOS()
                            {
                                IdDocumento = documento.IdDocumento,
                                DocumentoName = documento.DocumentoName,
                                DocumentoPath = documento.DocumentoPath,
                                Extencion = documento.Extencion,
                                IsActive = documento.IsActive,
                                LastModifiedDate = new UNID().getNewUNID(),
                                IdTurno = documento.IdTurno,
                                Fecha = documento.Fecha,
                                IdExpediente = documento.IdExpediente,
                                IdTipoDocumento = documento.TipoDocumento.IdTipoDocumento,
                                IsDocumentoOriginal = documento.IsDocumentoOriginal
                            }
                        );

                        entity.SaveChanges();
                        UpdateSyncLocal("GET_DOCUMENTOS", entity);
                    }

                }
        }

        public void InsertDocumentos(IEnumerable<Model.DocumentosModel> documentos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.DocumentosModel p in documentos)
                {
                    GET_DOCUMENTOS result = null;
                    try
                    {
                        result = (from o in entity.GET_DOCUMENTOS
                                  where o.IdDocumento == p.IdDocumento
                                  select o).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }

                    if (result == null)
                    {
                        entity.GET_DOCUMENTOS.AddObject(
                            new GET_DOCUMENTOS()
                            {
                                IdDocumento = p.IdDocumento,
                                DocumentoName = p.DocumentoName,
                                DocumentoPath = p.DocumentoPath,
                                Extencion = p.Extencion,
                                IsActive = p.IsActive,
                                LastModifiedDate = new UNID().getNewUNID(),
                                IsModified = true,
                                IdTurno = p.IdTurno,
                                Fecha = p.Fecha,
                                IdExpediente = p.IdExpediente,
                                IdTipoDocumento = p.TipoDocumento.IdTipoDocumento,
                                IsDocumentoOriginal = p.IsDocumentoOriginal
                            }
                        );

                    }
                }
                entity.SaveChanges();
                UpdateSyncLocal("GET_DOCUMENTOS", entity);
            }
        }

        public IEnumerable<Model.DocumentosModel> GetDocumentos()
        {

            ObservableCollection<Model.DocumentosModel> Documentos = new ObservableCollection<Model.DocumentosModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.GET_DOCUMENTOS
                     where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         Documentos.Add(new Model.DocumentosModel()
                         {
                             IdDocumento = p.IdDocumento,
                             DocumentoName = p.DocumentoName,
                             DocumentoPath = p.DocumentoPath,
                             Extencion = p.Extencion,
                             IsActive =  p.IsActive,
                             IdTurno =  p.IdTurno,
                             Fecha = p.Fecha,
                             IdExpediente = p.IdExpediente,
                             IdTipoDocumento = p.IdTipoDocumento,
                             TipoDocumento = new Model.TipoDocumentoModel()
                             {
                                 TipoDocumentoName = p.CAT_TIPO_DOCUMENTO.TipoDocumentoName
                             },
                             IsDocumentoOriginal = p.IsDocumentoOriginal
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return Documentos;
        }

        public IEnumerable<Model.DocumentosModel> GetDocumentos(long IdTurno)
        {
            ObservableCollection<Model.DocumentosModel> Documentos = new ObservableCollection<Model.DocumentosModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from a in entity.GET_ASUNTO
                     join t in entity.GET_TURNO
                     on a.IdAsunto equals t.IdAsunto
                     join o in entity.GET_DOCUMENTOS
                     on t.IdTurno equals o.IdTurno
                     where o.IsActive == true && t.IdTurno ==IdTurno
                     select o).ToList().ForEach(p =>
                     {
                         Documentos.Add(new Model.DocumentosModel()
                         {
                             IdDocumento = p.IdDocumento,
                             DocumentoName = p.DocumentoName,
                             DocumentoPath = p.DocumentoPath,
                             Extencion = p.Extencion,
                             IsActive = p.IsActive,
                             IdTurno = p.IdTurno,
                             Fecha = p.Fecha,
                             IdExpediente = p.IdExpediente,
                             IdTipoDocumento = p.IdTipoDocumento,
                             TipoDocumento = new Model.TipoDocumentoModel()
                             {
                                 TipoDocumentoName = p.CAT_TIPO_DOCUMENTO.TipoDocumentoName
                             },
                             IsDocumentoOriginal = p.IsDocumentoOriginal
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return Documentos;
        }

        public Model.DocumentosModel GetDocumentosID(Model.DocumentosModel documento)
        {
            throw new NotImplementedException();
        }

        public Model.DocumentosModel GetDocumentosAdd(Model.DocumentosModel documento)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (documento != null)
                {
                    //Validar si el elemento ya existe
                    GET_DOCUMENTOS result = null;
                    try
                    {
                        result = (from o in entity.GET_DOCUMENTOS
                                  where o.IdDocumento == documento.IdDocumento
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        documento = null;
                    }

                }
            }
            return documento;
        }

        public Model.DocumentosModel GetDocumentosMod(Model.DocumentosModel documento)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (documento != null)
                {
                    //Validar si el elemento ya existe
                    GET_DOCUMENTOS result = null;
                    try
                    {
                        result = (from o in entity.GET_DOCUMENTOS
                                  where o.IdDocumento == documento.IdDocumento &&
                                  o.DocumentoName == documento.DocumentoName
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        documento = null;
                    }

                }
            }
            return documento;
        }

        public void UpdateDocumentos(Model.DocumentosModel documento)
        {
            using (var entity = new GestorDocumentEntities())
            {
                GET_DOCUMENTOS result = null;
                try
                {
                    result = (from o in entity.GET_DOCUMENTOS
                              where o.IdDocumento == documento.IdDocumento
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IdDocumento = documento.IdDocumento;
                    result.DocumentoName = documento.DocumentoName;
                    result.DocumentoPath = documento.DocumentoPath;
                    result.Extencion = documento.Extencion;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();
                    result.IdTurno = documento.IdTurno;
                    result.Fecha = documento.Fecha;
                    result.IdExpediente = documento.IdExpediente;
                    result.IdTipoDocumento = documento.TipoDocumento.IdTipoDocumento;

                    entity.SaveChanges();
                    UpdateSyncLocal("GET_DOCUMENTOS", entity);
                }
            }
        }

        public void UpdateDocumentos(IEnumerable<Model.DocumentosModel> documentos)
        {
            throw new NotImplementedException();
        }

        public void DeleteDocumentos(IEnumerable<Model.DocumentosModel> documentos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.DocumentosModel p in documentos)
                {
                    GET_DOCUMENTOS result = null;
                    try
                    {
                        result = (from o in entity.GET_DOCUMENTOS
                                  where o.IdDocumento == p.IdDocumento
                                  select o).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }

                    if (result != null)
                    {
                        result.IsActive = false;
                        result.IsModified = true;
                        result.LastModifiedDate = new UNID().getNewUNID();
                    }
                }
                entity.SaveChanges();
                UpdateSyncLocal("GET_DOCUMENTOS", entity);
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
