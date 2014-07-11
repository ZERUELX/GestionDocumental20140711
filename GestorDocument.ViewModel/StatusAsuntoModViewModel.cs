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
    public class StatusAsuntoModViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IStatusAsunto _StatusAsuntoRepository;
        private StatusAsuntoViewModel _ParentStatusAsunto;

        public StatusAsuntoModel StatusAsunto
        {
            get { return _StatusAsunto; }
            set
            {
                if (_StatusAsunto != value)
                {
                    _StatusAsunto = value;
                    OnPropertyChanged(StatusAsuntoPropertyName);
                }
            }
        }
        private StatusAsuntoModel _StatusAsunto;
        public const string StatusAsuntoPropertyName = "StatusAsunto";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public StatusAsuntoModel CheckSave
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
        private StatusAsuntoModel _CheckSave;
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

            if ((this._StatusAsunto != null) || !String.IsNullOrEmpty(this._StatusAsunto.StatusName))
            {
                _CanSave = true;
                this._CheckSave = this._StatusAsuntoRepository.GetStatusAsuntoMod(this._StatusAsunto);

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
            this._StatusAsuntoRepository.UpdateStatusAsunto(this._StatusAsunto);
            this._ParentStatusAsunto.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public StatusAsuntoModViewModel(StatusAsuntoModel p, StatusAsuntoViewModel StatusAsuntoViewModel)
        {
            this._ParentStatusAsunto = StatusAsuntoViewModel;
            this._StatusAsuntoRepository = new GestorDocument.DAL.Repository.StatusAsuntoRepository();
            this._StatusAsunto = new StatusAsuntoModel()
            {
                IdStatusAsunto = p.IdStatusAsunto,
                StatusName = p.StatusName,
                IsActive = p.IsActive,
            };
        }

    }
}
