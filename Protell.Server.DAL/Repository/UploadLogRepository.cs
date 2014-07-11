using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;

namespace Protell.Server.DAL.Repository
{
    public class UploadLogRepository : IUploadLog
    {
        public GestorDocument.Model.UploadLogModel InsertUploadLogServer(GestorDocument.Model.UploadLogModel uploadLog)
        {
            throw new NotImplementedException();
        }

        public void InsertUploadLogLocal(GestorDocument.Model.UploadLogModel uploadLog)
        {
            throw new NotImplementedException();
        }

        public string GetSerializeUpLoadLog(GestorDocument.Model.UploadLogModel upLoadLog)
        {
            throw new NotImplementedException();
        }

        GestorDocument.Model.UploadLogModel IUploadLog.GetDeserializeUpLoadLog(string upLoadLog)
        {
            throw new NotImplementedException();
        }
    }
}
