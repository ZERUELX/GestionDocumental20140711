using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.DAL;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;
using System.IO;
using System.Configuration;
using System.ComponentModel;

namespace GestorDocument.ViewModel
{
    public class AsuntoModViewModel : ViewModelBase
    {
        public IConfirmation _Confirmation;

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

        #region Propiedades para ocultar
        public bool IsCheckedExterno
        {
            get { return _IsCheckedExterno; }
            set
            {
                if (_IsCheckedExterno != value)
                {
                    _IsCheckedExterno = value;
                    this.IsEnable();
                    OnPropertyChanged(IsCheckedExternoPropertyName);
                }
            }
        }
        private bool _IsCheckedExterno;
        public const string IsCheckedExternoPropertyName = "IsCheckedExterno";

        public bool IsEnabledExterno
        {
            get { return _IsEnabledExterno; }
            set
            {
                if (_IsEnabledExterno != value)
                {
                    _IsEnabledExterno = value;
                    OnPropertyChanged(IsEnabledExternoPropertyName);
                }
            }
        }
        protected bool _IsEnabledExterno;
        public const string IsEnabledExternoPropertyName = "IsEnabledExterno";

        public bool IsSelecedExterno
        {
            get { return _IsSelecedExterno; }
            set
            {
                if (_IsSelecedExterno != value)
                {
                    _IsSelecedExterno = value;
                    OnPropertyChanged(IsSelecedExternoPropertyName);
                }
            }
        }
        private bool _IsSelecedExterno;
        public const string IsSelecedExternoPropertyName = "IsSelecedExterno";

        public bool IsCheckedInterno
        {
            get { return _IsCheckedInterno; }
            set
            {
                if (_IsCheckedInterno != value)
                {
                    _IsCheckedInterno = value;
                    this.IsEnable();
                    OnPropertyChanged(IsCheckedInternoPropertyName);
                }
            }
        }
        private bool _IsCheckedInterno;
        public const string IsCheckedInternoPropertyName = "IsCheckedInterno";

        public bool IsEnabledInterno
        {
            get { return _IsEnabledInterno; }
            set
            {
                if (_IsEnabledInterno != value)
                {
                    _IsEnabledInterno = value;
                    OnPropertyChanged(IsEnabledInternoPropertyName);
                }
            }
        }
        protected bool _IsEnabledInterno;
        public const string IsEnabledInternoPropertyName = "IsEnabledInterno";

        public bool IsSelecedInterno
        {
            get { return _IsSelecedInterno; }
            set
            {
                if (_IsSelecedInterno != value)
                {
                    _IsSelecedInterno = value;
                    OnPropertyChanged(IsSelecedInternoPropertyName);
                }
            }
        }
        private bool _IsSelecedInterno;
        public const string IsSelecedInternoPropertyName = "IsSelecedInterno";
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

        #region ASUNTO Y TURNO
        // ***************************** ***************************** *****************************
        // Repository. ASUNTO
        private IAsunto _AsuntoRepository;
        public AsuntoViewModel _ParentAsunto;
        private AsuntoModel _P;

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

        // ***************************** ***************************** *****************************
        // Repository. TURNO
        private ITurno _TurnoRepository;

        //TURNO PARA OFICIALIA DE PARTES
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

        #region COMBOS
        // ***************************** ***************************** *****************************
        // COMBO UBICACION.
        private IUbicacion _UbicacionRepository;
        public ObservableCollection<UbicacionModel> Ubicacions
        {
            get { return _Ubicacions; }
            set
            {
                if (_Ubicacions != value)
                {
                    _Ubicacions = value;
                    OnPropertyChanged(UbicacionsPropertyName);
                }
            }
        }
        private ObservableCollection<UbicacionModel> _Ubicacions;
        public const string UbicacionsPropertyName = "Ubicacions";

        // COMBO INSTRUCCION.
        private IInstruccion _InstruccionRepository;
        public ObservableCollection<InstruccionModel> Instruccions
        {
            get { return _Instruccions; }
            set
            {
                if (_Instruccions != value)
                {
                    _Instruccions = value;
                    OnPropertyChanged(InstruccionsPropertyName);
                }
            }
        }
        private ObservableCollection<InstruccionModel> _Instruccions;
        public const string InstruccionsPropertyName = "Instruccions";

        // COMBO PRIORIDAD.
        private IPrioridad _PrioridadRepository;
        public ObservableCollection<PrioridadModel> Prioridads
        {
            get { return _Prioridads; }
            set
            {
                if (_Prioridads != value)
                {
                    _Prioridads = value;
                    OnPropertyChanged(PrioridadsPropertyName);
                }
            }
        }
        private ObservableCollection<PrioridadModel> _Prioridads;
        public const string PrioridadsPropertyName = "Prioridads";

        // COMBO STATUSASUNTO.
        private IStatusAsunto _StatusAsuntoRepository;
        public ObservableCollection<StatusAsuntoModel> StatusAsuntos
        {
            get { return _StatusAsuntos; }
            set
            {
                if (_StatusAsuntos != value)
                {
                    _StatusAsuntos = value;
                    OnPropertyChanged(StatusAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<StatusAsuntoModel> _StatusAsuntos;
        public const string StatusAsuntosPropertyName = "StatusAsuntos";

        #endregion

        #region NUEVA INSTRUCCION
        public InstruccionModel Instruccion
        {
            get { return _Instruccion; }
            set
            {
                if (_Instruccion != value)
                {
                    _Instruccion = value;
                    OnPropertyChanged(InstruccionPropertyName);
                }
            }
        }
        private InstruccionModel _Instruccion;
        public const string InstruccionPropertyName = "Instruccion";

        public InstruccionModel CheckSave
        {
            get { return _CheckSave; }
            set
            {
                if (_CheckSave != value)
                {
                    _CheckSave = value;
                    OnPropertyChanged(CheckSavePropertyName);
                }
            }
        }
        private InstruccionModel _CheckSave;
        public const string CheckSavePropertyName = "CheckSave";
        #endregion

        #region  SIGNATARIO, SIGNATARIO_EXTERNO, DESTINATARIO y DESTINATARIO_CCP
        // SIGNATARIO. 
        private ISignatario _SignatarioRepository;
        public ObservableCollection<SignatarioModel> Signatario
        {
            get { return _Signatario; }
            set
            {
                if (_Signatario != value)
                {
                    _Signatario = value;
                    OnPropertyChanged(SignatarioPropertyName);
                }
            }
        }
        private ObservableCollection<SignatarioModel> _Signatario;
        public const string SignatarioPropertyName = "Signatario";

        public bool ISEmptySignatario
        {
            get { return _ISEmptySignatario; }
            set
            {
                _ISEmptySignatario = value;
                OnPropertyChanged(ISEmptySignatarioPropertyName);
            }
        }
        private bool _ISEmptySignatario;
        public const string ISEmptySignatarioPropertyName = "ISEmptySignatario";
        // SIGNATARIO EXTERNO. 
        private ISignatarioExterno _SignatarioExternoRepository;
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

        public bool ISEmptySignatarioExterno
        {
            get { return _ISEmptySignatarioExterno; }
            set
            {
                _ISEmptySignatarioExterno = value;
                OnPropertyChanged(ISEmptySignatarioExternoPropertyName);
            }
        }
        private bool _ISEmptySignatarioExterno;
        public const string ISEmptySignatarioExternoPropertyName = "ISEmptySignatarioExterno";
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
        // DESTINATARIO CCP.
        private IDestinatarioCcp _DestinatarioCcpRepository;
        public ObservableCollection<DestinatarioCcpModel> DestinatarioCcp
        {
            get { return _DestinatarioCcp; }
            set
            {
                if (_DestinatarioCcp != value)
                {
                    _DestinatarioCcp = value;
                    OnPropertyChanged(DestinatarioCcpPropertyName);
                }
            }
        }
        private ObservableCollection<DestinatarioCcpModel> _DestinatarioCcp;
        public const string DestinatarioCcpPropertyName = "DestinatarioCcp";
        #endregion

        #region BORRADO SIGNATARIO, SIGNATARIO_EXTERNO ,DESTINATARIO y DESTINATARIO_CCP

        // BORRADO SIGNATARIO. 
        public ObservableCollection<SignatarioModel> DeleteSignatario
        {
            get { return _DeleteSignatario; }
            set
            {
                if (_DeleteSignatario != value)
                {
                    _DeleteSignatario = value;
                    OnPropertyChanged(DeleteSignatarioPropertyName);
                }
            }
        }
        private ObservableCollection<SignatarioModel> _DeleteSignatario;
        public const string DeleteSignatarioPropertyName = "DeleteSignatario";

        // BORRADO SIGNATARIO_EXTERNO. 
        public ObservableCollection<SignatarioExternoModel> DeleteSignatarioExterno
        {
            get { return _DeleteSignatarioExterno; }
            set
            {
                if (_DeleteSignatarioExterno != value)
                {
                    _DeleteSignatarioExterno = value;
                    OnPropertyChanged(DeleteSignatarioExternoPropertyName);
                }
            }
        }
        private ObservableCollection<SignatarioExternoModel> _DeleteSignatarioExterno;
        public const string DeleteSignatarioExternoPropertyName = "DeleteSignatarioExterno";

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

        //BORRADO DESTINATARIO CCP.
        public ObservableCollection<DestinatarioCcpModel> DeleteDestinatarioCcp
        {
            get { return _DeleteDestinatarioCcp; }
            set
            {
                if (_DeleteDestinatarioCcp != value)
                {
                    _DeleteDestinatarioCcp = value;
                    OnPropertyChanged(DeleteDestinatarioCcpPropertyName);
                }
            }
        }
        private ObservableCollection<DestinatarioCcpModel> _DeleteDestinatarioCcp;
        public const string DeleteDestinatarioCcpPropertyName = "DeleteDestinatarioCcp";
        #endregion

        #region NUEVOS  SIGNATARIO,SIGNATARIO_EXTERNO, DESTINATARIOS y DESTINATARIO_CCP
        // SIGNATARIO. 
        public ObservableCollection<SignatarioModel> NewSignatario
        {
            get { return _NewSignatario; }
            set
            {
                if (_NewSignatario != value)
                {
                    _NewSignatario = value;
                    OnPropertyChanged(NewSignatarioPropertyName);
                }
            }
        }
        private ObservableCollection<SignatarioModel> _NewSignatario;
        public const string NewSignatarioPropertyName = "NewSignatario";

        // SIGNATARIO_EXTERNO. 
        public ObservableCollection<SignatarioExternoModel> NewSignatarioExterno
        {
            get { return _NewSignatarioExterno; }
            set
            {
                if (_NewSignatarioExterno != value)
                {
                    _NewSignatarioExterno = value;
                    OnPropertyChanged(NewSignatarioExternoPropertyName);
                }
            }
        }
        private ObservableCollection<SignatarioExternoModel> _NewSignatarioExterno;
        public const string NewSignatarioExternoPropertyName = "NewSignatarioExterno";

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

        // DESTINATARIO CCP.
        public ObservableCollection<DestinatarioCcpModel> NewDestinatarioCcp
        {
            get { return _NewDestinatarioCcp; }
            set
            {
                if (_NewDestinatarioCcp != value)
                {
                    _NewDestinatarioCcp = value;
                    OnPropertyChanged(NewDestinatarioCcpPropertyName);
                }
            }
        }
        private ObservableCollection<DestinatarioCcpModel> _NewDestinatarioCcp;
        public const string NewDestinatarioCcpPropertyName = "NewDestinatarioCcp";

        #endregion

        #region  DOCUMENTOS
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

        public bool ISEmptyDocs
        {
            get { return _ISEmptyDocs; }
            set
            {
                _ISEmptyDocs = value;
                OnPropertyChanged(ISEmptyDocsPropertyName);
            }
        }
        private bool _ISEmptyDocs;
        public const string ISEmptyDocsPropertyName = "ISEmptyDocs";

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

        #region EXPEDIENTE
        //EXPEDIENTE
        private IExpediente _ExpedienteRepository;
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

        #region BOTON PARA GUARDAR ASUNTO y TURNAR
        // ***************************** ***************************** *****************************
        // boton de guardar avance de asunto.
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

        /// <summary>
        /// Can de SaveCommand. Regresa true si cumple la condicion, de lo contrario False.
        /// </summary>
        /// <returns></returns>
        public bool CanSave()
        {
            bool _CanSave = true;
            //SOLO GUARDA
            return _CanSave;
        }

        /// <summary>
        /// Attempt de SaveCommand(Se ejecuta si cumple la condicion).
        /// </summary>
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

        //boton de guardar asunto y turnar.
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
            bool _CanSave = true;
            //SOLO GUARDA
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
        #endregion

        #region BOTON PARA VALIDAR EL ASUNTO Y TURNAR
        // boton para validar avance de asunto.
        public RelayCommand ValidarAsuntoCommand
        {
            get
            {
                if (_ValidarAsuntoCommand == null)
                {
                    _ValidarAsuntoCommand = new RelayCommand(p => this.AttemptValidarAsunto(), p => this.CanValidarAsunto());
                }
                return _ValidarAsuntoCommand;
            }
        }
        private RelayCommand _ValidarAsuntoCommand;
        public bool CanValidarAsunto()
        {
            bool _CanSave = false;

            if ((!String.IsNullOrWhiteSpace( this._Asunto.Titulo)) && (!String.IsNullOrWhiteSpace(this._Asunto.Descripcion)))
            {
                _CanSave = true;
            }

            //solo para validar cuando se ingreso un documento
            if (this.Documentos.Count == 0)
                this.ISEmptyDocs = true;
            else
                this.ISEmptyDocs = false;
            //solo para validar cuando se ingreso un signatario
            if (this.Signatario.Count == 0)
                this.ISEmptySignatario = true;
            else
                this.ISEmptySignatario = false;
            //solo para validar cuando se ingreso un destinatario interno
            if (this.Destinatario.Count == 0)
                this.ISEmptyDestinatario = true;
            else
                this.ISEmptyDestinatario = false;
            //solo para validar cuando se ingreso un destinatario externo
            if (this.SignatarioExterno.Count == 0)
                this.ISEmptySignatarioExterno = true;
            else
                this.ISEmptySignatarioExterno = false;

            return _CanSave;
        }
        public void AttemptValidarAsunto()
        {
            //solo valida
        }

        //boton de guardar asunto y turnar.
        public RelayCommand ValidarTurnarCommand
        {
            get
            {
                if (_ValidarTurnarCommand == null)
                {
                    _ValidarTurnarCommand = new RelayCommand(p => this.AttemptValidaTurnar(), p => this.CanValidaTurnar());
                }
                return _ValidarTurnarCommand;
            }
        }
        private RelayCommand _ValidarTurnarCommand;
        public bool CanValidaTurnar()
        {
            bool _CanSave = false;

            if (!this.Turno.IsTurnado && this.CanValidarAsunto() && (this._Asunto.FechaCreacion != null) &&
                (this._Asunto.FechaRecibido != null) && (!String.IsNullOrWhiteSpace(this._Asunto.Contacto)) &&
                (this._Asunto.FechaDocumento != null) && (this._Asunto.Instruccion != null) &&
                (this._Asunto.Prioridad != null) && (this._Asunto.StatusAsunto != null) &&
                (this._Asunto.FechaVencimiento != null) && (!String.IsNullOrWhiteSpace(this._Asunto.Folio)) &&
                (!String.IsNullOrWhiteSpace(this._Asunto.ReferenciaDocumento)) &&
                this.Signatario.Count != 0 && this.Documentos.Count != 0
                && (this.Destinatario.Count != 0 || this.SignatarioExterno.Count != 0) 
                )
            {
                _CanSave = true;
            }
            
            return _CanSave;
        }
        public void AttemptValidaTurnar()
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

        #region BOTONES PARA ELIMINAR SIGNATARIOS, SIGNATARIOS_EXTERNOS,DESTINATARIOS, DOCUMENTOS y DESTINATARIOS_CCP
        // ***************************** ***************************** *****************************
        // ELiminar Signatarios.
        public RelayCommand DeleteSignatariosCommand
        {
            get
            {
                if (_DeleteSignatariosCommand == null)
                {
                    _DeleteSignatariosCommand = new RelayCommand(p => this.AttemptDeleteSignatarios(), p => this.CanDeleteSignatarios());
                }

                return _DeleteSignatariosCommand;
            }

        }
        private RelayCommand _DeleteSignatariosCommand;
        public bool CanDeleteSignatarios()
        {
            bool _CanDelete = false;

            foreach (SignatarioModel p in this.Signatario)
            {
                if (p.IsChecked)
                {
                    _CanDelete = true;
                    break;

                }
            }
            return _CanDelete;
        }
        public void AttemptDeleteSignatarios()
        {
            //TODO : elimina los datos
            try
            {
                //agrega a un aux los elementos que van a ser eliminados
                var query = (from o in this.Signatario
                             where o.IsChecked == true
                             select o).ToList();
                if (query.Count != 0)
                {
                    (from o in query
                     where o.IsChecked == true
                     select o).ToList().ForEach(o => this.DeleteSignatario.Add(o));
                }

                (from o in this.Signatario
                 where o.IsChecked == true
                 select o).ToList().ForEach(o => this.Signatario.Remove(o));
            }
            catch (Exception)
            {
            }
        }
        // ***************************** ***************************** *****************************
        // ELiminar Signatarios Externos.
        public RelayCommand DeleteSignatariosExternosCommand
        {
            get
            {
                if (_DeleteSignatariosExternosCommand == null)
                {
                    _DeleteSignatariosExternosCommand = new RelayCommand(p => this.AttemptDeleteSignatariosExternos(), p => this.CanDeleteSignatariosExternos());
                }

                return _DeleteSignatariosExternosCommand;
            }

        }
        private RelayCommand _DeleteSignatariosExternosCommand;
        public bool CanDeleteSignatariosExternos()
        {
            bool _CanDelete = false;

            foreach (SignatarioExternoModel p in this.SignatarioExterno)
            {
                if (p.IsChecked)
                {
                    _CanDelete = true;
                    break;

                }
            }
            return _CanDelete;
        }
        public void AttemptDeleteSignatariosExternos()
        {
            //TODO : elimina los datos
            try
            {
                //agrega a un aux los elementos que van a ser eliminados
                var query = (from o in this.SignatarioExterno
                             where o.IsChecked == true
                             select o).ToList();
                if (query.Count != 0)
                {
                    (from o in query
                     where o.IsChecked == true
                     select o).ToList().ForEach(o => this.DeleteSignatarioExterno.Add(o));
                }

                (from o in this.SignatarioExterno
                 where o.IsChecked == true
                 select o).ToList().ForEach(o => this.SignatarioExterno.Remove(o));
            }
            catch (Exception)
            {
            }
        }
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
        // ***************************** ***************************** *****************************
        // ELiminar Destinatarios Ccp.
        public RelayCommand DeleteDestinatariosCcpCommand
        {
            get
            {
                if (_DeleteDestinatariosCcpCommand == null)
                {
                    _DeleteDestinatariosCcpCommand = new RelayCommand(p => this.AttemptDeleteDestinatariosCcp(), p => this.CanDeleteDestinatariosCcp());
                }

                return _DeleteDestinatariosCcpCommand;
            }

        }
        private RelayCommand _DeleteDestinatariosCcpCommand;
        public bool CanDeleteDestinatariosCcp()
        {
            bool _CanDelete = false;

            foreach (DestinatarioCcpModel p in this.DestinatarioCcp)
            {
                if (p.IsChecked)
                {
                    _CanDelete = true;
                    break;

                }
            }
            return _CanDelete;
        }
        public void AttemptDeleteDestinatariosCcp()
        {
            //TODO : Delete to database
            try
            {
                var query = (from o in this.DestinatarioCcp
                             where o.IsChecked == true
                             select o).ToList();

                if (query.Count != 0)
                {
                    (from o in query
                     where o.IsChecked == true
                     select o).ToList().ForEach(o => this.DeleteDestinatarioCcp.Add(o));
                }

                (from o in this.DestinatarioCcp
                 where o.IsChecked == true
                 select o).ToList().ForEach(o => this.DestinatarioCcp.Remove(o));

            }
            catch (Exception)
            {
            }
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
            bool _CanSave = false;

            if (!this.Turno.IsTurnado && this.CanValidarAsunto() && (this._Asunto.FechaCreacion != null) &&
                (this._Asunto.FechaRecibido != null) && (!String.IsNullOrWhiteSpace(this._Asunto.Contacto)) &&
                (this._Asunto.FechaDocumento != null) && (this._Asunto.Instruccion != null) &&
                (this._Asunto.Prioridad != null) && (this._Asunto.StatusAsunto != null) &&
                (this._Asunto.FechaVencimiento != null) && (!String.IsNullOrWhiteSpace(this._Asunto.Folio)) &&
                (!String.IsNullOrWhiteSpace(this._Asunto.ReferenciaDocumento)) &&
                this.Signatario.Count != 0 && this.Documentos.Count != 0
                && (this.Destinatario.Count != 0 || this.SignatarioExterno.Count != 0) 
                )
            {
                _CanSave = true;
            }
            return _CanSave;
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

        #region BUSQUEDA DEL ASUNTO
        public BusquedaAsuntoTurnoViewModel Busqueda
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
        private BusquedaAsuntoTurnoViewModel _Busqueda;
        public const string BusquedaPropertyName = "Busqueda";
        #endregion

        #region CONSTRUCTOR
        // ***************************** ***************************** *****************************
        // constructor
        public AsuntoModViewModel(AsuntoModel p, AsuntoViewModel AsuntoViewModel, IConfirmation confirmation)
        {
            this._ParentAsunto = AsuntoViewModel;
            this._P = p;
            this._Confirmation = confirmation;
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this._UbicacionRepository = new GestorDocument.DAL.Repository.UbicacionRepository();
            this._InstruccionRepository = new GestorDocument.DAL.Repository.InstruccionRepository();
            this._PrioridadRepository = new GestorDocument.DAL.Repository.PrioridadRepository();
            this._StatusAsuntoRepository = new GestorDocument.DAL.Repository.StatusAsuntoRepository();
            this._SignatarioRepository = new GestorDocument.DAL.Repository.SignatarioRepository();
            this._SignatarioExternoRepository = new GestorDocument.DAL.Repository.SignatarioExternoRepository();
            this._DestinatarioRepository = new GestorDocument.DAL.Repository.DestinatarioRepository();
            this._DestinatarioCcpRepository = new GestorDocument.DAL.Repository.DestinatarioCcpRepository();
            this._DocumentosRepository = new GestorDocument.DAL.Repository.DocumentosRepository();
            this._ExpedienteRepository = new GestorDocument.DAL.Repository.ExpedienteRepository();
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
            this._SyncDocsRepository = new GestorDocument.DAL.Repository.SyncDocsRepository();

            this.LoadInfo();

            this.GetAsunto();

            this.GetRol();

            this.GetUsuario();

            this.GetTurno();

            this.GetExpediente();

            //BUSQUEDA DE ASUNTOS
            this.Busqueda = new BusquedaAsuntoTurnoViewModel(this._Rol);

            this.GetVisible();
        }

        #endregion

        #region METODOS

        public void LoadInfo()
        {
            this.Ubicacions = this._UbicacionRepository.GetUbicacions() as ObservableCollection<UbicacionModel>;
            this.Instruccions = this._InstruccionRepository.GetInstruccions() as ObservableCollection<InstruccionModel>;
            this.Prioridads = this._PrioridadRepository.GetPrioridads() as ObservableCollection<PrioridadModel>;
            this.StatusAsuntos = this._StatusAsuntoRepository.GetStatusAsuntos() as ObservableCollection<StatusAsuntoModel>;
            this.Signatario = this._SignatarioRepository.GetSignatarios(this._P.IdAsunto) as ObservableCollection<SignatarioModel>;
            this.SignatarioExterno = this._SignatarioExternoRepository.GetSignatariosExterno(this._P.IdAsunto) as ObservableCollection<SignatarioExternoModel>;
            this.Destinatario = this._DestinatarioRepository.GetDestinatarios(this._P.Turno.IdTurno) as ObservableCollection<DestinatarioModel>;
            this.DestinatarioCcp = this._DestinatarioCcpRepository.GetDestinatariosCcp(this._P.IdAsunto) as ObservableCollection<DestinatarioCcpModel>;
            this.Documentos = this._DocumentosRepository.GetDocumentos( this._P.Turno.IdTurno) as ObservableCollection<DocumentosModel>;
            this.Turnados = new ObservableCollection<TurnoModel>();
            this.DeleteDestinatario = new ObservableCollection<DestinatarioModel>();
            this.DeleteDestinatarioCcp = new ObservableCollection<DestinatarioCcpModel>();
            this.DeleteSignatario = new ObservableCollection<SignatarioModel>();
            this.DeleteDocumentos = new ObservableCollection<DocumentosModel>();
            this.DeleteSignatarioExterno = new ObservableCollection<SignatarioExternoModel>();
            this.NewDestinatario = new ObservableCollection<DestinatarioModel>();
            this.NewDestinatarioCcp = new ObservableCollection<DestinatarioCcpModel>();
            this.NewDocumentos = new ObservableCollection<DocumentosModel>();
            this.NewSignatario = new ObservableCollection<SignatarioModel>();
            this.NewSignatarioExterno = new ObservableCollection<SignatarioExternoModel>();
            this.SyncDocs = new ObservableCollection<SyncDocsModel>();

            this.GetSplitDirectory();
        }

        /// <summary>
        /// Agrega los Signatarios para el asunto
        /// </summary>
        public void GetSignatarios()
        {

            long IdSignatario = new UNID().getNewUNID();
            int con = 0;

            foreach (SignatarioModel signatario in this.Signatario)
            {
                con = con + 1;
                if (signatario.IdSignatario==0)
                {
                    SignatarioModel newSig = new SignatarioModel()
                    {
                        IdSignatario = IdSignatario + con,
                        IdAsunto = this.Asunto.IdAsunto,
                        IdDeterminante = signatario.IdDeterminante,
                        Fecha = DateTime.Now,
                        IsActive = true
                    };
                    this.NewSignatario.Add(newSig);
                }
            }
        }

        public void GetSignatariosExternos()
        {

            long IdSignatarioExterno = new UNID().getNewUNID();
            int con = 0;
            foreach (SignatarioExternoModel rel in this.SignatarioExterno)
            {
                con = con + 1;

                if (rel.IdSignatarioExterno == 0)
                {
                    SignatarioExternoModel newSig = new SignatarioExternoModel()
                    {
                        IdSignatarioExterno = IdSignatarioExterno + con,
                        IdAsunto = this.Asunto.IdAsunto,
                        IdDeterminante = rel.IdDeterminante,
                        Fecha = DateTime.Now,
                        IsActive = true
                    };
                    this.NewSignatarioExterno.Add(newSig);
                }
            }
        }

        /// <summary>
        /// Recupera los Destinatarios seleccionados del Asunto para guardar en la BD.
        /// </summary>
        public void GetDestinatarios()
        {
            long IdDestinatario = new UNID().getNewUNID();
            int con = 0;
            foreach (DestinatarioModel destinatario in this.Destinatario)
            {
                con = con + 1;
                if (destinatario.IdDestinatario ==0)
                {
                    DestinatarioModel newDes = new DestinatarioModel()
                    {
                        IdDestinatario = IdDestinatario + con,
                        IdTurno = this.Turno.IdTurno,
                        IdRol = destinatario.IdRol,
                        IsPrincipal = true,
                        IsActive = true
                    };
                    this.NewDestinatario.Add(newDes);   
                }
            }
        }

        /// <summary>
        /// Recupera los Destinatarios marcados como CCP en el Asunto para guardarlos en la BD.
        /// </summary>
        public void GetDestinatariosCcp()
        {
            long IdDestinatarioCcp = new UNID().getNewUNID();
            int con = 0;
            foreach (DestinatarioCcpModel rel in this.DestinatarioCcp)
            {
                con = con + 1;
                if (rel.IdDestinatarioCcp ==0)
                {
                    DestinatarioCcpModel newDes = new DestinatarioCcpModel()
                    {
                        IdDestinatarioCcp = IdDestinatarioCcp + con,
                        IdAsunto = this.Asunto.IdAsunto,
                        IdRol = rel.IdRol,
                        IsActive = true
                    };
                    this.NewDestinatarioCcp.Add(newDes);   
                }
            }
        }

        /// <summary>
        /// Recupera los documentos adjuntos al Asunto para guardarlos en la BD
        /// </summary>
        public void GetDocumentos()
        {
            
            foreach (DocumentosModel doc in this.Documentos)
            {
                if (doc.IdExpediente ==0 && doc.IdTurno==null)
                {
                    doc.IdExpediente = this.Expediente.IdExpediente;
                    doc.IdTurno = this.Turno.IdTurno;
                    doc.IdTipoDocumento = doc.TipoDocumento.IdTipoDocumento;

                    this.NewDocumentos.Add(doc);
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

        public void GetTurno()
        {
            this.Turno = new TurnoModel()
            {
                IdTurno = _P.Turno.IdTurno,
                FechaCreacion = _P.Turno.FechaCreacion,
                FechaEnvio = _P.Turno.FechaEnvio,
                IsActive = _P.Turno.IsActive,
                IdAsunto = _P.Turno.IdAsunto,
                IdStatusTurno = _P.Turno.IdStatusTurno,
                IdRol = _P.Turno.IdRol,
                IdUsuario = _P.Turno.IdUsuario,
                IsAtendido = _P.Turno.IsAtendido,
                IsTurnado =_P.Turno.IsTurnado,
                IsBorrador = _P.Turno.IsBorrador,
                Comentario = _P.Turno.Comentario
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
                    IdTurnoAnt = this.Turno.IdTurno,
                    IdTurno = IdTurno + con,
                    FechaCreacion = DateTime.Now,
                    IsActive = true,
                    IdAsunto = this.Asunto.IdAsunto,
                    IdStatusTurno = 1,
                    IdRol = destinatario.IdRol,
                    IdUsuario = this.Usuario.IdUsuario,
                    IsAtendido = false,
                    IsTurnado = false,
                    IsBorrador = true
                };

                this.Turnados.Add(turno);
            }
        }

        public void GetAsunto()
        {
            this._Asunto = new AsuntoModel()
            {
                IdAsunto = this._P.IdAsunto,
                FechaCreacion = this._P.FechaCreacion,
                FechaRecibido = this._P.FechaRecibido,
                FechaDocumento = this._P.FechaDocumento,
                ReferenciaDocumento = this._P.ReferenciaDocumento,
                Titulo = this._P.Titulo,
                Descripcion = this._P.Descripcion,
                Alcance = this._P.Alcance,
                Ubicacion = (this._P.Ubicacion!=null) ? new UbicacionModel
                {
                    IdUbicacion = (long)this._P.IdUbicacion,
                    UbicacionName = this._P.Ubicacion.UbicacionName
                } :null,
                Instruccion =(this._P.Instruccion!=null) ? new InstruccionModel
                {
                    IdInstruccion = (long)this._P.IdInstruccion,
                    InstruccionName = this._P.Instruccion.InstruccionName
                } : null,
                Prioridad =(this._P.Prioridad !=null) ? new PrioridadModel
                {
                    IdPrioridad = (long)this._P.IdPrioridad,
                    PrioridadName = this._P.Prioridad.PrioridadName
                } : null,
                StatusAsunto = new StatusAsuntoModel
                {
                    IdStatusAsunto = (long)this._P.IdStatusAsunto,
                    StatusName = this._P.StatusAsunto.StatusName
                },
                FechaVencimiento = this._P.FechaVencimiento,
                Folio = this._P.Folio,
                UbicacionText = this._P.UbicacionText,
                IsBorrador = this._P.IsBorrador,
                Contacto = this._P.Contacto,
                IsActive = this._P.IsActive,
                Anexos = this._P.Anexos
            };
        }

        public void GetExpediente()
        {
            this.Expediente = new ExpedienteModel()
            {
                IdExpediente = this._P.Expediente.IdExpediente,
                IdAsunto = this._P.Expediente.IdAsunto,
                Asunto = this.Asunto,
                IsActive = this._P.Expediente.IsActive
            };
        }

        /// <summary>
        /// Guarda cambios del asunto(Solo guarda,NO turna).
        /// </summary>
        private void GetSave()
        {
            //actualizamos en la tabla de GET_ASUNTO
            this._AsuntoRepository.UpdateAsunto(this._Asunto);

            //insertamos  y borramos en la tabla de relacion  REL_SIGNATARIO
            this.GetSignatarios();

            if (this.DeleteSignatario.Count != 0)
                this._SignatarioRepository.DeleteSignatario(this.DeleteSignatario);
            if (this.NewSignatario.Count != 0)
                this._SignatarioRepository.InsertSignatario(this.NewSignatario);

            //validamos
            if (this.IsCheckedInterno)
            {
                //insertamos y borramos en la tabla de relacion  REL_DESTINATARIO
                this.GetDestinatarios();

                if (this.DeleteDestinatario.Count != 0)
                    this._DestinatarioRepository.DeleteDestinatario(this.DeleteDestinatario);
                if (this.NewDestinatario.Count != 0)
                    this._DestinatarioRepository.InsertDestinatario(this.NewDestinatario);

                //Borramos en la tabla de relacion  REL_SIGNATARIO_EXTERNO
                if (this.DeleteSignatarioExterno.Count != 0)
                    this._SignatarioExternoRepository.DeleteSignatarioExterno(this.DeleteSignatarioExterno);
                
                if (this.NewSignatarioExterno.Count != 0)
                {
                    (from o in this.NewSignatarioExterno
                     select o).ToList().ForEach(o => this.NewSignatarioExterno.Remove(o));
                }
                if (this.SignatarioExterno.Count !=0)
                    this._SignatarioExternoRepository.DeleteSignatarioExterno(this.SignatarioExterno);

            }
            if (this.IsCheckedExterno)
            {
                //insertamos y borramos en la tabla de relacion  REL_SIGNATARIO_EXTERNO
                this.GetSignatariosExternos();

                if (this.DeleteSignatarioExterno.Count != 0)
                    this._SignatarioExternoRepository.DeleteSignatarioExterno(this.DeleteSignatarioExterno);

                if (this.NewSignatarioExterno.Count != 0)
                    this._SignatarioExternoRepository.InsertSignatarioExterno(this.NewSignatarioExterno);

                //borramos en la tabla de relacion  REL_DESTINATARIO
                if (this.DeleteDestinatario.Count != 0)
                    this._DestinatarioRepository.DeleteDestinatario(this.DeleteDestinatario);
                if (this.NewDestinatario.Count != 0)
                {
                    (from o in this.NewDestinatario
                     select o).ToList().ForEach(o => this.NewDestinatario.Remove(o));
                }
                if (this.Destinatario.Count !=0)
                    this._DestinatarioRepository.DeleteDestinatario(this.Destinatario);
            }

            //insertamos y borramos en la tabla de relacion  REL_DESTINATARIO_CCP
            this.GetDestinatariosCcp();

            if (this.DeleteDestinatarioCcp.Count != 0)
                this._DestinatarioCcpRepository.DeleteDestinatarioCcp(this.DeleteDestinatarioCcp);
            if (this.NewDestinatarioCcp.Count != 0)
                this._DestinatarioCcpRepository.InsertDestinatarioCcp(this.NewDestinatarioCcp);

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
            //actuliza la bandera de borrador del asunto
            this.Asunto.IsBorrador = false;
            this._AsuntoRepository.UpdateBorradorAsunto(this.Asunto);

            //guardarmos el turno para oficialia de partes
            this._TurnoRepository.UpdateTurno(this.Turno);

            //Generamos y guardamos los turnos a las UNIDADES NORMATIVAS
            this.GetTurnado();
            if (Turnados.Count != 0)
                this._TurnoRepository.InsertTurno(this._Turnados);   
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
                    IdDocumento = doc.IdDocumento,
                    StatusDoc = "PENDIENTE",
                    BanderaStatus = false,
                    Extencion = doc.Extencion
                };

                this.SyncDocs.Add(syncDoc);
            }
        }

        public void GetImprimirAsunto()
        {
            this.ImprimirAsunto = new AsuntoModel();

            this.ImprimirAsunto = this.Asunto;
            this.ImprimirAsunto.Expediente = this.Expediente;
            this.ImprimirAsunto.Turno = this.Turno;
            this.ImprimirAsunto.Turno.Destinatario = this.Destinatario;
            this.ImprimirAsunto.Signatario = this.Signatario;
            this.ImprimirAsunto.Turno.Documento = this.Documentos;
            this.ImprimirAsunto.SignatarioExterno = this.SignatarioExterno;
            this.ImprimirAsunto.DestinatarioCcp = this.DestinatarioCcp;
        }

        public void GetExistInstruccion(string InstruccionName)
        {
            this._Instruccion = new InstruccionModel()
            {

                IdInstruccion = new UNID().getNewUNID(),
                InstruccionName = InstruccionName,
                CveInstruccion = 0,
                IsActive = true
            };

            this._CheckSave = this._InstruccionRepository.GetInstruccionAdd(this._Instruccion);

            if (this._CheckSave == null)
            {
                this._InstruccionRepository.InsertInstruccion(this._Instruccion);
                this.Asunto.Instruccion = this.Instruccion;

                this.Instruccions = this._InstruccionRepository.GetInstruccions() as ObservableCollection<InstruccionModel>;
            }

        }

        #endregion

        public void IsEnable()
        {
            if (this.IsCheckedInterno)
            {
                this.IsEnabledInterno = true;
                this.IsSelecedInterno = true;
                this.IsEnabledExterno = false;
                this.IsSelecedExterno = false;
            }
            if (this.IsCheckedExterno)
            {
                this.IsEnabledInterno = false;
                this.IsSelecedInterno = false;
                this.IsEnabledExterno = true;
                this.IsSelecedExterno = true;
            }
        }

        public void GetVisible()
        {
            if (this.SignatarioExterno.Count !=0)
            {
                //banderas para desactivar los signatarios externos
                this.IsCheckedInterno = false;
                this.IsCheckedExterno = true;
                return;
            }
            if (this.Destinatario.Count != 0)
            {
                //banderas para desactivar los signatarios externos
                this.IsCheckedInterno = true;
                this.IsCheckedExterno = false;
                return;
            }

            if (this.SignatarioExterno.Count ==0 && this.Destinatario.Count == 0)
            {
                //banderas para desactivar los signatarios externos
                this.IsCheckedInterno = true;
                this.IsCheckedExterno = false;
                return;
            }

        }

    }
}
