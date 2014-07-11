using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.DAL.Repository.v2;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.v2
{
    public class MenuViewModel:ViewModelBase
    {
        public MenuViewModel()
        {
            this.Menu = new ObservableCollection<MenuModel>();

        }

        
        #region Propiedades

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

        #endregion

        #region Metodos.

        public void Init(long IdRol)
        {
            this.IdRol = IdRol;
            GetMenu();
        }

        public void GetMenu()
        {
            using (var repository=new MenuRepository())
            {
                this.Menu = repository.GetMenu(this.IdRol);
            }
            
        }

        #endregion

    }
}
