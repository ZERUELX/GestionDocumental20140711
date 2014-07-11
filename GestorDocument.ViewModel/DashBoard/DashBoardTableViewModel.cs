using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using GestorDocument.DAL.Repository;
using System.Collections.ObjectModel;
using GestorDocument.Model.DashBoardModel;
using System.Text;

namespace GestorDocument.ViewModel.DashBoard
{
    public class DashBoardTableViewModel:ViewModelBase
    {
        #region Instancias.
        IDashBoard oDashBoardRepository;
        #endregion

        #region Propiedades.
        public ObservableCollection<DashBoardTableModel> DashBoardTable
        {
            get { return _DashBoardTable; }
            set
            {
                if (_DashBoardTable != value)
                {
                    _DashBoardTable = value;
                    OnPropertyChanged(DashBoardTablePropertyName);
                }
            }
        }
        private ObservableCollection<DashBoardTableModel> _DashBoardTable;
        public const string DashBoardTablePropertyName = "DashBoardTable";

        public ObservableCollection<DashBoardTableModel> DashBoardTableDetalle
        {
            get { return _DashBoardTableDetalle; }
            set
            {
                if (_DashBoardTableDetalle != value)
                {
                    _DashBoardTableDetalle = value;
                    OnPropertyChanged(DashBoardTableDetallePropertyName);
                }
            }
        }
        private ObservableCollection<DashBoardTableModel> _DashBoardTableDetalle;
        public const string DashBoardTableDetallePropertyName = "DashBoardTableDetalle";

        public DashBoardTableModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    OnPropertyChanged(SelectedItemPropertyName);
                }
            }
        }
        private DashBoardTableModel _SelectedItem;
        public const string SelectedItemPropertyName = "SelectedItem";

        public DashBoardTableModel SelectedDireccion
        {
            get { return _SelectedDireccion; }
            set
            {
                if (_SelectedDireccion != value)
                {
                    //Si se selecciona una direccion, el selecteditem de todos (ocavm) se pone en null para des-seleccionarlo
                    _SelectedDireccion = value;
                    if (_SelectedDireccion != null)
                    {
                        this.SelectedOcavm = null;
                        this.SelectedItem = _SelectedDireccion;
                    }
                    OnPropertyChanged(SelectedDireccionPropertyName);
                }
            }
        }
        private DashBoardTableModel _SelectedDireccion;
        public const string SelectedDireccionPropertyName = "SelectedDireccion";

        public DashBoardTableModel SelectedOcavm
        {
            get { return _SelectedOcavm; }
            set
            {
                if (_SelectedOcavm != value)
                {
                    _SelectedOcavm = value;

                    //Si se selecciona todos, el selecteditem del detalle se pone en null para des-seleccionarlo
                    if (_SelectedOcavm != null)
                    {
                        this.SelectedDireccion = null;
                        this.SelectedItem = _SelectedOcavm;
                    }
                    
                    OnPropertyChanged(SelectedOcavmPropertyName);
                }
            }
        }
        private DashBoardTableModel _SelectedOcavm;
        public const string SelectedOcavmPropertyName = "SelectedOcavm";
        #endregion

        #region Constructor
        public DashBoardTableViewModel()
        {
            oDashBoardRepository = new DashBoardRepository();
            DashBoardTable = new ObservableCollection<DashBoardTableModel>();
            DashBoardTableDetalle = new ObservableCollection<DashBoardTableModel>();            
        }
        #endregion

        #region Metodos.
        public ObservableCollection<DashBoardTableModel> GetTotal(string Prioridad, AnioModel Anio, MesModel Mes, ObservableCollection<DeterminanteModel> Determinantes)
        {
            DashBoardTable.Clear();
            switch (Prioridad)
            {   
                case "Todos":
                    DashBoardTable.Add(oDashBoardRepository.GetDTOcavmTodos(Anio,Mes,Determinantes));
                    break;
                case "Urgente":
                    DashBoardTable.Add(oDashBoardRepository.GetDTOcavmUrgente(Anio, Mes, Determinantes));
                    break;
                case "Prioritario":
                    DashBoardTable.Add(oDashBoardRepository.GetDTOcavmPrioritarioOrdinario(Anio,Mes,Determinantes));
                    break;
                default:
                    DashBoardTable.Add(oDashBoardRepository.GetDTOcavmTodos(Anio, Mes, Determinantes));
                    break;
            }
            return DashBoardTable;
        }

        public ObservableCollection<DashBoardTableModel> GetDetalle(string Prioridad, AnioModel Anio, MesModel Mes, ObservableCollection<DeterminanteModel> Determinantes)
        {
            
            DashBoardTableDetalle.Clear();
            switch (Prioridad)
            {
                case "Todos":
                    DashBoardTableDetalle = oDashBoardRepository.GetDTDireccionesTodos(Anio, Mes, Determinantes);
                    break;
                case "Urgente":
                    DashBoardTableDetalle = oDashBoardRepository.GetDTDireccionesTodos(Anio, Mes, Determinantes);
                    break;
                case "Prioritario":
                    DashBoardTableDetalle = oDashBoardRepository.GetDTDireccionesTodos(Anio, Mes, Determinantes);
                    break;
                default:
                    DashBoardTableDetalle = oDashBoardRepository.GetDTDireccionesTodos(Anio, Mes, Determinantes);
                    break;
            }
            
            return DashBoardTableDetalle;
        }

        /// <summary>
        /// Obtiene el elemento seleccionado, considerando ambos grids
        /// </summary>
        /// <returns>Elemento seleccionado del grid</returns>
        public DashBoardTableModel GetSelectedItem()
        {
            return (this.SelectedDireccion != null) ? this.SelectedDireccion : this.SelectedOcavm;
        }

        
        #endregion
    }
}
