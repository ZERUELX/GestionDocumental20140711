using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GestorDocument.Model
{
    public class OrganigramaModel : ModelBase
    {

        // **************************** **************************** ****************************

        public long IdJerarquia
        {
            get { return _IdJerarquia; }
            set
            {
                if (_IdJerarquia != value)
                {
                    _IdJerarquia = value;
                    OnPropertyChanged(IdJerarquiaPropertyName);
                }
            }
        }
        private long _IdJerarquia;
        public const string IdJerarquiaPropertyName = "IdJerarquia";

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

        public Nullable<long> IdJerarquiaParent
        {
            get { return _IdJerarquiaParent; }
            set
            {
                if (_IdJerarquiaParent != value)
                {
                    _IdJerarquiaParent = value;
                    OnPropertyChanged(IdJerarquiaParentPropertyName);
                }
            }
        }
        private Nullable<long> _IdJerarquiaParent;
        public const string IdJerarquiaParentPropertyName = "IdJerarquiaParent";

        // **************************** **************************** ****************************

        public string JerarquiaName
        {
            get { return _JerarquiaName; }
            set
            {
                if (_JerarquiaName != value)
                {
                    _JerarquiaName = value;
                    OnPropertyChanged(JerarquiaNamePropertyName);
                }
            }
        }
        private string _JerarquiaName;
        public const string JerarquiaNamePropertyName = "JerarquiaName";

        // **************************** **************************** ****************************

        public string JerarquiaTitular
        {
            get { return _JerarquiaTitular; }
            set
            {
                if (_JerarquiaTitular != value)
                {
                    _JerarquiaTitular = value;
                    OnPropertyChanged(JerarquiaTitularPropertyName);
                }
            }
        }
        private string _JerarquiaTitular;
        public const string JerarquiaTitularPropertyName = "JerarquiaTitular";

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
        public Nullable<long> IdTipoUnidadNormativa
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
        private Nullable<long> _IdTipoUnidadNormativa;
        public const string IdTipoUnidadNormativaPropertyName = "IdTipoUnidadNormativa";

        // **************************** **************************** ****************************

        public TipoUnidadNormativaModel TipoUnidadNormativa
        {
            get { return _TipoUnidadNormativa; }
            set
            {
                if (_TipoUnidadNormativa != value)
                {
                    _TipoUnidadNormativa = value;
                    OnPropertyChanged(TipoUnidadNormativaPropertyName);
                }
            }
        }
        private TipoUnidadNormativaModel _TipoUnidadNormativa;
        public const string TipoUnidadNormativaPropertyName = "TipoUnidadNormativa";

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

        public bool IsCollapsed
        {
            get { return _IsCollapsed; }
            set
            {
                if (_IsCollapsed != value)
                {
                    _IsCollapsed = value;
                    OnPropertyChanged(IsCollapsedPropertyName);
                }
            }
        }
        private bool _IsCollapsed;
        public const string IsCollapsedPropertyName = "IsCollapsed";

        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set
            {
                if (_IsExpanded != value)
                {
                    _IsExpanded = value;
                    OnPropertyChanged(IsExpandedPropertyName);

                }
            }
        }
        private bool _IsExpanded;
        public const string IsExpandedPropertyName = "IsExpanded";

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    OnPropertyChanged(IsSelectedPropertyName);
                }
            }
        }
        private bool _IsSelected;
        public const string IsSelectedPropertyName = "IsSelected";

        // **************************** **************************** ****************************
        public ObservableCollection<OrganigramaModel> ChildrenJerarquia
        {
            get { return _ChildrenJerarquia; }
            set
            {
                if (_ChildrenJerarquia != value)
                {
                    _ChildrenJerarquia = value;
                }
            }
        }
        private ObservableCollection<OrganigramaModel> _ChildrenJerarquia;

        public OrganigramaModel()
        {
            this.IsExpanded = false;
            this._ChildrenJerarquia = new ObservableCollection<OrganigramaModel>();
        }
    }
}
