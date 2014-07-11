using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.PantallaInicio
{
    public class PantallaInicioViewModel :ViewModelBase
    {
        long idRol = 10;
        long idAtendido = 20130611180608439;
        long idUrgente = 20130611175650143;
        long idPendiente = 20130611180545475;
        long idOrdinario = 20130611175614758;
        long idPrioritarios = 20130611175702903;

        public int RowHeightTitulo
        {
            get { return _RowHeightTitulo; }
            set
            {
                if (_RowHeightTitulo != value)
                {
                    _RowHeightTitulo = value;
                    OnPropertyChanged(RowHeightTituloPropertyName);
                }
            }
        }
        private int _RowHeightTitulo;
        public const string RowHeightTituloPropertyName = "RowHeightTitulo";

        //public int RowHeight
        //{
        //    get { return _RowHeight; }
        //    set
        //    {
        //        if (_RowHeight != value)
        //        {
        //            _RowHeight = value;
        //            OnPropertyChanged(RowHeightPropertyName);
        //        }
        //    }
        //}
        //private int _RowHeight;
        //public const string RowHeightPropertyName = "RowHeight";

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
        // ***************************** ***************************** *****************************
        // Repository.
        private IAsunto _AsuntoRepository;
        public MainWindowViewModel _MainWindowViewModel;
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

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. TODOS LOS ASUNTOS
        public ObservableCollection<AsuntoModel> AuxTodosAsuntos
        {
            get { return _AuxTodosAsuntos; }
            set
            {
                if (_AuxTodosAsuntos != value)
                {
                    _AuxTodosAsuntos = value;
                    OnPropertyChanged(AuxTodosAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _AuxTodosAsuntos;
        public const string AuxTodosAsuntosPropertyName = "AuxTodosAsuntos";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. TODOS LOS ASUNTOS
        public ObservableCollection<AsuntoModel> TodosAsuntos
        {
            get { return _TodosAsuntos; }
            set
            {
                if (_TodosAsuntos != value)
                {
                    _TodosAsuntos = value;
                    OnPropertyChanged(TodosAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _TodosAsuntos;
        public const string TodosAsuntosPropertyName = "TodosAsuntos";

        public int CountTodos
        {
            get { return _CountTodos; }
            set
            {
                if (_CountTodos != value)
                {
                    _CountTodos = value;
                    OnPropertyChanged(CountTodosPropertyName);
                }
            }
        }
        private int _CountTodos;
        public const string CountTodosPropertyName = "CountTodos";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. LOS ASUNTOS ATENDIDOS
        public ObservableCollection<AsuntoModel> AtendidosAsuntos
        {
            get { return _AtendidosAsuntos; }
            set
            {
                if (_AtendidosAsuntos != value)
                {
                    _AtendidosAsuntos = value;
                    OnPropertyChanged(AtendidosAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _AtendidosAsuntos;
        public const string AtendidosAsuntosPropertyName = "AtendidosAsuntos";

        public int CountAtendidos
        {
            get { return _CountAtendidos; }
            set
            {
                if (_CountAtendidos != value)
                {
                    _CountAtendidos = value;
                    OnPropertyChanged(CountAtendidosPropertyName);
                }
            }
        }
        private int _CountAtendidos;
        public const string CountAtendidosPropertyName = "CountAtendidos";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. LOS ASUNTOS URGENTES
        public ObservableCollection<AsuntoModel> UrgentesAsuntos
        {
            get { return _UrgentesAsuntos; }
            set
            {
                if (_UrgentesAsuntos != value)
                {
                    _UrgentesAsuntos = value;
                    OnPropertyChanged(UrgentesAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _UrgentesAsuntos;
        public const string UrgentesAsuntosPropertyName = "UrgentesAsuntos";

        public int CountUrgentes
        {
            get { return _CountUrgentes; }
            set
            {
                if (_CountUrgentes != value)
                {
                    _CountUrgentes = value;
                    OnPropertyChanged(CountUrgentesPropertyName);
                }
            }
        }
        private int _CountUrgentes;
        public const string CountUrgentesPropertyName = "CountUrgentes";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. LOS ASUNTOS PRIORITARIOS
        public ObservableCollection<AsuntoModel> PendientesAsuntos
        {
            get { return _PendientesAsuntos; }
            set
            {
                if (_PendientesAsuntos != value)
                {
                    _PendientesAsuntos = value;
                    OnPropertyChanged(PendientesAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _PendientesAsuntos;
        public const string PendientesAsuntosPropertyName = "PendientesAsuntos";

        public int CountPendientes
        {
            get { return _CountPendientes; }
            set
            {
                if (_CountPendientes != value)
                {
                    _CountPendientes = value;
                    OnPropertyChanged(CountPendientesPropertyName);
                }
            }
        }
        private int _CountPendientes;
        public const string CountPendientesPropertyName = "CountPendientes";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. LOS ASUNTOS EN BORRADOR
        public ObservableCollection<AsuntoModel> BorradorAsuntos
        {
            get { return _BorradorAsuntos; }
            set
            {
                if (_BorradorAsuntos != value)
                {
                    _BorradorAsuntos = value;
                    OnPropertyChanged(BorradorAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _BorradorAsuntos;
        public const string BorradorAsuntosPropertyName = "BorradorAsuntos";

        public int CountBorrador
        {
            get { return _CountBorrador; }
            set
            {
                if (_CountBorrador != value)
                {
                    _CountBorrador = value;
                    OnPropertyChanged(CountBorradorPropertyName);
                }
            }
        }
        private int _CountBorrador;
        public const string CountBorradorPropertyName = "CountBorrador";

        public string TextBorrador
        {
            get { return _TextBorrador; }
            set
            {
                if (_TextBorrador != value)
                {
                    _TextBorrador = value;
                    OnPropertyChanged(TextBorradorPropertyName);
                }
            }
        }
        private string _TextBorrador;
        public const string TextBorradorPropertyName = "TextBorrador";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. LOS ASUNTOS FUERA DE LA FECHA LIMITE
        public ObservableCollection<AsuntoModel> AsuntosFueraFechaLimite
        {
            get { return _AsuntosFueraFechaLimite; }
            set
            {
                if (_AsuntosFueraFechaLimite != value)
                {
                    _AsuntosFueraFechaLimite = value;
                    OnPropertyChanged(AsuntosFueraFechaLimitePropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _AsuntosFueraFechaLimite;
        public const string AsuntosFueraFechaLimitePropertyName = "AsuntosFueraFechaLimite";

        public int CountFueraFechaLimite
        {
            get { return _CountFueraFechaLimite; }
            set
            {
                if (_CountFueraFechaLimite != value)
                {
                    _CountFueraFechaLimite = value;
                    OnPropertyChanged(CountFueraFechaLimitePropertyName);
                }
            }
        }
        private int _CountFueraFechaLimite;
        public const string CountFueraFechaLimitePropertyName = "CountFueraFechaLimite";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. LOS ASUNTOS DETRO DE LA FECHA LIMITE
        public ObservableCollection<AsuntoModel> AsuntosDetroFechaLimite
        {
            get { return _AsuntosDetroFechaLimite; }
            set
            {
                if (_AsuntosDetroFechaLimite != value)
                {
                    _AsuntosDetroFechaLimite = value;
                    OnPropertyChanged(AsuntosDetroFechaLimitePropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _AsuntosDetroFechaLimite;
        public const string AsuntosDetroFechaLimitePropertyName = "AsuntosDetroFechaLimite";

        public int CountDetroFechaLimite
        {
            get { return _CountDetroFechaLimite; }
            set
            {
                if (_CountDetroFechaLimite != value)
                {
                    _CountDetroFechaLimite = value;
                    OnPropertyChanged(CountDetroFechaLimitePropertyName);
                }
            }
        }
        private int _CountDetroFechaLimite;
        public const string CountDetroFechaLimitePropertyName = "CountDetroFechaLimite";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. LOS ASUNTOS ORDINARIOS
        public ObservableCollection<AsuntoModel> OrdinariosAsuntos
        {
            get { return _OrdinariosAsuntos; }
            set
            {
                if (_OrdinariosAsuntos != value)
                {
                    _OrdinariosAsuntos = value;
                    OnPropertyChanged(OrdinariosAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _OrdinariosAsuntos;
        public const string OrdinariosAsuntosPropertyName = "OrdinariosAsuntos";

        public int CountOrdinarios
        {
            get { return _CountOrdinarios; }
            set
            {
                if (_CountOrdinarios != value)
                {
                    _CountOrdinarios = value;
                    OnPropertyChanged(CountOrdinariosPropertyName);
                }
            }
        }
        private int _CountOrdinarios;
        public const string CountOrdinariosPropertyName = "CountOrdinarios";

        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid. LOS ASUNTOS PRIORITARIOS
        public ObservableCollection<AsuntoModel> PrioritariosAsuntos
        {
            get { return _PrioritariosAsuntos; }
            set
            {
                if (_PrioritariosAsuntos != value)
                {
                    _PrioritariosAsuntos = value;
                    OnPropertyChanged(PrioritariosAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _PrioritariosAsuntos;
        public const string PrioritariosAsuntosPropertyName = "PrioritariosAsuntos";

        public int CountPrioritarios
        {
            get { return _CountPrioritarios; }
            set
            {
                if (_CountPrioritarios != value)
                {
                    _CountPrioritarios = value;
                    OnPropertyChanged(CountPrioritariosPropertyName);
                }
            }
        }
        private int _CountPrioritarios;
        public const string CountPrioritariosPropertyName = "CountPrioritarios";

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public PantallaInicioViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this._MainWindowViewModel = mainWindowViewModel;
            this.Usuario = mainWindowViewModel.Usuario;
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this.LoadInfoGrid();
        }

        /// <summary>
        /// Carga todos los asuntos en una lista temporal y los asigna en listas diferentes segun el cuadrante principal.
        /// </summary>
        public void LoadInfoGrid()
        {
            this._AuxTodosAsuntos = new ObservableCollection<AsuntoModel>();
            this.TodosAsuntos = new ObservableCollection<AsuntoModel>();
            this.PendientesAsuntos = new ObservableCollection<AsuntoModel>();
            this.UrgentesAsuntos = new ObservableCollection<AsuntoModel>();
            this.AtendidosAsuntos = new ObservableCollection<AsuntoModel>();
            this.PrioritariosAsuntos = new ObservableCollection<AsuntoModel>();
            this.OrdinariosAsuntos = new ObservableCollection<AsuntoModel>();
            this.BorradorAsuntos = new ObservableCollection<AsuntoModel>();
            this.AsuntosDetroFechaLimite = new ObservableCollection<AsuntoModel>();
            this.AsuntosFueraFechaLimite = new ObservableCollection<AsuntoModel>();
 
            //TRAE TODOS LOS ASUNTOS DE LA BASE
            this.AuxTodosAsuntos = this._AsuntoRepository.GetAsuntos(this.Usuario.Rol) as ObservableCollection<AsuntoModel>;

            this.AuxTodosAsuntos.OrderByDescending(f=> f.FechaCreacion).ToList().ForEach(p=>
            {
                //TODOS
                if (!p.IsBorrador)
                    this.TodosAsuntos.Add(p);
            });

            this.CountTodos= this.TodosAsuntos.Count;
            this.RowHeightTitulo = 1;
            //this.RowHeight = 1;
            //valida dependiendo el rol 
            this.GetValidedBorrador();
        }

        /// <summary>
        /// ICA - Obtiene en lista temporal y las divide en categorias diferentes segun el cuadrante principal.
        /// </summary>
        public void GetValidedBorrador()
        {
            //Direcciones y areas
            if (idRol != this.Usuario.Rol.IdRol)
            {
                this.RowHeightTitulo = 0;
                //this.RowHeight = 0;
                this.TodosAsuntos.OrderByDescending(f => f.FechaCreacion).ToList().ForEach(p =>
                {
                    if (p.Turno != null)
                    {
                        //URGENTES
                        if (p.IdPrioridad == idUrgente &&
                            p.Turno.IdStatusTurno == 1)
                            this.UrgentesAsuntos.Add(p);
                        //ATENDIDOS
                        if (p.Turno.IsTurnado || p.Turno.IsAtendido)
                            this.AtendidosAsuntos.Add(p);
                        //PENDIENTES
                        if (p.Turno.IdStatusTurno == 1)
                            this.PendientesAsuntos.Add(p);
                        //ORDINARIOS
                        if (p.IdPrioridad == idOrdinario &&
                            p.Turno.IdStatusTurno == 1)
                            this.OrdinariosAsuntos.Add(p);
                        //PRIORITARIOS
                        if (p.IdPrioridad == idPrioritarios &&
                            p.Turno.IdStatusTurno == 1)
                            this.PrioritariosAsuntos.Add(p);
                        ////fecha de atencion
                        if (p.Turno.FechaEnvio !=null)
                        {
                            DateTime fechaVencimiento = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", p.FechaVencimiento));
                            DateTime fechaAtendido = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", p.Turno.FechaEnvio));
                            //fuera de la fecha limite
                            if (fechaVencimiento < fechaAtendido &&
                                (p.Turno.IsTurnado || p.Turno.IsAtendido))
                                this.AsuntosFueraFechaLimite.Add(p);
                            //detro de la fecha limite
                            if (fechaVencimiento >= fechaAtendido &&
                                (p.Turno.IsTurnado || p.Turno.IsAtendido))
                                this.AsuntosDetroFechaLimite.Add(p);   
                        }
                    }
                });
                
                (from p in this.TodosAsuntos
                 orderby p.FechaCreacion descending
                 where 
                 (
                    p.Turno != null ? p.Turno.IsBorrador: false
                 )
                 select p).ToList().ForEach(o => this.BorradorAsuntos.Add(o));
               
                this.CountBorrador = this.BorradorAsuntos.Count;

                this.TextBorrador = "( " + this.CountBorrador + " )";

                (from m in this._MainWindowViewModel.Menus.Menu
                 where m.MenuName == "Borrador"
                 select m).ToList().ForEach(o => o.CountBorrador = this.TextBorrador);

                this.CountAtendidos = this.AtendidosAsuntos.Count;
                this.CountPendientes = this.PendientesAsuntos.Count;
                this.CountUrgentes = this.UrgentesAsuntos.Count;
                this.CountOrdinarios = this.OrdinariosAsuntos.Count;
                this.CountPrioritarios = this.PrioritariosAsuntos.Count;
                this.CountFueraFechaLimite = this.AsuntosFueraFechaLimite.Count;
                this.CountDetroFechaLimite = this.AsuntosDetroFechaLimite.Count;

            }
            else
            {
                this.RowHeightTitulo = 30;
                //this.RowHeight = 40;
                //Borrador oficialia 
                this.AuxTodosAsuntos.OrderByDescending(f => f.FechaCreacion).ToList().ForEach(p =>
                {
                    //BORRADOR
                    if (p.IsBorrador)
                        this.BorradorAsuntos.Add(p);
                    //URGENTES
                    if (p.IdPrioridad == idUrgente &&
                        p.IdStatusAsunto != idAtendido &&
                        !p.IsBorrador)
                        this.UrgentesAsuntos.Add(p);
                    //ATENDIDOS
                    if (p.IdStatusAsunto == idAtendido &&
                       !p.IsBorrador)
                        this.AtendidosAsuntos.Add(p);
                    //PENDIENTES
                    if (p.IdStatusAsunto == idPendiente &&
                       !p.IsBorrador)
                        this.PendientesAsuntos.Add(p);
                    //ORDINARIOS
                    if (p.IdPrioridad == idOrdinario &&
                        p.StatusAsunto.IdStatusAsunto != idAtendido &&
                        !p.IsBorrador)
                        this.OrdinariosAsuntos.Add(p);
                    //PRIORITARIOS
                    if (p.IdPrioridad == idPrioritarios &&
                        p.StatusAsunto.IdStatusAsunto != idAtendido &&
                        !p.IsBorrador)
                        this.PrioritariosAsuntos.Add(p);
                    //fecha de atencion
                    if (p.FechaAtendido != null)
                    {
                        DateTime fechaVencimiento = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", p.FechaVencimiento));
                        DateTime fechaAtendido = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", p.FechaAtendido)); 
                        //fuera de la fecha limite

                        if (fechaVencimiento < fechaAtendido &&
                            p.IdStatusAsunto == idAtendido &&
                            !p.IsBorrador)
                            this.AsuntosFueraFechaLimite.Add(p);
                        //detro de la fecha limite
                        if (fechaVencimiento >= fechaAtendido &&
                            p.IdStatusAsunto == idAtendido &&
                            !p.IsBorrador)
                            this.AsuntosDetroFechaLimite.Add(p);
                    }

                });

                this.CountBorrador = this.BorradorAsuntos.Count;
                
                this.TextBorrador = "( " + this.CountBorrador + " )";

                (from m in this._MainWindowViewModel.Menus.Menu
                 where m.MenuName == "Borrador"
                 select m).ToList().ForEach(o => o.CountBorrador = this.TextBorrador);

                this.CountAtendidos = this.AtendidosAsuntos.Count;
                this.CountPendientes = this.PendientesAsuntos.Count;
                this.CountUrgentes = this.UrgentesAsuntos.Count;
                this.CountOrdinarios = this.OrdinariosAsuntos.Count;
                this.CountPrioritarios = this.PrioritariosAsuntos.Count;
                this.CountFueraFechaLimite = this.AsuntosFueraFechaLimite.Count;
                this.CountDetroFechaLimite = this.AsuntosDetroFechaLimite.Count;
            }

        }

    }
}
