using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class SignatarioRepository : ISignatario, ISync
    {
        public void InsertSignatario(IEnumerable<Model.SignatarioModel> signatarios)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.SignatarioModel p in signatarios)
                {
                    REL_SIGNATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO
                                    where o.IdSignatario == p.IdSignatario
                                    select o).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }

                    if (result == null)
                    {
                        entity.REL_SIGNATARIO.AddObject(
                            new REL_SIGNATARIO()
                            {
                                IdSignatario = p.IdSignatario,
                                IdAsunto = p.IdAsunto,
                                IdDeterminante = p.IdDeterminante,
                                Fecha = p.Fecha,
                                IsActive = true,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );
                    }
                }
                entity.SaveChanges();
                UpdateSyncLocal("REL_SIGNATARIO", entity);
             }
        }

        public IEnumerable<Model.SignatarioModel> GetSignatarios()
        {
            ObservableCollection<Model.SignatarioModel> signatarios = new ObservableCollection<Model.SignatarioModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.REL_SIGNATARIO
                     where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         signatarios.Add(new Model.SignatarioModel()
                         {
                             IdSignatario = p.IdSignatario,
                             IdAsunto = (long)p.IdAsunto,
                             Asunto = new Model.AsuntoModel()
                             {
                                 Titulo = p.GET_ASUNTO.Titulo
                             },
                             IdDeterminante = (long) p.IdDeterminante,
                             Determinante = new Model.DeterminanteModel()
                             {
                                 DeterminanteName = p.CAT_DETERMINANTE.DeterminanteName
                             },
                             Fecha = p.Fecha,
                             IsActive = p.IsActive,
                             IsModified = p.IsModified,
                             LastModifiedDate = p.LastModifiedDate
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return signatarios;
        }

        public IEnumerable<Model.SignatarioModel> GetSignatarios(long IdAsunto)
        {
            ObservableCollection<Model.SignatarioModel> signatarios = new ObservableCollection<Model.SignatarioModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.REL_SIGNATARIO
                     where o.IsActive == true && o.IdAsunto ==IdAsunto
                     select o).ToList().ForEach(p =>
                     {
                         signatarios.Add(new Model.SignatarioModel()
                         {
                             IdSignatario = p.IdSignatario,
                             IdAsunto = p.IdAsunto,
                             Asunto = new Model.AsuntoModel()
                             {
                                 IdAsunto = p.IdAsunto,
                                 Titulo = p.GET_ASUNTO.Titulo
                             },
                             IdDeterminante = p.IdDeterminante,
                             Determinante = new Model.DeterminanteModel()
                             {
                                 IdDeterminante = p.CAT_DETERMINANTE.IdDeterminante,
                                 DeterminanteName = p.CAT_DETERMINANTE.DeterminanteName,
                                 CveDeterminante = p.CAT_DETERMINANTE.CveDeterminante,
                                 Area = p.CAT_DETERMINANTE.Area,
                                 PrefijoFolio = p.CAT_DETERMINANTE.PrefijoFolio,
                                 TipoDeterminante = new Model.TipoDeterminanteModel() 
                                 {
                                     TipoDeterminanteName = p.CAT_DETERMINANTE.CAT_TIPO_DETERMINANTE.TipoDeterminanteName
                                 }
                             },
                             Fecha = p.Fecha,
                             IsActive = p.IsActive,
                             IsModified = p.IsModified,
                             LastModifiedDate = p.LastModifiedDate,
                             ServerLastModifiedDate = p.ServerLastModifiedDate
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return signatarios;
        }

        public Model.SignatarioModel GetSignatarioID(Model.SignatarioModel signatario)
        {
            throw new NotImplementedException();
        }

        public Model.SignatarioModel GetSignatarioAdd(Model.SignatarioModel signatario)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (signatario != null)
                {
                    //Validar si el elemento ya existe
                    REL_SIGNATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO
                                  where
                                  o.IdSignatario == signatario.IdSignatario && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        signatario = null;
                    }

                }
            }
            return signatario;
        }

        public Model.SignatarioModel GetSignatarioMod(Model.SignatarioModel signatario)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (signatario != null)
                {
                    //Validar si el elemento ya existe
                    REL_SIGNATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO
                                  where
                                  o.IdSignatario == signatario.IdSignatario && 
                                  o.IsActive == true && 
                                  o.IdDeterminante == signatario.IdDeterminante
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        signatario = null;
                    }

                }
            }
            return signatario;
        }

        public void UpdateSignatario(IEnumerable<Model.SignatarioModel> signatarios)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.SignatarioModel p in signatarios)
                {
                    REL_SIGNATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO
                                  where o.IdSignatario == p.IdSignatario
                                  select o).First();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    if (result != null)
                    {
                        entity.REL_SIGNATARIO.AddObject(
                            new REL_SIGNATARIO()
                            {
                                IdSignatario = p.IdSignatario,
                                IdAsunto = p.Asunto.IdAsunto,
                                IdDeterminante = p.Determinante.IdDeterminante,
                                Fecha = p.Fecha,
                                IsActive = true,
                                IsModified = true,
                                LastModifiedDate = new UNID().getNewUNID()
                            }
                        );
                    }
                }
                entity.SaveChanges();
                UpdateSyncLocal("REL_SIGNATARIO", entity);
            }
        }

        public void DeleteSignatario(IEnumerable<Model.SignatarioModel> signatarios)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.SignatarioModel p in signatarios)
                {
                    REL_SIGNATARIO result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO
                                  where o.IdSignatario == p.IdSignatario
                                  select o).First();
                    }
                    catch (Exception)
                    {
                    }

                    if (result != null)
                    {
                        result.IsActive = false;
                        result.IsModified = true;
                        result.LastModifiedDate = new UNID().getNewUNID();
                    }
                }
                entity.SaveChanges();
                UpdateSyncLocal("REL_SIGNATARIO", entity);
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
