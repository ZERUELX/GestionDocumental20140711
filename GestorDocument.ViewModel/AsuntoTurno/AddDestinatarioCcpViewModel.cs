using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class AddDestinatarioCcpViewModel : ViewModelBase
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
        // Coleccion para extraer los datos al grid
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
                    if (item.IsChecked == true)
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
            // Destinatarios con copia para
            
            if (this._AsuntoAddViewModel.DestinatarioCcp.Count > 0)
            {
                foreach (var r in this._AsuntoAddViewModel.DestinatarioCcp)
                    auxUnidsDestinatario.Add(r.Rol.Organigrama.IdJerarquia);
            }
            //valida con los ids que no exista para agrgar a lista

            foreach (OrganigramaModel item in this.AddItem)
            {
                if (item.IsChecked)
                {
                    if (!auxUnidsDestinatario.Contains(item.IdJerarquia))
                        this._AsuntoAddViewModel.DestinatarioCcp.Add(new DestinatarioCcpModel() { IdRol = item.IdRol, Rol = new RolModel() { IdRol = item.IdRol, Organigrama = item } });
                }
            }

        }

        public void ValidateOrganigramaMod()
        {
            //se agrega la lista de ids
            List<long> auxUnidsDestinatario = new List<long>();
            // Destinatarios con copia para
            
            if (this._AsuntoModViewModel.DestinatarioCcp.Count > 0)
            {
                foreach (var r in this._AsuntoModViewModel.DestinatarioCcp)
                    auxUnidsDestinatario.Add(r.Rol.Organigrama.IdJerarquia);
            }
            //valida con los ids que no exista para agrgar a lista

            foreach (OrganigramaModel item in this.AddItem)
            {
                if (item.IsChecked)
                {
                    if (!auxUnidsDestinatario.Contains(item.IdJerarquia))
                        this._AsuntoModViewModel.DestinatarioCcp.Add(new DestinatarioCcpModel() { IdRol = item.IdRol, Rol = new RolModel() { IdRol = item.IdRol, Organigrama = item } });
                }
            }
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddDestinatarioCcpViewModel(AsuntoAddViewModel asuntoAddViewModel)
        {
            this._AsuntoAddViewModel = asuntoAddViewModel;
            this._SelectedOrganigrama = asuntoAddViewModel._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol.Organigrama;
            this._Rol = asuntoAddViewModel._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol;
            this.AddItem = new List<OrganigramaModel>();
            this.Organigramas = new ObservableCollection<OrganigramaModel>();
            this._OrganigramaRepository = new GestorDocument.DAL.Repository.OrganigramaRepository();
            this.LoadInfoGrid();
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddDestinatarioCcpViewModel(AsuntoModViewModel asuntoModViewModel)
        {
            this._AsuntoModViewModel = asuntoModViewModel;
            this._SelectedOrganigrama = asuntoModViewModel._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol.Organigrama;
            this._Rol = asuntoModViewModel._ParentAsunto._PantallaInicioViewModel._MainWindowViewModel.Usuario.Rol;
            this.AddItem = new List<OrganigramaModel>();
            this.Organigramas = new ObservableCollection<OrganigramaModel>();
            this._OrganigramaRepository = new GestorDocument.DAL.Repository.OrganigramaRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            ObservableCollection<OrganigramaModel> res = this._OrganigramaRepository.GetOrganigrama(this._Rol) as ObservableCollection<OrganigramaModel>;

            res.OrderBy(o => o.JerarquiaName).ToList().ForEach(p=> this.Organigramas.Add(p));


        }
    }
}
