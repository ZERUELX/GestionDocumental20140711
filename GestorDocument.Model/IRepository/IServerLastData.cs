using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface IServerLastData
    {
        void UpdateServerLastDataServer();
        void UpdateServerLastDataLocal(long serverFecha);
        long GetServerLastFechaServer();
        long GetServerLastFechaLocal();
        Dictionary<string, string> GetResponseDictionary(string response);
        long GetDeserializeServerLast(string response);
    }
}
