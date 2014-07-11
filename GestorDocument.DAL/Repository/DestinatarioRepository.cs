using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class DestinatarioRepository : IDestinatario, ISync
    {
        public void InsertDestinatario(Model.DestinatarioModel destinatario)
        {
            using (var entity = new GestorDocumentEntities())

                if (destinatario != null)
                {
                    //Validar si el elemento ya existe
                    REL_DESTINATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO
                                  where o.IdDestinatario == destinatario.IdDestinatario
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.REL_DESTINATARIO.AddObject(
                            new REL_DESTINATARIO()
                            {
                                IdDestinatario = destinatario.IdDestinatario,
                                IdRol = destinatario.IdRol,
                                IdTurno = destinatario.IdTurno,
                                IsPrincipal = destinatario.IsPrincipal,
                                ServerLastModifiedDate = new UNID().getNewUNID()                                
                            }
                        );

                        entity.SaveChanges();

                        UpdateSyncLocal("REL_DESTINATARIO", entity);
                    }

                }
        }

        public void InsertDestinatario(IEnumerable<Model.DestinatarioModel> destinatarios)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.DestinatarioModel p in destinatarios)
                {
                    REL_DESTINATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO
                                  where o.IdDestinatario == p.IdDestinatario
                                  select o).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }

                    if (result == null)
                    {
                        entity.REL_DESTINATARIO.AddObject(
                            new REL_DESTINATARIO()
                            {
                                IdDestinatario = p.IdDestinatario
                                ,
                                IdRol = p.IdRol
                                ,
                                IdTurno = p.IdTurno
                                ,
                                IsPrincipal = p.IsPrincipal
                                ,
                                IsActive = p.IsActive
                                ,
                                IsModified= true
                                ,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );
                    }
                }
                entity.SaveChanges();
                UpdateSyncLocal("REL_DESTINATARIO", entity);
            }
        }

        public IEnumerable<Model.DestinatarioModel> GetDestinatarios()
        {
            ObservableCollection<Model.DestinatarioModel> destinatario = new ObservableCollection<Model.DestinatarioModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.REL_DESTINATARIO
                     //where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         destinatario.Add(new Model.DestinatarioModel()
                         {
                             IdDestinatario = p.IdDestinatario,
                             IdRol = p.IdRol,
                             IdTurno = p.IdTurno,
                             IsPrincipal=p.IsPrincipal,
                             ServerLastModifiedDate =p.ServerLastModifiedDate
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return destinatario;
        }

        public IEnumerable<Model.DestinatarioModel> GetDestinatarios(long Idturno)
        {
            ObservableCollection<Model.DestinatarioModel> destinatario = new ObservableCollection<Model.DestinatarioModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.REL_DESTINATARIO
                     join r in entity.APP_ROL
                     on o.IdRol equals r.IdRol
                     join or in entity.CAT_ORGANIGRAMA
                     on o.IdRol equals or.IdRol
                     where o.IsActive == true && o.IdTurno ==Idturno
                     select new {o,or}).ToList().ForEach(p =>
                     {
                         destinatario.Add(new Model.DestinatarioModel()
                         {
                             IdDestinatario = p.o.IdDestinatario,
                             IdRol = p.o.IdRol,
                             Rol = new Model.RolModel()
                             {
                                 IdRol = p.o.IdRol
                                 ,
                                 RolName = p.o.APP_ROL.RolName
                                 ,
                                 Organigrama = new Model.OrganigramaModel()
                                 {
                                     IdJerarquia = p.or.IdJerarquia
                                     ,
                                     JerarquiaName = p.or.JerarquiaName,
                                     JerarquiaTitular = p.or.JerarquiaTitular,
                                 }
                             },
                             IdTurno = p.o.IdTurno,
                             IsPrincipal = p.o.IsPrincipal,
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
            return destinatario;
        }

        public IEnumerable<Model.DestinatarioModel> GetSeguimientoDestinatarios(long IdAsunto)
        {
            ObservableCollection<Model.DestinatarioModel> destinatario = new ObservableCollection<Model.DestinatarioModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                  var query=  (from o in entity.GET_TURNO
                     join or in entity.CAT_ORGANIGRAMA
                     on o.IdRol equals or.IdRol
                     where o.IdAsunto == IdAsunto
                     select new
                     {
                         o,
                         or,
                         destinatario = o.REL_DESTINATARIO.Join
                         (entity.CAT_ORGANIGRAMA, post => post.IdRol, meta => meta.IdRol, (post, meta) =>
                             new { Post = post, Meta = meta }).Select(des => new Model.DestinatarioModel
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
                                         IdJerarquia = des.Meta.IdJerarquia,
                                         JerarquiaName = des.Meta.JerarquiaName,
                                         JerarquiaTitular =des.Meta.JerarquiaTitular
                                     }
                                 }
                                 ,
                                 IsActive = des.Post.IsActive
                             }).Where(w => w.IsActive)
                     }).ToList();

                  (from p in query
                   select p).ToList()
                              .ForEach
                              (o => o.destinatario
                                  .ToList()
                                  .ForEach(t => destinatario.Add(t))
                              );
                     
                }
                catch (Exception)
                {
                    ;
                }
            }
            return destinatario;


        }

        public Model.DestinatarioModel GetDestinatarioID(Model.DestinatarioModel destinatario)
        {
            throw new NotImplementedException();
        }

        public Model.DestinatarioModel GetDestinatarioAdd(Model.DestinatarioModel destinatario)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (destinatario != null)
                {
                    //Validar si el elemento ya existe
                    REL_DESTINATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO
                                  where o.IdDestinatario == destinatario.IdDestinatario
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        destinatario = null;
                    }

                }
            }
            return destinatario;
        }

        public Model.DestinatarioModel GetDestinatarioMod(Model.DestinatarioModel destinatario)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (destinatario != null)
                {
                    //Validar si el elemento ya existe
                    REL_DESTINATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO
                                  where
                                  o.IdDestinatario == destinatario.IdDestinatario &&
                                  o.IdRol == destinatario.IdRol &&
                                  o.IdTurno == destinatario.IdTurno
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        destinatario = null;
                    }

                }
            }
            return destinatario;
        }

        public void UpdateDestinatario(Model.DestinatarioModel destinatario)
        {
            using (var entity = new GestorDocumentEntities())
            {
                REL_DESTINATARIO result = null;
                try
                {
                    result = (from o in entity.REL_DESTINATARIO
                              where o.IdDestinatario == destinatario.IdDestinatario
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IdDestinatario = destinatario.IdDestinatario;
                    result.IdRol = destinatario.IdRol;
                    result.IdTurno = destinatario.IdTurno;
                    result.IsPrincipal = destinatario.IsPrincipal;
                    result.ServerLastModifiedDate = new UNID().getNewUNID();

                    entity.SaveChanges();
                    UpdateSyncLocal("REL_DESTINATARIO", entity);
                }
            }
        }

        public void UpdateDestinatario(IEnumerable<Model.DestinatarioModel> destinatarios)
        {
            throw new NotImplementedException();
        }

        public void DeleteDestinatario(IEnumerable<Model.DestinatarioModel> destinatarios)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.DestinatarioModel p in destinatarios)
                {
                    REL_DESTINATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_DESTINATARIO
                                  where o.IdDestinatario == p.IdDestinatario
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
                UpdateSyncLocal("REL_DESTINATARIO", entity);
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
