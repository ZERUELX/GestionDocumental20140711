using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class UbicacionRepository : IUbicacion, ISync
    {
        public void InsertUbicacion(Model.UbicacionModel ubicacion)
        {
            using (var entity = new GestorDocumentEntities())

                if (ubicacion != null)
                {
                    //Validar si el elemento ya existe
                    CAT_UBICACION result = null;
                    try
                    {
                        result = (from o in entity.CAT_UBICACION
                                  where o.IdUbicacion == ubicacion.IdUbicacion
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.CAT_UBICACION.AddObject(
                            new CAT_UBICACION()
                            {
                                IdUbicacion = ubicacion.IdUbicacion,
                                UbicacionName = ubicacion.UbicacionName.Trim(),
                                IsActive = true,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );

                        entity.SaveChanges();

                        UpdateSyncLocal("CAT_UBICACION", entity);
                    }

                }
        }

        public IEnumerable<Model.UbicacionModel> GetUbicacions()
        {
            ObservableCollection<Model.UbicacionModel> ubicacions = new ObservableCollection<Model.UbicacionModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_UBICACION
                     where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         ubicacions.Add(new Model.UbicacionModel()
                         {
                             IdUbicacion = p.IdUbicacion,
                             UbicacionName = p.UbicacionName,
                             //IsActive = p.IsActive,
                             //LastModifiedDate = p.LastModifiedDate,
                             //IsModified = p.IsModified
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return ubicacions;
        }

        public Model.UbicacionModel GetUbicacionID(Model.UbicacionModel ubicacion)
        {
            throw new NotImplementedException();
        }

        public Model.UbicacionModel GetUbicacionAdd(Model.UbicacionModel ubicacion)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (ubicacion != null)
                {
                    //Validar si el elemento ya existe
                    CAT_UBICACION result = null;
                    try
                    {
                        result = (from o in entity.CAT_UBICACION
                                  where
                                  o.IdUbicacion == ubicacion.IdUbicacion && o.IsActive == true ||
                                  o.UbicacionName == ubicacion.UbicacionName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        ubicacion = null;
                    }

                }
            }
            return ubicacion;
        }

        public Model.UbicacionModel GetUbicacionMod(Model.UbicacionModel ubicacion)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (ubicacion != null)
                {
                    //Validar si el elemento ya existe
                    CAT_UBICACION result = null;
                    try
                    {
                        result = (from o in entity.CAT_UBICACION
                                  where
                                  o.UbicacionName == ubicacion.UbicacionName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        ubicacion = null;
                    }

                }
            }
            return ubicacion;
        }

        public void UpdateUbicacion(Model.UbicacionModel ubicacion)
        {
            using (var entity = new GestorDocumentEntities())
            {
                CAT_UBICACION result = null;
                try
                {
                    result = (from o in entity.CAT_UBICACION
                              where o.IdUbicacion == ubicacion.IdUbicacion
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.UbicacionName = ubicacion.UbicacionName;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();
                    entity.SaveChanges();
                    UpdateSyncLocal("CAT_UBICACION", entity);
                }
            }
        }

        public void DeleteUbicacion(IEnumerable<Model.UbicacionModel> ubicacions)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.UbicacionModel p in ubicacions)
                {
                    CAT_UBICACION result = null;
                    try
                    {
                        result = (from o in entity.CAT_UBICACION
                                  where o.IdUbicacion == p.IdUbicacion
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