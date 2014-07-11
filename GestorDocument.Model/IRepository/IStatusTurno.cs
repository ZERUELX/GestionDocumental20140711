using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface IStatusTurno
    {
        // Create.
        void InsertStatusTurno(StatusTurnoModel statusturno);

        // Read.
        IEnumerable<StatusTurnoModel> GetStatusTurnos();
        StatusTurnoModel GetStatusTurnoID(StatusTurnoModel statusturno);
        StatusTurnoModel GetStatusTurnoAdd(StatusTurnoModel statusturno);
        StatusTurnoModel GetStatusTurnoMod(StatusTurnoModel statusturno);

        // Update.
        void UpdateStatusTurno(StatusTurnoModel statusturno);

        // Delete.
        void DeleteStatusTurno(IEnumerable<StatusTurnoModel> statusturnos);
    }
}
