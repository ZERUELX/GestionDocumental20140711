using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class PrioridadRepository : IPrioridad
    {
        public void InsertPrioridad(Model.PrioridadModel prioridad)
        {
            using (var entity = new GestorDocumentEntities())

                if (prioridad != null)
                {
                    //Validar si el elemento ya existe
                    CAT_PRIORIDAD result = null;
                    try
                    {
                        result = (from o in entity.CAT_PRIORIDAD
                                  where o.IdPrioridad == prioridad.IdPrioridad
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.CAT_PRIORIDAD.AddObject(
                            new CAT_PRIORIDAD()
                            {
                                IdPrioridad = prioridad.IdPrioridad,
                                PrioridadName = prioridad.PrioridadName.Trim(),
                                PathImagen = prioridad.PathImagen,
                                IsActive = true,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );

                        entity.SaveChanges();
                    }

                }
        }


        /// <summary>
        /// Obtiene las prioridades de los asuntos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.PrioridadModel> GetPrioridads()
        {
            ObservableCollection<Model.PrioridadModel> prioridads = new ObservableCollection<Model.PrioridadModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_PRIORIDAD
                     where o.IsActive == true
                     select o).OrderBy(o => o.PrioridadName).ToList().ForEach(p =>
                     {
                         prioridads.Add(new Model.PrioridadModel()
                         {
                             IdPrioridad = p.IdPrioridad,
                             PrioridadName = p.PrioridadName,
                             PathImagen = p.PathImagen,
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
            return prioridads;
        }

        public Model.PrioridadModel GetPrioridadID(Model.PrioridadModel prioridad)
        {
            throw new NotImplementedException();
        }

        public Model.PrioridadModel GetPrioridadAdd(Model.PrioridadModel prioridad)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (prioridad != null)
                {
                    //Validar si el elemento ya existe
                    CAT_PRIORIDAD result = null;
                    try
                    {
                        result = (from o in entity.CAT_PRIORIDAD
                                  where
                                  o.IdPrioridad == prioridad.IdPrioridad && o.IsActive == true ||
                                  o.PrioridadName == prioridad.PrioridadName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        prioridad = null;
                    }

                }
            }
            return prioridad;
        }

        public Model.PrioridadModel GetPrioridadMod(Model.PrioridadModel prioridad)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (prioridad != null)
                {
                    //Validar si el elemento ya existe
                    CAT_PRIORIDAD result = null;
                    try
                    {
                        result = (from o in entity.CAT_PRIORIDAD
                                  where
                                  o.PrioridadName == prioridad.PrioridadName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        prioridad = null;
                    }

                }
            }
            return prioridad;
        }

        public void UpdatePrioridad(Model.PrioridadModel prioridad)
        {
            using (var entity = new GestorDocumentEntities())
            {
                CAT_PRIORIDAD result = null;
                try
                {
                    result = (from o in entity.CAT_PRIORIDAD
                              where o.IdPrioridad == prioridad.IdPrioridad
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.PrioridadName = prioridad.PrioridadName;
                    result.PathImagen = prioridad.PathImagen;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();

                    entity.SaveChanges();
                }
            }
        }

        public void DeletePrioridad(IEnumerable<Model.PrioridadModel> prioridads)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.PrioridadModel p in prioridads)
                {
                    CAT_PRIORIDAD result = null;
                    try
                    {
                        result = (from o in entity.CAT_PRIORIDAD
                                  where o.IdPrioridad == p.IdPrioridad
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

    }
}
