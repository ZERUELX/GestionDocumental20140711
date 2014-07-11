using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface IExpediente
    {
        // Create.
        void InsertExpediente(ExpedienteModel expediente);

        // Read.
        IEnumerable<ExpedienteModel> GetExpedientes();
        IEnumerable<ExpedienteModel> GetExpediente(long IdExpediente);
        ExpedienteModel GetExpedienteID(ExpedienteModel expediente);
        ExpedienteModel GetExpedienteAdd(ExpedienteModel expediente);
        ExpedienteModel GetExpedienteMod(ExpedienteModel expediente);

        // Update.
        void UpdateExpediente(ExpedienteModel expediente);

        // Delete.
        void DeleteExpediente(IEnumerable<ExpedienteModel> expediente);
    }
}
