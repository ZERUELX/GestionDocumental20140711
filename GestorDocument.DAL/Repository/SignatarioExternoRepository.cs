using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class SignatarioExternoRepository : ISignatarioExterno, ISync
    {
        public void InsertSignatarioExterno(IEnumerable<Model.SignatarioExternoModel> signatariosExternos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.SignatarioExternoModel p in signatariosExternos)
                {
                    REL_SIGNATARIO_EXTERNO result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO_EXTERNO
                                  where o.IdSignatarioExterno == p.IdSignatarioExterno
                                  select o).First();
                    }
                    catch (Exception)
                    {
                        ;
                    }

                    if (result == null)
                    {
                        entity.REL_SIGNATARIO_EXTERNO.AddObject(
                            new REL_SIGNATARIO_EXTERNO()
                            {
                                IdSignatarioExterno = p.IdSignatarioExterno,
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
                UpdateSyncLocal("REL_SIGNATARIO_EXTERNO", entity);
            }
        }

        public IEnumerable<Model.SignatarioExternoModel> GetSignatariosExterno()
        {
            ObservableCollection<Model.SignatarioExternoModel> signatariosExternos = new ObservableCollection<Model.SignatarioExternoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.REL_SIGNATARIO_EXTERNO
                     where o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         signatariosExternos.Add(new Model.SignatarioExternoModel()
                         {
                             IdSignatarioExterno = p.IdSignatarioExterno,
                             IdAsunto = p.IdAsunto,
                             Asunto = new Model.AsuntoModel()
                             {
                                 Titulo = p.GET_ASUNTO.Titulo
                             },
                             IdDeterminante = p.IdDeterminante,
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
            return signatariosExternos;
        }

        public IEnumerable<Model.SignatarioExternoModel> GetSignatariosExterno(long IdAsunto)
        {
            ObservableCollection<Model.SignatarioExternoModel> signatariosExternos = new ObservableCollection<Model.SignatarioExternoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.REL_SIGNATARIO_EXTERNO
                     where o.IsActive == true && o.IdAsunto == IdAsunto
                     select o).ToList().ForEach(p =>
                     {
                         signatariosExternos.Add(new Model.SignatarioExternoModel()
                         {
                             IdSignatarioExterno = p.IdSignatarioExterno,
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
            return signatariosExternos;
        }

        public Model.SignatarioExternoModel GetSignatarioExternoID(Model.SignatarioExternoModel signatariosExterno)
        {
            throw new NotImplementedException();
        }

        public Model.SignatarioExternoModel GetSignatarioExternoAdd(Model.SignatarioExternoModel signatariosExterno)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (signatariosExterno != null)
                {
                    //Validar si el elemento ya existe
                    REL_SIGNATARIO_EXTERNO    result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO_EXTERNO
                                  where
                                  o.IdSignatarioExterno == signatariosExterno.IdSignatarioExterno && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        signatariosExterno = null;
                    }

                }
            }
            return signatariosExterno;
        }

        public Model.SignatarioExternoModel GetSignatarioExternoMod(Model.SignatarioExternoModel signatariosExterno)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (signatariosExterno != null)
                {
                    //Validar si el elemento ya existe
                    REL_SIGNATARIO_EXTERNO result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO_EXTERNO
                                  where
                                  o.IdSignatarioExterno == signatariosExterno.IdSignatarioExterno &&
                                  o.IsActive == true &&
                                  o.IdDeterminante == signatariosExterno.IdDeterminante
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        signatariosExterno = null;
                    }

                }
            }
            return signatariosExterno;
        }

        public void UpdateSignatarioExterno(IEnumerable<Model.SignatarioExternoModel> signatariosExternos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.SignatarioExternoModel p in signatariosExternos)
                {
                    REL_SIGNATARIO_EXTERNO result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO_EXTERNO
                                  where o.IdSignatarioExterno == p.IdSignatarioExterno
                                  select o).First();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    if (result != null)
                    {
                        entity.REL_SIGNATARIO_EXTERNO.AddObject(
                            new REL_SIGNATARIO_EXTERNO()
                            {
                                IdSignatarioExterno = p.IdSignatarioExterno,
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
                UpdateSyncLocal("REL_SIGNATARIO_EXTERNO", entity);
            }
        }

        public void DeleteSignatarioExterno(IEnumerable<Model.SignatarioExternoModel> signatariosExternos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.SignatarioExternoModel p in signatariosExternos)
                {
                    REL_SIGNATARIO_EXTERNO result = null;
                    try
                    {
                        result = (from o in entity.REL_SIGNATARIO_EXTERNO
                                  where o.IdSignatarioExterno == p.IdSignatarioExterno
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
                UpdateSyncLocal("REL_SIGNATARIO_EXTERNO", entity);
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
