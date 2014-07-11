using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel
{
    public class BusquedaAsuntoTurnoViewModel : ViewModelBase
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

        private IAsunto _AsuntoRepository;

        public ObservableCollection<AsuntoModel> ResultadoBusqueda
        {
            get { return _ResultadoBusqueda; }
            set
            {
                if (_ResultadoBusqueda != value)
                {
                    _ResultadoBusqueda = value;
                    OnPropertyChanged(ResultadoBusquedaPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _ResultadoBusqueda;
        public const string ResultadoBusquedaPropertyName = "ResultadoBusqueda";

        // ***************************** ***************************** *****************************
        // TEXTBOX FOLIO ASUNTO .

        public string SelectedFolio
        {
            get { return _SelectedFolio; }
            set
            {
                if (_SelectedFolio != value)
                {
                    _SelectedFolio = value;

                    if (_SelectedFolio == "")
                    {
                        _SelectedFolio = null;
                    }
                    OnPropertyChanged(SelectedFolioPropertyName);
                }
            }
        }
        private string _SelectedFolio;
        public const string SelectedFolioPropertyName = "SelectedFolio";

        // ***************************** ***************************** *****************************
        // TEXTBOX TITULO ASUNTO.

        public string SelectedTituloAsunto
        {
            get { return _SelectedTituloAsunto; }
            set
            {
                if (_SelectedTituloAsunto != value)
                {
                    _SelectedTituloAsunto = value;

                    if (_SelectedTituloAsunto == "")
                    {
                        _SelectedTituloAsunto = null;
                    }
                    OnPropertyChanged(SelectedTituloAsuntoPropertyName);
                }
            }
        }
        private string _SelectedTituloAsunto;
        public const string SelectedTituloAsuntoPropertyName = "SelectedTituloAsunto";

        // ***************************** ***************************** *****************************
        // TEXTBOX DESCRIPCION DEL ASUNTO.

        public string SelectedDescripcionAsunto
        {
            get { return _SelectedDescripcionAsunto; }
            set
            {
                if (_SelectedDescripcionAsunto != value)
                {
                    _SelectedDescripcionAsunto = value;

                    if (_SelectedDescripcionAsunto == "")
                    {
                        _SelectedDescripcionAsunto = null;
                    }
                    OnPropertyChanged(SelectedDescripcionAsuntoPropertyName);
                }
            }
        }
        private string _SelectedDescripcionAsunto;
        public const string SelectedDescripcionAsuntoPropertyName = "SelectedDescripcionAsunto";

        // ***************************** ***************************** *****************************
        // BUSQUEDA.

        public RelayCommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new RelayCommand(p => this.AttemptSearch(), p => this.CanSearch());
                }

                return _SearchCommand;
            }

        }
        private RelayCommand _SearchCommand;
        public bool CanSearch()
        {
            //solo busca
            return true;
        }
        public void AttemptSearch()
        {
            this.ResultadoBusqueda =
                this._AsuntoRepository.GetBusquedaAsunto(
                (!String.IsNullOrWhiteSpace(this._SelectedTituloAsunto)) ?   this._SelectedTituloAsunto.Trim():null
                ,(!String.IsNullOrWhiteSpace(this._SelectedFolio)) ? this._SelectedFolio.Trim():null
                ,(!String.IsNullOrWhiteSpace(this._SelectedDescripcionAsunto)) ? this._SelectedDescripcionAsunto.Trim() :null 
                ,this._Rol) as ObservableCollection<AsuntoModel>;
            
        }


        // ***************************** ***************************** *****************************
        // VALIDA BUSQUEDA.

        public RelayCommand ValidarSearchCommand
        {
            get
            {
                if (_ValidarSearchCommand == null)
                {
                    _ValidarSearchCommand = new RelayCommand(p => this.ValidarAttemptSearch(), p => this.ValidarCanSearch());
                }

                return _ValidarSearchCommand;
            }

        }
        private RelayCommand _ValidarSearchCommand;
        public bool ValidarCanSearch()
        {
            bool _CanSearch = false;


            if (
                (!String.IsNullOrWhiteSpace(this._SelectedFolio)) ||
                (!String.IsNullOrWhiteSpace(this._SelectedTituloAsunto)) ||
                (!String.IsNullOrWhiteSpace(this._SelectedDescripcionAsunto))
               )
            {
                _CanSearch = true;
            }
            

            return _CanSearch;
        }
        public void ValidarAttemptSearch()
        {
            //solo valida
        }

        // ***************************** ***************************** *****************************
        // CONSTRUCTOR.
        public BusquedaAsuntoTurnoViewModel(RolModel rol)
        {
            this._Rol = rol;
            this._ResultadoBusqueda = new ObservableCollection<AsuntoModel>();
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
        }

    }
}
