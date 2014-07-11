using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using GestorDocument.DAL;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using GestorDocument.ViewModel.TreeViewDireccion;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class TrancingAsuntoTurnoViewModel :ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private ITurno _TurnoRepository;
        public AsuntoNotificacionesViewModel _ParentAsunto;
        public IConfirmation _Confirmation;
        public IDownloadFile _Download;
        public bool BanderaAtender = false;

        public bool ISEmptyRespuesta
        {
            get { return _ISEmptyRespuesta; }
            set
            {
                _ISEmptyRespuesta = value;
                OnPropertyChanged(ISEmptyRespuestaPropertyName);
            }
        }
        private bool _ISEmptyRespuesta;
        public const string ISEmptyRespuestaPropertyName = "ISEmptyRespuesta";

        public bool ISEmptyComentario
        {
            get { return _ISEmptyComentario; }
            set
            {
                _ISEmptyComentario = value;
                OnPropertyChanged(ISEmptyComentarioPropertyName);
            }
        }
        private bool _ISEmptyComentario;
        public const string ISEmptyComentarioPropertyName = "ISEmptyComentario";


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

        #region SINCRONIZACION DE DOCUMENTOS
        // ***************************** ***************************** *****************************
        // Repository. SYNC_DOC
        private ISyncDocs _SyncDocsRepository;

        // SYNC_DOC. 
        public ObservableCollection<SyncDocsModel> SyncDocs
        {
            get { return _SyncDocs; }
            set
            {
                if (_SyncDocs != value)
                {
                    _SyncDocs = value;
                    OnPropertyChanged(SyncDocsPropertyName);
                }
            }
        }
        private ObservableCollection<SyncDocsModel> _SyncDocs;
        public const string SyncDocsPropertyName = "SyncDocs";

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

        #region ASUNTO

        public AsuntoModel Asunto
        {
            get { return _Asunto; }
            set
            {
                if (_Asunto != value)
                {
                    _Asunto = value;
                    OnPropertyChanged(AsuntoPropertyName);
                }
            }
        }
        private AsuntoModel _Asunto;
        public const string AsuntoPropertyName = "Asunto";

        #endregion

        #region TURNO

        public TurnoModel Turno
        {
            get { return _Turno; }
            set
            {
                if (_Turno != value)
                {
                    _Turno = value;
                    OnPropertyChanged(TurnoPropertyName);
                }
            }
        }
        private TurnoModel _Turno;
        public const string TurnoPropertyName = "Turno";

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

        #endregion

        #region EXPEDIENTE
        public ExpedienteModel Expediente
        {
            get { return _Expediente; }
            set
            {
                if (_Expediente != value)
                {
                    _Expediente = value;
                    OnPropertyChanged(ExpedientePropertyName);
                }
            }
        }
        private ExpedienteModel _Expediente;
        public const string ExpedientePropertyName = "Expediente";
        #endregion

        #region TREEVIEW, SEGUIMINETO_TURNO Y EXPEDIENTE_DOCUMENTO

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
        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el treview
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
        #endregion

        #region TURNADO
        // ***************************** ***************************** *****************************
        //TURNOS PARA LAS DEPENDENCIAS 
        public ObservableCollection<TurnoModel> Turnados
        {
            get { return _Turnados; }
            set
            {
                if (_Turnados != value)
                {
                    _Turnados = value;
                    OnPropertyChanged(TurnadosPropertyName);
                }
            }
        }
        private ObservableCollection<TurnoModel> _Turnados;
        public const string TurnadosPropertyName = "Turnados";
        #endregion

        #region DESTINATARIO
        
        // DESTINATARIO.
        private IDestinatario _DestinatarioRepository;
        public ObservableCollection<DestinatarioModel> Destinatario
        {
            get { return _Destinatario; }
            set
            {
                if (_Destinatario != value)
                {
                    _Destinatario = value;
                    OnPropertyChanged(DestinatarioPropertyName);
                }
            }
        }
        private ObservableCollection<DestinatarioModel> _Destinatario;
        public const string DestinatarioPropertyName = "Destinatario";

        public bool ISEmptyDestinatario
        {
            get { return _ISEmptyDestinatario; }
            set
            {
                _ISEmptyDestinatario = value;
                OnPropertyChanged(ISEmptyDestinatarioPropertyName);
            }
        }
        private bool _ISEmptyDestinatario;
        public const string ISEmptyDestinatarioPropertyName = "ISEmptyDestinatario";
        #endregion

        #region DOCUMENTOS
        // Repository. DOCMENTOS
        private IDocumentos _DocumentosRepository;
        // GRID DOCMENTOS
        public ObservableCollection<DocumentosModel> Documentos
        {
            get { return _Documentos; }
            set
            {
                if (_Documentos != value)
                {
                    _Documentos = value;
                    OnPropertyChanged(DocumentosPropertyName);
                }
            }
        }
        private ObservableCollection<DocumentosModel> _Documentos;
        public const string DocumentosPropertyName = "Documentos";

        #endregion

        #region NUEVOS DESTINATARIOS
        
        // DESTINATARIO.
        public ObservableCollection<DestinatarioModel> NewDestinatario
        {
            get { return _NewDestinatario; }
            set
            {
                if (_NewDestinatario != value)
                {
                    _NewDestinatario = value;
                    OnPropertyChanged(NewDestinatarioPropertyName);
                }
            }
        }
        private ObservableCollection<DestinatarioModel> _NewDestinatario;
        public const string NewDestinatarioPropertyName = "NewDestinatario";

        #endregion

        #region NUEVOS DOCUMENTOS
        // GRID DOCMENTOS
        public ObservableCollection<DocumentosModel> NewDocumentos
        {
            get { return _NewDocumentos; }
            set
            {
                if (_NewDocumentos != value)
                {
                    _NewDocumentos = value;
                    OnPropertyChanged(NewDocumentosPropertyName);
                }
            }
        }
        private ObservableCollection<DocumentosModel> _NewDocumentos;
        public const string NewDocumentosPropertyName = "NewDocumentos";
        #endregion

        #region BORRADO DESTINATARIO

        //BORRADO DESTINATARIO.
        public ObservableCollection<DestinatarioModel> DeleteDestinatario
        {
            get { return _DeleteDestinatario; }
            set
            {
                if (_DeleteDestinatario != value)
                {
                    _DeleteDestinatario = value;
                    OnPropertyChanged(DeleteDestinatarioPropertyName);
                }
            }
        }
        private ObservableCollection<DestinatarioModel> _DeleteDestinatario;
        public const string DeleteDestinatarioPropertyName = "DeleteDestinatario";
        #endregion

        #region BORRADO  DOCUMENTOS
        // GRID DOCMENTOS
        public ObservableCollection<DocumentosModel> DeleteDocumentos
        {
            get { return _DeleteDocumentos; }
            set
            {
                if (_DeleteDocumentos != value)
                {
                    _DeleteDocumentos = value;
                    OnPropertyChanged(DeleteDocumentosPropertyName);
                }
            }
        }
        private ObservableCollection<DocumentosModel> _DeleteDocumentos;
        public const string DeleteDocumentosPropertyName = "DeleteDocumentos";

        #endregion 

        #region BOTONES PARA ELIMINAR  DESTINATARIOS Y DOCUMENTOS
        // ***************************** ***************************** *****************************
        // ELiminar Destinatarios.
        public RelayCommand DeleteDestinatariosCommand
        {
            get
            {
                if (_DeleteDestinatariosCommand == null)
                {
                    _DeleteDestinatariosCommand = new RelayCommand(p => this.AttemptDeleteDestinatarios(), p => this.CanDeleteDestinatarios());
                }

                return _DeleteDestinatariosCommand;
            }

        }
        private RelayCommand _DeleteDestinatariosCommand;
        public bool CanDeleteDestinatarios()
        {
            bool _CanDelete = false;

            foreach (DestinatarioModel p in this.Destinatario)
            {
                if (p.IsChecked)
                {
                    _CanDelete = true;
                    break;

                }
            }
            return _CanDelete;
        }
        public void AttemptDeleteDestinatarios()
        {
            //TODO : Delete to database
            try
            {
                var query = (from o in this.Destinatario
                             where o.IsChecked == true
                             select o).ToList();
                if (query.Count != 0)
                {
                    (from o in query
                     where o.IsChecked == true
                     select o).ToList().ForEach(o => this.DeleteDestinatario.Add(o));
                }

                (from o in this.Destinatario
                 where o.IsChecked == true
                 select o).ToList().ForEach(o => this.Destinatario.Remove(o));
            }
            catch (Exception)
            {
            }
        }
        // ***************************** ***************************** *****************************
        // ELiminar Documentos.
        public RelayCommand DeleteDocumentosCommand
        {
            get
            {
                if (_DeleteDocumentosCommand == null)
                {
                    _DeleteDocumentosCommand = new RelayCommand(p => this.AttemptDeleteDocumentos(), p => this.CanDeleteDocumentos());
                }

                return _DeleteDocumentosCommand;
            }

        }
        private RelayCommand _DeleteDocumentosCommand;
        public bool CanDeleteDocumentos()
        {
            bool _CanDelete = false;

            foreach (DocumentosModel p in this.Documentos)
            {
                if (p.IsCheckedDelete)
                {
                    _CanDelete = true;
                    break;

                }
            }
            return _CanDelete;
        }
        public void AttemptDeleteDocumentos()
        {
            //TODO : Delete to database
            try
            {
                var query = (from o in this.Documentos
                             where o.IsCheckedDelete == true
                             select o).ToList();
                if (query.Count != 0)
                {
                    (from o in query
                     where o.IsCheckedDelete == true
                     select o).ToList().ForEach(o => this.DeleteDocumentos.Add(o));
                }

                (from o in this.Documentos
                 where o.IsCheckedDelete == true
                 select o).ToList().ForEach(o => this.Documentos.Remove(o));
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region BOTON PARA GUARDAR_TURNAR , GUARDAR  Y ATENDER
        // ***************************** ***************************** *****************************
        // boton de Guardar  
        public RelayCommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(p => this.AttemptSave(), p => this.CanSave());
                }
                return _SaveCommand;
            }
        }
        private RelayCommand _SaveCommand;
        public bool CanSave()
        {
            bool _CanSave = true;
            return _CanSave;
        }
        public void AttemptSave()
        {
            
            this._Confirmation.Msg = "! Esta seguro de guardar ¡";

            this._Confirmation.Show();


            if (this._Confirmation.Response)
            {
                this.GetSave();
                //REFERESCAR EL GRID
                this._ParentAsunto._PantallaInicioViewModel.LoadInfoGrid();
            }
            

        }

        //boton de Guardar y Turnar.
        public RelayCommand SaveTurnarCommand
        {
            get
            {
                if (_SaveTurnarCommand == null)
                {
                    _SaveTurnarCommand = new RelayCommand(p => this.AttemptTurnar(), p => this.CanTurnar());
                }
                return _SaveTurnarCommand;
            }
        }
        private RelayCommand _SaveTurnarCommand;
        public bool CanTurnar()
        {
            bool _CanSave = false;

            if (this.Destinatario.Count != 0)
            {
                _CanSave = true;
            }
            return _CanSave;
        }
        public void AttemptTurnar()
        {
            this._Confirmation.Msg = "! Esta seguro de Turnar ¡";

            this._Confirmation.Show();

            if (this._Confirmation.Response)
            {
                this.GetSaveTurnar();
                //REFERESCAR EL GRID
                this._ParentAsunto._PantallaInicioViewModel.LoadInfoGrid();
            }
            
        }

        //boton de atender.
        public RelayCommand SaveAtenderCommand
        {
            get
            {
                if (_SaveAtenderCommand == null)
                {
                    _SaveAtenderCommand = new RelayCommand(p => this.AttemptAtender(), p => this.CanAtender());
                }
                return _SaveAtenderCommand;
            }
        }
        private RelayCommand _SaveAtenderCommand;
        public bool CanAtender()
        {
            bool _CanSave = false;

            if (this.Destinatario.Count ==0)
            {
                _CanSave = true;
            }
            return _CanSave;
        }
        public void AttemptAtender()
        {
            this._Confirmation.Msg = "!Esta Seguro de Atender el turno¡";

            this._Confirmation.Show();

            if (this._Confirmation.Response)
            {
                this.GetSaveAtender();
                //REFERESCAR EL GRID
                this._ParentAsunto._PantallaInicioViewModel.LoadInfoGrid();
            }

        }
        #endregion

        #region BOTON PARA VALIDAR GUARDAR_TURNAR  Y ATENDER
        
        //boton de Turnar.
        public RelayCommand ValidarTurnarCommand
        {
            get
            {
                if (_ValidarTurnarCommand == null)
                {
                    _ValidarTurnarCommand = new RelayCommand(p => this.AttemptValidarTurnar(), p => this.CanValidarTurnar());
                }
                return _ValidarTurnarCommand;
            }
        }
        private RelayCommand _ValidarTurnarCommand;
        public bool CanValidarTurnar()
        {
            bool _CanSave = false;

            if (this.Destinatario.Count != 0 && !string.IsNullOrWhiteSpace(this.Turno.Comentario))
            {
                _CanSave = true;
            }

            if (this.Destinatario.Count != 0)
                this.ISEmptyDestinatario = false;
            else
                this.ISEmptyDestinatario = true;

            if (!string.IsNullOrWhiteSpace(this.Turno.Comentario))
                this.ISEmptyComentario = false;
            else
                this.ISEmptyComentario = true;


            return _CanSave;
        }
        public void AttemptValidarTurnar()
        {
            //solo valida
        }

        //boton de atender
        public RelayCommand ValidarAtenderCommand
        {
            get
            {
                if (_ValidarAtenderCommand == null)
                {
                    _ValidarAtenderCommand = new RelayCommand(p => this.AttemptAtenderValidar(), p => this.CanAtenderValidar());
                }
                return _ValidarAtenderCommand;
            }
        }
        private RelayCommand _ValidarAtenderCommand;
        public bool CanAtenderValidar()
        {
            bool _CanSave = false;

            if (!string.IsNullOrWhiteSpace(this.Turno.Respuesta))
            {
                _CanSave = true;
                this.ISEmptyRespuesta = false;
            }
            else
                this.ISEmptyRespuesta = true;

            return _CanSave;
        }
        public void AttemptAtenderValidar()
        {
            //solo valida
        }
        #endregion

        #region BOTON  REGRESAR
        // ***************************** ***************************** *****************************
        // boton de guardar avance de asunto.
        public RelayCommand RegresarCommand
        {
            get
            {
                if (_RegresarCommand == null)
                {
                    _RegresarCommand = new RelayCommand(p => this.AttemptRegresar(), p => this.CanRegresar());
                }
                return _RegresarCommand;
            }
        }
        private RelayCommand _RegresarCommand;
        public bool CanRegresar()
        {
            bool _CanSave = true;
            //solo guarda
            return _CanSave;
        }
        public void AttemptRegresar()
        {

            this._Confirmation.Msg = "! Esta seguro de salir ¡ \n Guarde antes de salir.";

            this._Confirmation.Show();

            this._Confirmation.Msg = null;


        }
        #endregion
        
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

        public TipoUnidadNormativaModel TipoUnidadNormativa
        {
            get { return _TipoUnidadNormativa; }
            set
            {
                if (_TipoUnidadNormativa != value)
                {
                    _TipoUnidadNormativa = value;
                    OnPropertyChanged(TipoUnidadNormativaPropertyName);
                }
            }
        }
        private TipoUnidadNormativaModel _TipoUnidadNormativa;
        public const string TipoUnidadNormativaPropertyName = "TipoUnidadNormativa";

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

        #region CONSTRUCTOR

        public TrancingAsuntoTurnoViewModel(AsuntoNotificacionesViewModel asuntoNotificacionesViewModel, AsuntoModel selectedAsuntoTurno, IConfirmation confirmation, IDownloadFile download)
        {
            this._ParentAsunto = asuntoNotificacionesViewModel;
            this._SelectedAsuntoTurno = selectedAsuntoTurno;
            this._Confirmation = confirmation;
            this._Download = download;
            this.TipoUnidadNormativa = this._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol.Organigrama.TipoUnidadNormativa;
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
            this._ExpedienteRepository = new GestorDocument.DAL.Repository.ExpedienteRepository();
            this._DestinatarioRepository = new GestorDocument.DAL.Repository.DestinatarioRepository();
            this._DocumentosRepository = new GestorDocument.DAL.Repository.DocumentosRepository();
            this._Turnos = new ObservableCollection<TurnoModel>();
            this._SeguimientoTurnos = new ObservableCollection<TurnoModel>();
            this._SyncDocsRepository = new GestorDocument.DAL.Repository.SyncDocsRepository();
            this._SeguimientoTurnos = new ObservableCollection<TurnoModel>();
            this._SignatarioExternoRepository = new GestorDocument.DAL.Repository.SignatarioExternoRepository();
            this.SignatarioExterno = new ObservableCollection<SignatarioExternoModel>();
            this._SuccessPathServer = ConfigurationManager.AppSettings["ServerDocsFolder"].ToString();

            this.GetRol();

            this.GetUsuario();

            this.LoadInfoGrid();

            this.GetAsunto();

            this.GetTurno();

            this.GetExpediente();
        }

        #endregion

        #region METODOS

        public void LoadInfoGrid()
        {
            this.Destinatario = this._DestinatarioRepository.GetDestinatarios(this._SelectedAsuntoTurno.Turno.IdTurno) as ObservableCollection<DestinatarioModel>;
            this.Documentos = this._DocumentosRepository.GetDocumentos(this._SelectedAsuntoTurno.Turno.IdTurno) as ObservableCollection<DocumentosModel>;
            this.DeleteDestinatario = new ObservableCollection<DestinatarioModel>();
            this.DeleteDocumentos = new ObservableCollection<DocumentosModel>();
            this.NewDestinatario = new ObservableCollection<DestinatarioModel>();
            this.NewDocumentos = new ObservableCollection<DocumentosModel>();
            this.Turnados = new ObservableCollection<TurnoModel>();
            this.SyncDocs = new ObservableCollection<SyncDocsModel>();

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
            this.TreeViewSeguimientoViewModel = new TreeViewSeguimientoViewModel(this._SelectedAsuntoTurno,this.Rol, null);

            this.TreeViewSeguimientoViewModel.Children.ToList()
                .ForEach(p =>
                {
                    if (!p.IsExpanded)
                        p.IsExpanded = true;
                });

            this.GetSplitDirectory();
        }

        public void GetAsunto()
        {
            this._Asunto = new AsuntoModel()
            {
                IdAsunto = this._SelectedAsuntoTurno.IdAsunto
                ,
                FechaCreacion = this._SelectedAsuntoTurno.FechaCreacion
                ,
                FechaRecibido = this._SelectedAsuntoTurno.FechaRecibido
                ,
                FechaDocumento = this._SelectedAsuntoTurno.FechaDocumento
                ,
                ReferenciaDocumento = this._SelectedAsuntoTurno.ReferenciaDocumento
                ,
                Titulo = this._SelectedAsuntoTurno.Titulo
                ,
                Descripcion = this._SelectedAsuntoTurno.Descripcion
                ,
                Alcance = this._SelectedAsuntoTurno.Alcance
                ,
                Ubicacion = (this._SelectedAsuntoTurno.Ubicacion != null) ? new UbicacionModel
                {
                    IdUbicacion = (long)this._SelectedAsuntoTurno.IdUbicacion
                    ,
                    UbicacionName = this._SelectedAsuntoTurno.Ubicacion.UbicacionName
                } : null
                ,
                Instruccion = (this._SelectedAsuntoTurno.Instruccion != null) ? new InstruccionModel
                {
                    IdInstruccion = (long)this._SelectedAsuntoTurno.IdInstruccion
                    ,
                    InstruccionName = this._SelectedAsuntoTurno.Instruccion.InstruccionName
                } : null
                ,
                Prioridad = (this._SelectedAsuntoTurno.Prioridad != null) ? new PrioridadModel
                {
                    IdPrioridad = (long)this._SelectedAsuntoTurno.IdPrioridad
                    ,
                    PrioridadName = this._SelectedAsuntoTurno.Prioridad.PrioridadName
                } : null
                ,
                StatusAsunto = new StatusAsuntoModel
                {
                    IdStatusAsunto = (long)this._SelectedAsuntoTurno.IdStatusAsunto
                    ,
                    StatusName = this._SelectedAsuntoTurno.StatusAsunto.StatusName
                }
                ,
                FechaVencimiento = this._SelectedAsuntoTurno.FechaVencimiento
                ,
                Folio = this._SelectedAsuntoTurno.Folio
            };
        }

        public void GetTurno()
        {
            this.Turno = new TurnoModel()
            {
                IdTurnoAnt = this._SelectedAsuntoTurno.Turno.IdTurnoAnt
                ,
                IdTurno = this._SelectedAsuntoTurno.Turno.IdTurno
                ,
                FechaCreacion = this._SelectedAsuntoTurno.Turno.FechaCreacion
                ,
                FechaEnvio = this._SelectedAsuntoTurno.Turno.FechaEnvio
                ,
                IsActive = this._SelectedAsuntoTurno.Turno.IsActive
                ,
                IdAsunto = this._SelectedAsuntoTurno.Turno.IdAsunto
                ,
                IdStatusTurno = this._SelectedAsuntoTurno.Turno.IdStatusTurno
                ,
                IdRol = this._SelectedAsuntoTurno.Turno.IdRol
                ,
                IdUsuario = this._SelectedAsuntoTurno.Turno.IdUsuario
                ,
                IsAtendido = this._SelectedAsuntoTurno.Turno.IsAtendido
                ,
                IsTurnado = this._SelectedAsuntoTurno.Turno.IsTurnado
                ,
                IsBorrador = this._SelectedAsuntoTurno.Turno.IsBorrador
                ,
                Comentario = this.SelectedAsuntoTurno.Turno.Comentario
                ,
                Respuesta = this.SelectedAsuntoTurno.Turno.Respuesta
            };
        }

        public void GetTurnado()
        {
            long IdTurno = new UNID().getNewUNID();
            int con = 0;
            foreach (DestinatarioModel destinatario in this.Destinatario)
            {
                con = con + 1;
                
                TurnoModel turno = new TurnoModel()
                {
                    IdTurnoAnt = this.Turno.IdTurno
                    ,
                    IdTurno = IdTurno + con
                    ,
                    FechaCreacion = DateTime.Now
                    ,
                    IsActive = true
                    ,
                    IdAsunto = this.Asunto.IdAsunto
                    ,
                    IdStatusTurno = 1
                    ,
                    IdRol = destinatario.IdRol
                    ,
                    IdUsuario = this.Usuario.IdUsuario
                    ,
                    IsAtendido = false
                    ,
                    IsTurnado = false
                    ,
                    IsBorrador = true

                };

                this.Turnados.Add(turno);
            }
        }

        public void GetExpediente()
        {
            this.Expediente = new ExpedienteModel()
            {
                IdExpediente = this._SelectedAsuntoTurno.Expediente.IdExpediente
                ,
                IdAsunto = this._SelectedAsuntoTurno.Expediente.IdAsunto
                ,
                Asunto = this.Asunto
                ,
                IsActive = this._SelectedAsuntoTurno.Expediente.IsActive
            };
        }

        public void GetDocumentos()
        {
            foreach (DocumentosModel doc in this.Documentos)
            {
                if (doc.IdExpediente == 0 && doc.IdTurno == null)
                {
                    doc.IdExpediente = this.Expediente.IdExpediente;
                    doc.IdTurno = this.Turno.IdTurno;
                    doc.IdTipoDocumento = doc.TipoDocumento.IdTipoDocumento;

                    this.NewDocumentos.Add(doc);
                }
            }
        }

        public void GetDestinatarios()
        {
            long IdDestinatario = new UNID().getNewUNID();
            int con = 0;
            foreach (DestinatarioModel destinatario in this.Destinatario)
            {
                con = con + 1;
                if (destinatario.IdDestinatario == 0)
                {
                    DestinatarioModel newDes = new DestinatarioModel()
                    {
                        IdDestinatario = IdDestinatario + con
                        ,
                        IdTurno = this.Turno.IdTurno
                        ,
                        IdRol = destinatario.IdRol
                        ,
                        IsPrincipal = true
                        ,
                        IsActive = true
                    };
                    this.NewDestinatario.Add(newDes);
                }
            }
        }

        public void GetDeleteDocumentos()
        {
            foreach (DocumentosModel doc in this.DeleteDocumentos)
                File.Delete(this.SuccessPath + doc.IdDocumento + "." + doc.Extencion);
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

        public void GetSave()
        {
            //insertamos y borramos en la tabla de relacion  REL_DESTINATARIO
            this.GetDestinatarios();

            this._TurnoRepository.UpdateTurno(this.Turno);

            if (this.DeleteDestinatario.Count != 0)
                this._DestinatarioRepository.DeleteDestinatario(this.DeleteDestinatario);
            if (this.NewDestinatario.Count != 0)
                this._DestinatarioRepository.InsertDestinatario(this.NewDestinatario);

            //insertamos y borramos en la tabla de relacion  GET_DOCUMENTOS
            this.GetDocumentos();

            if (this.DeleteDocumentos.Count != 0)
            {
                this._DocumentosRepository.DeleteDocumentos(this.DeleteDocumentos);
                this.GetDeleteDocumentos();
            }

            if (this.NewDocumentos.Count != 0)
            {
                this._DocumentosRepository.InsertDocumentos(this.NewDocumentos);
                //llenado de la tabla SYNC_DOC para la sincronizacion de  documento
                this.GetSyncDocs();
                this._SyncDocsRepository.InsertSyncDocs(this._SyncDocs);
            }
        }

        private void GetSaveTurnar()
        {
            this.GetSave();

            //guardar en la tabla de  GET_TURNO y cambia la bandera de isTurnado a true
            this.Turno.IsTurnado = true;
            this.Turno.FechaEnvio = DateTime.Now;
            this.Turno.IsBorrador = false;
            this.Turno.IdStatusTurno = 2;
            //cuando se turna se borra la respuesta
            this.Turno.Respuesta = null;
            this._TurnoRepository.UpdateTurno(this.Turno);

            //Generamos y guardamos los turnos a las UNIDADES NORMATIVAS
            this.GetTurnado();
            this._TurnoRepository.InsertTurno(this._Turnados);

        }

        public void GetSaveAtender()
        {
            this.GetSave();

            //guardar en la tabla de  GET_TURNO y cambia la bandera de isTurnado a true
            this.Turno.IsAtendido = true;
            this.Turno.FechaEnvio = DateTime.Now;
            this.Turno.IsBorrador = false;
            this.Turno.IdStatusTurno = 3;
            this.Turno.Comentario = null;
            this._TurnoRepository.UpdateTurno(this.Turno);
            // CUANDO SE ATIENDE SE BORRAN EL COMENTARIO Y LOS DESTINATARIOS
            if (this.Destinatario.Count != 0)
                this._DestinatarioRepository.DeleteDestinatario(this.Destinatario);
            if (this.NewDestinatario.Count != 0)
                this._DestinatarioRepository.DeleteDestinatario(this.NewDestinatario);

        }

        private void GetRol()
        {
            this._Rol = this._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol;
        }

        private void GetUsuario()
        {
            this.Usuario = this._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario;
        }

        public void GetSyncDocs()
        {
            foreach (DocumentosModel doc in this.NewDocumentos)
            {
                SyncDocsModel syncDoc = new SyncDocsModel()
                {
                    IdDocumento = doc.IdDocumento
                    ,
                    StatusDoc = "PENDIENTE"
                    ,
                    BanderaStatus = false
                    ,
                    Extencion = doc.Extencion
                };

                this.SyncDocs.Add(syncDoc);
            }
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
        #endregion

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
            TrancingAsuntoTurnoViewModel.IsRunning = false;
            this.JobDone = true;
        }

        public void DlgDoc(Object sender, System.Timers.ElapsedEventArgs args)
        {

            this.t.Enabled = false;
            ((System.Timers.Timer)sender).Stop();
            this.OpenDoc();

        }

        public void start()
        {
            this.JobDone = false;
            TrancingAsuntoTurnoViewModel.IsRunning = true;
            t.Enabled = true;
            t.Start();
        }

        public void DlgDescargaDoc(Object sender, System.Timers.ElapsedEventArgs args)
        {

            this.t.Enabled = false;
            ((System.Timers.Timer)sender).Stop();
            this.CierraDlg();

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
    } 
}
