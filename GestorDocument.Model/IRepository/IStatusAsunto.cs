using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface IStatusAsunto
    {
        // Create.
        void InsertStatusAsunto(StatusAsuntoModel statusasunto);

        // Read.
        IEnumerable<StatusAsuntoModel> GetStatusAsuntos();
        StatusAsuntoModel GetStatusAsuntoID(StatusAsuntoModel statusasunto);
        StatusAsuntoModel GetStatusAsuntoAdd(StatusAsuntoModel statusasunto);
        StatusAsuntoModel GetStatusAsuntoMod(StatusAsuntoModel statusasunto);

        // Update.
        void UpdateStatusAsunto(StatusAsuntoModel statusasunto);

        // Delete.
        void DeleteStatusAsunto(IEnumerable<StatusAsuntoModel> statusasuntos);
    }
}
