using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model.DashBoardModel;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using GestorDocument.DAL.Repository;

namespace GestorDocument.ViewModel.DashBoard
{
    public class PendientesViewModel:ViewModelBase
    {
        #region Constructor.

        public PendientesViewModel()
        {
            oDashBoardRepository = new DashBoardRepository();            
        }
        #endregion

        #region Instancias
        IDashBoard oDashBoardRepository = null;
        #endregion

        #region Propiedades.

        public PendienteIndicadorModel Pendientes
        {
            get { return _Pendientes; }
            set
            {
                if (_Pendientes != value)
                {
                    _Pendientes = value;
                    OnPropertyChanged(PendientesPropertyName);
                }
            }
        }
        private PendienteIndicadorModel _Pendientes;
        public const string PendientesPropertyName = "Pendientes";

        #endregion

        #region Metodos.
        public PendienteIndicadorModel GetPendientes(ObservableCollection<DeterminanteModel> Determinantes)
        {
            Pendientes = oDashBoardRepository.GetPendientes(Determinantes);
            return Pendientes;
        }
        #endregion
    }
}
