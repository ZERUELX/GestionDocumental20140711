using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class TipoDeterminanteRepository : ITipoDeterminante
    {
        public void InsertTipoDeterminante(Model.TipoDeterminanteModel tipodeterminante)
        {
            using (var entity = new GestorDocumentEntities())
          
                if (tipodeterminante != null)
                {
                    //Validar si el elemento ya existe
                    CAT_TIPO_DETERMINANTE result = null;
                    try
                    {
                        result = (from o in entity.CAT_TIPO_DETERMINANTE
                                  where o.IdTipoDeterminante == tipodeterminante.IdTipoDeterminante
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.CAT_TIPO_DETERMINANTE.AddObject(
                            new CAT_TIPO_DETERMINANTE()
                            {
                                IdTipoDeterminante = tipodeterminante.IdTipoDeterminante,
                                TipoDeterminanteName = tipodeterminante.TipoDeterminanteName.Trim(),
                                IsActive = true,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );

                        entity.SaveChanges();
                    }

                }
            }

        public IEnumerable<Model.TipoDeterminanteModel> GetTipoDeterminantes()
        {
            ObservableCollection<Model.TipoDeterminanteModel> tipodeterminantes = new ObservableCollection<Model.TipoDeterminanteModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_TIPO_DETERMINANTE
                     where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         tipodeterminantes.Add(new Model.TipoDeterminanteModel()
                         {
                             IdTipoDeterminante = p.IdTipoDeterminante,
                             TipoDeterminanteName = p.TipoDeterminanteName,
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
            return tipodeterminantes;
        }
        
        public Model.TipoDeterminanteModel GetTipoDeterminanteID(Model.TipoDeterminanteModel tipodeterminante)
        {
            throw new NotImplementedException();
        }

        public Model.TipoDeterminanteModel GetTipoDeterminanteAdd(Model.TipoDeterminanteModel tipodeterminante)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (tipodeterminante != null)
                {
                    //Validar si el elemento ya existe
                    CAT_TIPO_DETERMINANTE result = null;
                    try
                    {
                        result = (from o in entity.CAT_TIPO_DETERMINANTE
                                  where
                                  o.IdTipoDeterminante == tipodeterminante.IdTipoDeterminante && o.IsActive == true ||
                                  o.TipoDeterminanteName == tipodeterminante.TipoDeterminanteName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        tipodeterminante = null;
                    }

                }
            }
            return tipodeterminante;
        }

        public Model.TipoDeterminanteModel GetTipoDeterminanteMod(Model.TipoDeterminanteModel tipodeterminante)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (tipodeterminante != null)
                {
                    //Validar si el elemento ya existe
                    CAT_TIPO_DETERMINANTE result = null;
                    try
                    {
                        result = (from o in entity.CAT_TIPO_DETERMINANTE
                                  where
                                  o.TipoDeterminanteName == tipodeterminante.TipoDeterminanteName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        tipodeterminante = null;
                    }

                }
            }
            return tipodeterminante;
        }

        public void UpdateTipoDeterminante(Model.TipoDeterminanteModel tipodeterminante)
        {
            using (var entity = new GestorDocumentEntities())
            {
                CAT_TIPO_DETERMINANTE result = null;
                try
                {
                    result = (from o in entity.CAT_TIPO_DETERMINANTE
                              where o.IdTipoDeterminante == tipodeterminante.IdTipoDeterminante
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.TipoDeterminanteName = tipodeterminante.TipoDeterminanteName;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteTipoDeterminante(IEnumerable<Model.TipoDeterminanteModel> tipodeterminantes)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.TipoDeterminanteModel p in tipodeterminantes)
                {
                    CAT_TIPO_DETERMINANTE result = null;
                    try
                    {
                        result = (from o in entity.CAT_TIPO_DETERMINANTE
                                  where o.IdTipoDeterminante == p.IdTipoDeterminante
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
