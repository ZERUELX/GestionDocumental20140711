using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class TipoDocumentoRepository : ITipoDocumento
    {
        public void InsertTipoDocumento(Model.TipoDocumentoModel tipodocumento)
        {
            using (var entity = new GestorDocumentEntities())

                if (tipodocumento != null)
                {
                    //Validar si el elemento ya existe
                    CAT_TIPO_DOCUMENTO result = null;
                    try
                    {
                        result = (from o in entity.CAT_TIPO_DOCUMENTO
                                  where o.IdTipoDocumento == tipodocumento.IdTipoDocumento
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        entity.CAT_TIPO_DOCUMENTO.AddObject(
                            new CAT_TIPO_DOCUMENTO()
                            {
                                IdTipoDocumento = tipodocumento.IdTipoDocumento,
                                TipoDocumentoName = tipodocumento.TipoDocumentoName.Trim(),
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
        /// Collecion de datos de tipo TipoDocumentoModel() existentes en la BD.
        /// </summary>
        /// <returns>IEnumerable<Model.TipoDocumentoModel> </returns>
        public IEnumerable<Model.TipoDocumentoModel> GetTipoDocumentos()
        {
            ObservableCollection<Model.TipoDocumentoModel> tipodocumentos = new ObservableCollection<Model.TipoDocumentoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_TIPO_DOCUMENTO
                     where o.IsActive == true
                     select o).OrderBy(o=> o.TipoDocumentoName).ToList().ForEach(p =>
                     {
                         tipodocumentos.Add(new Model.TipoDocumentoModel()
                         {
                             IdTipoDocumento = p.IdTipoDocumento,
                             TipoDocumentoName = p.TipoDocumentoName,
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
            return tipodocumentos;
        }

        public Model.TipoDocumentoModel GetTipoDocumentoID(Model.TipoDocumentoModel tipodocumento)
        {
            throw new NotImplementedException();
        }

        public Model.TipoDocumentoModel GetTipoDocumentoAdd(Model.TipoDocumentoModel tipodocumento)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (tipodocumento != null)
                {
                    //Validar si el elemento ya existe
                    CAT_TIPO_DOCUMENTO result = null;
                    try
                    {
                        result = (from o in entity.CAT_TIPO_DOCUMENTO
                                  where
                                  o.IdTipoDocumento == tipodocumento.IdTipoDocumento && o.IsActive == true ||
                                  o.TipoDocumentoName == tipodocumento.TipoDocumentoName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        tipodocumento = null;
                    }

                }
            }
            return tipodocumento;
        }

        public Model.TipoDocumentoModel GetTipoDocumentoMod(Model.TipoDocumentoModel tipodocumento)
        {
            using (var entity = new GestorDocumentEntities())
            {
                if (tipodocumento != null)
                {
                    //Validar si el elemento ya existe
                    CAT_TIPO_DOCUMENTO result = null;
                    try
                    {
                        result = (from o in entity.CAT_TIPO_DOCUMENTO
                                  where
                                  o.TipoDocumentoName == tipodocumento.TipoDocumentoName && o.IsActive == true
                                  select o).First();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }


                    if (result == null)
                    {
                        tipodocumento = null;
                    }

                }
            }
            return tipodocumento;
        }

        public void UpdateTipoDocumento(Model.TipoDocumentoModel tipodocumento)
        {
            using (var entity = new GestorDocumentEntities())
            {
                CAT_TIPO_DOCUMENTO result = null;
                try
                {
                    result = (from o in entity.CAT_TIPO_DOCUMENTO
                              where o.IdTipoDocumento == tipodocumento.IdTipoDocumento
                              select o).First();
                }
                catch (Exception ex)
                {
                    ;
                }

                if (result != null)
                {
                    result.TipoDocumentoName = tipodocumento.TipoDocumentoName;
                    result.IsModified = true;
                    result.LastModifiedDate = new UNID().getNewUNID();

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteTipoDocumento(IEnumerable<Model.TipoDocumentoModel> tipodocumentos)
        {
            using (var entity = new GestorDocumentEntities())
            {
                foreach (Model.TipoDocumentoModel p in tipodocumentos)
                {
                    CAT_TIPO_DOCUMENTO result = null;
                    try
                    {
                        result = (from o in entity.CAT_TIPO_DOCUMENTO
                                  where o.IdTipoDocumento == p.IdTipoDocumento
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
