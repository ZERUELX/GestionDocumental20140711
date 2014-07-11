using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class TipoExtencionModel :ModelBase
    {

        // **************************** **************************** ****************************
        public long IdTipoExtencion
        {
            get { return _IdTipoExtencion; }
            set
            {
                if (_IdTipoExtencion != value)
                {
                    _IdTipoExtencion = value;
                    OnPropertyChanged(IdTipoExtencionPropertyName);
                }
            }
        }
        private long _IdTipoExtencion;
        public const string IdTipoExtencionPropertyName = "IdTipoExtencion";

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

        public string Path
        {
            get { return _Path; }
            set
            {
                if (_Path != value)
                {
                    _Path = value;
                    OnPropertyChanged(PathPropertyName);
                }
            }
        }
        private string _Path;
        public const string PathPropertyName = "Path";
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
