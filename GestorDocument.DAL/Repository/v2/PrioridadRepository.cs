using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;

namespace GestorDocument.DAL.Repository.v2
{
    public class PrioridadRepository
    {
        public List<PrioridadModel> GetPrioridads()
        {
            List<PrioridadModel> prioridads = new List<PrioridadModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_PRIORIDAD
                     where o.IsActive == true
                     select o).OrderBy(o => o.PrioridadName).ToList().ForEach(p =>
                     {
                         prioridads.Add(new Model.PrioridadModel()
                         {
                             IdPrioridad = p.IdPrioridad,
                             PrioridadName = p.PrioridadName,
                             PathImagen = p.PathImagen,
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
            return prioridads;
        }
    }
}
