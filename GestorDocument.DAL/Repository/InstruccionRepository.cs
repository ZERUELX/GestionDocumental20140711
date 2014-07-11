using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class InstruccionRepository : IInstruccion,ISync
    {
        public void InsertInstruccion(Model.InstruccionModel instruccion)
        {
            using (var entity = new GestorDocumentEntities())

                if (instruccion != null)
                {
                    //Validar si el elemento ya existe
                    CAT_INSTRUCCION result = null;
                    try
                    {
                        result = (from o in entity.CAT_INSTRUCCION
                                  where o.IdInstruccion == instruccion.IdInstruccion
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.CAT_INSTRUCCION.AddObject(
                            new CAT_INSTRUCCION()
                            {
                                IdInstruccion = instruccion.IdInstruccion,
                                CveInstruccion = instruccion.CveInstruccion,
                                InstruccionName = instruccion.InstruccionName.Trim(),
                                IsActive = instruccion.IsActive,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );

                        entity.SaveChanges();

                        UpdateSyncLocal("CAT_INSTRUCCION", entity);
                    }

                }
        }

        public IEnumerable<Model.InstruccionModel> GetInstruccions()
        {
            ObservableCollection<Model.InstruccionModel> Instruccions = new ObservableCollection<Model.InstruccionModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_INSTRUCCION
                     where o.IsActive == true
                     select o).OrderBy( o=> o.InstruccionName).ToList().ForEach(p =>
                     {
                         Instruccions.Add(new Model.InstruccionModel()
                         {
                             IdInstruccion = p.IdInstruccion,
                             CveInstruccion = p.CveInstruccion,
                             InstruccionName = p.InstruccionName,
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
            return Instruccions;
        }

        public Model.InstruccionModel GetInstruccionID(Model.InstruccionModel instruccion)
        {
            throw new NotImplementedException();
        }

        public Model.InstruccionModel GetInstruccionAdd(Model.InstruccionModel instruccion)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (instruccion != null)
                {
                    //Validar si el elemento ya existe
                    CAT_INSTRUCCION result = null;
                    try
                    {
                        result = (from o in entity.CAT_INSTRUCCION
                                  where
                                  o.IdInstruccion == instruccion.IdInstruccion && o.IsActive == true ||
                                  o.InstruccionName == instruccion.InstruccionName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        instruccion = null;
                    }

                }
            }
            return instruccion;
        }

        public Model.InstruccionModel GetInstruccionMod(Model.InstruccionModel instruccion)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (instruccion != null)
                {
                    //Validar si el elemento ya existe
                    CAT_INSTRUCCION result = null;
                    try
                    {
                        result = (from o in entity.CAT_INSTRUCCION
                                  where
                                  o.InstruccionName == instruccion.InstruccionName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        instruccion = null;
                    }

                }
            }
            return instruccion;
        }

        public void UpdateInstruccion(Model.InstruccionModel instruccion)
        {
            using (var entity = new GestorDocumentEntities())
            {
                CAT_INSTRUCCION result = null;
                try
                {
                    result = (from o in entity.CAT_INSTRUCCION
                              where o.IdInstruccion == instruccion.IdInstruccion
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IdInstruccion = instruccion.IdInstruccion;
                    result.CveInstruccion = instruccion.CveInstruccion;
                    result.InstruccionName = instruccion.InstruccionName;
                    result.LastModifiedDate = new UNID().getNewUNID();
                    result.IsModified = true;

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteInstruccion(IEnumerable<Model.InstruccionModel> instruccions)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.InstruccionModel p in instruccions)
                {
                    CAT_INSTRUCCION result = null;
                    try
                    {
                        result = (from o in entity.CAT_INSTRUCCION
                                  where o.IdInstruccion == p.IdInstruccion
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
