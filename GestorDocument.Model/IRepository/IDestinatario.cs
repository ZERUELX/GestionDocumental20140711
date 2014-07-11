using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface IDestinatario
    {
        // Create.
        void InsertDestinatario(DestinatarioModel destinatario);
        void InsertDestinatario(IEnumerable<DestinatarioModel> destinatarios);

        // Read.
        IEnumerable<DestinatarioModel> GetDestinatarios();
        IEnumerable<DestinatarioModel> GetDestinatarios(long Idturno);
        IEnumerable<DestinatarioModel> GetSeguimientoDestinatarios(long IdAsunto);
        DestinatarioModel GetDestinatarioID(DestinatarioModel destinatario);
        DestinatarioModel GetDestinatarioAdd(DestinatarioModel destinatario);
        DestinatarioModel GetDestinatarioMod(DestinatarioModel destinatario);

        // Update.
        void UpdateDestinatario(DestinatarioModel destinatario);
        void UpdateDestinatario(IEnumerable<DestinatarioModel> destinatarios);

        // Delete.
        void DeleteDestinatario(IEnumerable<DestinatarioModel> destinatarios);
    }
}
