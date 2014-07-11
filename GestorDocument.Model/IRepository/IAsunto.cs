using System;
using System.Collections.Generic;

namespace GestorDocument.Model.IRepository
{
    public interface IAsunto
    {
        // Create.
        void InsertAsunto(AsuntoModel asunto);

        // Read.
        IEnumerable<AsuntoModel> GetBusqueda(string prioridad, string statusAsunto, string destinatario, string signatario, DateTime? rangofechadesde, DateTime? rangofechahasta, string referenciadocumento, string tituloAsunto, string descripcionAsunto, string nombreDocumento, RolModel rol);
        IEnumerable<AsuntoModel> GetBusquedaAsunto(string tituloAsunto, string folioAsunto,string descripcionAsunto, RolModel rol);
        IEnumerable<AsuntoModel> GetAsuntos();
        IEnumerable<AsuntoModel> GetAsuntos(RolModel rol);
        AsuntoModel GetAsuntoID(AsuntoModel asunto);
        AsuntoModel GetAsuntoAdd(AsuntoModel asunto);
        AsuntoModel GetAsuntoMod(AsuntoModel asunto);

        // Update.
        void UpdateAsunto(AsuntoModel asunto);

        // Update Cerrar Asunto.
        void UpdateCloseAsunto(AsuntoModel asunto);

        // Update Borrador Asunto.
        void UpdateBorradorAsunto(AsuntoModel asunto);

        // Delete.
        void DeleteAsunto(IEnumerable<AsuntoModel> asuntos);
    }
}
