using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface IDeterminante
    {
        // Create.
        void InsertDeterminante(DeterminanteModel determinante);

        // Read.
        IEnumerable<DeterminanteModel> GetDeterminantes();
        IEnumerable<DeterminanteModel> GetDeterminantes(long IdAsunto);
        DeterminanteModel GetDeterminanteID(DeterminanteModel determinante);
        DeterminanteModel GetDeterminanteAdd(DeterminanteModel determinante);
        DeterminanteModel GetDeterminanteMod(DeterminanteModel determinante);

        // Update.
        void UpdateDeterminante(DeterminanteModel determinante);

        // Delete.
        void DeleteDeterminante(IEnumerable<DeterminanteModel> determinantes);
    }
}
