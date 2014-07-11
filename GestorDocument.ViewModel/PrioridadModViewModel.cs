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
    public class PrioridadModViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IPrioridad _PrioridadRepository;
        private PrioridadViewModel _ParentPrioridad;

        public PrioridadModel Prioridad
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
        private PrioridadModel _Prioridad;
        public const string PrioridadPropertyName = "Prioridad";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public PrioridadModel CheckSave
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
        private PrioridadModel _CheckSave;
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

            if ((this._Prioridad != null) || !String.IsNullOrEmpty(this._Prioridad.PrioridadName))
            {
                _CanSave = true;
                this._CheckSave = this._PrioridadRepository.GetPrioridadMod(this._Prioridad);

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
            this._PrioridadRepository.UpdatePrioridad(this._Prioridad);
            this._ParentPrioridad.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public PrioridadModViewModel(PrioridadModel p, PrioridadViewModel PrioridadViewModel)
        {
            this._ParentPrioridad = PrioridadViewModel;
            this._PrioridadRepository = new GestorDocument.DAL.Repository.PrioridadRepository();
            this._Prioridad = new PrioridadModel()
            {
                IdPrioridad = p.IdPrioridad,
                PrioridadName = p.PrioridadName,
                PathImagen = p.PathImagen,
                IsActive = p.IsActive,
            };
        }

    }
}
