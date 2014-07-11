using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface IDestinatarioCcp
    {
        // Create.
        void InsertDestinatarioCcp(DestinatarioCcpModel destinatarioCcp);
        void InsertDestinatarioCcp(IEnumerable<DestinatarioCcpModel> destinatariosCcp);

        // Read.
        IEnumerable<DestinatarioCcpModel> GetDestinatariosCcp();
        IEnumerable<DestinatarioCcpModel> GetDestinatariosCcp(long IdAsunto);
        DestinatarioCcpModel GetDestinatarioCcpID(DestinatarioCcpModel destinatarioCcp);
        DestinatarioCcpModel GetDestinatarioCcpAdd(DestinatarioCcpModel destinatarioCcp);
        DestinatarioCcpModel GetDestinatarioCcpMod(DestinatarioCcpModel destinatarioCcp);

        // Update.
        void UpdateDestinatarioCcp(DestinatarioCcpModel destinatarioCcp);
        void UpdateDestinatarioCcp(IEnumerable<DestinatarioCcpModel> destinatariosCcp);

        // Delete.
        void DeleteDestinatarioCcp(IEnumerable<DestinatarioCcpModel> destinatariosCcp);
    }
}
