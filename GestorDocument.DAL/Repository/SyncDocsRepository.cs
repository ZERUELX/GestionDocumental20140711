using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class SyncDocsRepository : ISyncDocs
    {
        public void InsertSyncDoc(Model.SyncDocsModel syncDoc)
        {
            throw new NotImplementedException();
        }

        public void InsertSyncDocs(IEnumerable<Model.SyncDocsModel> syncDocs)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.SyncDocsModel p in syncDocs)
                {
                    SYNC_DOC result = null;
                    try
                    {
                        result = (from o in entity.SYNC_DOC
                                  where o.IdDocumento == p.IdDocumento
                                  select o).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    if (result == null)
                    {
                        entity.SYNC_DOC.AddObject(
                            new SYNC_DOC()
                            {
                                IdDocumento = p.IdDocumento
                                ,
                                BanderaStatus = p.BanderaStatus
                                ,
                                LastModifiedDate = new UNID().getNewUNID()
                                ,
                                StatusDoc = p.StatusDoc
                                ,
                                Extencion = p.Extencion
                            });
                    }
                }
                entity.SaveChanges();
            }
        }

        public void UpdateSyncDoc(Model.SyncDocsModel syncDoc)
        {
            throw new NotImplementedException();
        }

        public void UpdateSyncDocs(IEnumerable<Model.SyncDocsModel> syncDocs)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.SyncDocsModel p in syncDocs)
                {
                    SYNC_DOC result = null;
                    try
                    {
                        result = (from o in entity.SYNC_DOC
                                  where o.IdDocumento == p.IdDocumento
                                  select o).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    if (result != null)
                    {
                        result.BanderaStatus = p.BanderaStatus;
                        result.FechaCarga = p.FechaCarga;
                        result.Exception = p.Exception;
                        result.LastModifiedDate = new UNID().getNewUNID();
                        result.StatusDoc = p.StatusDoc;
                        result.Extencion = p.Extencion;
                    }
                }
                entity.SaveChanges();
            }
        }

        public IEnumerable<Model.SyncDocsModel> GetSyncDocs()
        {
            ObservableCollection<Model.SyncDocsModel> syncDocs = new ObservableCollection<Model.SyncDocsModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.SYNC_DOC
                     where !o.BanderaStatus
                     select o).ToList().ForEach(p =>
                     {
                         syncDocs.Add(new Model.SyncDocsModel()
                         {
                             IdDocumento = p.IdDocumento
                             ,
                             BanderaStatus = p.BanderaStatus
                             ,
                             Exception = p.Exception
                             ,
                             FechaCarga = p.FechaCarga
                             ,
                             LastModifiedDate = p.LastModifiedDate
                             ,
                             StatusDoc = p.StatusDoc
                             ,
                             Extencion = p.Extencion
                             
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return syncDocs;
        }
    }
}
