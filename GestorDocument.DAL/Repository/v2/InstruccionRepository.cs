using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model;

namespace GestorDocument.DAL.Repository.v2
{
    public class InstruccionRepository
    {
        public List<InstruccionModel> GetInstruccions()
        {
            List<InstruccionModel> Instruccions = new List<InstruccionModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_INSTRUCCION
                     where o.IsActive == true
                     select o).OrderBy(o => o.InstruccionName).ToList().ForEach(p =>
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
    }
}
