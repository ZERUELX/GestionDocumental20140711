using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class ResultadoBusquedaAsuntoTurnoViewModel : ViewModelBase
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

        #region BUSQUEDA DEL ASUNTO
        public BusquedaAsuntoTurnoViewModel Busqueda
        {
            get { return _Busqueda; }
            set
            {
                if (_Busqueda != value)
                {
                    _Busqueda = value;
                    OnPropertyChanged(BusquedaPropertyName);
                }
            }
        }
        private BusquedaAsuntoTurnoViewModel _Busqueda;
        public const string BusquedaPropertyName = "Busqueda";
        #endregion

        private IAsunto _AsuntoRepository;
        private ITurno _TurnoRepository;

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

        public AsuntoModel ReadAsunto
        {
            get { return _ReadAsunto; }
            set
            {
                if (_ReadAsunto != value)
                {
                    _ReadAsunto = value;
                    OnPropertyChanged(ReadAsuntoPropertyName);
                }
            }
        }
        private AsuntoModel _ReadAsunto;
        public const string ReadAsuntoPropertyName = "ReadAsunto";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el lisbox
        public ObservableCollection<TurnoModel> SeguimientoTurnos
        {
            get { return _SeguimientoTurnos; }
            set
            {
                if (_SeguimientoTurnos != value)
                {
                    _SeguimientoTurnos = value;
                    OnPropertyChanged(SeguimientoTurnosPropertyName);
                }
            }
        }
        private ObservableCollection<TurnoModel> _SeguimientoTurnos;
        public const string SeguimientoTurnosPropertyName = "SeguimientoTurnos";

        // SIGNATARIO EXTERNO. 
        public ObservableCollection<SignatarioExternoModel> SignatarioExterno
        {
            get { return _SignatarioExterno; }
            set
            {
                if (_SignatarioExterno != value)
                {
                    _SignatarioExterno = value;
                    OnPropertyChanged(SignatarioExternoPropertyName);
                }
            }
        }
        private ObservableCollection<SignatarioExternoModel> _SignatarioExterno;
        public const string SignatarioExternoPropertyName = "SignatarioExterno";

        private ISignatarioExterno _SignatarioExternoRepository;

        // ***************************** ***************************** *****************************
        // DESTINATARIOS
        private IDestinatario _DestinatarioRepository;

        // ***************************** ***************************** *****************************
        // CONSTRUCTOR.
        public ResultadoBusquedaAsuntoTurnoViewModel(BusquedaAsuntoTurnoViewModel busqueda)
        {
            this._Busqueda = busqueda;
            this._ResultadoBusqueda = new ObservableCollection<AsuntoModel>();

            busqueda.ResultadoBusqueda.OrderByDescending(f=> f.FechaCreacion).ToList().ForEach(p =>this.ResultadoBusqueda.Add(p));

            this._DestinatarioRepository = new GestorDocument.DAL.Repository.DestinatarioRepository();
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
            this._SignatarioExternoRepository = new GestorDocument.DAL.Repository.SignatarioExternoRepository();
            this.SignatarioExterno = new ObservableCollection<SignatarioExternoModel>();

            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            (from p in this.ResultadoBusqueda
             select p).ToList().ForEach(o => o.Turno.Destinatario = this._DestinatarioRepository.GetSeguimientoDestinatarios(o.IdAsunto));
        }

        public void GetDocsDestinatrios()
        {

            //para obtener los destinatarios y documentos 
            ObservableCollection<TurnoModel> seguimiento = this._TurnoRepository.GetTurnosTrancing(this.ReadAsunto.IdAsunto) as ObservableCollection<TurnoModel>;

            this.SeguimientoTurnos = seguimiento;

            this.ReadAsunto.Turno = (from o in this.SeguimientoTurnos
                                     select o).First();

            this.SignatarioExterno = this._SignatarioExternoRepository.GetSignatariosExterno(this.ReadAsunto.IdAsunto) as ObservableCollection<SignatarioExternoModel>;

            this.ReadAsunto.SignatarioExterno = this.SignatarioExterno;

        }

    }
}
