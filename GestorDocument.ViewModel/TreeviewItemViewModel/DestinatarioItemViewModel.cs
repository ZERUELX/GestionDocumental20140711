using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;

namespace GestorDocument.ViewModel.TreeviewItemViewModel
{
    public class DestinatarioItemViewModel : ViewModelBase, IParentItem
    {
        #region ORGANIGRAMA MODEL
        private IOrganigrama _OrgRepository;

        public OrganigramaModel Organigrama
        {
            get { return _Organigrama; }
            set
            {
                if (_Organigrama != value)
                {
                    _Organigrama = value;
                    OnPropertyChanged(OrganigramaPropertyName);
                }
            }
        }
        private OrganigramaModel _Organigrama;
        public const string OrganigramaPropertyName = "Organigrama";
        #endregion

        #region PROPIEDADES DEL INTERFAZ IParentItem
        public bool HasLoadedChildren
        {
            get { return _HasLoadedChildren; }
            set
            {
                if (_HasLoadedChildren != value)
                {
                    _HasLoadedChildren = value;
                    OnPropertyChanged(HasLoadedChildrenPropertyName);
                }
            }
        }
        private bool _HasLoadedChildren;
        public const string HasLoadedChildrenPropertyName = "HasLoadedChildren";


        public ObservableCollection<DestinatarioItemViewModel> Children
        {
            get { return _Children; }
            set
            {
                if (_Children != value)
                {
                    _Children = value;
                    OnPropertyChanged(ChildrenPropertyName);
                }
            }
        }
        private ObservableCollection<DestinatarioItemViewModel> _Children;
        public const string ChildrenPropertyName = "Children";

        public IParentItem Parent
        {
            get { return _Parent; }
            set
            {
                if (_Parent != value)
                {
                    _Parent = value;
                    OnPropertyChanged(ParentPropertyName);
                }
            }
        }
        private IParentItem _Parent;
        public const string ParentPropertyName = "Parent";
        #endregion

        #region PROPIEDADES TREEVIEW
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set
            {
                if (_IsExpanded != value)
                {
                    _IsExpanded = value;

                    if (_IsExpanded && this.CanOpenChild)
                    {
                        if (!this.HasLoadedChildren)
                        {
                            this.Children = new ObservableCollection<DestinatarioItemViewModel>();
                            this.GetChildren();
                            this.HasLoadedChildren = true;
                        }
                    }
                    OnPropertyChanged(IsExpandedPropertyName);
                }
            }
        }
        private bool _IsExpanded;
        public const string IsExpandedPropertyName = "IsExpanded";
        #endregion

        #region PROPIEDADES PARA VALIDAR

        //Indica si puede obtener hijos
        public bool CanOpenChild
        {
            get { return _CanOpenChild; }
            set
            {
                if (_CanOpenChild != value)
                {
                    _CanOpenChild = value;
                    OnPropertyChanged(CanOpenChildPropertyName);
                }
            }
        }
        private bool _CanOpenChild;
        public const string CanOpenChildPropertyName = "CanOpenChild";

        //Indica si uno de los hijos ha sido seleccionado
        public bool HasChildrenCheck
        {
            get { return _HasChildrenCheck; }
            set
            {
                if (_HasChildrenCheck != value)
                {
                    _HasChildrenCheck = value;

                    if (_HasChildrenCheck)
                        this.Parent.HasChildrenCheck = true;
                    else
                    {
                        int res = 0;

                        try
                        {
                            res = this.Parent.Children.Where(o => o._HasChildrenCheck == true).ToList().Count();
                        }
                        catch (Exception)
                        {
                            res = 0;
                        }

                        if (res == 0)
                            this.Parent.HasChildrenCheck = false;
                    }

                    OnPropertyChanged(HasChildrenCheckPropertyName);
                }
            }
        }
        private bool _HasChildrenCheck;
        public const string HasChildrenCheckPropertyName = "HasChildrenCheck";

        //Indica si se muestra el check o si se puede elegir el elmento
        public bool CanCheck
        {
            get { return _CanCheck; }
            set
            {
                if (_CanCheck != value)
                {
                    _CanCheck = value;
                    OnPropertyChanged(CanCheckPropertyName);
                }
            }
        }
        private bool _CanCheck;
        public const string CanCheckPropertyName = "CanCheck";
        #endregion

        #region PROPIEDAD QUE SE ENLAZA AL TREEVIEW
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (_IsChecked != value)
                {
                    _IsChecked = value;

                    this.HasChildrenCheck = _IsChecked;

                    OnPropertyChanged(IsCheckedPropertyName);
                }
            }
        }
        private bool _IsChecked;
        public const string IsCheckedPropertyName = "IsChecked";
        #endregion

        #region CONSTRUCTOR
        public DestinatarioItemViewModel(IParentItem Parent)
        {
            this.IsChecked = false;
            this.IsExpanded = false;
            this.CanOpenChild = false;
            this.HasLoadedChildren = false;
            this.CanCheck = true;
            this.Parent = Parent;

            this._OrgRepository = new GestorDocument.DAL.Repository.OrganigramaRepository();
        }
        #endregion

        #region METODOS
        public void GetChildren()
        {
            if (this.CanOpenChild)
            {
                this._OrgRepository.GetOrganigramaParent(this.Organigrama).ToList().ForEach(o =>
                {
                    ObservableCollection<OrganigramaModel> temp = new ObservableCollection<OrganigramaModel>();
                    temp.Add(o);

                    this.Children.Add(new DestinatarioItemViewModel(this)
                    {
                        CanOpenChild = false,
                        Organigrama = o
                    });
                });

            }
        }
        #endregion

    }
}
