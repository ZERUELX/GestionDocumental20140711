using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;

namespace GestorDocument.DAL.Repository.v2
{
    public class TipoDocumentoRepository
    {
        public List<TipoDocumentoModel> GetTipoDocumentos()
        {
            List<TipoDocumentoModel> tipodocumentos = new List<TipoDocumentoModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_TIPO_DOCUMENTO
                     where o.IsActive == true
                     select o).OrderBy(o => o.TipoDocumentoName).ToList().ForEach(p =>
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
    }
}
