using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using GestorDocument.ViewModel.TreeViewDireccion;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class TrancingAsuntoTurnoReadViewModel : ViewModelBase
    {
        public IConfirmation _Confirmation;
        public IDownloadFile _Download;

        public string MsjAtencion
        {
            get { return _MsjAtencion; }
            set
            {
                if (_MsjAtencion != value)
                {
                    _MsjAtencion = value;
                    OnPropertyChanged(MsjAtencionPropertyName);
                }
            }
        }
        private string _MsjAtencion;
        public const string MsjAtencionPropertyName = "MsjAtencion";

        #region PROPIEDADES DE RUTAS, DESCARGAS Y DOCUMEMENTOS LOCALES
        public string SuccessPath
        {
            get { return _SuccessPath; }
            set
            {
                if (_SuccessPath != value)
                {
                    _SuccessPath = value;
                    OnPropertyChanged(SuccessPathPropertyName);
                }
            }
        }
        private string _SuccessPath;
        public const string SuccessPathPropertyName = "SuccessPath";
        // ***************************** ***************************** *****************************
        public string SuccessPathServer
        {
            get { return _SuccessPathServer; }
            set
            {
                if (_SuccessPathServer != value)
                {
                    _SuccessPathServer = value;
                    OnPropertyChanged(SuccessPathServerPropertyName);
                }
            }
        }
        private string _SuccessPathServer;
        public const string SuccessPathServerPropertyName = "SuccessPathServer";
        // ***************************** ***************************** *****************************
        public Uri Descarga
        {
            get { return _Descarga; }
            set
            {
                if (_Descarga != value)
                {
                    _Descarga = value;
                    OnPropertyChanged(DescargaPropertyName);
                }
            }
        }
        private Uri _Descarga;
        public const string DescargaPropertyName = "Descarga";

        // ***************************** ***************************** *****************************
        public string[] FilesDocumetos
        {
            get { return _FilesDocumetos; }
            set
            {
                if (_FilesDocumetos != value)
                {
                    _FilesDocumetos = value;
                    OnPropertyChanged(FilesDocumetosPropertyName);
                }
            }
        }
        private string[] _FilesDocumetos;
        public const string FilesDocumetosPropertyName = "FilesDocumetos";

        #endregion

        #region Propiedades Hilo
        public static bool IsRunning = false;
        System.Timers.Timer t;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged("Message");
                }
            }
        }
        string _message;
        public bool JobDone
        {
            get { return _jobDone; }
            set
            {
                if (value != _jobDone)
                {
                    this._jobDone = value;
                    OnPropertyChanged("JobDone");
                }
            }
        }
        bool _jobDone;
        #endregion

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

        // ***************************** ***************************** *****************************
        // Repository.
        private ITurno _TurnoRepository;
        public AsuntoNotificacionesViewModel _ParentAsunto;
        
        public AsuntoModel SelectedAsuntoTurno
        {
            get { return _SelectedAsuntoTurno; }
            set
            {
                if (_SelectedAsuntoTurno != value)
                {
                    _SelectedAsuntoTurno = value;
                    OnPropertyChanged(SelectedAsuntoTurnoPropertyName);
                }
            }
        }
        private AsuntoModel _SelectedAsuntoTurno;
        public const string SelectedAsuntoTurnoPropertyName = "SelectedAsuntoTurno";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el treview

        public TreeViewSeguimientoViewModel TreeViewSeguimientoViewModel
        {
            get { return _TreeViewSeguimientoViewModel; }
            set
            {
                if (_TreeViewSeguimientoViewModel != value)
                {
                    _TreeViewSeguimientoViewModel = value;
                    OnPropertyChanged(TreeViewSeguimientoViewModelPropertyName);
                }
            }
        }
        private TreeViewSeguimientoViewModel _TreeViewSeguimientoViewModel;
        public const string TreeViewSeguimientoViewModelPropertyName = "TreeViewSeguimientoViewModel";

        public ObservableCollection<TurnoModel> Turnos
        {
            get { return _Turnos; }
            set
            {
                if (_Turnos != value)
                {
                    _Turnos = value;
                    OnPropertyChanged(TurnosPropertyName);
                }
            }
        }
        private ObservableCollection<TurnoModel> _Turnos;
        public const string TurnosPropertyName = "Turnos";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el lisbox
        public ObservableCollection<TurnoModel> SeguimientoTurnos
        {
            get { return _SeguimientoTurnos; }
            set
            {
                if (_SeguimientoTurnos != value)
                {
                    _SeguimientoTurnos = value;
                    OnPropertyChanged(SeguimientoTurnosPropertyName);
                }
            }
        }
        private ObservableCollection<TurnoModel> _SeguimientoTurnos;
        public const string SeguimientoTurnosPropertyName = "SeguimientoTurnos";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el listView Expediente
        private IExpediente _ExpedienteRepository;
        public ObservableCollection<ExpedienteModel> ExpedienteDocumento
        {
            get { return _ExpedienteDocumento; }
            set
            {
                if (_ExpedienteDocumento != value)
                {
                    _ExpedienteDocumento = value;
                    OnPropertyChanged(ExpedienteDocumentoPropertyName);
                }
            }
        }
        private ObservableCollection<ExpedienteModel> _ExpedienteDocumento;
        public const string ExpedienteDocumentoPropertyName = "ExpedienteDocumento";

        public ExpedienteModel SelectedExpedienteDocumento
        {
            get { return _SelectedExpedienteDocumento; }
            set
            {
                if (_SelectedExpedienteDocumento != value)
                {
                    _SelectedExpedienteDocumento = value;
                    OnPropertyChanged(SelectedExpedienteDocumentoPropertyName);
                }
            }
        }
        private ExpedienteModel _SelectedExpedienteDocumento;
        public const string SelectedExpedienteDocumentoPropertyName = "SelectedExpedienteDocumento";

        // ***************************** ***************************** *****************************

        #region IMPRIMIR CARATULA
        // IMPRIMIR
        public RelayCommand ImprimirCommand
        {
            get
            {
                if (_ImprimirCommand == null)
                {
                    _ImprimirCommand = new RelayCommand(p => this.AttemptImprimir(), p => this.CanImprimir());
                }

                return _ImprimirCommand;
            }

        }
        private RelayCommand _ImprimirCommand;

        public bool CanImprimir()
        {
            //por si se usa
            return true;
        }
        public void AttemptImprimir()
        {
            //solo valida
        }

        public AsuntoModel ImprimirAsunto
        {
            get { return _ImprimirAsunto; }
            set
            {
                if (_ImprimirAsunto != value)
                {
                    _ImprimirAsunto = value;
                    OnPropertyChanged(ImprimirAsuntoPropertyName);
                }
            }
        }
        private AsuntoModel _ImprimirAsunto;
        public const string ImprimirAsuntoPropertyName = "ImprimirAsunto";
        #endregion 

        public TurnoModel ParentTrancing
        {
            get { return _ParentTrancing; }
            set
            {
                if (_ParentTrancing != value)
                {
                    _ParentTrancing = value;
                }
            }
        }
        private TurnoModel _ParentTrancing;

        public AsuntoModel ReadAsunto
        {
            get { return _ReadAsunto; }
            set
            {
                if (_ReadAsunto != value)
                {
                    _ReadAsunto = value;
                    OnPropertyChanged(ReadAsuntoPropertyName);
                }
            }
        }
        private AsuntoModel _ReadAsunto;
        public const string ReadAsuntoPropertyName = "ReadAsunto";

        // SIGNATARIO EXTERNO. 
        public ObservableCollection<SignatarioExternoModel> SignatarioExterno
        {
            get { return _SignatarioExterno; }
            set
            {
                if (_SignatarioExterno != value)
                {
                    _SignatarioExterno = value;
                    OnPropertyChanged(SignatarioExternoPropertyName);
                }
            }
        }
        private ObservableCollection<SignatarioExternoModel> _SignatarioExterno;
        public const string SignatarioExternoPropertyName = "SignatarioExterno";
        private ISignatarioExterno _SignatarioExternoRepository;

        public TrancingAsuntoTurnoReadViewModel(AsuntoNotificacionesViewModel asuntoNotificacionesViewModel, AsuntoModel selectedAsuntoTurno, IConfirmation confirmation, IDownloadFile download)
        {
            this._ParentAsunto = asuntoNotificacionesViewModel;
            this._SelectedAsuntoTurno = selectedAsuntoTurno;
            this._Confirmation = confirmation;
            this._Download = download;
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
            this._ExpedienteRepository = new GestorDocument.DAL.Repository.ExpedienteRepository();
            this._Turnos = new ObservableCollection<TurnoModel>();
            this._SeguimientoTurnos = new ObservableCollection<TurnoModel>();
            this._SignatarioExternoRepository = new GestorDocument.DAL.Repository.SignatarioExternoRepository();
            this.SignatarioExterno = new ObservableCollection<SignatarioExternoModel>();
            this._SuccessPathServer = ConfigurationManager.AppSettings["ServerDocsFolder"].ToString();

            this.GetRol();

            this.GetUsuario();

            this.LoadInfoGrid();


            this.GetAtendidoTurnado();
        }

        public void LoadInfoGrid()
        {

            //para obtener los datos del seguimiento
            ObservableCollection<TurnoModel> seguimiento = this._TurnoRepository.GetTurnosTrancing(this._SelectedAsuntoTurno.IdAsunto) as ObservableCollection<TurnoModel>;

            seguimiento.ToList().ForEach(t =>
            {
                if (t.IdTurnoAnt == null)
                    t.CanCheck = false;

                if (t.IsAtendido)
                    t.FechaAtendidoTurnado = "Fecha de Atención";

                if (t.IsTurnado)
                    t.FechaAtendidoTurnado = "Fecha de Turnado";
            });

            this.SeguimientoTurnos = seguimiento;

            //para obtener los datos del expediente
            this.ExpedienteDocumento = this._ExpedienteRepository.GetExpediente(this._SelectedAsuntoTurno.Expediente.IdExpediente) as ObservableCollection<ExpedienteModel>;

            //para obtener el arbol
            this.TreeViewSeguimientoViewModel = new TreeViewSeguimientoViewModel(this._SelectedAsuntoTurno, this.Rol, null);

            this.TreeViewSeguimientoViewModel.Children.ToList()
                .ForEach(p =>
                {
                    if (!p.IsExpanded)
                        p.IsExpanded = true;
                });

            this.GetSplitDirectory();
        }

        public void GetSplitDirectory()
        {
            string nameFolder = ConfigurationManager.AppSettings["LocalDocsApp"].ToString();

            string appDirectory = System.IO.Directory.GetCurrentDirectory();
            string[] directory = System.IO.Directory.GetFileSystemEntries(appDirectory);

            foreach (string ruta in directory)
            {
                string[] _DocumentoPath = ruta.Split('\\');
                if (nameFolder == _DocumentoPath.Last())
                {
                    this.SuccessPath = ruta + "\\";
                    break;
                }
            }
        }

        private void GetRol()
        {
            this._Rol = this._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol;
        }

        private void GetUsuario()
        {
            this.Usuario = this._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario;
        }

        public void GetImprimirAsunto()
        {
            this.ImprimirAsunto = new AsuntoModel();
            this.ImprimirAsunto = this.SelectedAsuntoTurno;
            this.ImprimirAsunto.Turno = (from o in this.SeguimientoTurnos
                                         select o).First();

        }

        public void GetReadAsunto()
        {
            this.ReadAsunto = new AsuntoModel();
            this.ReadAsunto = this.SelectedAsuntoTurno;
            this.ReadAsunto.Turno = (from o in this.SeguimientoTurnos
                                     select o).First();

            this.SignatarioExterno = this._SignatarioExternoRepository.GetSignatariosExterno(this.SelectedAsuntoTurno.IdAsunto) as ObservableCollection<SignatarioExternoModel>;

            this.ReadAsunto.SignatarioExterno = this.SignatarioExterno;
        }

        #region METODOS DEL HILO

        public void SetOpenDoc()
        {
            this.Message = "Espere Abriendo documento ...";
            this._jobDone = false;
            t = new System.Timers.Timer(1000);
            t.Enabled = false;

            t.Elapsed += new System.Timers.ElapsedEventHandler(DlgDoc);

        }

        private string SearchDocumento(long idDocumento)
        {
            string resPathDoc = null;
            try
            {
                string pathDoc = this.SuccessPath;
                pathDoc = pathDoc + this.SelectedExpedienteDocumento.Documento.IdDocumento + "." + this.SelectedExpedienteDocumento.Documento.Extencion;

                if (File.Exists(pathDoc))
                    resPathDoc = pathDoc;
            }
            catch (Exception)
            {
                ;
            }
            return resPathDoc;
        }

        public void CierraDlg()
        {
            TrancingAsuntoTurnoReadViewModel.IsRunning = false;
            this.JobDone = true;
        }

        public void DlgDoc(Object sender, System.Timers.ElapsedEventArgs args)
        {

            this.t.Enabled = false;
            ((System.Timers.Timer)sender).Stop();
            this.OpenDoc();

        }

        public void DlgDescargaDoc(Object sender, System.Timers.ElapsedEventArgs args)
        {

            this.t.Enabled = false;
            ((System.Timers.Timer)sender).Stop();
            this.CierraDlg();

        }

        public void start()
        {
            this.JobDone = false;
            TrancingAsuntoTurnoReadViewModel.IsRunning = true;
            t.Enabled = true;
            t.Start();
        }

        public void OpenDoc()
        {
            if (this.SelectedExpedienteDocumento != null)
            {
                string ruta = this.SearchDocumento(this.SelectedExpedienteDocumento.Documento.IdDocumento);

                if (!String.IsNullOrEmpty(ruta))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = ruta;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                    this.CierraDlg();
                }
                else
                {
                    this.CierraDlg();
                    this.DownloadFile();
                }

            }
        }

        public void DownloadFile()
        {
            bool reponse = false;

            _Confirmation.Msg = "Archivo no se encuentra en la PC\n ¿ Desea Descargarlo ?";
            _Confirmation.Show();

            reponse = _Confirmation.Response;
            if (reponse)
            {
                _Download.Show(this);
            }

        }

        public void SetDownloadFile()
        {
            this.Message = "Descargando documento espere ...";
            this._jobDone = false;
            t = new System.Timers.Timer(1000);
            t.Enabled = false;

            t.Elapsed += new System.Timers.ElapsedEventHandler(DlgDescargaDoc);
            this.DescargaDocumento();
        }

        public void DescargaDocumento()
        {
            string pathDoc = this.SuccessPathServer;
            pathDoc = pathDoc + this.SelectedExpedienteDocumento.Documento.IdDocumento + "." + this.SelectedExpedienteDocumento.Documento.Extencion;

            if (File.Exists(pathDoc))
            {
                this.Descarga = new Uri(this.SuccessPathServer + this.SelectedExpedienteDocumento.Documento.IdDocumento + "." + this.SelectedExpedienteDocumento.Documento.Extencion);
            }
            
            //this.Descarga = new Uri(this.SuccessPathServer + this.SelectedExpedienteDocumento.Documento.IdDocumento + "." + this.SelectedExpedienteDocumento.Documento.Extencion);
            //SetOpenDoc();
        }
        #endregion

        public void GetAtendidoTurnado()
        {

            if (this.SelectedAsuntoTurno.IdStatusAsunto == 20130611180608439)
            {
                this.MsjAtencion = "ASUNTO FINALIZADO...";
            }
            else if(this.SelectedAsuntoTurno.Turno !=null)
            {
                if (this.SelectedAsuntoTurno.Turno.IsAtendido || this.SelectedAsuntoTurno.Turno.IsTurnado)
                    this.MsjAtencion = "TURNO ATENDIDO...";
            }
            else
                this.MsjAtencion = "TURNO DE SOLO LECTURA...";

        }
    }
}
