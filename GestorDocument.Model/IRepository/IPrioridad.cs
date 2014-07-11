using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface IPrioridad
    {
        // Create.
        void InsertPrioridad(PrioridadModel prioridad);

        // Read.
        IEnumerable<PrioridadModel> GetPrioridads();
        PrioridadModel GetPrioridadID(PrioridadModel prioridad);
        PrioridadModel GetPrioridadAdd(PrioridadModel prioridad);
        PrioridadModel GetPrioridadMod(PrioridadModel prioridad);

        // Update.
        void UpdatePrioridad(PrioridadModel prioridad);

        // Delete.
        void DeletePrioridad(IEnumerable<PrioridadModel> prioridads);
    }
}
