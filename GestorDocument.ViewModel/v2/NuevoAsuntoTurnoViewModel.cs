using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.DAL;
using GestorDocument.DAL.Repository.v2;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.v2
{
    public class NuevoAsuntoTurnoViewModel:ViewModelBase
    {
        #region Constructor.

        public NuevoAsuntoTurnoViewModel()
        {

        }

        #endregion

        #region Instancias
        InstruccionRepository instruccionRepository = new InstruccionRepository();
        PrioridadRepository prioridadReposiroty = new PrioridadRepository();
        StatusAsuntoRepository statusAsuntoRepository = new StatusAsuntoRepository();

        #endregion

        #region Propiedades.

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

        #region  SIGNATARIO, SIGNATARIO_EXTERNO, DESTINATARIO y DESTINATARIO_CCP
        // SIGNATARIO. 
        
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

        #region DOCUMENTOS

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


        #endregion

        #region Metodos.

        public void Init(UsuarioModel usuario)
        {
            this.Signatario = new ObservableCollection<SignatarioModel>();
            this.SignatarioExterno = new ObservableCollection<SignatarioExternoModel>();
            this.Destinatario = new ObservableCollection<DestinatarioModel>();
            this.DestinatarioCcp = new ObservableCollection<DestinatarioCcpModel>();
            this.Documentos = new ObservableCollection<DocumentosModel>();
            this.Turnados = new ObservableCollection<TurnoModel>();
            this.DeleteDocumentos = new ObservableCollection<DocumentosModel>();
            this.SyncDocs = new ObservableCollection<SyncDocsModel>();
            this.Usuario = usuario;            
            GetInstruccion();
            GetPrioridad();
            GetStatusAsunto();
            NuevoAsunto();
            NuevoTurno();
        }

        public void NuevoAsunto()
        {
            this.Asunto = new AsuntoModel()
            {
                IdAsunto = new UNID().getUDF_UnidId(),
                FechaCreacion = DateTime.Now,
                FechaVencimiento = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now)),
                FechaRecibido = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now)),
                FechaDocumento = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now)),
                IsActive = true,
                IsBorrador = true
            };
            long idStatusAsunto = 20130611180545475;
            this.Asunto.StatusAsunto = (from q in this.StatusAsuntos
                                        where q.IdStatusAsunto == idStatusAsunto
                                        select q).FirstOrDefault();
            this.IsCheckedInterno = true;
            this.IsCheckedExterno = false;
        }

        public void NuevoTurno()
        {
            this.Turno = new TurnoModel()
            {
                IdTurno = new UNID().getNewUNID(),
                FechaCreacion = DateTime.Now,
                IsActive = true,
                IdAsunto = this.Asunto.IdAsunto,
                IdStatusTurno = 1,
                IdRol = this.Usuario.Rol.IdRol,
                IdUsuario = this.Usuario.IdUsuario,
                IsAtendido = false,
                IsBorrador = true
            };

        }

        public void GetInstruccion()
        {
            this.Instruccions = new ObservableCollection<InstruccionModel>(instruccionRepository.GetInstruccions());
        }

        public void GetPrioridad()
        {
            this.Prioridads = new ObservableCollection<PrioridadModel>(prioridadReposiroty.GetPrioridads());
        }

        public void GetStatusAsunto()
        {
            this.StatusAsuntos = new ObservableCollection<StatusAsuntoModel>(statusAsuntoRepository.GetStatusAsuntos());
        }

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

        #endregion
    }
}
