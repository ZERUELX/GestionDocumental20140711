using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model.DashBoardModel;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using GestorDocument.DAL.Repository;

namespace GestorDocument.ViewModel.DashBoard
{
    public class AtendidosViewModel:ViewModelBase
    {
        #region Instancias
        IDashBoard oDashBoardRepository = null;
        #endregion
        #region Constructor
        public AtendidosViewModel()
        {
            oDashBoardRepository = new DashBoardRepository();            
        }
        #endregion

        #region Propiedades.
        public AtendidoIndicadorModel Atendidos
        {
            get { return _Atendidos; }
            set
            {
                if (_Atendidos != value)
                {
                    _Atendidos = value;
                    OnPropertyChanged(AtendidosPropertyName);
                }
            }
        }
        private AtendidoIndicadorModel _Atendidos;
        public const string AtendidosPropertyName = "Atendidos"; 
        #endregion

        #region Metodos.

        public AtendidoIndicadorModel GetAtendidos(ObservableCollection<DeterminanteModel> Determinante)
        {
            Atendidos = oDashBoardRepository.GetAtendidos(Determinante);
            return Atendidos;
        }
        #endregion


    }
}
