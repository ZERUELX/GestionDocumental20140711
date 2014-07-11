using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestorDocument.Model
{
    public class TurnoModel : ModelBase
    {

        // **************************** **************************** ****************************

        public long IdTurno
        {
            get { return _IdTurno; }
            set
            {
                if (_IdTurno != value)
                {
                    _IdTurno = value;
                    OnPropertyChanged(IdTurnoPropertyName);
                }
            }
        }
        private long _IdTurno;
        public const string IdTurnoPropertyName = "IdTurno";

        // **************************** **************************** ****************************

        public Nullable<long> IdTurnoAnt
        {
            get { return _IdTurnoAnt; }
            set
            {
                if (_IdTurnoAnt != value)
                {
                    _IdTurnoAnt = value;
                    OnPropertyChanged(IdTurnoAntPropertyName);
                }
            }
        }
        private Nullable<long> _IdTurnoAnt;
        public const string IdTurnoAntPropertyName = "IdTurnoAnt";

        // **************************** **************************** ****************************

        public DateTime FechaCreacion
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
        private DateTime _FechaCreacion;
        public const string FechaCreacionPropertyName = "FechaCreacion";

        // **************************** **************************** ****************************

        public Nullable<DateTime> FechaEnvio
        {
            get { return _FechaEnvio; }
            set
            {
                if (_FechaEnvio != value)
                {
                    _FechaEnvio = value;
                    OnPropertyChanged(FechaEnvioPropertyName);
                }
            }
        }
        private Nullable<DateTime> _FechaEnvio;
        public const string FechaEnvioPropertyName = "FechaEnvio";

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

        public long IdStatusTurno
        {
            get { return _IdStatusTurno; }
            set
            {
                if (_IdStatusTurno != value)
                {
                    _IdStatusTurno = value;
                    OnPropertyChanged(IdStatusTurnoPropertyName);
                }
            }
        }
        private long _IdStatusTurno;
        public const string IdStatusTurnoPropertyName = "IdStatusTurno";

        // **************************** **************************** ****************************

        public Nullable<long> IdRol
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
        private Nullable<long> _IdRol;
        public const string IdRolPropertyName = "IdRol";

        // **************************** **************************** ****************************

        public Nullable<long> IdUsuario
        {
            get { return _IdUsuario; }
            set
            {
                if (_IdUsuario != value)
                {
                    _IdUsuario = value;
                    OnPropertyChanged(IdUsuarioPropertyName);
                }
            }
        }
        private Nullable<long> _IdUsuario;
        public const string IdUsuarioPropertyName = "IdUsuario";

        // **************************** **************************** ****************************

        public string Comentario
        {
            get { return _Comentario; }
            set
            {
                if (_Comentario != value)
                {
                    _Comentario = value;
                    OnPropertyChanged(ComentarioPropertyName);
                }
            }
        }
        private string _Comentario;
        public const string ComentarioPropertyName = "Comentario";

        // **************************** **************************** ****************************

        public string Respuesta
        {
            get { return _Respuesta; }
            set
            {
                if (_Respuesta != value)
                {
                    _Respuesta = value;
                    OnPropertyChanged(RespuestaPropertyName);
                }
            }
        }
        private string _Respuesta;
        public const string RespuestaPropertyName = "Respuesta";

        // **************************** **************************** ****************************

        public Nullable<long> ServerLastModifiedDate
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
        private Nullable<long> _ServerLastModifiedDate;
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

        // **************************** **************************** ****************************

        public StatusTurnoModel StatusTurno
        {
            get { return _StatusTurno; }
            set
            {
                if (_StatusTurno != value)
                {
                    _StatusTurno = value;
                    OnPropertyChanged(StatusTurnoPropertyName);
                }
            }
        }
        private StatusTurnoModel _StatusTurno;
        public const string StatusTurnoPropertyName = "StatusTurno";

        // **************************** **************************** ****************************
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

        // **************************** **************************** ****************************
        public bool IsAtendido
        {
            get { return _IsAtendido; }
            set
            {
                if (_IsAtendido != value)
                {
                    _IsAtendido = value;
                    OnPropertyChanged(IsAtendidoPropertyName);
                }
            }
        }
        private bool _IsAtendido;
        public const string IsAtendidoPropertyName = "IsAtendido";

        // **************************** **************************** ****************************

        public bool IsTurnado
        {
            get { return _IsTurnado; }
            set
            {
                if (_IsTurnado != value)
                {
                    _IsTurnado = value;
                    OnPropertyChanged(IsTurnadoPropertyName);
                }
            }
        }
        private bool _IsTurnado;
        public const string IsTurnadoPropertyName = "IsTurnado";

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
        
        public IEnumerable<DocumentosModel> Documento
        {
            get { return _Documento; }
            set
            {
                if (_Documento != value)
                {
                    _Documento = value;
                    OnPropertyChanged(DocumentoPropertyName);
                }
            }
        }
        private IEnumerable<DocumentosModel> _Documento;
        public const string DocumentoPropertyName = "Documento";

        public IEnumerable<DestinatarioModel> Destinatario
        {
            get { return _Destinatario; }
            set
            {
                if (_Destinatario != value)
                {
                    _Destinatario = value;
                    this.CoverStringDestinatario();
                    OnPropertyChanged(DestinatarioPropertyName);
                }
            }
        }
        private IEnumerable<DestinatarioModel> _Destinatario;
        public const string DestinatarioPropertyName = "Destinatario";

        public string Destinatarios
        {
            get { return _Destinatarios; }
            set
            {
                if (_Destinatarios != value)
                {
                    _Destinatarios = value;
                    OnPropertyChanged(DestinatariosPropertyName);
                }
            }
        }
        private string _Destinatarios;
        public const string DestinatariosPropertyName = "Destinatarios";

        //Indica si se muestra el check o si se puede elegir el elmento
        public bool CanCheck
        {
            get { return _CanCheck; }
            set
            {
                if (_CanCheck != value)
                {
                    _CanCheck = value;
                    OnPropertyChanged(CanCheckPropertyName);
                }
            }
        }
        private bool _CanCheck;
        public const string CanCheckPropertyName = "CanCheck";

        //Indica si se pinta en negritas
        public string FontWeight
        {
            get { return _FontWeight; }
            set
            {
                if (_FontWeight != value)
                {
                    _FontWeight = value;
                    OnPropertyChanged(FontWeightPropertyName);
                }
            }
        }
        private string _FontWeight;
        public const string FontWeightPropertyName = "FontWeight";

        public string Foreground
        {
            get { return _Foreground; }
            set
            {
                if (_Foreground != value)
                {
                    _Foreground = value;
                    OnPropertyChanged(ForegroundPropertyName);
                }
            }
        }
        private string _Foreground;
        public const string ForegroundPropertyName = "Foreground";

        public string FechaAtendidoTurnado
        {
            get { return _FechaAtendidoTurnado; }
            set
            {
                if (_FechaAtendidoTurnado != value)
                {
                    _FechaAtendidoTurnado = value;
                    OnPropertyChanged(FechaAtendidoTurnadoPropertyName);
                }
            }
        }
        private string _FechaAtendidoTurnado;
        public const string FechaAtendidoTurnadoPropertyName = "FechaAtendidoTurnado";


        public void CoverStringDestinatario()
        {
            List<string> destinatarios = new List<string>();

            foreach (DestinatarioModel item in this.Destinatario)
                destinatarios.Add(item.Rol.RolName);

            this.Destinatarios = string.Join(" , ", destinatarios);

        }

        // **************************** **************************** ****************************
        public ObservableCollection<TurnoModel> TrancingTurno
        {
            get { return _TrancingTurno; }
            set
            {
                if (_TrancingTurno != value)
                {
                    _TrancingTurno = value;
                }
            }
        }
        private ObservableCollection<TurnoModel> _TrancingTurno;

        public TurnoModel()
        {
            this._TrancingTurno = new ObservableCollection<TurnoModel>();
        }
    }
}
