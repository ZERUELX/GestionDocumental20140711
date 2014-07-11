using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GestorDocument.Model
{
    public class DocumentosModel : ModelBase
    {

        // **************************** **************************** ****************************

        public long IdDocumento
        {
            get { return _IdDocumento; }
            set
            {
                if (_IdDocumento != value)
                {
                    _IdDocumento = value;
                    OnPropertyChanged(IdDocumentoPropertyName);
                }
            }
        }
        private long _IdDocumento;
        public const string IdDocumentoPropertyName = "IdDocumento";

        // **************************** **************************** ****************************

        public string DocumentoName
        {
            get { return _DocumentoName; }
            set
            {
                if (_DocumentoName != value)
                {
                    _DocumentoName = value;
                    OnPropertyChanged(DocumentoNamePropertyName);
                }
            }
        }
        private string _DocumentoName;
        public const string DocumentoNamePropertyName = "DocumentoName";

        // **************************** **************************** ****************************

        public string DocumentoPath
        {
            get { return _DocumentoPath; }
            set
            {
                if (_DocumentoPath != value)
                {
                    _DocumentoPath = value;
                    OnPropertyChanged(DocumentoPathPropertyName);
                }
            }
        }
        private string _DocumentoPath;
        public const string DocumentoPathPropertyName = "DocumentoPath";

        // **************************** **************************** ****************************

        public string Extencion
        {
            get { return _Extencion; }
            set
            {
                if (_Extencion != value)
                {
                    _Extencion = value;
                    OnPropertyChanged(ExtencionPropertyName);
                }
            }
        }
        private string _Extencion;
        public const string ExtencionPropertyName = "Extencion";

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

        public Nullable<long> IdTurno
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
        private Nullable<long> _IdTurno;
        public const string IdTurnoPropertyName = "IdTurno";

        // **************************** **************************** ****************************

        public Nullable<DateTime> Fecha
        {
            get { return _Fecha; }
            set
            {
                if (_Fecha != value)
                {
                    _Fecha = value;
                    OnPropertyChanged(FechaPropertyName);
                }
            }
        }
        private Nullable<DateTime> _Fecha;
        public const string FechaPropertyName = "Fecha";

        // **************************** **************************** ****************************

        public long IdExpediente
        {
            get { return _IdExpediente; }
            set
            {
                if (_IdExpediente != value)
                {
                    _IdExpediente = value;
                    OnPropertyChanged(IdExpedientePropertyName);
                }
            }
        }
        private long _IdExpediente;
        public const string IdExpedientePropertyName = "IdExpediente";

        // **************************** **************************** ****************************

        public long IdTipoDocumento
        {
            get { return _IdTipoDocumento; }
            set
            {
                if (_IdTipoDocumento != value)
                {
                    _IdTipoDocumento = value;
                    OnPropertyChanged(IdTipoDocumentoPropertyName);
                }
            }
        }
        private long _IdTipoDocumento;
        public const string IdTipoDocumentoPropertyName = "IdTipoDocumento";

        // **************************** **************************** ****************************

        public Nullable<bool> IsDocumentoOriginal
        {
            get { return _IsDocumentoOriginal; }
            set
            {
                if (_IsDocumentoOriginal != value)
                {
                    _IsDocumentoOriginal = value;
                    OnPropertyChanged(IsDocumentoOriginalPropertyName);
                }
            }
        }
        private Nullable<bool> _IsDocumentoOriginal;
        public const string IsDocumentoOriginalPropertyName = "IsDocumentoOriginal";

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

        // **************************** **************************** ****************************

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

        // **************************** **************************** ****************************

        public TipoDocumentoModel TipoDocumento
        {
            get { return _TipoDocumento; }
            set
            {
                if (_TipoDocumento != value)
                {
                    _TipoDocumento = value;
                    OnPropertyChanged(TipoDocumentoPropertyName);
                }
            }
        }
        private TipoDocumentoModel _TipoDocumento;
        public const string TipoDocumentoPropertyName = "TipoDocumento";

        // **************************** **************************** ****************************

        public TipoExtencionModel TipoExtencion
        {
            get { return _TipoExtencion; }
            set
            {
                if (_TipoExtencion != value)
                {
                    _TipoExtencion = value;
                    OnPropertyChanged(TipoExtencionPropertyName);
                }
            }
        }
        private TipoExtencionModel _TipoExtencion;
        public const string TipoExtencionPropertyName = "TipoExtencion";



        // **************************** **************************** ****************************
        public bool IsCheckedDelete
        {
            get { return _IsCheckedDelete; }
            set
            {
                if (_IsCheckedDelete != value)
                {
                    _IsCheckedDelete = value;
                    OnPropertyChanged(IsCheckedDeletePropertyName);
                }
            }
        }
        private bool _IsCheckedDelete;
        public const string IsCheckedDeletePropertyName = "IsCheckedDelete";

        
    }
}
