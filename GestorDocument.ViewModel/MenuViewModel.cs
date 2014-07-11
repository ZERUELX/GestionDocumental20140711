using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository. Usuario
        private IMenu _MenuRepository;

        public ObservableCollection<MenuModel> Menu
        {
            get { return _Menu; }
            set
            {
                if (_Menu != value)
                {
                    _Menu = value;
                    OnPropertyChanged(MenuPropertyName);
                }
            }
        }
        private ObservableCollection<MenuModel> _Menu;
        public const string MenuPropertyName = "Menu";

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

        public MenuViewModel(RolModel rol)
        {
            this.Rol = rol;
            this._MenuRepository = new GestorDocument.DAL.Repository.MenuRepository();
            this.LoadInfo();
        }

        public void LoadInfo()
        {
            this.Menu = this._MenuRepository.GetMenu(this.Rol.IdRol) as ObservableCollection<MenuModel>;
        }
    }
}
