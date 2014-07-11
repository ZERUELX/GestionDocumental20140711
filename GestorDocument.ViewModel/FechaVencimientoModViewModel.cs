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
    public class FechaVencimientoModViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IFechaVencimiento _FechaVencimientoRepository;
        private FechaVencimientoViewModel _ParentFechaVencimiento;

        public FechaVencimientoModel FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set
            {
                if (_FechaVencimiento != value)
                {
                    _FechaVencimiento = value;
                    OnPropertyChanged(FechaVencimientoPropertyName);
                }
            }
        }
        private FechaVencimientoModel _FechaVencimiento;
        public const string FechaVencimientoPropertyName = "FechaVencimiento";

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
        public FechaVencimientoModel CheckSave
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
        private FechaVencimientoModel _CheckSave;
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

            if (
                (this._FechaVencimiento.Asunto != null) &&
                (this._FechaVencimiento.FechaVencimiento != null) &&
                (this._FechaVencimiento.FechaCreacion != null) &&
                (this._FechaVencimiento != null)
                )
            {
                _CanSave = true;
                this._CheckSave = this._FechaVencimientoRepository.GetFechaVencimientoMod(this._FechaVencimiento);

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
            this._FechaVencimientoRepository.UpdateFechaVencimiento(this._FechaVencimiento);
            this._ParentFechaVencimiento.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public FechaVencimientoModViewModel(FechaVencimientoModel p, FechaVencimientoViewModel FechaVencimientoViewModel)
        {
            this._ParentFechaVencimiento = FechaVencimientoViewModel;
            this._FechaVencimientoRepository = new GestorDocument.DAL.Repository.FechaVencimientoRepository();
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this.LoadInfo();

            this._FechaVencimiento = new FechaVencimientoModel()
            {
                IdFechaVencimiento = p.IdFechaVencimiento,
                Asunto = new AsuntoModel()
                {
                    IdAsunto = p.IdAsunto,
                    Titulo = p.Asunto.Titulo
                },
                FechaVencimiento = p.FechaVencimiento,
                FechaCreacion = p.FechaCreacion,
                IsActual = p.IsActual,
                IsActive = p.IsActive,
            };

            var i = 0;
            foreach (AsuntoModel v in this.Asuntos)
            {
                i++;
                if (v.IdAsunto == this._FechaVencimiento.Asunto.IdAsunto)
                {
                    this._FechaVencimiento.Asunto = this.Asuntos[i - 1];
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
