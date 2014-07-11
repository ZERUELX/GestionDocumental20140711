using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.DAL;

namespace GestorDocument.DAL.Repository.v2
{
    public class TableroRepository:IDisposable
    {
        /// <summary>
        /// Ejecuta el spGetTablero para obtener la informacion del tablero principal.
        /// </summary>
        /// <param name="IdRol"></param>
        /// <returns></returns>
        public List<TableroModel> GetTablero(long IdRol)
        {
            List<TableroModel> items = new List<TableroModel>();
            try
            {
                using (var entity=new  GestorDocumentEntities())
                {
                    entity.spGetTablero(IdRol).ToList().ForEach(row =>
                    {
                        items.Add(new TableroModel()
                        {
                            IdTablero = row.IdTablero,
                            Categoria = row.CATEGORIA,
                            Total = (int)row.TOTAL
                        });
                    });
                }
            }
            catch (Exception)
            {                                
            }
            return items;
        }

        public void Dispose()
        {
            return;
        }
    }
}
