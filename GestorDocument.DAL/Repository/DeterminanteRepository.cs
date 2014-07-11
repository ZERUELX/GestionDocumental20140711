using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class DeterminanteRepository : IDeterminante, ISync 
    {
        public void InsertDeterminante(Model.DeterminanteModel determinante)
        {
            using (var entity = new GestorDocumentEntities())

                if (determinante != null)
                {
                    //Validar si el elemento ya existe
                    CAT_DETERMINANTE result = null;
                    try
                    {
                        result = (from o in entity.CAT_DETERMINANTE
                                  where o.IdDeterminante == determinante.IdDeterminante
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.CAT_DETERMINANTE.AddObject(
                            new CAT_DETERMINANTE()
                            {
                                IdDeterminante = determinante.IdDeterminante,
                                CveDeterminante = determinante.CveDeterminante,
                                Area = determinante.Area,
                                PrefijoFolio = determinante.PrefijoFolio,
                                DeterminanteName = determinante.DeterminanteName.Trim(),
                                IsActive = determinante.IsActive,
                                LastModifiedDate = new UNID().getNewUNID(),
                                IdTipoDeterminante = determinante.TipoDeterminante.IdTipoDeterminante
                            }
                        );

                        entity.SaveChanges();
                    }

                }
        }
        /// <summary>
        /// Obtiene los Determinantes(Signatarios)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.DeterminanteModel> GetDeterminantes()
        {
            ObservableCollection<Model.DeterminanteModel> Determinantes = new ObservableCollection<Model.DeterminanteModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_DETERMINANTE
                     where o.IsActive == true
                     select o).OrderBy(o => o.DeterminanteName).ToList().ForEach(p =>
                     {
                         Determinantes.Add(new Model.DeterminanteModel()
                         {
                             IdDeterminante = p.IdDeterminante,
                             CveDeterminante = p.CveDeterminante,
                             Area = p.Area,
                             PrefijoFolio = p.PrefijoFolio,
                             DeterminanteName = p.DeterminanteName,
                             IsActive = p.IsActive,
                             LastModifiedDate = p.LastModifiedDate,
                             IsModified = p.IsModified,
                             IdTipoDeterminante = p.IdTipoDeterminante,
                             TipoDeterminante = new Model.TipoDeterminanteModel()
                             {
                                 TipoDeterminanteName = p.CAT_TIPO_DETERMINANTE.TipoDeterminanteName,
                                 IdTipoDeterminante = p.CAT_TIPO_DETERMINANTE.IdTipoDeterminante
                             }
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return Determinantes;
        }

        public IEnumerable<Model.DeterminanteModel> GetDeterminantes(long IdAsunto)
        {
            ObservableCollection<Model.DeterminanteModel> Determinantes = new ObservableCollection<Model.DeterminanteModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from a in entity.GET_ASUNTO
                     join r in entity.REL_SIGNATARIO
                     on a.IdAsunto equals r.IdAsunto
                     join o in entity.CAT_DETERMINANTE
                     on r.IdDeterminante equals o.IdDeterminante
                     where o.IsActive == true && a.IdAsunto ==IdAsunto
                     select o).ToList().ForEach(p =>
                     {
                         Determinantes.Add(new Model.DeterminanteModel()
                         {
                             IdDeterminante = p.IdDeterminante,
                             CveDeterminante = p.CveDeterminante,
                             Area = p.Area,
                             PrefijoFolio = p.PrefijoFolio,
                             DeterminanteName = p.DeterminanteName,
                             IsActive = p.IsActive,
                             LastModifiedDate = p.LastModifiedDate,
                             IsModified = p.IsModified,
                             IdTipoDeterminante = p.IdTipoDeterminante,
                             TipoDeterminante = new Model.TipoDeterminanteModel()
                             {
                                 TipoDeterminanteName = p.CAT_TIPO_DETERMINANTE.TipoDeterminanteName,
                                 IdTipoDeterminante = p.CAT_TIPO_DETERMINANTE.IdTipoDeterminante
                             }
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return Determinantes;
        }

        public Model.DeterminanteModel GetDeterminanteID(Model.DeterminanteModel determinante)
        {
            throw new NotImplementedException();
        }

        public Model.DeterminanteModel GetDeterminanteAdd(Model.DeterminanteModel determinante)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (determinante != null)
                {
                    //Validar si el elemento ya existe
                    CAT_DETERMINANTE result = null;
                    try
                    {
                        result = (from o in entity.CAT_DETERMINANTE
                                  where
                                  o.IdDeterminante == determinante.IdDeterminante && o.IsActive == true ||
                                  o.DeterminanteName == determinante.DeterminanteName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        determinante = null;
                    }

                }
            }
            return determinante;
        }

        public Model.DeterminanteModel GetDeterminanteMod(Model.DeterminanteModel determinante)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (determinante != null)
                {
                    //Validar si el elemento ya existe
                    CAT_DETERMINANTE result = null;
                    try
                    {
                        result = (from o in entity.CAT_DETERMINANTE
                                  where
                                  o.DeterminanteName == determinante.DeterminanteName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        determinante = null;
                    }

                }
            }
            return determinante;
        }

        public void UpdateDeterminante(Model.DeterminanteModel determinante)
        {
            using (var entity = new GestorDocumentEntities())
            {
                CAT_DETERMINANTE result = null;
                try
                {
                    result = (from o in entity.CAT_DETERMINANTE
                              where o.IdDeterminante == determinante.IdDeterminante
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.IdDeterminante = determinante.IdDeterminante;
                    result.CveDeterminante = determinante.CveDeterminante;
                    result.Area = determinante.Area;
                    result.PrefijoFolio = determinante.PrefijoFolio;
                    result.DeterminanteName = determinante.DeterminanteName;
                    result.LastModifiedDate = new UNID().getNewUNID();
                    result.IsModified = true;
                    result.IdTipoDeterminante = determinante.TipoDeterminante.IdTipoDeterminante;

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteDeterminante(IEnumerable<Model.DeterminanteModel> determinantes)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.DeterminanteModel p in determinantes)
                {
                    CAT_DETERMINANTE result = null;
                    try
                    {
                        result = (from o in entity.CAT_DETERMINANTE
                                  where o.IdDeterminante == p.IdDeterminante
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
