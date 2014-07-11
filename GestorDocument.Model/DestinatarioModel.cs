using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class DestinatarioModel : ModelBase
    {

        // **************************** **************************** ****************************

        public long IdDestinatario
        {
            get { return _IdDestinatario; }
            set
            {
                if (_IdDestinatario != value)
                {
                    _IdDestinatario = value;
                    OnPropertyChanged(IdDestinatarioPropertyName);
                }
            }
        }
        private long _IdDestinatario;
        public const string IdDestinatarioPropertyName = "IdDestinatario";

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

        public bool IsPrincipal
        {
            get { return _IsPrincipal; }
            set
            {
                if (_IsPrincipal != value)
                {
                    _IsPrincipal = value;
                    OnPropertyChanged(IsPrincipalPropertyName);
                }
            }
        }
        private bool _IsPrincipal;
        public const string IsPrincipalPropertyName = "IsPrincipal";

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
        
    }
}
