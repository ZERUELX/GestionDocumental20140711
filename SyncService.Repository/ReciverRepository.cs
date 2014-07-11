using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SyncService.Dal.Pocos;
using RestSharp;
using System.Configuration;

namespace SyncService.Repository
{
    public class ReciverRepository
    {         
        #region Local
        public List<string> GetIsModified()
        {
            
                List<string> lst = null;
                using (var entity = new SyncServiceEntity())
                {
                    lst = new List<string>();
                    (from md in entity.MODIFIEDDATAs
                     join s in entity.SYNCTABLEs on md.IdSincTable equals s.IdSincTable
                     where md.IsModified == true
                     orderby s.OrderTable ascending
                     select new { s.SincTableName }).ToList().ForEach(row =>
                                      lst.Add(row.SincTableName)
                                      );

                    if (lst.Count > 0)
                    {
                        return lst;
                    }
                    else
                    {
                        return null;
                    }

                }

        }

        public string GetJsonTable(string tableName)
        {

            using (var entity = new SyncServiceEntity())
                {
                    string json = entity.SP_TABLE_JSON(tableName).First<string>();
                    return json;
                }
            
        }

        public bool _SpConfirmSincRows(string json, string tableName)
        {
            bool x = false;

            using (var entity = new SyncServiceEntity())
                {
                    entity.SpConfirmSincRows(json, tableName);
                    return x = true;
                }
            
        } 
        #endregion
    }
}
