using System;
using System.Linq;
using SyncService.Server.DAL.POCOS;

namespace SyncService.Server.DAL.Repository
{
    public class ReceiverRepository
    {       
        public string GetSpUpsertServerRows(string json, string tableName)
        {
            try
            {
                using (var entity = new SyncServiceServerEntity())
                {
                    string ids = entity.SpUpsertServerRows(json, tableName).First<string>();
                    return ids;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        
    }
}
