using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class MenuModel : ModelBase
    {
        // **************************** **************************** ****************************
        public long IdMenu
        {
            get { return _IdMenu; }
            set
            {
                if (_IdMenu != value)
                {
                    _IdMenu = value;
                    OnPropertyChanged(IdMenuPropertyName);
                }
            }
        }
        private long _IdMenu;
        public const string IdMenuPropertyName = "IdMenu";

        // **************************** **************************** ****************************
        public Nullable<long> IdMenuParent
        {
            get { return _IdMenuParent; }
            set
            {
                if (_IdMenuParent != value)
                {
                    _IdMenuParent = value;
                    OnPropertyChanged(IdMenuParentPropertyName);
                }
            }
        }
        private Nullable<long> _IdMenuParent;
        public const string IdMenuParentPropertyName = "IdMenuParent";

        // **************************** **************************** ****************************

        public string MenuName
        {
            get { return _MenuName; }
            set
            {
                if (_MenuName != value)
                {
                    _MenuName = value;
                    OnPropertyChanged(MenuNamePropertyName);
                }
            }
        }
        private string _MenuName;
        public const string MenuNamePropertyName = "MenuName";

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

        // **************************** **************************** ****************************
        public string PathMenu
        {
            get { return _PathMenu; }
            set
            {
                if (_PathMenu != value)
                {
                    _PathMenu = value;
                    OnPropertyChanged(PathMenuPropertyName);
                }
            }
        }
        private string _PathMenu;
        public const string PathMenuPropertyName = "PathMenu";

        // **************************** **************************** ****************************

        public string CountBorrador
        {
            get { return _CountBorrador; }
            set
            {
                if (_CountBorrador != value)
                {
                    _CountBorrador = value;
                    OnPropertyChanged(CountBorradorPropertyName);
                }
            }
        }
        private string _CountBorrador;
        public const string CountBorradorPropertyName = "CountBorrador";
        // **************************** **************************** ****************************
    }
}
