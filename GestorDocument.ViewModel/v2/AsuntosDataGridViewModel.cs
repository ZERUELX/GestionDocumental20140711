using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.DAL.Repository.v2;
using GestorDocument.Model.v2;
using System.Windows.Media;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;

namespace GestorDocument.ViewModel.v2
{
    public class AsuntosDataGridViewModel:ViewModelBase
    {
        #region Constructor.
        public AsuntosDataGridViewModel()
        {
            HistorialAsuntos = new ObservableCollection<AsuntosDataGridModel>();
            
        }
        #endregion

        #region Propiedades.

        private IDestinatario _DestinatarioRepository;

        //public RelayCommand RelayCommand
        //{
        //    get
        //    {
        //        if (_RelayCommand == null)
        //        {
        //            _RelayCommand = new RelayCommand(p => this.AttempBack(), p => this.CanAttempBack());
        //        }
        //        return _RelayCommand;
        //    }
        //}
        //private RelayCommand _RelayCommand;
        //public const string RelayCommandPropertyName = "RelayCommand";


        public BusquedaViewModel BusquedaVM
        {
            get { return _BusquedaVM; }
            set
            {
                if (_BusquedaVM != value)
                {
                    _BusquedaVM = value;
                    OnPropertyChanged(BusquedaVMPropertyName);
                }
            }
        }
        private BusquedaViewModel _BusquedaVM;
        public const string BusquedaVMPropertyName = "BusquedaVM";

        public RelayCommand BusquedaCommand
        {
            get
            {
                if (_BusquedaCommand == null)
                {
                    _BusquedaCommand = new RelayCommand(p => this.AttemptBuscar(), p => this.CanBuscar());
                }

                return _BusquedaCommand;
            }

        }
        private RelayCommand _BusquedaCommand;
        public bool CanBuscar()
        {
            //solo busca
            return true;
        }
        public void AttemptBuscar()
        {

         

            //prioridad
            this.BusquedaVM.GetPrioridad();
            //status asunto
            this.BusquedaVM.GetStatusAsunto();
            //destinatario
            this.BusquedaVM.GetDestinatarios();
            //signatarios
            this.BusquedaVM.GetSignatarios();
            //rango de fechas
            this.BusquedaVM.GetRangoFechas();

            this.BusquedaVM.ResultadoBusquedaNueva =
                this.BusquedaVM.Resultado.LoadInfoGridBusqueda(
                this.BusquedaVM.SelectedPrio,
                this.BusquedaVM.SelectedStatusAsun,
                this.BusquedaVM.SelectedDest,
                this.BusquedaVM.SelectedSign,
                this.BusquedaVM.SelectedFechaDesde,
                this.BusquedaVM.SelectedFechaHasta,
                (!String.IsNullOrWhiteSpace(this.BusquedaVM.SelectedFolio)) ? this.BusquedaVM.SelectedFolio.Trim() : null,
                (!String.IsNullOrWhiteSpace(this.BusquedaVM.SelectedTituloAsunto)) ? this.BusquedaVM.SelectedTituloAsunto.Trim() : null,
                (!String.IsNullOrWhiteSpace(this.BusquedaVM.SelectedDescripcionAsunto)) ? this.BusquedaVM.SelectedDescripcionAsunto.Trim() : null,
                (!String.IsNullOrWhiteSpace(this.BusquedaVM.SelectedNameDocumento)) ? this.BusquedaVM.SelectedNameDocumento.Trim() : null,
                this._Rol);

            if (this.HistorialAsuntos.Count > 0)
            {
                this.TituloGrid = "RESULTADOS DE LA BUSQUEDA DE ASUNTOS";
                this.BackgroundTitulo = "#AC58FA";
            }
            else
            {
                this.TituloGrid = " SIN RESULTADO DE LA BUSQUEDA DE ASUNTOS";
                this.BackgroundTitulo = "#AC58FA";
            }

            this.HistorialAsuntos = this.BusquedaVM.ResultadoBusquedaNueva;

         
        }


        public ObservableCollection<AsuntosDataGridModel> HistorialAsuntos
        {
            get { return _HistorialAsuntos; }
            set
            {
                if (_HistorialAsuntos != value)
                {
                    _HistorialAsuntos = value;
                    OnPropertyChanged(HistorialAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntosDataGridModel> _HistorialAsuntos;
        public const string HistorialAsuntosPropertyName = "HistorialAsuntos";

        public AsuntosDataGridModel SelectedItem
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
        private AsuntosDataGridModel _SelectedItem;
        public const string SelectedItemPropertyName = "SelectedItem";

        public long IdRol
        {
            get { return _IdRol; }
            set
            {
                if (_IdRol != value)
                {
                    _IdRol = value;
                    OnPropertyChanged(IdRolPropertyName);
                }
            }
        }
        private long _IdRol;
        public const string IdRolPropertyName = "IdRol";

        public string BackgroundColorTitle
        {
            get { return _BackgroundColorTitle; }
            set
            {
                if (_BackgroundColorTitle != value)
                {
                    _BackgroundColorTitle = value;
                    OnPropertyChanged(BackgroundColorTitlePropertyName);
                }
            }
        }
        private string _BackgroundColorTitle;
        public const string BackgroundColorTitlePropertyName = "BackgroundColorTitle";

        public BusquedaViewModel Busqueda
        {
            get { return _Busqueda; }
            set
            {
                if (_Busqueda != value)
                {
                    _Busqueda = value;
                    OnPropertyChanged(BusquedaPropertyName);
                }
            }
        }
        private BusquedaViewModel _Busqueda;
        public const string BusquedaPropertyName = "Busqueda";

        public RolModel Rol
        {
            get { return _Rol; }
            set
            {
                if (_Rol != value)
                {
                    _Rol = value;
                    OnPropertyChanged(RolPropertyName);
                }
            }
        }
        private RolModel _Rol;
        public const string RolPropertyName = "Rol";

        public string TituloGrid
        {
            get { return _TituloGrid; }
            set
            {
                if (_TituloGrid != value)
                {
                    _TituloGrid = value;
                    OnPropertyChanged(TituloGridPropertyName);
                }
            }
        }
        private string _TituloGrid;
        public const string TituloGridPropertyName = "TituloGrid";

        public string BackgroundTitulo
        {
            get { return _BackgroundTitulo; }
            set
            {
                if (_BackgroundTitulo != value)
                {
                    _BackgroundTitulo = value;
                    OnPropertyChanged(BackgroundTituloPropertyName);
                }
            }
        }
        private string _BackgroundTitulo;
        public const string BackgroundTituloPropertyName = "BackgroundTitulo";


        #endregion

        #region Metodos.

        public void Init(long IdRol, string tipoAsunto)
        {
            switch (tipoAsunto)
            {
                case "Asuntos Urgentes":
                    BackgroundColorTitle = "#FE2E2E";
                    break;
                case "Asuntos Pendientes":
                    BackgroundColorTitle = "#FF8000";
                    break;
                case "Todos los Asuntos":
                    BackgroundColorTitle = "#80CBC9";
                    break;
                case "Asuntos Atendidos":
                    BackgroundColorTitle = "#088A08";
                    break;
                case "Asuntos Prioritarios":
                    BackgroundColorTitle = "#FF8000";
                    break;
                case "Asuntos Ordinarios":
                    BackgroundColorTitle = "#FF8000";
                    break;
                case "Asuntos Atendidos Dentro de Fecha":
                    BackgroundColorTitle = "#088A08";
                    break;
                case "Asuntos Atendidos Fuera de Fecha":
                    BackgroundColorTitle = "#088A08";
                    break;
                case "Borrador":
                    BackgroundColorTitle = "#0040FF";
                    break;
                default:
                    break;
            }
            //_Rol = new RolModel();
            //_Rol.IdRol = IdRol;
            //this.Busqueda = new BusquedaViewModel(this._Rol);
            //textBTituloGrid.FontSize = 20;
            //textBTituloGrid.Text = tipoAsunto;
            //textBTituloGrid.Foreground = Brushes.White;


          
            this.IdRol = IdRol;
            this.BusquedaVM = new BusquedaViewModel(int.Parse(this.IdRol.ToString()));
            GetHistorial(tipoAsunto);
        }

        public void GetHistorial(string tipoAsunto)
        {
            using (var repository=new AsuntoRepository())
            {
                this.HistorialAsuntos = new ObservableCollection<AsuntosDataGridModel>(repository.getAsuntosOfiPart(tipoAsunto));                 
            }
        }


    

        //RELAY ATTEMP Y RELEASE

        //public bool CanAttempBack()
        //{
        //    bool _canBack = true;
        //    //if (String.IsNullOrEmpty(this._BackModel.Titulo))
        //    //    _canBack = false;

          

        //    return _canBack;
        //}

        //public void AttempBack()
        //{
            
        //}

        #endregion

    }
}
