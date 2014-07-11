using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Generic;


namespace GestorDocument.ViewModel
{
   public class ReporteEficienciaViewModel:ViewModelBase
    {

        private IReportes _ReportesRepository;
        #region Propiedades.

        public ObservableCollection<RolModel> Destinatarios
        {
            get { return _Destinatarios; }
            set
            {
                if (_Destinatarios != null)
                {
                    _Destinatarios = value;
                    OnPropertyChanged(DestinatariosPropertyName);
                                       
                }
            }
        }               
        public ObservableCollection<RolModel> _Destinatarios;
        public const string DestinatariosPropertyName = "Destinatarios";

        public ObservableCollection<DeterminanteModel> Signatarios
        {
            get { return _Signatarios; }
            set
            {
                if (_Signatarios != null)
                    _Signatarios = value;
                OnPropertyChanged(SignatariosPropertyName);
            }
        }
        private ObservableCollection<DeterminanteModel> _Signatarios;
        public const string SignatariosPropertyName = "Signatarios";

        private ObservableCollection<StatusTurnoModel> _Turnos;
        public ObservableCollection<StatusTurnoModel> Turnos
        {
            get { return _Turnos; }
            set
            {
                if (_Turnos != value)
                {
                    _Turnos = value;
                    OnPropertyChanged(TurnosPropertyName);
                }
            }
        }
        private const string TurnosPropertyName = "Turnos";

        private ObservableCollection<PrioridadModel> _Prioridad;
        public ObservableCollection<PrioridadModel> Prioridad
        {
            get { return _Prioridad; }
            set
            {
                if (_Prioridad != value)
                {
                    _Prioridad = value;
                    OnPropertyChanged(PrioridadPropertyName);
                }
            }
        }
        private const string PrioridadPropertyName = "Prioridad";

        private DateTime? _FechaInicio;
        public DateTime? FechaInicio
        {
            get { return _FechaInicio; }
            set
            {
                if (_FechaInicio != value)
                {
                    _FechaInicio = value;
                    OnPropertyChanged(FechaInicioPropertyName);
                }
            }
        }
        private const string FechaInicioPropertyName = "FechaActual";

        private DateTime? _FechaFin;
        public DateTime? FechaFin
        {
            get { return _FechaFin; }
            set
            {
                if (_FechaFin != value)
                {
                    _FechaFin = value;
                    OnPropertyChanged(FechaFinPropertyName);
                }
            }
        }
        private const string FechaFinPropertyName = "FechaFin";

        public bool IsDateChecked
        {
            get { return _IsDateChecked; }
            set
            {
                if (_IsDateChecked != value)
                {
                    _IsDateChecked = value;
                    OnPropertyChanged(IsDateCheckedPropertyName);
                }
            }
        }
        private bool _IsDateChecked;
        public const string IsDateCheckedPropertyName = "IsDateChecked";


        public List<long> IdDestinatarios
        {
            get { return _IdDestinatarios; }
            set
            {
                if (_IdDestinatarios != value)
                {
                    _IdDestinatarios = value;
                    OnPropertyChanged(IdDestinatariosPropertyName);
                }

            }
        }
        private List<long> _IdDestinatarios;
        public const string IdDestinatariosPropertyName = "IdDestinatarios";

        public List<long> IdSignatarios
        {
            get { return _IdSignatarios; }
            set
            {
                if (_IdSignatarios != value)
                {
                    _IdSignatarios = value;
                    OnPropertyChanged(IdSignatariosPropertyName);
                }

            }
        }
        private List<long> _IdSignatarios;
        public const string IdSignatariosPropertyName = "IdSignatarios";

        public string SelectedDest
        {
            get { return _SelectedDest; }
            set
            {
                if (_SelectedDest != value)
                {
                    _SelectedDest = value;
                    OnPropertyChanged(SelectedDestPropertyName);
                }
            }
        }
        private string _SelectedDest;
        public const string SelectedDestPropertyName = "SelectedDest";

        public string SelectedSign
        {
            get { return _SelectedSign; }
            set
            {
                if (_SelectedSign != value)
                {
                    _SelectedSign = value;
                    OnPropertyChanged(SelectedSignPropertyName);
                }
            }
        }
        private string _SelectedSign;
        public const string SelectedSignPropertyName = "SelectedSign";

        #endregion

        #region Cadenas.
        private string _DestinatariosText;
        public string DestinatariosText
        {
            get { return _DestinatariosText; }
            set
            {
                if (_DestinatariosText != value)
                {
                    _DestinatariosText = value;
                    OnPropertyChanged(DestinatariosTextPropertyName);
                }
            }
        }
        private const string DestinatariosTextPropertyName = "DestinatariosText";

        private string _SignatariosText;
        public string SignatariosText
        {
            get { return _SignatariosText; }
            set
            {
                if (_SignatariosText != value)
                {
                    _SignatariosText = value;
                    OnPropertyChanged(SignatariosTextPropertyName);
                }
            }
        }
        private const string SignatariosTextPropertyName = "SignatariosText";       
        
        #endregion

        #region IsCheks

        private bool _IsTodosDestinatarios;
        public bool IsTodosDestinatarios
        {
            get { return _IsTodosDestinatarios; }
            set
            {
                if (_IsTodosDestinatarios != value)
                {
                    _IsTodosDestinatarios = value;

                    try
                    {
                        
                        (from d in this._Destinatarios
                         select d).ToList().ForEach(d => d.IsActive = _IsTodosDestinatarios);
                        if (value)
                            AllDestinatarios();
                        else
                            this.DestinatariosText = "";
                    }
                    catch (System.Exception)
                    {
                        ;
                    }
                    OnPropertyChanged(IsTodosDestinatariosPropertyName);

                }
            }
        }
        private const string IsTodosDestinatariosPropertyName = "IsTodosDestinatarios";

        private bool _IsTodosSignatarios;
        public bool IsTodosSignatarios
        {
            get { return _IsTodosSignatarios; }
            set
            {
                if (_IsTodosSignatarios != value)
                {
                    _IsTodosSignatarios = value;

                    try
                    {

                        (from d in this.Signatarios
                         select d).ToList().ForEach(d => d.IsActive = _IsTodosSignatarios);
                        if (value)
                            AllSignatarios();
                        else
                            this.SignatariosText = "";
                    }
                    catch (System.Exception)
                    {
                        ;
                    }
                    OnPropertyChanged(IsTodosSignatariosPropertyName);

                }
            }
        }
        private const string IsTodosSignatariosPropertyName = "IsTodosSignatarios";
        
        #endregion
        
        #region Contructor
        public ReporteEficienciaViewModel()
        {
            this._ReportesRepository = new GestorDocument.DAL.Repository.ReportesRepository();

            
            this.GetTurnos();
            this.GetPrioridad();
            this.GetFecha();
            this.LoadInfo();
        }
        #endregion

        #region Metodos.        
        public void LoadInfo()
        {
            this._Destinatarios = this._ReportesRepository.GetDestinatarios() as ObservableCollection<RolModel>;
            this._Signatarios = this._ReportesRepository.GetSignatarios() as ObservableCollection<DeterminanteModel>;

            this.FechaInicio = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now));
            this.FechaFin = DateTime.Parse(string.Format("{0:dd/MM/yyyy}", DateTime.Now));
        }

        private void GetDestinatarios()
        {
            this.IdDestinatarios = new List<long>();
            try
            {
                this.IdDestinatarios = (from o in this.Destinatarios
                                        where o.IsActive == true
                                        select o.IdRol).ToList();
            }
            catch (Exception)
            {
            }
            this.SelectedDest = null;
            if (this.IdDestinatarios.Count != 0)
                this.SelectedDest = String.Join(",", this.IdDestinatarios);
        }       

        private void GetSignatarios()
        {
            this.IdSignatarios = new List<long>();
            try
            {
                this.IdSignatarios = (from o in this.Signatarios
                                      where o.IsActive == true
                                      select o.IdDeterminante).ToList();
            }
            catch (Exception)
            {
            }
            this.SelectedSign = null;
            if (IdSignatarios.Count != 0)
                this.SelectedSign = String.Join(",", this.IdSignatarios);
        }

        private void GetTurnos()
        {
            this.Turnos = _ReportesRepository.GetTurnos() as ObservableCollection<StatusTurnoModel>;
        }

        private void GetPrioridad()
        {
            this.Prioridad = _ReportesRepository.GetPrioridad() as ObservableCollection<PrioridadModel>;
        }

        private void GetFecha()
        {
            this.FechaInicio = DateTime.Now;
            this.FechaFin = DateTime.Now;
        }

        public void GetRangoFechas()
        {
            if (this.IsDateChecked == false)
            {
                this.FechaInicio = null;
                this.FechaFin = null;
            }
        }

        /// <summary>
        /// ----------------------------------------------------------------------------------------------
        /// </summary>
        /// 
        public void AttemptValidar()
        {
            //solo valida
        }

        private RelayCommand _GetTextosCommand;
        public RelayCommand GetTextosCommand
        {
            get
            {
                if (_GetTextosCommand == null)
                {
                    _GetTextosCommand = new RelayCommand(t => this.AttemptValidar(), p => this.GetTextos());
                }
                return _GetTextosCommand;
            }
        }
        private bool GetTextos()
        {
            bool x = false;
            try
            {
                this.AllDestinatarios();
                this.AllSignatarios();
                if (!String.IsNullOrEmpty(this.DestinatariosText) || 
                    !String.IsNullOrEmpty(this.SignatariosText) || 
                    (_IsDateChecked))
                {
                    x = true;    
                }
            }
            catch (Exception)
            {
                ;
            }
            return x;
        }

        // ***************************** ***************************** *****************************
        // FILTRO.

        public RelayCommand FiltroCommand
        {
            get
            {
                if (_FiltroCommand == null)
                {
                    _FiltroCommand = new RelayCommand(p => this.AttemptSearch(), p => this.CanSearch());
                }

                return _FiltroCommand;
            }

        }
        private RelayCommand _FiltroCommand;
        public bool CanSearch()
        {
            //solo busca
            return true;
        }
        public void AttemptSearch()
        {
            
            
            //destinatario
            this.GetDestinatarios();
            //signatarios
            this.GetSignatarios();
            //rango de fechas
            this.GetRangoFechas();

        }

        private void AllDestinatarios()
        {
            var res = (from d in Destinatarios
                       where d.IsActive == true
                       select d).ToList();
            string destinatarios = String.Join(",", res.Select(item => item.RolName.ToString()).ToList());
            this.DestinatariosText = destinatarios;
        }

        private void AllSignatarios()
        {
            var res = (from s in Signatarios
                       where s.IsActive == true
                       select s).ToList();
            string signatarios = String.Join(",", res.Select(x => x.DeterminanteName.ToString()).ToList());
            SignatariosText = signatarios;            
        }

        #endregion

    }
}
