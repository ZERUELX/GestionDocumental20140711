using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class SyncDocsModel :ModelBase
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

        public bool BanderaStatus
        {
            get { return _BanderaStatus; }
            set
            {
                if (_BanderaStatus != value)
                {
                    _BanderaStatus = value;
                    OnPropertyChanged(BanderaStatusPropertyName);
                }
            }
        }
        private bool _BanderaStatus;
        public const string BanderaStatusPropertyName = "BanderaStatus";

        // **************************** **************************** ****************************

        public Nullable<DateTime> FechaCarga
        {
            get { return _FechaCarga; }
            set
            {
                if (_FechaCarga != value)
                {
                    _FechaCarga = value;
                    OnPropertyChanged(IsActivePropertyName);
                }
            }
        }
        private Nullable<DateTime> _FechaCarga;
        public const string IsActivePropertyName = "FechaCarga";

        // **************************** **************************** ****************************

        public string Exception
        {
            get { return _Exception; }
            set
            {
                if (_Exception != value)
                {
                    _Exception = value;
                    OnPropertyChanged(ExceptionPropertyName);
                }
            }
        }
        private string _Exception;
        public const string ExceptionPropertyName = "Exception";

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

        public string StatusDoc
        {
            get { return _StatusDoc; }
            set
            {
                if (_StatusDoc != value)
                {
                    _StatusDoc = value;
                    OnPropertyChanged(StatusDocPropertyName);
                }
            }
        }
        private string _StatusDoc;
        public const string StatusDocPropertyName = "StatusDoc";

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
    }
}
