using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;
using System.Configuration;
using GestorDocument.ViewModel.PantallaInicio;
using GestorDocument.ViewModel.Login;

namespace GestorDocument.ViewModel
{
    public class MainWindowViewModel :ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository. Usuario
        private IUsuario _UsuarioRepository;

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

        public MenuViewModel Menus
        {
            get { return _Menus; }
            set
            {
                if (_Menus != value)
                {
                    _Menus = value;
                    OnPropertyChanged(MenusPropertyName);
                }
            }
        }
        private MenuViewModel _Menus;
        public const string MenusPropertyName = "Menus";

        public PantallaInicioViewModel PantallaInicio
        {
            get { return _PantallaInicio; }
            set
            {
                if (_PantallaInicio != value)
                {
                    _PantallaInicio = value;
                    OnPropertyChanged(PantallaInicioPropertyName);
                }
            }
        }
        private PantallaInicioViewModel _PantallaInicio;
        public const string PantallaInicioPropertyName = "PantallaInicio";

        public UserLoginViewModel UserLogin
        {
            get { return _UserLogin; }
            set
            {
                if (_UserLogin != value)
                {
                    _UserLogin = value;
                    OnPropertyChanged(UserLoginPropertyName);
                }
            }
        }
        private UserLoginViewModel _UserLogin;
        public const string UserLoginPropertyName = "UserLogin";

        public MainWindowViewModel()
        {
            this._Usuario = new UsuarioModel() { UsuarioCorreo = ConfigurationManager.AppSettings["UsuarioCorreo"].ToString() };
            this._UsuarioRepository = new GestorDocument.DAL.Repository.UsuarioRepository();

            this.LoadInfo();

            this.LoadInfoPantallaInicio();
        }

        public MainWindowViewModel(UserLoginViewModel userLogin)
        {
            this.UserLogin = userLogin;
            this._Usuario = userLogin.User;
            this._UsuarioRepository = new GestorDocument.DAL.Repository.UsuarioRepository();

            this.LoadInfo();

            this.LoadInfoPantallaInicio();
        }

        public void LoadInfo()
        {
            this.Usuario = this._UsuarioRepository.GetUsuarioID(this._Usuario);

            this.Menus = new MenuViewModel(this.Usuario.Rol);

        }

        /// <summary>
        /// Carga tablero con cuadrantes.
        /// </summary>
        public void LoadInfoPantallaInicio()
        {
            if (this.Usuario != null)
            {
                this.PantallaInicio = new PantallaInicioViewModel(this);

                (from m in this.Menus.Menu
                 where m.MenuName == "Borrador"
                 select m).ToList().ForEach(o => o.CountBorrador = this.PantallaInicio.TextBorrador);
                
            }
        }

    }
}
