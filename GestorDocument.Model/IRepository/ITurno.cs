using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface ITurno
    {
        // Create.
        void InsertTurno(TurnoModel turno);
        void InsertTurno(IEnumerable<TurnoModel> turnos);

        // Read.
        IEnumerable<TurnoModel> GetTurnos();
        IEnumerable<TurnoModel> GetTurnosTrancing(TurnoModel turno);
        IEnumerable<TurnoModel> GetTurnosTrancing(long IdAsunto);
        IEnumerable<TurnoModel> GetTurnoSeguimiento(TurnoModel turno);
        IEnumerable<TurnoModel> GetTurnoSeguimiento(long IdAsunto);
        int GetTurnoCloseAsunto(long IdAsunto);
        int GetRespuestaTurnos(long IdAsunto);
        TurnoModel GetTurnoID(TurnoModel turno);
        TurnoModel GetTurnoByID(TurnoModel turno);
        TurnoModel GetTurnoID();
        TurnoModel GetTurnoAdd(TurnoModel turno);
        TurnoModel GetTurnoMod(TurnoModel turno);

        // Update.
        void UpdateTurno(TurnoModel turno);

        // Delete.
        void DeleteTurno(IEnumerable<TurnoModel> turnos);
    }
}
