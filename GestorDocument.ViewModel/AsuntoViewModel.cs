using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.DAL;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;
using GestorDocument.ViewModel.PantallaInicio;

namespace GestorDocument.ViewModel
{
    public class AsuntoViewModel : ViewModelBase
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

        // ***************************** ***************************** *****************************
        // Repository.
        private IAsunto _AsuntoRepository;
        public PantallaInicioViewModel _PantallaInicioViewModel;
        public int _Filtro;
        public int _FiltroUrgentes;
        public int _FiltroAtendidos;
        public int _FiltroPendientes;
        public int _FiltroTodos;
        public int _FiltroBorrador;
        public int _FiltroDetroFechaLimite;
        public int _FiltroFueraFechaLimite;
        public int _FiltroPrioritario;
        public int _FiltroOrdinario;

        public string TituloGrid
        {
            get { return _TituloGrid; }
            set
            {
                if (_TituloGrid != value)
                {
                    _TituloGrid = value;
                    OnPropertyChanged(TituloGridPropertyName);
                }
            }
        }
        private string _TituloGrid;
        public const string TituloGridPropertyName = "TituloGrid";

        public string BackgroundTitulo
        {
            get { return _BackgroundTitulo; }
            set
            {
                if (_BackgroundTitulo != value)
                {
                    _BackgroundTitulo = value;
                    OnPropertyChanged(BackgroundTituloPropertyName);
                }
            }
        }
        private string _BackgroundTitulo;
        public const string BackgroundTituloPropertyName = "BackgroundTitulo";

        public AsuntoModel SelectedAsunto
        {
            get { return _SelectedAsunto; }
            set
            {
                if (_SelectedAsunto != value)
                {
                    _SelectedAsunto = value;
                    OnPropertyChanged(SelectedAsuntoPropertyName);
                }
            }
        }
        private AsuntoModel _SelectedAsunto;
        public const string SelectedAsuntoPropertyName = "SelectedAsunto";

        public TurnoModel SelectedTurno
        {
            get { return _SelectedTurno; }
            set
            {
                if (_SelectedTurno != value)
                {
                    _SelectedTurno = value;
                    OnPropertyChanged(SelectedTurnoPropertyName);
                }
            }
        }
        private TurnoModel _SelectedTurno;
        public const string SelectedTurnoPropertyName = "SelectedTurno";

        public BusquedaViewModel Busqueda
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
        private BusquedaViewModel _Busqueda;
        public const string BusquedaPropertyName = "Busqueda";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<AsuntoModel> Asuntos
        {
            get { return _Asuntos; }
            set
            {
                if (_Asuntos != value)
                {
                    _Asuntos = value;
                    OnPropertyChanged(AsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _Asuntos;
        public const string AsuntosPropertyName = "Asuntos";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<TurnoModel> Turnos
        {
            get { return _Turnos; }
            set
            {
                if (_Turnos != value)
                {
                    _Turnos = value;
                    OnPropertyChanged(TurnoPropertyName);
                }
            }
        }
        private ObservableCollection<TurnoModel> _Turnos;
        public const string TurnoPropertyName = "Turnos";

        
        // ***************************** ***************************** *****************************
        // ELiminar.
        public RelayCommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand(p => this.AttemptDelete(), p => this.CanDelete());
                }

                return _DeleteCommand;
            }

        }
        private RelayCommand _DeleteCommand;
        public bool CanDelete()
        {
            bool _CanDelete = false;

            foreach (AsuntoModel p in this.Asuntos)
            {
                if (p.IsChecked)
                {
                    _CanDelete = true;
                    break;

                }
            }

            return _CanDelete;
        }
        public void AttemptDelete()
        {
            //TODO : Delete to database
            List<AsuntoModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.Asuntos
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._AsuntoRepository.DeleteAsunto(DeleteItem);
            this.LoadInfoGrid();
        }

        // ***************************** ***************************** *****************************
        // DESTINATARIOS
        private IDestinatario _DestinatarioRepository;


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AsuntoViewModel()
        {
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this.LoadInfoGrid();
        }

        /// <summary>
        /// Constructor de AsuntoViewModel
        /// </summary>
        /// <param name="pantallaInicioViewModel">ViewModel d la pantalla principal.</param>
        /// <param name="filtro">Filtro(Urgentes,Todos,Pendientes,Atendidos)</param>
        public AsuntoViewModel(PantallaInicioViewModel pantallaInicioViewModel, int filtro)
        {
            this._PantallaInicioViewModel = pantallaInicioViewModel;
            this._Rol = _PantallaInicioViewModel.Usuario.Rol;
            this._Filtro = filtro;
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this.Busqueda = new BusquedaViewModel(this._Rol);
            this._DestinatarioRepository = new GestorDocument.DAL.Repository.DestinatarioRepository();
            this.LoadInfoGrid();
        }
        
        /// <summary>
        /// Obtiene los asuntos segun el filtro
        /// </summary>
        public void LoadInfoGrid()
        {
            this.Asuntos = new ObservableCollection<AsuntoModel>();

            //URGENTES
            if (this._Filtro == 1)
            {
                this._FiltroUrgentes = _Filtro;
                this.Asuntos = this._PantallaInicioViewModel.UrgentesAsuntos;
                this.TituloGrid = "ASUNTOS URGENTES POR ATENDER";
                this.BackgroundTitulo = "#FE2E2E";

            }
            //ATENDIDOS
            if (this._Filtro == 2)
            {
                this._FiltroAtendidos = _Filtro;
                this.Asuntos = this._PantallaInicioViewModel.AtendidosAsuntos;
                this.TituloGrid = "ASUNTOS ATENDIDOS";
                this.BackgroundTitulo = "#088A08";
            }
            //PENDIENTES
            if (this._Filtro == 3)
            {
                this._FiltroPendientes = _Filtro;
                this.Asuntos = this._PantallaInicioViewModel.PendientesAsuntos;
                this.TituloGrid = "ASUNTOS PENDIENTES POR ATENDER";
                this.BackgroundTitulo = "#FF8000";
            }

            //TODOS
            if (this._Filtro == 4)
            {
                this._FiltroTodos = _Filtro;
                this.Asuntos = this._PantallaInicioViewModel.TodosAsuntos;
                this.TituloGrid = "TOTAL DE ASUNTOS RECIBIDOS/ TURNADOS";
                this.BackgroundTitulo = "#01A9DB";
            }

            //BORRADOR
            if (this._Filtro == 5)
            {
                this._FiltroBorrador = _Filtro;
                this.Asuntos = this._PantallaInicioViewModel.BorradorAsuntos;
                this.TituloGrid = "ASUNTOS EN BORRADOR";
                this.BackgroundTitulo = "#0040FF";
            }

            //DETRO DE LA FECHA LIMITE
            if (this._Filtro == 6)
            {
                this._FiltroDetroFechaLimite = _Filtro;
                this.Asuntos = this._PantallaInicioViewModel.AsuntosDetroFechaLimite;
                this.TituloGrid = "ASUNTOS ATENDIDOS DENTRO DE LA FECHA LÍMITE";
                this.BackgroundTitulo = "#088A08";
            }
            //FUERA DE LA FECHA LIMITE
            if (this._Filtro == 7)
            {
                this._FiltroFueraFechaLimite = _Filtro;
                this.Asuntos = this._PantallaInicioViewModel.AsuntosFueraFechaLimite;
                this.TituloGrid = "ASUNTOS ATENDIDOS FUERA DE LA FECHA LÍMITE";
                this.BackgroundTitulo = "#FE2E2E";
            }
            //PRIORITARIO
            if (this._Filtro == 8)
            {
                this._FiltroPrioritario = _Filtro;
                this.Asuntos = this._PantallaInicioViewModel.PrioritariosAsuntos;
                this.TituloGrid = "ASUNTOS PRIORITARIOS POR ATENDER";
                this.BackgroundTitulo = "#AEB404";
            }
            //ORDINARIO
            if (this._Filtro == 9)
            {
                this._FiltroOrdinario = _Filtro;
                this.Asuntos = this._PantallaInicioViewModel.OrdinariosAsuntos;
                this.TituloGrid = "ASUNTOS ORDINARIO POR ATENDER";
                this.BackgroundTitulo = "#A4A4A4";
            }

            (from p in this.Asuntos
             select p).ToList().ForEach(o => o.Turno.Destinatario = this._DestinatarioRepository.GetSeguimientoDestinatarios(o.IdAsunto));
        }

        public void LoadInfoGridBusqueda()
        {
            //this.Asuntos = new ObservableCollection<AsuntoModel>();

            //if (this.Busqueda.ResultadoBusqueda.Count !=0)
            //{
            //    this.Asuntos = this.Busqueda.ResultadoBusqueda;

            //    (from p in this.Asuntos
            //     select p).ToList().ForEach(o => o.Turno.Destinatario = this._DestinatarioRepository.GetSeguimientoDestinatarios(o.IdAsunto));

            //    this.TituloGrid = "RESULTADOS DE LA BUSQUEDA DE ASUNTOS";
            //    this.BackgroundTitulo = "#AC58FA";
            //}
            //else
            //{
            //    this.TituloGrid = " SIN RESULTADO DE LA BUSQUEDA DE ASUNTOS";
            //    this.BackgroundTitulo = "#AC58FA";
            //}
        }

    }
}
