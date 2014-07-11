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
    public class StatusTurnoAddViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IStatusTurno _StatusTurnoRepository;
        private StatusTurnoViewModel _ParentStatusTurno;

        public StatusTurnoModel StatusTurno
        {
            get { return _StatusTurno; }
            set
            {
                if (_StatusTurno != value)
                {
                    _StatusTurno = value;
                    OnPropertyChanged(StatusTurnoPropertyName);
                }
            }
        }
        private StatusTurnoModel _StatusTurno;
        public const string StatusTurnoPropertyName = "StatusTurno";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public StatusTurnoModel CheckSave
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
        private StatusTurnoModel _CheckSave;
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

            if ((!String.IsNullOrEmpty(this._StatusTurno.StatusName)) && (this._StatusTurno != null))
            {
                _CanSave = true;
                this._CheckSave = this._StatusTurnoRepository.GetStatusTurnoAdd(this._StatusTurno);

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
            this._StatusTurnoRepository.InsertStatusTurno(this._StatusTurno);
            this._ParentStatusTurno.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public StatusTurnoAddViewModel(StatusTurnoViewModel StatusTurnoViewModel)
        {
            this._ParentStatusTurno = StatusTurnoViewModel;
            this._StatusTurnoRepository = new GestorDocument.DAL.Repository.StatusTurnoRepository();
            this._StatusTurno = new StatusTurnoModel()
            {
                IdStatusTurno = new UNID().getNewUNID(),
                IsActive = true
            };
        }
    }
}
