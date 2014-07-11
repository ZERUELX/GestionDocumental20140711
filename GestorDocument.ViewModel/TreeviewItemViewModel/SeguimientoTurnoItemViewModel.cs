using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.TreeviewItemViewModel
{
    public class SeguimientoTurnoItemViewModel : ViewModelBase, ISeguimientoParentItem
    {
        #region ROL Y USUARIO
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

        public UsuarioModel Usuario
        {
            get { return _Usuario; }
            set
            {
                if (_Usuario != value)
                {
                    _Usuario = value;
                    OnPropertyChanged(UsuarioPropertyName);
                }
            }
        }
        private UsuarioModel _Usuario;
        public const string UsuarioPropertyName = "Usuario";

        #endregion

        #region TURNO MODEL
        private ITurno _TurnoRepository;

        public TurnoModel Turno
        {
            get { return _Turno; }
            set
            {
                if (_Turno != value)
                {
                    _Turno = value;
                    OnPropertyChanged(TurnoPropertyName);
                }
            }
        }
        private TurnoModel _Turno;
        public const string TurnoPropertyName = "Turno";
        #endregion

        #region PROPIEDADES DEL INTERFAZ ISeguimientoParentItem
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


        public ObservableCollection<SeguimientoTurnoItemViewModel> Children
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
        private ObservableCollection<SeguimientoTurnoItemViewModel> _Children;
        public const string ChildrenPropertyName = "Children";

        public ISeguimientoParentItem Parent
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
        private ISeguimientoParentItem _Parent;
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

                    if (this.CanOpenChild)
                    {
                        if (!this.HasLoadedChildren)
                        {
                            this.Children = new ObservableCollection<SeguimientoTurnoItemViewModel>();
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
        public SeguimientoTurnoItemViewModel(ISeguimientoParentItem Parent, RolModel rol)
        {

            this.IsChecked = false;
            this.IsExpanded = true;
            this.CanOpenChild = true;
            this.HasLoadedChildren = false;
            this.CanCheck = true;
            this.Parent = Parent;
            this.Rol = rol;
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
        }
        #endregion

        #region METODOS
        public void GetChildren()
        {
            if (this.CanOpenChild)
            {
                this._TurnoRepository.GetTurnosTrancing(this.Turno).ToList().ForEach(o =>
                {
                    ObservableCollection<TurnoModel> temp = new ObservableCollection<TurnoModel>();
                    temp.Add(o);

                    this.Children.Add(new SeguimientoTurnoItemViewModel(this,this.Rol)
                    {
                        CanOpenChild = true,
                        IsExpanded = true,
                        Turno=o
                    });


                   (from c in this.Children
                     select c).ToList().ForEach
                     (p =>
                         {
                             if (p.Turno.Rol.IdRol == this.Rol.IdRol)
                                 p.Turno.Foreground = "Black";
                             else if (p.Turno.IsAtendido || p.Turno.IsTurnado)
                                 p.Turno.Foreground = "#585858";
                             else
                                 p.Turno.Foreground = "Red";

                            p.Children= this.GetChildren(p.Turno);
                         }
                     );

                });
            }
        }

        public ObservableCollection<SeguimientoTurnoItemViewModel> GetChildren(TurnoModel parent)
        {
            ObservableCollection<SeguimientoTurnoItemViewModel> auxChildren = new ObservableCollection<SeguimientoTurnoItemViewModel>();

            this._TurnoRepository.GetTurnosTrancing(parent).ToList().ForEach(o =>
            {
                ObservableCollection<TurnoModel> temp = new ObservableCollection<TurnoModel>();
                temp.Add(o);

                if (o.Rol.IdRol == this.Rol.IdRol)
                    o.Foreground = "Black";
                else if (o.IsAtendido || o.IsTurnado)
                    o.Foreground = "#585858";
                else
                    o.Foreground = "Red";

                auxChildren.Add(new SeguimientoTurnoItemViewModel(this, this.Rol)
                {
                    CanOpenChild = true,
                    IsExpanded = true,
                    Turno = o,
                });

                
            });

            auxChildren.ToList().ForEach(c =>
            {
                c.Children = new ObservableCollection<SeguimientoTurnoItemViewModel>();

                c.Children = this.GetChildren(c.Turno);
            });


            return auxChildren;
        }
        #endregion
    }
}
