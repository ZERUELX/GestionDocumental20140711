using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SyncService.Server.DAL.Repository;

namespace SyncService.Service.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [DataContractFormat]
    public class Receiver : IReceiver
    {
        

        public string LoadCatGeneric(string listPocos, string dataUser, string tableName)
        {
            ReceiverRepository _IReciverRepository = new ReceiverRepository();
            string ids = "";
            try
            {
                 ids=_IReciverRepository.GetSpUpsertServerRows(listPocos, tableName);
            }
            catch (Exception ex)
            {

                ids = ex.Message;
            }
            return ids;
        }
    }
}
