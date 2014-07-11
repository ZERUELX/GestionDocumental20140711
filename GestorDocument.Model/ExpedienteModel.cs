using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class ExpedienteModel : ModelBase
    {

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

        public Nullable<long> IdAsunto
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
        private Nullable<long> _IdAsunto;
        public const string IdAsuntoPropertyName = "IdAsunto";

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

        public DocumentosModel Documento
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
        private DocumentosModel _Documento;
        public const string DocumentoPropertyName = "Documento";


        // **************************** **************************** ****************************

        public SyncDocsModel SyncDocs
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
        private SyncDocsModel _SyncDocs;
        public const string SyncDocsPropertyName = "SyncDocs";


        // **************************** **************************** ****************************
        public bool IsClick
        {
            get { return _IsClick; }
            set
            {
                if (_IsClick != value)
                {
                    _IsClick = value;
                    OnPropertyChanged(IsClickPropertyName);
                }
            }
        }
        private bool _IsClick;
        public const string IsClickPropertyName = "IsClick";

        
    }
}
