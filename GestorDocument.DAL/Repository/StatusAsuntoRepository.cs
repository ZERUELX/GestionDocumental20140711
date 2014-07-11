using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class StatusAsuntoRepository : IStatusAsunto
    {
        public void InsertStatusAsunto(Model.StatusAsuntoModel statusasunto)
        {
            using (var entity = new GestorDocumentEntities())

                if (statusasunto != null)
                {
                    //Validar si el elemento ya existe
                    CAT_STATUS_ASUNTO result = null;
                    try
                    {
                        result = (from o in entity.CAT_STATUS_ASUNTO
                                  where o.IdStatusAsunto == statusasunto.IdStatusAsunto
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.CAT_STATUS_ASUNTO.AddObject(
                            new CAT_STATUS_ASUNTO()
                            {
                                IdStatusAsunto = statusasunto.IdStatusAsunto,
                                StatusName = statusasunto.StatusName.Trim(),
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
        /// Obtiene el estatus del asunto.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.StatusAsuntoModel> GetStatusAsuntos()
        {
            ObservableCollection<Model.StatusAsuntoModel> statusasuntos = new ObservableCollection<Model.StatusAsuntoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_STATUS_ASUNTO
                     where o.IsActive == true
                     select o).OrderBy(o => o.StatusName).ToList().ForEach(p =>
                     {
                         statusasuntos.Add(new Model.StatusAsuntoModel()
                         {
                             IdStatusAsunto = p.IdStatusAsunto,
                             StatusName = p.StatusName,
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
            return statusasuntos;
        }

        public Model.StatusAsuntoModel GetStatusAsuntoID(Model.StatusAsuntoModel statusasunto)
        {
            throw new NotImplementedException();
        }

        public Model.StatusAsuntoModel GetStatusAsuntoAdd(Model.StatusAsuntoModel statusasunto)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (statusasunto != null)
                {
                    //Validar si el elemento ya existe
                    CAT_STATUS_ASUNTO result = null;
                    try
                    {
                        result = (from o in entity.CAT_STATUS_ASUNTO
                                  where
                                  o.IdStatusAsunto == statusasunto.IdStatusAsunto && o.IsActive == true ||
                                  o.StatusName == statusasunto.StatusName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        statusasunto = null;
                    }

                }
            }
            return statusasunto;
        }

        public Model.StatusAsuntoModel GetStatusAsuntoMod(Model.StatusAsuntoModel statusasunto)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (statusasunto != null)
                {
                    //Validar si el elemento ya existe
                    CAT_STATUS_ASUNTO result = null;
                    try
                    {
                        result = (from o in entity.CAT_STATUS_ASUNTO
                                  where
                                  o.StatusName == statusasunto.StatusName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        statusasunto = null;
                    }

                }
            }
            return statusasunto;
        }

        public void UpdateStatusAsunto(Model.StatusAsuntoModel statusasunto)
        {
            using (var entity = new GestorDocumentEntities())
            {
                CAT_STATUS_ASUNTO result = null;
                try
                {
                    result = (from o in entity.CAT_STATUS_ASUNTO
                              where o.IdStatusAsunto == statusasunto.IdStatusAsunto
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.StatusName = statusasunto.StatusName;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteStatusAsunto(IEnumerable<Model.StatusAsuntoModel> statusasuntos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.StatusAsuntoModel p in statusasuntos)
                {
                    CAT_STATUS_ASUNTO result = null;
                    try
                    {
                        result = (from o in entity.CAT_STATUS_ASUNTO
                                  where o.IdStatusAsunto == p.IdStatusAsunto
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
