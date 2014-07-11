using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class StatusTurnoRepository : IStatusTurno
    {
        public void InsertStatusTurno(Model.StatusTurnoModel statusturno)
        {
            using (var entity = new GestorDocumentEntities())

                if (statusturno != null)
                {
                    //Validar si el elemento ya existe
                    CAT_STATUS_TURNO result = null;
                    try
                    {
                        result = (from o in entity.CAT_STATUS_TURNO
                                  where o.IdStatusTurno == statusturno.IdStatusTurno
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.CAT_STATUS_TURNO.AddObject(
                            new CAT_STATUS_TURNO()
                            {
                                IdStatusTurno = statusturno.IdStatusTurno,
                                StatusName = statusturno.StatusName.Trim(),
                                IsActive = true,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );

                        entity.SaveChanges();
                    }

                }
        }

        public IEnumerable<Model.StatusTurnoModel> GetStatusTurnos()
        {
            ObservableCollection<Model.StatusTurnoModel> statusturnos = new ObservableCollection<Model.StatusTurnoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_STATUS_TURNO
                     where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         statusturnos.Add(new Model.StatusTurnoModel()
                         {
                             IdStatusTurno = p.IdStatusTurno,
                             StatusName = p.StatusName,
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
            return statusturnos;
        }

        public Model.StatusTurnoModel GetStatusTurnoID(Model.StatusTurnoModel statusturno)
        {
            throw new NotImplementedException();
        }

        public Model.StatusTurnoModel GetStatusTurnoAdd(Model.StatusTurnoModel statusturno)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (statusturno != null)
                {
                    //Validar si el elemento ya existe
                    CAT_STATUS_TURNO result = null;
                    try
                    {
                        result = (from o in entity.CAT_STATUS_TURNO
                                  where
                                  o.IdStatusTurno == statusturno.IdStatusTurno && o.IsActive == true ||
                                  o.StatusName == statusturno.StatusName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        statusturno = null;
                    }

                }
            }
            return statusturno;
        }

        public Model.StatusTurnoModel GetStatusTurnoMod(Model.StatusTurnoModel statusturno)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (statusturno != null)
                {
                    //Validar si el elemento ya existe
                    CAT_STATUS_TURNO result = null;
                    try
                    {
                        result = (from o in entity.CAT_STATUS_TURNO
                                  where
                                  o.StatusName == statusturno.StatusName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        statusturno = null;
                    }

                }
            }
            return statusturno;
        }

        public void UpdateStatusTurno(Model.StatusTurnoModel statusturno)
        {
            using (var entity = new GestorDocumentEntities())
            {
                CAT_STATUS_TURNO result = null;
                try
                {
                    result = (from o in entity.CAT_STATUS_TURNO
                              where o.IdStatusTurno == statusturno.IdStatusTurno
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.StatusName = statusturno.StatusName;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteStatusTurno(IEnumerable<Model.StatusTurnoModel> statusturnos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.StatusTurnoModel p in statusturnos)
                {
                    CAT_STATUS_TURNO result = null;
                    try
                    {
                        result = (from o in entity.CAT_STATUS_TURNO
                                  where o.IdStatusTurno == p.IdStatusTurno
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
