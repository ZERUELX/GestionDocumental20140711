using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GestorDocument.Model
{
    public class TipoDocumentoModel: ModelBase
    {
        // ***************************** ***************************** *****************************

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

        // ***************************** ***************************** *****************************

        public string TipoDocumentoName
        {
            get { return _TipoDocumentoName; }
            set
            {
                if (_TipoDocumentoName != value)
                {
                    _TipoDocumentoName = value;
                    OnPropertyChanged(TipoDocumentoNamePropertyName);
                }
            }
        }
        private string _TipoDocumentoName;
        public const string TipoDocumentoNamePropertyName = "TipoDocumentoName";

        // ***************************** ***************************** *****************************

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

        // *************************** **************************** ****************************

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

    }
}
