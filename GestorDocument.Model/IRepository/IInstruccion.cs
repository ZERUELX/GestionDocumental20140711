using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface IInstruccion
    {
        // Create.
        void InsertInstruccion(InstruccionModel instruccion);

        // Read.
        IEnumerable<InstruccionModel> GetInstruccions();
        InstruccionModel GetInstruccionID(InstruccionModel instruccion);
        InstruccionModel GetInstruccionAdd(InstruccionModel instruccion);
        InstruccionModel GetInstruccionMod(InstruccionModel instruccion);

        // Update.
        void UpdateInstruccion(InstruccionModel instruccion);

        // Delete.
        void DeleteInstruccion(IEnumerable<InstruccionModel> instruccions);
    }
}
