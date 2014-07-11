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
    public class AsuntoAddViewModel : ViewModelBase
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

        #region Propiedades para ocultar campos
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

        #region DOCUMENTOS
        
        // GRID DOCMENTOS
        private IDocumentos _DocumentosRepository;
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
        public bool CanSave()
        {
            bool _CanSave = true;
            //solo guarda
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
            //solo guarda
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

            if (!string.IsNullOrWhiteSpace(this._Asunto.Titulo) && !string.IsNullOrWhiteSpace(this._Asunto.Descripcion))
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

        #region BOTONES PARA ELIMINAR SIGNATARIOS, SIGNATARIOS_EXTERNOS, DESTINATARIOS, DOCUMENTOS y DESTINATARIOS_CCP
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
        // ELiminar Destinatarios.
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

        #region CONSTRUCTORES
        // ***************************** ***************************** *****************************
        // constructor
        public AsuntoAddViewModel(AsuntoViewModel AsuntoViewModel, IConfirmation confirmation)
        {
            this._ParentAsunto = AsuntoViewModel;
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

            this._Asunto = new AsuntoModel()
            {
                IdAsunto = new UNID().getNewUNID(),
                FechaCreacion =DateTime.Now,
                FechaVencimiento = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now)),
                FechaRecibido = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now)),
                FechaDocumento = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now)),
                IsActive =true,
                IsBorrador = true
            };

            this.GetRol();

            this.GetUsuario();

            //generamos un nuevo turno para OFICIALIA DE PARTES
            this.GetTurno();

            //BUSQUEDA DE ASUNTOS
            this.Busqueda = new BusquedaAsuntoTurnoViewModel(this._Rol);
            
            this.LoadInfo();
            //AGREGAMOS EL ESTATUS
            long idStatusAsunto = 20130611180545475;

            this.Asunto.StatusAsunto = (from q in this.StatusAsuntos
                                        where q.IdStatusAsunto ==idStatusAsunto
                                        select q).FirstOrDefault();

            //banderas para desactivar los signatarios externos
            this.IsCheckedInterno = true;
            this.IsCheckedExterno = false;
            
        }

        public AsuntoAddViewModel()
        {
            //this._ParentAsunto = AsuntoViewModel;
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this._UbicacionRepository = new GestorDocument.DAL.Repository.UbicacionRepository();
            this._InstruccionRepository = new GestorDocument.DAL.Repository.InstruccionRepository();
            this._PrioridadRepository = new GestorDocument.DAL.Repository.PrioridadRepository();
            this._StatusAsuntoRepository = new GestorDocument.DAL.Repository.StatusAsuntoRepository();
            this._SignatarioRepository = new GestorDocument.DAL.Repository.SignatarioRepository();
            this._DestinatarioRepository = new GestorDocument.DAL.Repository.DestinatarioRepository();
            this._DocumentosRepository = new GestorDocument.DAL.Repository.DocumentosRepository();
            this._ExpedienteRepository = new GestorDocument.DAL.Repository.ExpedienteRepository();
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
            this._Asunto = new AsuntoModel()
            {
                IdAsunto = new UNID().getNewUNID(),
                FechaCreacion = DateTime.Now,
                FechaVencimiento = DateTime.Now,
                FechaRecibido = DateTime.Now,
                FechaDocumento = DateTime.Now
            };

            this.GetRol();

            this.GetUsuario();

            //generamos un nuevo turno para OFICIALIA DE PARTES
            this.GetTurno();

            this.LoadInfo();
            //AGREGAMOS EL ESTATUS
            this.Asunto.StatusAsunto = (from q in this.StatusAsuntos
                                        select q).FirstOrDefault();
        }

        #endregion

        #region METODOS 

        public void LoadInfo()
        {
            this.Ubicacions = this._UbicacionRepository.GetUbicacions() as ObservableCollection<UbicacionModel>;
            this.Instruccions = this._InstruccionRepository.GetInstruccions() as ObservableCollection<InstruccionModel>;
            this.Prioridads = this._PrioridadRepository.GetPrioridads() as ObservableCollection<PrioridadModel>;
            this.StatusAsuntos = this._StatusAsuntoRepository.GetStatusAsuntos() as ObservableCollection<StatusAsuntoModel>;
            this.Signatario = new ObservableCollection<SignatarioModel>();
            this.SignatarioExterno = new ObservableCollection<SignatarioExternoModel>();
            this.Destinatario = new ObservableCollection<DestinatarioModel>();
            this.DestinatarioCcp = new ObservableCollection<DestinatarioCcpModel>();
            this.Documentos = new ObservableCollection<DocumentosModel>();
            this.Turnados = new ObservableCollection<TurnoModel>();
            this.DeleteDocumentos = new ObservableCollection<DocumentosModel>();
            this.SyncDocs = new ObservableCollection<SyncDocsModel>();

            this.GetSplitDirectory();
        }

        public void GetSignatarios()
        {

            long IdSignatario = new UNID().getNewUNID();
            int con = 0;

            foreach (SignatarioModel rel in this.Signatario)
            {
                con = con + 1;
                rel.IdSignatario = IdSignatario + con;
                rel.IdAsunto = this.Asunto.IdAsunto;
                rel.Fecha = DateTime.Now;
                rel.IsActive = true;
                
            }
        }

        public void GetSignatariosExternos()
        {

            long IdSignatarioExterno = new UNID().getNewUNID();
            int con = 0;

            foreach (SignatarioExternoModel rel in this.SignatarioExterno)
            {
                con = con + 1;
                rel.IdSignatarioExterno = IdSignatarioExterno + con;
                rel.IdAsunto = this.Asunto.IdAsunto;
                rel.Fecha = DateTime.Now;
                rel.IsActive = true;

            }
        }

        public void GetDestinatarios()
        {
            long IdDestinatario = new UNID().getNewUNID();
            int con = 0;
            foreach (DestinatarioModel rel in this.Destinatario)
            {
                con = con + 1;
                rel.IdDestinatario = IdDestinatario + con;
                rel.IdTurno = this.Turno.IdTurno;
                rel.IsPrincipal = true;
                rel.IsActive = true;
            }
        }

        public void GetDestinatariosCcp()
        {
            long IdDestinatarioCcp = new UNID().getNewUNID();
            int con = 0;
            foreach (DestinatarioCcpModel rel in this.DestinatarioCcp)
            {
                con = con + 1;
                rel.IdDestinatarioCcp = IdDestinatarioCcp + con;
                rel.IdAsunto = this.Asunto.IdAsunto;
                rel.IsActive = true;
            }
        }

        public void GetExpediente()
        {
            this.Expediente = new ExpedienteModel() 
            {
                IdExpediente = new UNID().getNewUNID(),
                IdAsunto = this.Asunto.IdAsunto,
                Asunto = this.Asunto,
                IsActive = true
            };
        }

        public void GetDocumentos()
        {
            foreach (DocumentosModel doc in this.Documentos)
            {
                doc.IdExpediente = this.Expediente.IdExpediente;
                doc.IdTurno = this.Turno.IdTurno;
                doc.IdTipoDocumento = doc.TipoDocumento.IdTipoDocumento;
            }
        }

        public void GetTurno()
        {
            this.Turno = new TurnoModel() 
            {
                IdTurno = new UNID().getNewUNID(),
                FechaCreacion = DateTime.Now,
                IsActive = true,
                IdAsunto = this.Asunto.IdAsunto,
                IdStatusTurno = 1,
                IdRol = this.Rol.IdRol,
                IdUsuario = this.Usuario.IdUsuario ,
                IsAtendido = false,
                IsBorrador = true
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

        private void GetSave()
        {
            //logica para guardar el asunto

            //guardar en la tabla de relacion  GET_ASUNTO
            this._AsuntoRepository.InsertAsunto(this._Asunto);

            //guardarmos el turno para oficialia de partes
            this._TurnoRepository.InsertTurno(this.Turno);

            //guardar en la tabla de relacion  REL_SIGNATARIO
            if (this.Signatario.Count != 0)
            {
                this.GetSignatarios();
                this._SignatarioRepository.InsertSignatario(this._Signatario);
            }
            //validamos
            if (this.IsCheckedInterno)
            {
                //guardar en la tabla de relacion  REL_DESTINATARIO
                if (this.Destinatario.Count != 0)
                {
                    this.GetDestinatarios();
                    this._DestinatarioRepository.InsertDestinatario(this._Destinatario);
                }
                if (this.SignatarioExterno.Count != 0)
                {
                    (from o in this.SignatarioExterno
                    select o).ToList().ForEach(o => this.SignatarioExterno.Remove(o));
                }
    
            }
            if (this.IsCheckedExterno)
            {
                //guardar en la tabla de relacion  REL_SIGNATARIO_EXTERNO
                if (this.SignatarioExterno.Count != 0)
                {
                    this.GetSignatariosExternos();
                    this._SignatarioExternoRepository.InsertSignatarioExterno(this._SignatarioExterno);
                }
                //Eliminamos
                if (this.Destinatario.Count != 0)
                {
                    (from o in this.Destinatario
                     select o).ToList().ForEach(o => this.Destinatario.Remove(o));
                }
                
            }
            

            //guardar en la tabla de relacion  REL_DESTINATARIO_CCP
            if (this.DestinatarioCcp.Count != 0)
            {
                this.GetDestinatariosCcp();
                this._DestinatarioCcpRepository.InsertDestinatarioCcp(this._DestinatarioCcp);
            }

            //guardar en la tabla de relacion  GET_EXPEDIENTE
            this.GetExpediente();
            this._ExpedienteRepository.InsertExpediente(this._Expediente);

            //guardar en la tabla de relacion  GET_DOCUMENTOS
            if (this.Documentos.Count != 0)
            {
                this.GetDocumentos();
                this._DocumentosRepository.InsertDocumentos(this._Documentos);

                //llenado de la tabla SYNC_DOC para la sincronizacion de  documento
                this.GetSyncDocs();
                this._SyncDocsRepository.InsertSyncDocs(this._SyncDocs);

            }

            //Borramos los documentos de la carpeta de la aplicacion
            if (this.DeleteDocumentos.Count != 0)
                this.GetDeleteDocumentos();

        }

        private void GetSaveTurnar()
        {
            this.GetSave();

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
            if (Turnados.Count !=0)
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

        public void GetDeleteDocumentos()
        {
            foreach (DocumentosModel doc in this.DeleteDocumentos)
                File.Delete(this.SuccessPath + doc.IdDocumento + "." + doc.Extencion);
        }

        public void GetSyncDocs()
        {
            foreach (DocumentosModel doc in this.Documentos)
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
                CveInstruccion =0,
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

    }
}

