using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface ITipoDeterminante
    {
        // Create.
        void InsertTipoDeterminante(TipoDeterminanteModel tipodeterminante);

        // Read.
        IEnumerable<TipoDeterminanteModel> GetTipoDeterminantes();
        TipoDeterminanteModel GetTipoDeterminanteID(TipoDeterminanteModel tipodeterminante);
        TipoDeterminanteModel GetTipoDeterminanteAdd(TipoDeterminanteModel tipodeterminante);
        TipoDeterminanteModel GetTipoDeterminanteMod(TipoDeterminanteModel tipodeterminante);

        // Update.
        void UpdateTipoDeterminante(TipoDeterminanteModel tipodeterminante);

        // Delete.
        void DeleteTipoDeterminante(IEnumerable<TipoDeterminanteModel> tipodeterminantes);
    }
}
