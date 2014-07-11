using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.ViewModel.TreeviewItemViewModel;
using System.Collections.ObjectModel;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using GestorDocument.ViewModel.AsuntoTurno;

namespace GestorDocument.ViewModel.TreeViewDireccion
{
    public class DestinatarioDireccionesTreeViewModel : ViewModelBase, IParentItem
    {
        private IOrganigrama _OrganigramaRepository;
        private TrancingAsuntoTurnoViewModel _TrancingAsuntoTurnoViewModel;
        public ObservableCollection<OrganigramaModel> AddItem =null;

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

        #region BOTON PARA AGREGAR DESTINATARIOS
        public RelayCommand AddOrganigramaCommand
        {
            get
            {
                if (_AddOrganigramaCommand == null)
                {
                    _AddOrganigramaCommand = new RelayCommand(p => this.AttemptSave(), p => this.CanSave());
                }
                return _AddOrganigramaCommand;
            }
        }
        private RelayCommand _AddOrganigramaCommand;
        public bool CanSave()
        {
            return this.HasChildrenCheck;
        }
        public void AttemptSave()
        {
            foreach (DestinatarioItemViewModel item in this.Children)
            {
                if (item.IsChecked == false)
                    GetRecursivo(item);
                else
                    this.AddItem.Add(item.Organigrama);
            }

           this.ValidateOrganigramaTrancing();
        }
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
        public DestinatarioDireccionesTreeViewModel(TrancingAsuntoTurnoViewModel trancingAsuntoTurnoViewModel, IParentItem Parent)
        {
            this._TrancingAsuntoTurnoViewModel = trancingAsuntoTurnoViewModel;
            this.Children = new ObservableCollection<DestinatarioItemViewModel>();
            this._OrganigramaRepository = new GestorDocument.DAL.Repository.OrganigramaRepository();
            this.Rol = trancingAsuntoTurnoViewModel._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol;
            this.TipoUnidadNormativa = trancingAsuntoTurnoViewModel._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol.Organigrama.TipoUnidadNormativa;
            this.Parent = Parent;
            this.AddItem = new ObservableCollection<OrganigramaModel>();
            this.GetBrothers();
        }
        #endregion

        #region METODOS
        public void GetBrothers()
        {
            if (this.Rol != null && this.Rol.Organigrama != null)
            {
                this._OrganigramaRepository.GetOrganigramaParent(new OrganigramaModel()
                {
                    IdJerarquia = (long)this._Rol.Organigrama.IdJerarquiaParent
                }).ToList().ForEach(o =>
                {
                    ObservableCollection<DestinatarioItemViewModel> temp = new ObservableCollection<DestinatarioItemViewModel>();
                    temp.Add(
                            new DestinatarioItemViewModel(this)
                            {
                                Organigrama = o
                            }
                        );

                    this.Children.Add(new DestinatarioItemViewModel(this)
                    {
                        CanOpenChild = (o.IdRol == this.Rol.IdRol ) ? true : false,
                        Organigrama = o,
                        CanCheck = (o.IdRol == this.Rol.IdRol) ? false : true,
                        Children = (o.IdRol == this.Rol.IdRol) ? temp : new ObservableCollection<DestinatarioItemViewModel>(),

                    });
                });
            }
        }

        public void ValidateOrganigramaTrancing()
        {
            //se agrega la lista de ids
            List<long> auxUnidsDestinatario = new List<long>();
            if (this._TrancingAsuntoTurnoViewModel.Destinatario.Count > 0)
            {
                foreach (var r in this._TrancingAsuntoTurnoViewModel.Destinatario)
                    auxUnidsDestinatario.Add(r.Rol.Organigrama.IdJerarquia);
            }
            //valida con los ids que no exista para agrgar a lista

            foreach (OrganigramaModel item in this.AddItem)
            {
                if (!auxUnidsDestinatario.Contains(item.IdJerarquia))
                {
                    this._TrancingAsuntoTurnoViewModel.Destinatario.Add(new DestinatarioModel() { IdRol = item.IdRol, Rol = new RolModel() { IdRol = item.IdRol, Organigrama = item } });
                }
            }
        }

        public void GetRecursivo(DestinatarioItemViewModel parent)
        {
            if (parent.Children !=null)
            {
                foreach (var item in parent.Children)
                {
                    if (item.IsChecked == true)
                    {
                        AddItem.Add(item.Organigrama);
                        GetRecursivo(item);
                    }
                }   
            }
        }
        #endregion
    }
}
