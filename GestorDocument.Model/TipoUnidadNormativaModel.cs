using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class TipoUnidadNormativaModel :ModelBase
    {
        // **************************** **************************** ****************************
        public long IdTipoUnidadNormativa
        {
            get { return _IdTipoUnidadNormativa; }
            set
            {
                if (_IdTipoUnidadNormativa != value)
                {
                    _IdTipoUnidadNormativa = value;
                    OnPropertyChanged(IdTipoUnidadNormativaPropertyName);
                }
            }
        }
        private long _IdTipoUnidadNormativa;
        public const string IdTipoUnidadNormativaPropertyName = "IdTipoUnidadNormativa";

        // **************************** **************************** ****************************

        public string TipoUnidadNormativaName
        {
            get { return _TipoUnidadNormativaName; }
            set
            {
                if (_TipoUnidadNormativaName != value)
                {
                    _TipoUnidadNormativaName = value;
                    OnPropertyChanged(TipoUnidadNormativaNamePropertyName);
                }
            }
        }
        private string _TipoUnidadNormativaName;
        public const string TipoUnidadNormativaNamePropertyName = "TipoUnidadNormativaName";
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
    }
}
