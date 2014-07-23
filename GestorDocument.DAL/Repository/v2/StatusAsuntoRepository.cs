using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;

namespace GestorDocument.DAL.Repository.v2
{
    public class StatusAsuntoRepository
    {
        public List<StatusAsuntoModel> GetStatusAsuntos()
        {
            List<Model.StatusAsuntoModel> statusasuntos = new List<StatusAsuntoModel>();
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
    }
}
