using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestorDocument.Model
{
    public class AsuntoModel : ModelBase, IDataErrorInfo
    {

        // **************************** **************************** ****************************

        public long IdAsunto
        {
            get { return _IdAsunto; }
            set
            {
                if (_IdAsunto != value)
                {
                    _IdAsunto = value;
                    OnPropertyChanged(IdAsuntoPropertyName);
                }
            }
        }
        private long _IdAsunto;
        public const string IdAsuntoPropertyName = "IdAsunto";

        // **************************** **************************** ****************************

        public Nullable<DateTime> FechaCreacion
        {
            get { return _FechaCreacion; }
            set
            {
                if (_FechaCreacion != value)
                {
                    _FechaCreacion = value;
                    OnPropertyChanged(FechaCreacionPropertyName);
                }
            }
        }
        private Nullable<DateTime> _FechaCreacion;
        public const string FechaCreacionPropertyName = "FechaCreacion";

        // **************************** **************************** ****************************

        public Nullable<DateTime> FechaRecibido
        {
            get { return _FechaRecibido; }
            set
            {
                if (_FechaRecibido != value)
                {
                    _FechaRecibido = value;
                    OnPropertyChanged(FechaRecibidoPropertyName);
                }
            }
        }
        private Nullable<DateTime> _FechaRecibido;
        public const string FechaRecibidoPropertyName = "FechaRecibido";

        // **************************** **************************** ****************************

        public Nullable<DateTime> FechaDocumento
        {
            get { return _FechaDocumento; }
            set
            {
                if (_FechaDocumento != value)
                {
                    _FechaDocumento = value;
                    OnPropertyChanged(FechaDocumentoPropertyName);
                }
            }
        }
        private Nullable<DateTime> _FechaDocumento;
        public const string FechaDocumentoPropertyName = "FechaDocumento";

        // **************************** **************************** ****************************

        public string ReferenciaDocumento
        {
            get { return _ReferenciaDocumento; }
            set
            {
                if (_ReferenciaDocumento != value)
                {
                    _ReferenciaDocumento = value;
                    OnPropertyChanged(ReferenciaDocumentoPropertyName);
                }
            }
        }
        private string _ReferenciaDocumento;
        public const string ReferenciaDocumentoPropertyName = "ReferenciaDocumento";

        // **************************** **************************** ****************************

        public string Titulo
        {
            get { return _Titulo; }
            set
            {
                if (_Titulo != value)
                {
                    _Titulo = value;
                    OnPropertyChanged(TituloPropertyName);
                }
            }
        }
        private string _Titulo;
        public const string TituloPropertyName = "Titulo";

        // **************************** **************************** ****************************

        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                if (_Descripcion != value)
                {
                    _Descripcion = value;
                    OnPropertyChanged(DescripcionPropertyName);
                }
            }
        }
        private string _Descripcion;
        public const string DescripcionPropertyName = "Descripcion";

        // **************************** **************************** ****************************

        public string Alcance
        {
            get { return _Alcance; }
            set
            {
                if (_Alcance != value)
                {
                    _Alcance = value;
                    OnPropertyChanged(AlcancePropertyName);
                }
            }
        }
        private string _Alcance;
        public const string AlcancePropertyName = "Alcance";

        // **************************** **************************** ****************************

        public Nullable<long> IdUbicacion
        {
            get { return _IdUbicacion; }
            set
            {
                if (_IdUbicacion != value)
                {
                    _IdUbicacion = value;
                    OnPropertyChanged(IdUbicacionPropertyName);
                }
            }
        }
        private Nullable<long> _IdUbicacion;
        public const string IdUbicacionPropertyName = "IdUbicacion";

        // **************************** **************************** ****************************

        public Nullable<long> IdInstruccion
        {
            get { return _IdInstruccion; }
            set
            {
                if (_IdInstruccion != value)
                {
                    _IdInstruccion = value;
                    OnPropertyChanged(IdInstruccionPropertyName);
                }
            }
        }
        private Nullable<long> _IdInstruccion;
        public const string IdInstruccionPropertyName = "IdInstruccion";

        // **************************** **************************** ****************************

        public Nullable<long> IdPrioridad
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
        private Nullable<long> _IdPrioridad;
        public const string IdPrioridadPropertyName = "IdPrioridad";

        // **************************** **************************** ****************************

        public Nullable<long> IdStatusAsunto
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
        private Nullable<long> _IdStatusAsunto;
        public const string IdStatusAsuntoPropertyName = "IdStatusAsunto";

        // **************************** **************************** ****************************

        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set
            {
                if (_FechaVencimiento != value)
                {
                    _FechaVencimiento = value;
                    OnPropertyChanged(FechaVencimientoPropertyName);
                }
            }
        }
        private DateTime _FechaVencimiento;
        public const string FechaVencimientoPropertyName = "FechaVencimiento";

        // **************************** **************************** ****************************

        public string Folio
        {
            get { return _Folio; }
            set
            {
                if (_Folio != value)
                {
                    _Folio = value;
                    OnPropertyChanged(FolioPropertyName);
                }
            }
        }
        private string _Folio;
        public const string FolioPropertyName = "Folio";

        // **************************** **************************** ****************************

        public bool IsActive
        {
            get { return _IsActive; }
            set
            {
                if (_IsActive != value)
                {
                    _IsActive = value;
                    OnPropertyChanged(IsActivePropertyName);
                }
            }
        }
        private bool _IsActive;
        public const string IsActivePropertyName = "IsActive";

        // **************************** **************************** ****************************

        public long LastModifiedDate
        {
            get { return _LastModifiedDate; }
            set
            {
                if (_LastModifiedDate != value)
                {
                    _LastModifiedDate = value;
                    OnPropertyChanged(LastModifiedDatePropertyName);
                }
            }
        }
        private long _LastModifiedDate;
        public const string LastModifiedDatePropertyName = "LastModifiedDate";

        // **************************** **************************** ****************************

        public bool IsModified
        {
            get { return _IsModified; }
            set
            {
                if (_IsModified != value)
                {
                    _IsModified = value;
                    OnPropertyChanged(IsModifiedPropertyName);
                }
            }
        }
        private bool _IsModified;
        public const string IsModifiedPropertyName = "IsModified";

        // **************************** **************************** ****************************

        public long ServerLastModifiedDate
        {
            get { return _ServerLastModifiedDate; }
            set
            {
                if (_ServerLastModifiedDate != value)
                {
                    _ServerLastModifiedDate = value;
                    OnPropertyChanged(ServerLastModifiedDatePropertyName);
                }
            }
        }
        private long _ServerLastModifiedDate;
        public const string ServerLastModifiedDatePropertyName = "ServerLastModifiedDate";

        // **************************** **************************** ****************************

        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (_IsChecked != value)
                {
                    _IsChecked = value;
                    OnPropertyChanged(IsCheckedPropertyName);
                }
            }
        }
        private bool _IsChecked;
        public const string IsCheckedPropertyName = "IsChecked";

        // **************************** **************************** ****************************

        public UbicacionModel Ubicacion
        {
            get { return _Ubicacion; }
            set
            {
                if (_Ubicacion != value)
                {
                    _Ubicacion = value;
                    OnPropertyChanged(UbicacionPropertyName);
                }
            }
        }
        private UbicacionModel _Ubicacion;
        public const string UbicacionPropertyName = "Ubicacion";

        // **************************** **************************** ****************************

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

        // **************************** **************************** ****************************

        public PrioridadModel Prioridad
        {
            get { return _Prioridad; }
            set
            {
                if (_Prioridad != value)
                {
                    _Prioridad = value;
                    OnPropertyChanged(PrioridadPropertyName);
                }
            }
        }
        private PrioridadModel _Prioridad;
        public const string PrioridadPropertyName = "Prioridad";

        // **************************** **************************** ****************************

        public StatusAsuntoModel StatusAsunto
        {
            get { return _StatusAsunto; }
            set
            {
                if (_StatusAsunto != value)
                {
                    _StatusAsunto = value;
                    OnPropertyChanged(StatusAsuntoPropertyName);
                }
            }
        }
        private StatusAsuntoModel _StatusAsunto;
        public const string StatusAsuntoPropertyName = "StatusAsunto";

        // **************************** **************************** ****************************

        public Nullable<DateTime> FechaAtendido
        {
            get { return _FechaAtendido; }
            set
            {
                if (_FechaAtendido != value)
                {
                    _FechaAtendido = value;
                    OnPropertyChanged(FechaAtendidoPropertyName);
                }
            }
        }
        private Nullable<DateTime> _FechaAtendido;
        public const string FechaAtendidoPropertyName = "FechaAtendido";

        // **************************** **************************** ****************************
        public string UbicacionText
        {
            get { return _UbicacionText; }
            set
            {
                if (_UbicacionText != value)
                {
                    _UbicacionText = value;
                    OnPropertyChanged(UbicacionTextPropertyName);
                }
            }
        }
        private string _UbicacionText;
        public const string UbicacionTextPropertyName = "UbicacionText";

        // **************************** **************************** ****************************

        public bool IsBorrador
        {
            get { return _IsBorrador; }
            set
            {
                if (_IsBorrador != value)
                {
                    _IsBorrador = value;
                    OnPropertyChanged(IsBorradorPropertyName);
                }
            }
        }
        private bool _IsBorrador;
        public const string IsBorradorPropertyName = "IsBorrador";

        // **************************** **************************** ****************************

        public string Contacto
        {
            get { return _Contacto; }
            set
            {
                if (_Contacto != value)
                {
                    _Contacto = value;
                    OnPropertyChanged(ContactoPropertyName);
                }
            }
        }
        private string _Contacto;
        public const string ContactoPropertyName = "Contacto";

        // **************************** **************************** ****************************

        public string Anexos
        {
            get { return _Anexos; }
            set
            {
                if (_Anexos != value)
                {
                    _Anexos = value;
                    OnPropertyChanged(AnexosPropertyName);
                }
            }
        }
        private string _Anexos;
        public const string AnexosPropertyName = "Anexos";

        // **************************** **************************** ****************************

        public int ConRespuesta
        {
            get { return _ConRespuesta; }
            set
            {
                if (_ConRespuesta != value)
                {
                    _ConRespuesta = value;

                    OnPropertyChanged(ConRespuestaPropertyName);
                }
                this.GetValidarCerrarTurno();
            }
        }
        private int _ConRespuesta;
        public const string ConRespuestaPropertyName = "ConRespuesta";

        // **************************** **************************** ****************************

        public string RespuestaTurnos
        {
            get { return _RespuestaTurnos; }
            set
            {
                if (_RespuestaTurnos != value)
                {
                    _RespuestaTurnos = value;
                    OnPropertyChanged(RespuestaTurnosPropertyName);
                }
            }
        }
        private string _RespuestaTurnos;
        public const string RespuestaTurnosPropertyName = "RespuestaTurnos";

        // **************************** **************************** ****************************
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

        public IEnumerable<TurnoModel> Turnos
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
        private IEnumerable<TurnoModel> _Turnos;
        public const string TurnosPropertyName = "Turnos";

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

        public IEnumerable<ExpedienteModel> Expedientes
        {
            get { return _Expedientes; }
            set
            {
                if (_Expedientes != value)
                {
                    _Expedientes = value;
                    OnPropertyChanged(ExpedientesPropertyName);
                }
            }
        }
        private IEnumerable<ExpedienteModel> _Expedientes;
        public const string ExpedientesPropertyName = "Expedientes";

        public IEnumerable<SignatarioModel> Signatario
        {
            get { return _Signatario; }
            set
            {
                if (_Signatario != value)
                {
                    _Signatario = value;
                    this.CoverStringSignatario();
                    OnPropertyChanged(SignatarioPropertyName);
                }
            }
        }
        private IEnumerable<SignatarioModel> _Signatario;
        public const string SignatarioPropertyName = "Signatario";

        public string Signatarios
        {
            get { return _Signatarios; }
            set
            {
                if (_Signatarios != value)
                {
                    _Signatarios = value;
                    OnPropertyChanged(SignatariosPropertyName);
                }
            }
        }
        private string _Signatarios;
        public const string SignatariosPropertyName = "Signatarios";

        public IEnumerable<SignatarioExternoModel> SignatarioExterno
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
        private IEnumerable<SignatarioExternoModel> _SignatarioExterno;
        public const string SignatarioExternoPropertyName = "SignatarioExterno";

        public IEnumerable<DestinatarioCcpModel> DestinatarioCcp
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
        private IEnumerable<DestinatarioCcpModel> _DestinatarioCcp;
        public const string DestinatarioCcpPropertyName = "DestinatarioCcp";

        public void CoverStringSignatario()
        {
            List<string> signatarios = new List<string>();

            foreach (SignatarioModel item in this.Signatario)
                signatarios.Add(item.Determinante.DeterminanteName);

            this.Signatarios = string.Join(" , ", signatarios);

        }

        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get
            {
                string error = null;
                switch (propertyName)
                {
                    case "ReferenciaDocumento":
                        if (string.IsNullOrWhiteSpace(this.ReferenciaDocumento))
                            error = "CAMPO OBLIGATORIO";
                        break;
                    case "Folio":
                        if (string.IsNullOrWhiteSpace(this.Folio))
                            error = "CAMPO OBLIGATORIO";
                        break;
                    case "FechaDocumento":
                        if (string.IsNullOrWhiteSpace(this.FechaDocumento.ToString()))
                            error = "CAMPO OBLIGATORIO";
                        break;

                    case "FechaRecibido":
                        if (string.IsNullOrWhiteSpace(this.FechaRecibido.ToString()))
                            error = "CAMPO OBLIGATORIO";
                        break;
                    case "Instruccion":
                        if (this.Instruccion==null)
                            error = "CAMPO OBLIGATORIO";
                        break;
                    case "Titulo":
                        if (string.IsNullOrWhiteSpace(this.Titulo))
                            error = "CAMPO OBLIGATORIO";
                        break;
                    case "FechaVencimiento":
                        if (string.IsNullOrWhiteSpace(this.FechaVencimiento.ToString()))
                            error = "CAMPO OBLIGATORIO";
                        break;
                    case "Descripcion":
                        if (string.IsNullOrWhiteSpace(this.Descripcion))
                            error = "CAMPO OBLIGATORIO";
                        break;
                    case "Prioridad":
                        if (this.Prioridad == null)
                            error = "CAMPO OBLIGATORIO";
                        break;
                    case "Contacto":
                        if (string.IsNullOrWhiteSpace(this.Contacto))
                            error = "CAMPO OBLIGATORIO";
                        break;
                }
                return error;
            }
        }

        public void GetValidarCerrarTurno()
        {
            int cont = this.ConRespuesta;
            if (cont != 0)
                this.RespuestaTurnos = "NO";
            else
                this.RespuestaTurnos = "SI";
        }

    }
}
