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
    public class ExpedienteModViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IExpediente _ExpedienteRepository;
        private ExpedienteViewModel _ParentExpediente;

        public ExpedienteModel Expediente
        {
            get { return _Expediente; }
            set
            {
                if (_Expediente != value)
                {
                    _Expediente = value;
                    OnPropertyChanged(ExpedientePropertyName);
                }
            }
        }
        private ExpedienteModel _Expediente;
        public const string ExpedientePropertyName = "Expediente";

        // ***************************** ***************************** *****************************
        // COMBO ASUNTOS.
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


        // ***************************** ***************************** *****************************
        // auxiliar.
        public ExpedienteModel CheckSave
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
        private ExpedienteModel _CheckSave;
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

            if ((this._Expediente.Asunto != null) )
            {
                _CanSave = true;
                this._CheckSave = this._ExpedienteRepository.GetExpedienteMod(this._Expediente);

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
            this._ExpedienteRepository.UpdateExpediente(this._Expediente);
            this._ParentExpediente.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public ExpedienteModViewModel(ExpedienteModel p, ExpedienteViewModel ExpedienteViewModel)
        {
            this._ParentExpediente = ExpedienteViewModel;
            this._ExpedienteRepository = new GestorDocument.DAL.Repository.ExpedienteRepository();
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this.LoadInfo();

            this._Expediente = new ExpedienteModel()
            {
                IdExpediente = p.IdExpediente,
                Asunto = new AsuntoModel
                {
                    IdAsunto = (long)p.IdAsunto,
                    Titulo = p.Asunto.Titulo
                },
                IsActive = p.IsActive,
            };

            var i = 0;
            foreach (AsuntoModel v in this.Asuntos)
            {
                i++;
                if (v.IdAsunto == this._Expediente.Asunto.IdAsunto)
                {
                    this._Expediente.Asunto = this.Asuntos[i - 1];
                    break;
                }
            }
        }

        public void LoadInfo()
        {
            this.Asuntos = this._AsuntoRepository.GetAsuntos() as ObservableCollection<AsuntoModel>;
        }

    }
}
