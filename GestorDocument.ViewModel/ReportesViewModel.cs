using GestorDocument.Model.IRepository;
using GestorDocument.Model;

using System.Collections.ObjectModel;
using System.Linq;
using System;



namespace GestorDocument.ViewModel
{
    public class ReportesViewModel:ViewModelBase
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

        private DateTime _FechaInicio;
        public DateTime FechaInicio
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

        private DateTime _FechaFin;
        public DateTime FechaFin
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

        private string _TurnosText;
        public string TurnosText
        {
            get { return _TurnosText; }
            set
            {
                if (_TurnosText != value)
                {
                    _TurnosText = value;
                    OnPropertyChanged(TurnosTextPropertyName);
                }
            }
        }
        private const string TurnosTextPropertyName = "TurnosText";

        private string _PrioridadText;
        public string PrioridadText
        {
            get { return _PrioridadText; }
            set
            {
                if (_PrioridadText != value)
                {
                    _PrioridadText = value;
                    OnPropertyChanged(PrioridadTextPropertyName);
                }
            }
        
        
        }
        private const string PrioridadTextPropertyName = "PrioridadText";
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

        private bool _IsTodosTurnos;
        public bool IsTodosTurnos
        {
            get { return _IsTodosTurnos; }
            set
            {
                if (_IsTodosTurnos != value)
                {
                    _IsTodosTurnos = value;

                    try
                    {

                        (from d in this.Turnos
                         select d).ToList().ForEach(d => d.IsActive = _IsTodosTurnos);
                        if (value)
                            this.AllTurnos();
                        else
                            this.TurnosText = "";
                    }
                    catch (System.Exception)
                    {
                        ;
                    }
                    OnPropertyChanged(IsTodosTurnosPropertyName);

                }
            }
        }
        private const string IsTodosTurnosPropertyName = "IsTodosTurnos";


        private bool _IsTodosPrioridad;
        public bool IsTodosPrioridad
        {
            get { return _IsTodosPrioridad; }
            set
            {
                if (_IsTodosPrioridad != value)
                {
                    _IsTodosPrioridad = value;

                    try
                    {

                        (from d in this.Prioridad
                         select d).ToList().ForEach(d => d.IsActive = _IsTodosPrioridad);
                        if (value)
                            this.AllPrioridad();
                        else
                            this.PrioridadText = "";
                    }
                    catch (System.Exception)
                    {
                        ;
                    }
                    OnPropertyChanged(IsTodosPrioridadPropertyName);

                }
            }
        }
        private const string IsTodosPrioridadPropertyName = "IsTodosPrioridad";

        #endregion
        
        #region Contructor
        public ReportesViewModel()
        {
            this._ReportesRepository = new GestorDocument.DAL.Repository.ReportesRepository();
            this.GetDestinatarios();
            this.GetSignatario();
            this.GetTurnos();
            this.GetPrioridad();
            this.GetFecha();
        }
        #endregion

        #region Metodos.        

        private void GetDestinatarios()
        {            
            this._Destinatarios = _ReportesRepository.GetDestinatarios() as ObservableCollection<RolModel>;                                    
        }       

        private void GetSignatario()
        {
            this._Signatarios = this._ReportesRepository.GetSignatarios() as ObservableCollection<DeterminanteModel>;
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
                AllDestinatarios();
                AllSignatarios();
                AllTurnos();
                AllPrioridad();
                if (!string.IsNullOrEmpty(this.DestinatariosText) & !String.IsNullOrEmpty(this.SignatariosText)
                    &!String.IsNullOrEmpty(this.TurnosText) & !String.IsNullOrEmpty(this.PrioridadText)
                    & (this.FechaInicio <= this.FechaFin))
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

        private void AllDestinatarios()
        {
            var res = (from d in Destinatarios
                       where d.IsActive == true
                       select d).ToList();
            string Text = String.Join(",", res.Select(item => item.RolName.ToString()).ToArray());
            DestinatariosText = Text;
        }

        private void AllSignatarios()
        {
            var res = (from s in Signatarios
                       where s.IsActive == true
                       select s).ToList();
            string text = String.Join(",", res.Select(x => x.DeterminanteName.ToString()).ToArray());
            SignatariosText = text;            
        }

        private void AllTurnos()
        {
            var res = (from t in Turnos
                       where t.IsActive == true
                       select t).ToList();
            string text = String.Join(",", res.Select(x => x.StatusName.ToString()).ToArray());
            TurnosText = text;            
        }

        private void AllPrioridad()
        {
            var res = (from p in Prioridad
                       where p.IsActive == true
                       select p).ToList();
            string Text = String.Join(",", res.Select(x => x.PrioridadName.ToString()).ToArray());
            PrioridadText = Text; 
        }

        #endregion

       
    }
}
