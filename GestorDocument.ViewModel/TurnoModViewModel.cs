using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.DAL;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel
{
    public class TurnoModViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private ITurno _TurnoRepository;
        private TurnoViewModel _ParentTurno;

        public TurnoModel Turno
        {
            get { return _Turno; }
            set
            {
                if (_Turno != value)
                {
                    _Turno = value;
                    OnPropertyChanged(TurnoPropertyName);
                }
            }
        }
        private TurnoModel _Turno;
        public const string TurnoPropertyName = "Turno";

        // ***************************** ***************************** *****************************
        // COMBO ASUNTO.
        private IAsunto _AsuntoRepository;
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

        // COMBO STATUSTURNO.
        private IStatusTurno _StatusTurnoRepository;
        public ObservableCollection<StatusTurnoModel> StatusTurnos
        {
            get { return _StatusTurnos; }
            set
            {
                if (_StatusTurnos != value)
                {
                    _StatusTurnos = value;
                    OnPropertyChanged(StatusTurnosPropertyName);
                }
            }
        }
        private ObservableCollection<StatusTurnoModel> _StatusTurnos;
        public const string StatusTurnosPropertyName = "StatusTurnos";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public TurnoModel CheckSave
        {
            get { return _CheckSave; }
            set
            {
                if (_CheckSave != value)
                {
                    _CheckSave = value;
                    OnPropertyChanged(CheckSavePropertyName);
                }
            }
        }
        private TurnoModel _CheckSave;
        public const string CheckSavePropertyName = "CheckSave";


        // ***************************** ***************************** *****************************
        // label, para desplegar si el elemento existe o no.
        public string ElementExists
        {
            get { return _ElementExists; }
            set
            {
                if (_ElementExists != value)
                {
                    _ElementExists = value;
                    OnPropertyChanged(ElementExistsPropertyName);
                }
            }
        }
        private string _ElementExists;
        public const string ElementExistsPropertyName = "ElementExists";


        // ***************************** ***************************** *****************************
        // boton de guardar.
        public RelayCommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(p => this.AttemptSave(), p => this.CanSave());
                }
                return _SaveCommand;
            }
        }
        private RelayCommand _SaveCommand;
        public bool CanSave()
        {
            bool _CanSave = false;

            if ((this._Turno != null))
            {
                _CanSave = true;
                this._CheckSave = this._TurnoRepository.GetTurnoMod(this._Turno);

                if (this._CheckSave != null)
                {
                    _CanSave = false;
                    ElementExists = "El elemento ya existe.";

                }
                else
                {
                    _CanSave = true;
                    ElementExists = "";
                }
            }

            return _CanSave;
        }
        public void AttemptSave()
        {
            //logica para guardar el registro
            this._TurnoRepository.UpdateTurno(this._Turno);
            this._ParentTurno.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public TurnoModViewModel(TurnoModel p, TurnoViewModel TurnoViewModel)
        {
            this._ParentTurno = TurnoViewModel;
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this._StatusTurnoRepository = new GestorDocument.DAL.Repository.StatusTurnoRepository();
            this.LoadInfo();

            this._Turno = new TurnoModel()
            {
                IdTurno = p.IdTurno,
                IdTurnoAnt = p.IdTurnoAnt,
                FechaCreacion = p.FechaCreacion,
                FechaEnvio = p.FechaEnvio,
                Asunto = new AsuntoModel
                {
                    IdAsunto = p.IdAsunto,
                    Titulo = p.Asunto.Titulo                    
                },
                StatusTurno = new StatusTurnoModel
                {
                    IdStatusTurno = p.IdStatusTurno,
                    StatusName = p.StatusTurno.StatusName
                },
                IdRol = p.IdRol,
                IdUsuario = p.IdUsuario,
                Comentario = p.Comentario,
                Respuesta = p.Respuesta,
                IsActive = p.IsActive,
            };

            var i = 0;
            foreach (AsuntoModel v in this.Asuntos)
            {
                i++;
                if (v.IdAsunto == this._Turno.Asunto.IdAsunto)
                {
                    this._Turno.Asunto = this.Asuntos[i - 1];
                    break;
                }
            }

            i = 0;
            foreach (StatusTurnoModel v in this.StatusTurnos)
            {
                i++;
                if (v.IdStatusTurno == this._Turno.StatusTurno.IdStatusTurno)
                {
                    this._Turno.StatusTurno = this.StatusTurnos[i - 1];
                    break;
                }
            }

        }

        public void LoadInfo()
        {
            this.Asuntos = this._AsuntoRepository.GetAsuntos() as ObservableCollection<AsuntoModel>;
            this.StatusTurnos = this._StatusTurnoRepository.GetStatusTurnos() as ObservableCollection<StatusTurnoModel>;
        }

    }
}
