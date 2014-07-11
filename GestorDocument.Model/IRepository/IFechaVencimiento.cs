using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface IFechaVencimiento
    {
        // Create.
        void InsertFechaVencimiento(FechaVencimientoModel fechavencimiento);

        // Read.
        IEnumerable<FechaVencimientoModel> GetFechaVencimientos();
        FechaVencimientoModel GetFechaVencimientoID(FechaVencimientoModel fechavencimiento);
        FechaVencimientoModel GetFechaVencimientoAdd(FechaVencimientoModel fechavencimiento);
        FechaVencimientoModel GetFechaVencimientoMod(FechaVencimientoModel fechavencimiento);

        // Update.
        void UpdateFechaVencimiento(FechaVencimientoModel fechavencimiento);

        // Delete.
        void DeleteFechaVencimiento(IEnumerable<FechaVencimientoModel> fechavencimientos);
    }
}
