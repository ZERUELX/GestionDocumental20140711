using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class FechaVencimientoRepository : IFechaVencimiento
    {
        public void InsertFechaVencimiento(Model.FechaVencimientoModel fechavencimiento)
        {
            using (var entity = new GestorDocumentEntities())

                if (fechavencimiento != null)
                {
                    //Validar si el elemento ya existe
                    GET_FECHA_VENCIMIENTO result = null;
                    try
                    {
                        result = (from o in entity.GET_FECHA_VENCIMIENTO
                                  where o.IdFechaVencimiento == fechavencimiento.IdFechaVencimiento
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.GET_FECHA_VENCIMIENTO.AddObject(
                            new GET_FECHA_VENCIMIENTO()
                            {
                                IdFechaVencimiento = fechavencimiento.IdFechaVencimiento,
                                IdAsunto = fechavencimiento.Asunto.IdAsunto,
                                FechaVencimiento = fechavencimiento.FechaVencimiento,
                                FechaCreacion = fechavencimiento.FechaCreacion,
                                IsActual = true,
                                IsActive = fechavencimiento.IsActive,
                                LastModifiedDate = new UNID().getNewUNID(),
                            }
                        );

                        entity.SaveChanges();
                    }

                }
        }

        public IEnumerable<Model.FechaVencimientoModel> GetFechaVencimientos()
        {
            ObservableCollection<Model.FechaVencimientoModel> FechaVencimientos = new ObservableCollection<Model.FechaVencimientoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.GET_FECHA_VENCIMIENTO
                     where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         FechaVencimientos.Add(new Model.FechaVencimientoModel()
                         {
                             IdFechaVencimiento = p.IdFechaVencimiento,
                             IdAsunto = p.IdAsunto,
                             Asunto = new Model.AsuntoModel()
                             {
                                 Titulo = p.GET_ASUNTO.Titulo
                             },
                             FechaVencimiento = p.FechaVencimiento,
                             FechaCreacion = p.FechaCreacion,
                             IsActual = true,
                             IsActive = p.IsActive,
                             LastModifiedDate = new UNID().getNewUNID(),
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return FechaVencimientos;
        }

        public Model.FechaVencimientoModel GetFechaVencimientoID(Model.FechaVencimientoModel fechavencimiento)
        {
            throw new NotImplementedException();
        }

        public Model.FechaVencimientoModel GetFechaVencimientoAdd(Model.FechaVencimientoModel fechavencimiento)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (fechavencimiento != null)
                {
                    //Validar si el elemento ya existe
                    GET_FECHA_VENCIMIENTO result = null;
                    try
                    {
                        result = (from o in entity.GET_FECHA_VENCIMIENTO
                                  where o.IdFechaVencimiento == fechavencimiento.IdFechaVencimiento
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        fechavencimiento = null;
                    }

                }
            }
            return fechavencimiento;
        }

        public Model.FechaVencimientoModel GetFechaVencimientoMod(Model.FechaVencimientoModel fechavencimiento)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (fechavencimiento != null)
                {
                    //Validar si el elemento ya existe
                    GET_FECHA_VENCIMIENTO result = null;
                    try
                    {
                        result = (from o in entity.GET_FECHA_VENCIMIENTO
                                  where o.IdFechaVencimiento == fechavencimiento.IdFechaVencimiento &&
                                  o.IdAsunto == fechavencimiento.IdAsunto
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        fechavencimiento = null;
                    }

                }
            }
            return fechavencimiento;
        }

        public void UpdateFechaVencimiento(Model.FechaVencimientoModel fechavencimiento)
        {
            using (var entity = new GestorDocumentEntities())
            {
                GET_FECHA_VENCIMIENTO result = null;
                try
                {
                    result = (from o in entity.GET_FECHA_VENCIMIENTO
                              where o.IdFechaVencimiento == fechavencimiento.IdFechaVencimiento
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IdAsunto = fechavencimiento.Asunto.IdAsunto;
                    result.FechaVencimiento = fechavencimiento.FechaVencimiento;
                    result.FechaCreacion = fechavencimiento.FechaCreacion;
                    result.IsActual = true;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();
                    entity.SaveChanges();
                }
            }
        }

        public void DeleteFechaVencimiento(IEnumerable<Model.FechaVencimientoModel> fechavencimientos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.FechaVencimientoModel p in fechavencimientos)
                {
                    GET_FECHA_VENCIMIENTO result = null;
                    try
                    {
                        result = (from o in entity.GET_FECHA_VENCIMIENTO
                                  where o.IdFechaVencimiento == p.IdFechaVencimiento
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
