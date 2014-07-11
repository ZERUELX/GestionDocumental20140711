using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.DAL;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;
using GestorDocument.Model.v2;

namespace GestorDocument.ViewModel
{
    public class BusquedaViewModel : ViewModelBase
    {

        #region ROL Y USUARIO
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

        public UsuarioModel Usuario
        {
            get { return _Usuario; }
            set
            {
                if (_Usuario != value)
                {
                    _Usuario = value;
                    OnPropertyChanged(UsuarioPropertyName);
                }
            }
        }
        private UsuarioModel _Usuario;
        public const string UsuarioPropertyName = "Usuario";

        #endregion

        private IAsunto _AsuntoRepository;

        public ResultadoViewModel Resultado
        {
            get { return _Resultado; }
            set
            {
                if (_Resultado != value)
                {
                    _Resultado = value;
                    OnPropertyChanged(ResultadoPropertyName);
                }
            }
        }
        private ResultadoViewModel _Resultado;
        public const string ResultadoPropertyName = "Resultado";


        public ObservableCollection<AsuntoModel> ResultadoBusqueda
        {
            get { return _ResultadoBusqueda; }
            set
            {
                if (_ResultadoBusqueda != value)
                {
                    _ResultadoBusqueda = value;
                    OnPropertyChanged(ResultadoBusquedaPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _ResultadoBusqueda;
        public const string ResultadoBusquedaPropertyName = "ResultadoBusqueda";

        public ObservableCollection<AsuntosDataGridModel> ResultadoBusquedaNueva
        {
            get { return _ResultadoBusquedaNueva; }
            set
            {
                if (_ResultadoBusquedaNueva != value)
                {
                    _ResultadoBusquedaNueva = value;
                    OnPropertyChanged(ResultadoBusquedaNuevaPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntosDataGridModel> _ResultadoBusquedaNueva;
        public const string ResultadoBusquedaNuevaPropertyName = "ResultadoBusqueda";

        public AsuntoModel SelectedAsunto
        {
            get { return _SelectedAsunto; }
            set
            {
                if (_SelectedAsunto != value)
                {
                    _SelectedAsunto = value;
                    OnPropertyChanged(SelectedAsuntoPropertyName);
                }
            }
        }
        private AsuntoModel _SelectedAsunto;
        public const string SelectedAsuntoPropertyName = "SelectedAsunto";

        // ***************************** ***************************** *****************************
        // CARGAR COMBO PRIORIDAD.

        private IPrioridad _PrioridadRepository;
        public ObservableCollection<PrioridadModel> dataListPrio
        {
            get { return _dataListPrio; }
            set
            {
                if (_dataListPrio != value)

                {
                    _dataListPrio = value;
                    OnPropertyChanged(dataListPrioPropertyName);
                }
            }
        }
        private ObservableCollection<PrioridadModel> _dataListPrio;
        public const string dataListPrioPropertyName = "dataListPrio";

        public PrioridadModel SelectedPrioridad
        {
            get { return _SelectedPrioridad; }
            set
            {
                if (_SelectedPrioridad != value)
                {

                    _SelectedPrioridad = value;
                    OnPropertyChanged(SelectedPrioridadPropertyName);
                }
            }
        }
        private PrioridadModel _SelectedPrioridad;
        public const string SelectedPrioridadPropertyName = "SelectedPrioridad";

        public string SelectedPrioridadName
        {
            get { return _SelectedPrioridadName; }
            set
            {
                if (_SelectedPrioridadName != value)
                {
                    _SelectedPrioridadName = value;
                    OnPropertyChanged(SelectedPrioridadNamePropertyName);
                }
            }
        }
        private string _SelectedPrioridadName;
        public const string SelectedPrioridadNamePropertyName = "SelectedPrioridadName";

        public string SelectedPrio
        {
            get { return _SelectedPrio; }
            set
            {
                if (_SelectedPrio != value)
                {
                    _SelectedPrio = value;
                    OnPropertyChanged(SelectedPrioPropertyName);
                }
            }
        }
        private string _SelectedPrio;
        public const string SelectedPrioPropertyName = "SelectedPrio";

        // ***************************** ***************************** *****************************
        // CARGAR COMBO STATUSASUNTO.

        private IStatusAsunto _StatusAsuntoRepository;
        public ObservableCollection<StatusAsuntoModel> dataListStatus
        {
            get { return _dataListStatus; }
            set
            {
                if (_dataListStatus != value)
                {
                    _dataListStatus = value;
                    OnPropertyChanged(dataListStatusPropertyName);
                }
            }
        }
        private ObservableCollection<StatusAsuntoModel> _dataListStatus;
        public const string dataListStatusPropertyName = "dataListStatus";

        public StatusAsuntoModel SelectedStatusAsunto
        {
            get { return _SelectedStatusAsunto; }
            set
            {
                if (_SelectedStatusAsunto != value)
                {
                    _SelectedStatusAsunto = value;
                    OnPropertyChanged(SelectedStatusAsuntoPropertyName);
                }
            }
        }
        private StatusAsuntoModel _SelectedStatusAsunto;
        public const string SelectedStatusAsuntoPropertyName = "SelectedStatusAsunto";

        public string SelectedStatusAsuntoName
        {
            get { return _SelectedStatusAsuntoName; }
            set
            {
                if (_SelectedStatusAsuntoName != value)
                {
                    _SelectedStatusAsuntoName = value;
                    OnPropertyChanged(SelectedStatusAsuntoNamePropertyName);
                }
            }
        }
        private string _SelectedStatusAsuntoName;
        public const string SelectedStatusAsuntoNamePropertyName = "SelectedStatusAsuntoName";

        public string SelectedStatusAsun
        {
            get { return _SelectedStatusAsun; }
            set
            {
                if (_SelectedStatusAsun != value)
                {
                    _SelectedStatusAsun = value;
                    OnPropertyChanged(SelectedStatusAsunPropertyName);
                }
            }
        }
        private string _SelectedStatusAsun;
        public const string SelectedStatusAsunPropertyName = "SelectedStatusAsun";


        // ***************************** ***************************** *****************************
        // CARGAR COMBO DESTINATARIOS.

        private IOrganigrama _OrganigramaRepository;
        public ObservableCollection<OrganigramaModel> dataListDestinatarios
        {
            get { return _dataListDestinatarios; }
            set
            {
                if (_dataListDestinatarios != value)
                {
                    _dataListDestinatarios = value;
                    OnPropertyChanged(dataListDestinatariosPropertyName);
                }
            }
        }
        private ObservableCollection<OrganigramaModel> _dataListDestinatarios;
        public const string dataListDestinatariosPropertyName = "dataListDestinatarios";


        public OrganigramaModel SelectedDestinatario
        {
            get { return _SelectedDestinatario; }
            set
            {
                if (_SelectedDestinatario != value)
                {
                    _SelectedDestinatario = value;
                    OnPropertyChanged(SelectedDestinatarioPropertyName);
                }
            }
        }
        private OrganigramaModel _SelectedDestinatario;
        public const string SelectedDestinatarioPropertyName = "SelectedDestinatario";

        public string SelectedDest
        {
            get { return _SelectedDest; }
            set
            {
                if (_SelectedDest != value)
                {
                    _SelectedDest = value;
                    OnPropertyChanged(SelectedDestPropertyName);
                }
            }
        }
        private string _SelectedDest;
        public const string SelectedDestPropertyName = "SelectedDest";

        public string SelectedDestinatarioName
        {
            get { return _SelectedDestinatarioName; }
            set
            {
                if (_SelectedDestinatarioName != value)
                {
                    _SelectedDestinatarioName = value;
                    OnPropertyChanged(SelectedDestinatarioNamePropertyName);
                }
            }
        }
        private string _SelectedDestinatarioName;
        public const string SelectedDestinatarioNamePropertyName = "SelectedDestinatarioName";

        // ***************************** ***************************** *****************************
        // CARGAR COMBO SIGNATARIOS.

        private IDeterminante _DeterminanteRepository;
        public ObservableCollection<DeterminanteModel> dataListSignatarios
        {
            get { return _dataListSignatarios; }
            set
            {
                if (_dataListSignatarios != value)
                {
                    _dataListSignatarios = value;
                    OnPropertyChanged(dataListSignatariosPropertyName);
                }
            }
        }
        private ObservableCollection<DeterminanteModel> _dataListSignatarios;
        public const string dataListSignatariosPropertyName = "dataListSignatarios";

        public string SelectedSign
        {
            get { return _SelectedSign; }
            set
            {
                if (_SelectedSign != value)
                {
                    _SelectedSign = value;
                    OnPropertyChanged(SelectedSignPropertyName);
                }
            }
        }
        private string _SelectedSign;
        public const string SelectedSignPropertyName = "SelectedSign";

        public string SelectedSignatarioName
        {
            get { return _SelectedSignatarioName; }
            set
            {
                if (_SelectedSignatarioName != value)
                {
                    _SelectedSignatarioName = value;
                    OnPropertyChanged(SelectedSignatarioNamePropertyName);
                }
            }
        }
        private string _SelectedSignatarioName;
        public const string SelectedSignatarioNamePropertyName = "SelectedSignatarioName";

        // ***************************** ***************************** *****************************
        // DATEPICKER DESDE.

        public DateTime? SelectedFechaDesde
        {
            get { return _SelectedFechaDesde; }
            set
            {
                if (_SelectedFechaDesde != value)
                {
                    _SelectedFechaDesde = value;
                    OnPropertyChanged(SelectedFechaDesdePropertyName);
                }
            }
        }
        private DateTime? _SelectedFechaDesde;
        public const string SelectedFechaDesdePropertyName = "SelectedFechaDesde";

        // ***************************** ***************************** *****************************
        // DATEPICKER HASTA.

        public DateTime? SelectedFechaHasta
        {
            get { return _SelectedFechaHasta; }
            set
            {
                if (_SelectedFechaHasta != value)
                {
                    _SelectedFechaHasta = value;
                    OnPropertyChanged(SelectedFechaHastaPropertyName);
                }
            }
        }
        private DateTime? _SelectedFechaHasta;
        public const string SelectedFechaHastaPropertyName = "SelectedFechaHasta";

        // ***************************** ***************************** *****************************
        // TEXTBOX REFERENCIADOCUMENTO.

        public string SelectedFolio
        {
            get { return _SelectedFolio; }
            set
            {
                if (_SelectedFolio != value)
                {
                    _SelectedFolio = value;

                    if (_SelectedFolio == "")
                    {
                        _SelectedFolio = null;
                    }
                    OnPropertyChanged(SelectedFolioPropertyName);
                }
            }
        }
        private string _SelectedFolio;
        public const string SelectedFolioPropertyName = "SelectedFolio";

        // ***************************** ***************************** *****************************
        // TEXTBOX TITULOASUNTO.

        public string SelectedTituloAsunto
        {
            get { return _SelectedTituloAsunto; }
            set
            {
                if (_SelectedTituloAsunto != value)
                {
                    _SelectedTituloAsunto = value;

                    if (_SelectedTituloAsunto == "")
                    {
                        _SelectedTituloAsunto = null;
                    }
                    OnPropertyChanged(SelectedTituloAsuntoPropertyName);
                }
            }
        }
        private string _SelectedTituloAsunto;
        public const string SelectedTituloAsuntoPropertyName = "SelectedTituloAsunto";

        // ***************************** ***************************** *****************************
        // TEXTBOX DESCRIPCION_ASUNTO.

        public string SelectedDescripcionAsunto
        {
            get { return _SelectedDescripcionAsunto; }
            set
            {
                if (_SelectedDescripcionAsunto != value)
                {
                    _SelectedDescripcionAsunto = value;

                    if (_SelectedDescripcionAsunto == "")
                    {
                        _SelectedDescripcionAsunto = null;
                    }
                    OnPropertyChanged(SelectedDescripcionAsuntoPropertyName);
                }
            }
        }
        private string _SelectedDescripcionAsunto;
        public const string SelectedDescripcionAsuntoPropertyName = "SelectedDescripcionAsunto";

        // ***************************** ***************************** *****************************
        // TEXTBOX NOMBRE_DOCUMENTO.

        public string SelectedNameDocumento
        {
            get { return _SelectedNameDocumento; }
            set
            {
                if (_SelectedNameDocumento != value)
                {
                    _SelectedNameDocumento = value;

                    if (_SelectedNameDocumento == "")
                    {
                        _SelectedDescripcionAsunto = null;
                    }
                    OnPropertyChanged(SelectedNameDocumentoPropertyName);
                }
            }
        }
        private string _SelectedNameDocumento;
        public const string SelectedNameDocumentoPropertyName = "SelectedNameDocumento";

        // ***************************** ***************************** *****************************
        // CHECKBOX CHECKED.

        public bool IsDateChecked
        {
            get { return _IsDateChecked; }
            set
            {
                if (_IsDateChecked != value)
                {
                    _IsDateChecked = value;
                    OnPropertyChanged(IsDateCheckedPropertyName);
                }
            }
        }
        private bool _IsDateChecked;
        public const string IsDateCheckedPropertyName = "IsDateChecked";

        public int ContadorDestinatarios
        {
            get { return _ContadorDestinatarios; }
            set
            {
                if (_ContadorDestinatarios != value)
                {
                    _ContadorDestinatarios = value;
                    OnPropertyChanged(ContadorDestinatariosPropertyName);
                }
            }
        }
        private int _ContadorDestinatarios;
        public const string ContadorDestinatariosPropertyName = "ContadorDestinatarios";

        public int ContadorSignatarios
        {
            get { return _ContadorSignatarios; }
            set
            {
                if (_ContadorSignatarios != value)
                {
                    _ContadorSignatarios = value;
                    OnPropertyChanged(ContadorSignatariosPropertyName);
                }
            }
        }
        private int _ContadorSignatarios;
        public const string ContadorSignatariosPropertyName = "ContadorSignatarios";

        // ***************************** ***************************** *****************************
        //  DESTINATARIOS,SIGNATARIOS, PRIORIDAD, STATUS_ASUNTO

        public List<long> IdDestinatarios
        {
            get { return _IdDestinatarios; }
            set 
            {
                if (_IdDestinatarios != value)
                {
                    _IdDestinatarios = value;
                    OnPropertyChanged(IdDestinatariosPropertyName);
                }
                
            }
        }
        private List<long> _IdDestinatarios;
        public const string IdDestinatariosPropertyName = "IdDestinatarios";

        public List<long> IdSignatarios
        {
            get { return _IdSignatarios; }
            set
            {
                if (_IdSignatarios != value)
                {
                    _IdSignatarios = value;
                    OnPropertyChanged(IdSignatariosPropertyName);
                }

            }
        }
        private List<long> _IdSignatarios;
        public const string IdSignatariosPropertyName = "IdSignatarios";

        public List<long> IdPrioridad
        {
            get { return _IdPrioridad; }
            set
            {
                if (_IdPrioridad != value)
                {
                    _IdPrioridad = value;
                    OnPropertyChanged(IdPrioridadPropertyName);
                }

            }
        }
        private List<long> _IdPrioridad;
        public const string IdPrioridadPropertyName = "IdPrioridad";

        public List<long> IdStatusAsunto
        {
            get { return _IdStatusAsunto; }
            set
            {
                if (_IdStatusAsunto != value)
                {
                    _IdStatusAsunto = value;
                    OnPropertyChanged(IdStatusAsuntoPropertyName);
                }

            }
        }
        private List<long> _IdStatusAsunto;
        public const string IdStatusAsuntoPropertyName = "IdStatusAsunto";

        public List<string> NamesPrioridad
        {
            get { return _NamesPrioridad; }
            set
            {
                if (_NamesPrioridad != value)
                {
                    _NamesPrioridad = value;
                    OnPropertyChanged(NamesPrioridadPropertyName);
                }

            }
        }
        private List<string> _NamesPrioridad;
        public const string NamesPrioridadPropertyName = "NamesPrioridad";

        public List<string> NamesStatusAsunto
        {
            get { return _NamesStatusAsunto; }
            set
            {
                if (_NamesStatusAsunto != value)
                {
                    _NamesStatusAsunto = value;
                    OnPropertyChanged(NamesStatusAsuntoPropertyName);
                }

            }
        }
        private List<string> _NamesStatusAsunto;
        public const string NamesStatusAsuntoPropertyName = "NamesStatusAsunto";

        

        // ***************************** ***************************** *****************************
        // BUSQUEDA.

        public RelayCommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new RelayCommand(p => this.AttemptSearch(), p => this.CanSearch());
                }

                return _SearchCommand;
            }

        }
        private RelayCommand _SearchCommand;
        public bool CanSearch()
        {
            //solo busca
            return true;
        }
        public void AttemptSearch()
        {
            //prioridad
            this.GetPrioridad();
            //status asunto
            this.GetStatusAsunto();
            //destinatario
            this.GetDestinatarios();
            //signatarios
            this.GetSignatarios();
            //rango de fechas
            this.GetRangoFechas();

            this.ResultadoBusqueda = 
                this.Resultado.LoadInfoGrid(
                this._SelectedPrio,
                this._SelectedStatusAsun,
                this._SelectedDest,
                this._SelectedSign,
                this._SelectedFechaDesde,
                this._SelectedFechaHasta,
                (!String.IsNullOrWhiteSpace(this.SelectedFolio)) ? this.SelectedFolio.Trim() : null,
                (!String.IsNullOrWhiteSpace(this.SelectedTituloAsunto)) ? this.SelectedTituloAsunto.Trim() : null,
                (!String.IsNullOrWhiteSpace(this.SelectedDescripcionAsunto)) ? this.SelectedDescripcionAsunto.Trim() : null,
                (!String.IsNullOrWhiteSpace(this.SelectedNameDocumento)) ? this.SelectedNameDocumento.Trim() : null,
                this._Rol);
        }

       

   

        // ***************************** ***************************** *****************************
        // VALIDA BUSQUEDA.

        public RelayCommand ValidarSearchCommand
        {
            get
            {
                if (_ValidarSearchCommand == null)
                {
                    _ValidarSearchCommand = new RelayCommand(p => this.ValidarAttemptSearch(), p => this.ValidarCanSearch());
                }

                return _ValidarSearchCommand;
            }

        }
        private RelayCommand _ValidarSearchCommand;
        public bool ValidarCanSearch()
        {
            bool _CanSearch = false;

            this.AllDestinatarios();
            this.AllSignatarios();
            this.AllPrioridad();
            this.AllStatusAsunto();

            if ((!String.IsNullOrWhiteSpace(this.SelectedFolio)) || (!String.IsNullOrWhiteSpace(this.SelectedTituloAsunto)) ||
                (!String.IsNullOrEmpty(this.SelectedPrioridadName)) || (!String.IsNullOrEmpty(this.SelectedDestinatarioName)) ||
                (!String.IsNullOrEmpty(this.SelectedSignatarioName)) || (!String.IsNullOrEmpty(this.SelectedStatusAsuntoName)) ||
                (!String.IsNullOrWhiteSpace(this.SelectedDescripcionAsunto)) || (!String.IsNullOrWhiteSpace(this.SelectedNameDocumento)) ||
                (_IsDateChecked))
            {
                _CanSearch = true;
            }

            return _CanSearch;
        }
        public void ValidarAttemptSearch()
        {
            //solo valida
        }

        // ***************************** ***************************** *****************************
        // CONSTRUCTOR.
        /// <summary>
        /// Constructor BusquedaViewModel 
        /// Carga campos de panel de busqueda.
        /// </summary>
        /// <param name="rol">Rol de usuario Logueado.</param>
        public BusquedaViewModel(RolModel rol)
        {
            this._Rol = rol;
            this.Resultado = new ResultadoViewModel();
            this._ResultadoBusqueda = new ObservableCollection<AsuntoModel>();
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();

            this._PrioridadRepository = new GestorDocument.DAL.Repository.PrioridadRepository();
            this._StatusAsuntoRepository = new GestorDocument.DAL.Repository.StatusAsuntoRepository();
            this._OrganigramaRepository = new GestorDocument.DAL.Repository.OrganigramaRepository();
            this._DeterminanteRepository = new GestorDocument.DAL.Repository.DeterminanteRepository();

            this.NamesPrioridad = new List<string>();
            this.NamesStatusAsunto = new List<string>();
            this.SelectedFechaDesde = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now));
            this.SelectedFechaHasta = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now));

            this.LoadInfo();
        }

        public BusquedaViewModel(int idRol)
        {
            //this._Rol = rol;
            this.Resultado = new ResultadoViewModel();
            this._ResultadoBusqueda = new ObservableCollection<AsuntoModel>();
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();

            this._PrioridadRepository = new GestorDocument.DAL.Repository.PrioridadRepository();
            this._StatusAsuntoRepository = new GestorDocument.DAL.Repository.StatusAsuntoRepository();
            this._OrganigramaRepository = new GestorDocument.DAL.Repository.OrganigramaRepository();
            this._DeterminanteRepository = new GestorDocument.DAL.Repository.DeterminanteRepository();

            this.NamesPrioridad = new List<string>();
            this.NamesStatusAsunto = new List<string>();
            this.SelectedFechaDesde = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now));
            this.SelectedFechaHasta = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now));

            this.LoadInfo();


        }
        
        /// <summary>
        /// Carga campos de panel de busqueda.
        /// </summary>
        public void LoadInfo()
        {
            
            this.dataListPrio = this._PrioridadRepository.GetPrioridads() as ObservableCollection<PrioridadModel>;
            this.dataListStatus = this._StatusAsuntoRepository.GetStatusAsuntos() as ObservableCollection<StatusAsuntoModel>;
            this.dataListDestinatarios = this._OrganigramaRepository.GetOrganigrama() as ObservableCollection<OrganigramaModel>;
            this.dataListSignatarios = this._DeterminanteRepository.GetDeterminantes() as ObservableCollection<DeterminanteModel>;
        }

        public void GetDestinatarios()
        {
            this.IdDestinatarios = new List<long>();
            try
            {
                this.IdDestinatarios = (from o in this.dataListDestinatarios
                                        where o.IsChecked == true
                                        select o.IdJerarquia).ToList();
            }
            catch (Exception)
            {
            }
            this.SelectedDest = null;
            if (this.IdDestinatarios.Count != 0)
            {
                this.SelectedDest = String.Join(",", this.IdDestinatarios);
            }
        }

        public void GetSignatarios()
        {
            this.IdSignatarios  = new List<long>();
            try
            {
                this.IdSignatarios = (from o in this.dataListSignatarios
                                      where o.IsChecked == true
                                      select o.IdDeterminante).ToList();
            }
            catch (Exception)
            {
            }
            this.SelectedSign = null;
            if (IdSignatarios.Count != 0)
            {
                this.SelectedSign = String.Join(",", this.IdSignatarios);
            }

        }

        public void GetPrioridad()
        {
            this.IdPrioridad = new List<long>();
            
            try
            {
                this.IdPrioridad = (from o in this.dataListPrio
                                    where o.IsChecked == true
                                    select o.IdPrioridad).ToList();
            }
            catch (Exception)
            {
            }
            this.SelectedPrio = null;
            if (this.IdPrioridad.Count != 0)
            {
                this.SelectedPrio = String.Join(",", this.IdPrioridad);
            }
            

        }

        public void GetStatusAsunto()
        {
            this.IdStatusAsunto = new List<long>();
            try
            {
                this.IdStatusAsunto = (from o in this.dataListStatus
                                       where o.IsChecked == true
                                       select o.IdStatusAsunto).ToList();
            }
            catch (Exception)
            {
            }
            this.SelectedStatusAsun = null;
            if (this.IdStatusAsunto.Count != 0)
            {
                this.SelectedStatusAsun = String.Join(",", this.IdStatusAsunto);
            }
        }

        public void GetRangoFechas()
        {
            if (this.IsDateChecked == false)
            {
                this.SelectedFechaDesde = null;
                this._SelectedFechaHasta = null;
            }
        }

        public void GetPriridadNames()
        {
            //se agrega la lista de ids
            List<string> auxUnids = new List<string>();
            if (this.NamesPrioridad.Count > 0)
            {
                (from o in this.NamesPrioridad
                 select o).ToList().ForEach
                (
                    o => auxUnids.Add(o)
                );
            }

            foreach (PrioridadModel p in this.dataListPrio)
            {
                if (p.IsChecked)
                {
                    if (!auxUnids.Contains(p.PrioridadName))
                    {
                        this.NamesPrioridad.Add(p.PrioridadName);
                    }
                }
                else
                {
                    this.NamesPrioridad.Remove(p.PrioridadName);   
                }
                
            }

            this.SelectedPrioridadName = null;

            if (this.NamesPrioridad.Count != 0)
            {
                this.SelectedPrioridadName = String.Join(", ", this.NamesPrioridad);
            }
        }

        public void GetStatusAsuntoNames()
        {
            //se agrega la lista de ids
            List<string> auxUnids = new List<string>();
            if (this.NamesStatusAsunto.Count > 0)
            {
                (from o in this.NamesStatusAsunto
                 select o).ToList().ForEach
                (
                    o => auxUnids.Add(o)
                );
            }

            foreach (StatusAsuntoModel p in this.dataListStatus)
            {
                if (p.IsChecked)
                {
                    if (!auxUnids.Contains(p.StatusName))
                    {
                        this.NamesStatusAsunto.Add(p.StatusName);
                    }
                }
                else
                {
                    this.NamesStatusAsunto.Remove(p.StatusName);
                }

            }

            this.SelectedStatusAsuntoName = null;

            if (this.NamesStatusAsunto.Count != 0)
            {
                this.SelectedStatusAsuntoName = String.Join(", ", this.NamesStatusAsunto);
            }
        }

        private void AllDestinatarios()
        {
            var res = (from d in this.dataListDestinatarios
                       where d.IsChecked == true
                       select d).ToList();
            string destinatarios = String.Join(",", res.Select(item => item.JerarquiaName.ToString()).ToList());
            this.SelectedDestinatarioName = destinatarios;
        }

        private void AllPrioridad()
        {
            var res = (from d in this.dataListPrio
                       where d.IsChecked == true
                       select d).ToList();
            string prioridad = String.Join(",", res.Select(item => item.PrioridadName.ToString()).ToList());
            this.SelectedPrioridadName = prioridad;
        }

        private void AllSignatarios()
        {
            var res = (from d in this.dataListSignatarios
                       where d.IsChecked == true
                       select d).ToList();
            string signatario = String.Join(",", res.Select(item => item.DeterminanteName.ToString()).ToList());
            this.SelectedSignatarioName = signatario;
        }

        private void AllStatusAsunto()
        {
            var res = (from d in this.dataListStatus
                       where d.IsChecked == true
                       select d).ToList();
            string status = String.Join(",", res.Select(item => item.StatusName.ToString()).ToList());
            this.SelectedStatusAsuntoName = status;
        }
    }
}
