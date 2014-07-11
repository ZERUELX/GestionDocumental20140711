using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using SyncService.Server.DAL.Repository;


namespace SyncService.Service.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [DataContractFormat]
    public class Broadcast : IBroadcast
    {

        public string GetModifiedData()
        {
            string ModifiedData = "";
            BroadcastRepository _BroadCastRepository = new BroadcastRepository();
            try
            {
                ModifiedData=_BroadCastRepository.GetModifiedData();               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return ModifiedData;
        }

        public string GetTablesUpdate(string tableName, string maxJson)
        {
            string res = "";
            BroadcastRepository _BroadCastRepository = new BroadcastRepository();
            try
            {
                res = _BroadCastRepository.GetTablesUpdate(tableName, maxJson);
            }
            catch (Exception ex )
            {
                res = ex.Message;
            }
            return res;
        }
    }
}
