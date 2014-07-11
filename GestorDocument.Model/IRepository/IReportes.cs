using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace GestorDocument.Model.IRepository
{
    public interface IReportes
    {

        #region Combos.
        IEnumerable<RolModel> GetDestinatarios();
        IEnumerable<DeterminanteModel> GetSignatarios();
        IEnumerable<StatusTurnoModel> GetTurnos();
        IEnumerable<PrioridadModel> GetPrioridad();        
        #endregion
    }
}
