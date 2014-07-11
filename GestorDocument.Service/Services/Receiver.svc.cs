using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using Protell.Server.DAL;

namespace GestorDocument.Service.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [DataContractFormat]
    public class Receiver : IReceiver
    {

        public string LoadCatGeneric(string listPocos, string dataUser, string tableName)
        {
            #region propiedades genericas
            //IUploadLog _UploadLogRepository = new UploadLogRepository();
            //IListUnids _ListUnids = new ListUnidsRepository();
            //IServerLastData _ServerLastDataRepository = new ServerLastDataRepository();
            //IEvidenceSync _EvidenceSyncRepository = new EvidenceSyncRepository();
            //string res = null;
            //List<ListUnidsModel> evListIds = null;
            //UploadLogModel evDataUser = null;
            //Model.UploadLogModel user = null;
            #endregion
            //implementar la logica
            throw new NotImplementedException();
        }        
    }
}
