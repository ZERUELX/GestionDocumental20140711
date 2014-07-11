using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class DestinatarioCcpRepository : IDestinatarioCcp, ISync
    {
        public void InsertDestinatarioCcp(Model.DestinatarioCcpModel destinatarioCcp)
        {
            using (var entity = new GestorDocumentEntities())

                if (destinatarioCcp != null)
                {
                    //Validar si el elemento ya existe
                    REL_DESTINATARIO_CCP result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO_CCP
                                  where o.IdDestinatarioCcp == destinatarioCcp.IdDestinatarioCcp
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.REL_DESTINATARIO_CCP.AddObject(
                            new REL_DESTINATARIO_CCP()
                            {
                                IdDestinatarioCcp = destinatarioCcp.IdDestinatarioCcp,
                                IdRol = destinatarioCcp.IdRol,
                                IdAsunto = destinatarioCcp.IdAsunto,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );

                        entity.SaveChanges();

                        UpdateSyncLocal("REL_DESTINATARIO_CCP", entity);
                    }

                }
        }

        public void InsertDestinatarioCcp(IEnumerable<Model.DestinatarioCcpModel> destinatariosCcp)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.DestinatarioCcpModel p in destinatariosCcp)
                {
                    REL_DESTINATARIO_CCP result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO_CCP
                                  where o.IdDestinatarioCcp == p.IdDestinatarioCcp
                                  select o).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }

                    if (result == null)
                    {
                        entity.REL_DESTINATARIO_CCP.AddObject(
                            new REL_DESTINATARIO_CCP()
                            {
                                IdDestinatarioCcp = p.IdDestinatarioCcp
                                ,
                                IdRol = p.IdRol
                                ,
                                IdAsunto = p.IdAsunto
                                ,
                                IsActive = p.IsActive
                                ,
                                IsModified = true
                                ,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );
                    }
                }

                entity.SaveChanges();

                UpdateSyncLocal("REL_DESTINATARIO_CCP", entity);
            }
        }

        public IEnumerable<Model.DestinatarioCcpModel> GetDestinatariosCcp()
        {
            ObservableCollection<Model.DestinatarioCcpModel> destinatarioCcp = new ObservableCollection<Model.DestinatarioCcpModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.REL_DESTINATARIO_CCP
                     where o.IsActive
                     select o).ToList().ForEach(p =>
                     {
                         destinatarioCcp.Add(new Model.DestinatarioCcpModel()
                         {
                             IdDestinatarioCcp = p.IdDestinatarioCcp,
                             IdRol = p.IdRol,
                             IdAsunto = p.IdAsunto,
                             IsActive = p.IsActive,
                             ServerLastModifiedDate = p.ServerLastModifiedDate
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return destinatarioCcp;
        }

        public IEnumerable<Model.DestinatarioCcpModel> GetDestinatariosCcp(long IdAsunto)
        {
            ObservableCollection<Model.DestinatarioCcpModel> destinatarioCcp = new ObservableCollection<Model.DestinatarioCcpModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.REL_DESTINATARIO_CCP
                     join r in entity.APP_ROL
                     on o.IdRol equals r.IdRol
                     join or in entity.CAT_ORGANIGRAMA
                     on o.IdRol equals or.IdRol
                     where o.IsActive == true && o.IdAsunto == IdAsunto
                     select new { o, or }).ToList().ForEach(p =>
                     {
                         destinatarioCcp.Add(new Model.DestinatarioCcpModel()
                         {
                             IdDestinatarioCcp = p.o.IdDestinatarioCcp,
                             IdRol = p.o.IdRol,
                             Rol = new Model.RolModel()
                             {
                                 IdRol = p.o.IdRol
                                 ,
                                 RolName = p.o.APP_ROL.RolName
                                 ,
                                 Organigrama = new Model.OrganigramaModel()
                                 {
                                     IdJerarquia = p.or.IdJerarquia,
                                     JerarquiaName = p.or.JerarquiaName,
                                     JerarquiaTitular =p.or.JerarquiaTitular
                                 }
                             },
                             IdAsunto = p.o.IdAsunto,
                             IsActive = p.o.IsActive,
                             LastModidiedDate = p.o.LastModifiedDate,
                             IsModified = p.o.IsModified,
                             ServerLastModifiedDate = p.o.ServerLastModifiedDate
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return destinatarioCcp;
        }

        public Model.DestinatarioCcpModel GetDestinatarioCcpID(Model.DestinatarioCcpModel destinatarioCcp)
        {
            throw new NotImplementedException();
        }

        public Model.DestinatarioCcpModel GetDestinatarioCcpAdd(Model.DestinatarioCcpModel destinatarioCcp)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (destinatarioCcp != null)
                {
                    //Validar si el elemento ya existe
                    REL_DESTINATARIO_CCP result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO_CCP
                                  where o.IdDestinatarioCcp == destinatarioCcp.IdDestinatarioCcp
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        destinatarioCcp = null;
                    }

                }
            }
            return destinatarioCcp;
        }

        public Model.DestinatarioCcpModel GetDestinatarioCcpMod(Model.DestinatarioCcpModel destinatarioCcp)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (destinatarioCcp != null)
                {
                    //Validar si el elemento ya existe
                    REL_DESTINATARIO_CCP result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO_CCP
                                  where
                                  o.IdDestinatarioCcp == destinatarioCcp.IdDestinatarioCcp &&
                                  o.IdRol == destinatarioCcp.IdRol &&
                                  o.IdAsunto == destinatarioCcp.IdAsunto
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        destinatarioCcp = null;
                    }

                }
            }
            return destinatarioCcp;
        }

        public void UpdateDestinatarioCcp(Model.DestinatarioCcpModel destinatarioCcp)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (destinatarioCcp != null)
                {
                    REL_DESTINATARIO_CCP result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO_CCP
                                  where o.IdDestinatarioCcp == destinatarioCcp.IdDestinatarioCcp
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }

                    if (result != null)
                    {
                        result.IdDestinatarioCcp = destinatarioCcp.IdDestinatarioCcp;
                        result.IdRol = destinatarioCcp.IdRol;
                        result.IdAsunto = destinatarioCcp.IdAsunto;
                        result.IsModified = true;
                        result.LastModifiedDate = new UNID().getNewUNID();

                        entity.SaveChanges();

                        UpdateSyncLocal("REL_DESTINATARIO_CCP", entity);
                    }
                    
                }
            }
        }

        public void UpdateDestinatarioCcp(IEnumerable<Model.DestinatarioCcpModel> destinatariosCcp)
        {
            throw new NotImplementedException();
        }

        public void DeleteDestinatarioCcp(IEnumerable<Model.DestinatarioCcpModel> destinatariosCcp)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.DestinatarioCcpModel p in destinatariosCcp)
                {
                    REL_DESTINATARIO_CCP result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO_CCP
                                  where o.IdDestinatarioCcp == p.IdDestinatarioCcp
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

                UpdateSyncLocal("REL_DESTINATARIO_CCP", entity);
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
