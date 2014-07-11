using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using GestorDocument.DAL.Repository;
using System.Collections.ObjectModel;
using GestorDocument.Model.DashBoardModel;
using System;

namespace GestorDocument.ViewModel.DashBoard
{
    public class AnioMesViewModel:ViewModelBase
    {
        #region Instancias.
        private IDashBoard DashBoardRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Construye el objeto con anio y mes tomados del sistema (actuales)
        /// </summary>
        public AnioMesViewModel():this(null,null)
        {
        }

        /// <summary>
        /// Construye el objeto estableciendo el anio y mes pasados por parametro.
        /// </summary>
        /// <param name="anio">Numero de año valido</param>
        /// <param name="mes">Numero entre 1 y 12 que representa los meses</param>
        public AnioMesViewModel(int? anio, int? mes)
        {
            DashBoardRepository = new DashBoardRepository();
            GetAnios();
            GetMes();

            //Si vienen nulos los parametros se ponen los actuales
            anio = (anio == null) ? DateTime.Now.Year : anio;
            mes = (mes == null) ? DateTime.Now.Month : mes;

            //Seleccionar de la coleccion los que coincidan
            foreach (AnioModel item in this.Anios)
            {
                if (item.Anio == (int)anio)
                {
                    this.SelectedAnio = item;
                    break;
                }
            }

            foreach (MesModel item in this.Meses)
            {
                if (item.Mes == (int)mes)
                {
                    this.SelectedMes = item;
                    break;
                }
            }
            
        }
        #endregion

        #region Propiedades       

        public ObservableCollection<AnioModel> Anios
        {
            get { return _Anio; }
            set
            {
                if (_Anio != value)
                {
                    _Anio = value;
                    OnPropertyChanged(AnioPropertyName);                    
                }
            }
        }
        private ObservableCollection<AnioModel> _Anio;
        public const string AnioPropertyName = "Anio";

        public ObservableCollection<MesModel> Meses
        {
            get { return _Meses; }
            set
            {
                if (_Meses != value)
                {
                    _Meses = value;
                    OnPropertyChanged(MesPropertyName);
                }
            }
        }
        private ObservableCollection<MesModel> _Meses;
        public const string MesPropertyName = "Meses";

        /// <summary>
        /// Representa el anio seleccionado por el usuario
        /// </summary>
        public AnioModel SelectedAnio
        {
            get { return _SelectedAnio; }
            set
            {
                if (_SelectedAnio != value)
                {
                    _SelectedAnio = value;
                    OnPropertyChanged(SelectedAnioPropertyName);
                }
            }
        }
        private AnioModel _SelectedAnio;
        public const string SelectedAnioPropertyName = "SelectedAnio";

        /// <summary>
        /// Representea el mes seleccionado por el usuario
        /// </summary>
        public MesModel SelectedMes
        {
            get { return _SelectedMes; }
            set
            {
                if (_SelectedMes != value)
                {
                    _SelectedMes = value;
                    OnPropertyChanged(SelectedMesPropertyName);
                }
            }
        }
        private MesModel _SelectedMes;
        public const string SelectedMesPropertyName = "SelectedMes";
        #endregion

        #region Metodos.
        private void GetAnios()
        {
            Anios = DashBoardRepository.GetAnio() as ObservableCollection<AnioModel>;
        }
        private void GetMes()
        {
            Meses = DashBoardRepository.GetMes() as ObservableCollection<MesModel>;
        }
        #endregion
    }
}
