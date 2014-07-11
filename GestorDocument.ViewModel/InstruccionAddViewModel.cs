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
    public class InstruccionAddViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IInstruccion _InstruccionRepository;
        private InstruccionViewModel _ParentInstruccion;

        public InstruccionModel Instruccion
        {
            get { return _Instruccion; }
            set
            {
                if (_Instruccion != value)
                {
                    _Instruccion = value;
                    OnPropertyChanged(InstruccionPropertyName);
                }
            }
        }
        private InstruccionModel _Instruccion;
        public const string InstruccionPropertyName = "Instruccion";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public InstruccionModel CheckSave
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
        private InstruccionModel _CheckSave;
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
            // (!String.IsNullOrEmpty(this._Instruccion.InstruccionName))
            if ((!String.IsNullOrEmpty(this._Instruccion.InstruccionName)) && (this._Instruccion != null))
            {
                _CanSave = true;
                this._CheckSave = this._InstruccionRepository.GetInstruccionAdd(this._Instruccion);

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
            this._InstruccionRepository.InsertInstruccion(this._Instruccion);
            this._ParentInstruccion.LoadInfoGrid();

        }


        // ***************************** ***************************** *****************************
        // constructor
        public InstruccionAddViewModel(InstruccionViewModel InstruccionViewModel)
        {
            this._ParentInstruccion = InstruccionViewModel;
            this._InstruccionRepository = new GestorDocument.DAL.Repository.InstruccionRepository();
            this._Instruccion = new InstruccionModel()
            {
                IdInstruccion = new UNID().getNewUNID(),
                IsActive = true
            };
        }

        public InstruccionAddViewModel()
        {
            this._InstruccionRepository = new GestorDocument.DAL.Repository.InstruccionRepository();
            this._Instruccion = new InstruccionModel()
            {
                IdInstruccion = new UNID().getNewUNID(),
                IsActive = true
            };
        }
    }
}
