using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public delegate void EventHandler<EventArgs>(object sender, EventArgs e);
    public class AddOrganigramaAsuntoViewModel: ViewModelBase
    {

        private AsuntoAddViewModel _AsuntoAddViewModel;
        private AsuntoModViewModel _AsuntoModViewModel;
        private TrancingAsuntoTurnoViewModel _TrancingAsuntoTurnoViewModel;
        public List<OrganigramaModel> AddItem = null;
        
        // ***************************** ***************************** *****************************
        // Repository.
        private IOrganigrama _OrganigramaRepository;

        public OrganigramaModel SelectedOrganigrama
        {
            get { return _SelectedOrganigrama; }
            set
            {
                if (_SelectedOrganigrama != value)
                {
                    _SelectedOrganigrama = value;
                    OnPropertyChanged(OrganigramaPropertyName);
                }
            }
        }
        private OrganigramaModel _SelectedOrganigrama;
        public const string OrganigramaPropertyName = "SelectedOrganigrama";
        // ***************************** ***************************** *****************************
        // treeview.
        public TreeViewViewModel TreeView
        {
            get { return _TreeView; }
            set
            {
                if (_TreeView != value)
                {
                    _TreeView = value;
                    OnPropertyChanged(TreeViewPropertyName);
                }
            }
        }
        private TreeViewViewModel _TreeView;
        public const string TreeViewPropertyName = "TreeView";
        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el treview
        public ObservableCollection<OrganigramaModel> Organigramas
        {
            get { return _Organigramas; }
            set
            {
                if (_Organigramas != value)
                {
                    _Organigramas = value;
                    OnPropertyChanged(DeterminantesPropertyName);
                }
            }
        }
        private ObservableCollection<OrganigramaModel> _Organigramas;
        public const string DeterminantesPropertyName = "Organigramas";        

        public OrganigramaModel Parent
        {
            get { return _Parent; }
            set
            {
                if (_Parent != value)
                {
                    _Parent = value;
                }
            }
        }
        private OrganigramaModel _Parent;
            

        // ***************************** ***************************** *****************************
        // Agregar.
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
            bool _CanSave = false;

            foreach (OrganigramaModel p in this.Organigramas)
            {
                if (p.IsChecked)
                {
                    _CanSave = true;
                    break;
                }
            }

            return _CanSave;
        }
        public void AttemptSave()
        {
            //TODO : agrega a lista temporal
            try
            { 
                foreach (var item in Organigramas)
                {
                    if (item.IsChecked ==true)
                        AddItem.Add(item);
                }
            }
            catch (Exception)
            {

            }
            
            //antes de agregar valida que no exista el determinate
            if (this._AsuntoAddViewModel != null)
                this.ValidateOrganigrama();
            else if (this._AsuntoModViewModel != null)
                this.ValidateOrganigramaMod();
        }

        public void ValidateOrganigrama()
        {
            //se agrega la lista de ids
            List<long> auxUnidsDestinatario = new List<long>();
            
            if (this._AsuntoAddViewModel.Destinatario.Count > 0)
            {
                foreach (var r in this._AsuntoAddViewModel.Destinatario)
                    auxUnidsDestinatario.Add(r.Rol.Organigrama.IdJerarquia);
            }
            //valida con los ids que no exista para agrgar a lista

            foreach (OrganigramaModel item in this.AddItem)
            {
                if (item.IsChecked)
                {
                    if (!auxUnidsDestinatario.Contains(item.IdJerarquia))
                        this._AsuntoAddViewModel.Destinatario.Add(new DestinatarioModel() { IdRol = item.IdRol, Rol = new RolModel() { IdRol = item.IdRol, Organigrama = item } });
                }
            }
            
        }

        public void ValidateOrganigramaMod()
        {
            //se agrega la lista de ids
            List<long> auxUnidsDestinatario = new List<long>();
            
            if (this._AsuntoModViewModel.Destinatario.Count > 0)
            {
                foreach (var r in this._AsuntoModViewModel.Destinatario)
                    auxUnidsDestinatario.Add(r.Rol.Organigrama.IdJerarquia);
            }
            //valida con los ids que no exista para agrgar a lista

            foreach (OrganigramaModel item in this.AddItem)
            {
                if (item.IsChecked)
                {
                    if (!auxUnidsDestinatario.Contains(item.IdJerarquia))
                        this._AsuntoModViewModel.Destinatario.Add(new DestinatarioModel() { IdRol = item.IdRol, Rol = new RolModel() { IdRol = item.IdRol, Organigrama = item } });
                }
            }
            
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddOrganigramaAsuntoViewModel(AsuntoAddViewModel asuntoAddViewModel)
        {
            this._AsuntoAddViewModel = asuntoAddViewModel;
            this._SelectedOrganigrama = asuntoAddViewModel._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol.Organigrama;
            this.AddItem = new List<OrganigramaModel>();
            this._TreeView = new TreeViewViewModel();
            this.Organigramas = new ObservableCollection<OrganigramaModel>();
            this._OrganigramaRepository = new GestorDocument.DAL.Repository.OrganigramaRepository();
            this.LoadInfoGrid();
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddOrganigramaAsuntoViewModel(AsuntoModViewModel asuntoModViewModel)
        {
            this._AsuntoModViewModel = asuntoModViewModel;
            this._SelectedOrganigrama = asuntoModViewModel._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol.Organigrama;
            this.AddItem = new List<OrganigramaModel>();
            this._TreeView = new TreeViewViewModel();
            this.Organigramas = new ObservableCollection<OrganigramaModel>();
            this._OrganigramaRepository = new GestorDocument.DAL.Repository.OrganigramaRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            //obtengo el arborol
           ObservableCollection<OrganigramaModel> res = this._OrganigramaRepository.GetOrganigramaParent(this._SelectedOrganigrama) as ObservableCollection<OrganigramaModel>;

           res.OrderBy(o=> o.JerarquiaName).ToList().ForEach(p=> this.Organigramas.Add(p)); 
        }


    }
}
