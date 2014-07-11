using System;
using System.Linq;
using SyncService.Server.DAL.POCOS;

namespace SyncService.Server.DAL.Repository
{
    public class BroadcastRepository 
    {
        public string GetModifiedData()
        {
            string res = "";
            try
            {
                using (var entity = new SyncServiceServerEntity())
                {
                    res = entity.SP_TABLE_JSON_MODIFIEDDATA("MODIFIEDDATA").First<string>();
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }

        public string GetTablesUpdate(string tableName, string maxJson)
        {
            JsonRepository json = new JsonRepository();
            string res = "";
            try
            {
                res = json.GetJsonDownload(maxJson, tableName);
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }        
    }
}
