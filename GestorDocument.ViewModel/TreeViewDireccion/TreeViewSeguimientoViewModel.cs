using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.ViewModel.TreeviewItemViewModel;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.TreeViewDireccion
{
    public class TreeViewSeguimientoViewModel : ViewModelBase, ISeguimientoParentItem
    {
        private ITurno _TurnoRepository;
        public AsuntoModel SelectedAsuntoTurno
        {
            get { return _SelectedAsuntoTurno; }
            set
            {
                if (_SelectedAsuntoTurno != value)
                {
                    _SelectedAsuntoTurno = value;
                    OnPropertyChanged(SelectedAsuntoTurnoPropertyName);
                }
            }
        }
        private AsuntoModel _SelectedAsuntoTurno;
        public const string SelectedAsuntoTurnoPropertyName = "SelectedAsuntoTurno";
        public ObservableCollection<TurnoModel> AddItem = null;

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

        //Indica si uno de los hijos ha sido seleccionado
        public bool HasChildrenCheck
        {
            get { return _HasChildrenCheck; }
            set
            {
                if (_HasChildrenCheck != value)
                {
                    _HasChildrenCheck = value;

                    OnPropertyChanged(HasChildrenCheckPropertyName);
                }
            }
        }
        private bool _HasChildrenCheck;
        public const string HasChildrenCheckPropertyName = "HasChildrenCheck";

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


         #region CONSTRUCTOR
        /// <summary>
        /// Constructor del Treeview.
        /// </summary>
        /// <param name="selectedAsuntoTurno"></param>
        /// <param name="rol"></param>
        /// <param name="Parent"></param>
        public TreeViewSeguimientoViewModel(AsuntoModel selectedAsuntoTurno,RolModel rol ,ISeguimientoParentItem Parent)
        {
            this.SelectedAsuntoTurno = selectedAsuntoTurno;
            this.Children = new ObservableCollection<SeguimientoTurnoItemViewModel>();
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
            this.Parent = Parent;
            this.AddItem = new ObservableCollection<TurnoModel>();
            this.Rol = rol;
            this.GetSeguimiento();
        }
        #endregion

        /// <summary>
        /// WTF!
        /// </summary>
        public void GetSeguimiento()
        {
            if (this.SelectedAsuntoTurno != null )
            {
                this._TurnoRepository.GetTurnoSeguimiento(this.SelectedAsuntoTurno.IdAsunto)
                    .ToList().ForEach(o =>
                {
                    ObservableCollection<SeguimientoTurnoItemViewModel> temp = new ObservableCollection<SeguimientoTurnoItemViewModel>();
                    temp.Add(
                            new SeguimientoTurnoItemViewModel(this,this.Rol)
                            {
                                Turno = o
                            }
                        );

                    this.Children.Add(new SeguimientoTurnoItemViewModel(this, this.Rol)
                    {
                        CanOpenChild = true,
                        Turno = o,
                        CanCheck = false,
                        Children =  new ObservableCollection<SeguimientoTurnoItemViewModel>(),
                        IsExpanded =false
                    });

                    (from c in this.Children
                     select c).ToList().ForEach
                     (p =>
                     {
                         if (p.Turno.Rol.IdRol == this.Rol.IdRol)
                             p.Turno.Foreground = "Black";
                         else
                             p.Turno.Foreground = "#585858";
                     }
                     );
                    

                });
            }
        }
    }
}
