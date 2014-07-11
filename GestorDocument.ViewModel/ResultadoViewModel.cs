using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.DAL;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;
using GestorDocument.Model.v2;

namespace GestorDocument.ViewModel
{
    public class ResultadoViewModel : ViewModelBase
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
        // LISTBOX DE ASUNTOS.

        private IAsunto _AsuntoRepository;
        GestorDocument.DAL.Repository.v2.BusquedaRepository br;

        public AsuntoModel SelectedResultado
        {
            get { return _SelectedResultado; }
            set
            {
                if (_SelectedResultado != value)
                {
                    _SelectedResultado = value;
                    OnPropertyChanged(SelectedResultadoPropertyName);
                }
            }
        }
        private AsuntoModel _SelectedResultado;
        public const string SelectedResultadoPropertyName = "SelectedResultado";

        public ObservableCollection<AsuntoModel> Resultado
        {
            get { return _Resultado; }
            set
            {
                if (_Resultado != value)
                {
                    _Resultado = value;
                    OnPropertyChanged(ResultadoPropertyName);
                }
            }
        }
        private ObservableCollection<AsuntoModel> _Resultado;
        public const string ResultadoPropertyName = "Resultado";

        public ObservableCollection<AsuntosDataGridModel> ResultadoBusqueda
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
        private ObservableCollection<AsuntosDataGridModel> _ResultadoBusqueda;
        public const string ResultadoBusquedaPropertyName = "ResultadoBusqueda";

        // ***************************** ***************************** *****************************
        // FILTROS: PRIORIDAD.

        public PrioridadModel FiltroPrioridad
        {
            get { return _FiltroPrioridad; }
            set
            {
                if (_FiltroPrioridad != value)
                {
                    _FiltroPrioridad = value;
                    OnPropertyChanged(FiltroPrioridadPropertyName);
                }
            }
        }
        private PrioridadModel _FiltroPrioridad;
        public const string FiltroPrioridadPropertyName = "FiltroPrioridad";

        // FILTROS: STATUS ASUNTO.
        public StatusAsuntoModel FiltroStatusAsunto
        {
            get { return _FiltroStatusAsunto; }
            set
            {
                if (_FiltroStatusAsunto != value)
                {
                    _FiltroStatusAsunto = value;
                    OnPropertyChanged(FiltroStatusAsuntoPropertyName);
                }
            }
        }
        private StatusAsuntoModel _FiltroStatusAsunto;
        public const string FiltroStatusAsuntoPropertyName = "FiltroStatusAsunto";

        // FILTROS: DESTINATARIO.
        public string FiltroDestinatario
        {
            get { return _FiltroDestinatario; }
            set
            {
                if (_FiltroDestinatario != value)
                {
                    _FiltroDestinatario = value;
                    OnPropertyChanged(FiltroDestinatarioPropertyName);
                }
            }
        }
        private string _FiltroDestinatario;
        public const string FiltroDestinatarioPropertyName = "FiltroDestinatario";

        // FILTROS: SIGNATARIO.
        public string FiltroSignatario
        {
            get { return _FiltroSignatario; }
            set
            {
                if (_FiltroSignatario != value)
                {
                    _FiltroSignatario = value;
                    OnPropertyChanged(FiltroSignatarioPropertyName);
                }
            }
        }
        private string _FiltroSignatario;
        public const string FiltroSignatarioPropertyName = "FiltroSignatario";

        // FILTROS: RANGO DE FECHA DESDE.
        public DateTime? FiltroRangoFechaDesde
        {
            get { return _FiltroRangoFechaDesde; }
            set
            {
                if (_FiltroRangoFechaDesde != value)
                {
                    _FiltroRangoFechaDesde = value;
                    OnPropertyChanged(FiltroRangoFechaDesdePropertyName);
                }
            }
        }
        private DateTime? _FiltroRangoFechaDesde;
        public const string FiltroRangoFechaDesdePropertyName = "FiltroRangoFechaDesde";

        // FILTROS: RANGO DE FECHA HASTA.
        public DateTime? FiltroRangoFechaHasta
        {
            get { return _FiltroRangoFechaHasta; }
            set
            {
                if (_FiltroRangoFechaHasta != value)
                {
                    _FiltroRangoFechaHasta = value;
                    OnPropertyChanged(FiltroRangoFechaHastaPropertyName);
                }
            }
        }
        private DateTime? _FiltroRangoFechaHasta;
        public const string FiltroRangoFechaHastaPropertyName = "FiltroRangoFechaHasta";

        // FILTROS: FOLIO DOCUMENTO.
        public string FiltroFolioDocumento
        {
            get { return _FiltroFolioDocumento; }
            set
            {
                if (_FiltroFolioDocumento != value)
                {
                    _FiltroFolioDocumento = value;
                    OnPropertyChanged(FiltroFolioDocumentoPropertyName);
                }
            }
        }
        private string _FiltroFolioDocumento;
        public const string FiltroFolioDocumentoPropertyName = "FiltroFolioDocumento";

        // ***************************** ***************************** *****************************
        // CONSTRUCTOR.

        public ResultadoViewModel()
        {
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            br = new DAL.Repository.v2.BusquedaRepository();

        }

        public ObservableCollection<AsuntoModel> LoadInfoGrid(string prioridad, string statusAsunto, string destinatario, string signatario, DateTime? rangofechadesde, DateTime? rangofechahasta, string folio, string tituloAsunto, string descripcionAsunto, string nombreDocumento, RolModel rol)
        {
            // VALORES EN PANTALLA PARA FILTROS.
            this._Rol = rol;
            //this.FiltroPrioridad = prioridad;
            //this.FiltroStatusAsunto = statusasunto;
            this.FiltroDestinatario = destinatario;
            this.FiltroSignatario = signatario;
            this.FiltroRangoFechaDesde = rangofechadesde;
            this.FiltroRangoFechaHasta = rangofechahasta;
            this.FiltroFolioDocumento = folio;

            this.Resultado = this._AsuntoRepository.GetBusqueda(prioridad, statusAsunto, destinatario, signatario, rangofechadesde, rangofechahasta, folio, tituloAsunto, descripcionAsunto, nombreDocumento, this._Rol) as ObservableCollection<AsuntoModel>;

            return this.Resultado;
        }

        public ObservableCollection<AsuntosDataGridModel> LoadInfoGridBusqueda(string prioridad, string statusAsunto, string destinatario, string signatario, DateTime? rangofechadesde, DateTime? rangofechahasta, string folio, string tituloAsunto, string descripcionAsunto, string nombreDocumento, RolModel rol)
        {
            // VALORES EN PANTALLA PARA FILTROS.
            this._Rol = rol;
            //this.FiltroPrioridad = prioridad;
            //this.FiltroStatusAsunto = statusasunto;
            this.FiltroDestinatario = destinatario;
            this.FiltroSignatario = signatario;
            this.FiltroRangoFechaDesde = rangofechadesde;
            this.FiltroRangoFechaHasta = rangofechahasta;
            this.FiltroFolioDocumento = folio;

            this.ResultadoBusqueda = this.br.GetBusqueda(prioridad, statusAsunto, destinatario, signatario, rangofechadesde, rangofechahasta, folio, tituloAsunto, descripcionAsunto, nombreDocumento, this._Rol) as ObservableCollection<AsuntosDataGridModel>;

            return this.ResultadoBusqueda;
        }

    }
}
