using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class DestinatarioCcpModel :  ModelBase
    {
        // **************************** **************************** ****************************

        public long IdDestinatarioCcp
        {
            get { return _IdDestinatarioCcp; }
            set
            {
                if (_IdDestinatarioCcp != value)
                {
                    _IdDestinatarioCcp = value;
                    OnPropertyChanged(IdDestinatarioCcpPropertyName);
                }
            }
        }
        private long _IdDestinatarioCcp;
        public const string IdDestinatarioCcpPropertyName = "IdDestinatarioCcp";

        // **************************** **************************** ****************************

        public long IdRol
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
        private long _IdRol;
        public const string IdRolPropertyName = "IdRol";

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

        public long LastModidiedDate
        {
            get { return _LastModidiedDate; }
            set
            {
                if (_LastModidiedDate != value)
                {
                    _LastModidiedDate = value;
                    OnPropertyChanged(LastModidiedDatePropertyName);
                }
            }
        }
        private long _LastModidiedDate;
        public const string LastModidiedDatePropertyName = "LastModidiedDate";

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

    }
}
