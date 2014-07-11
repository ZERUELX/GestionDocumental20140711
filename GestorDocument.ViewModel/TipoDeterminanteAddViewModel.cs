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
    public class TipoDeterminanteAddViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private ITipoDeterminante _TipoDeterminanteRepository;
        private TipoDeterminanteViewModel _ParentTipoDeterminante;

        public TipoDeterminanteModel TipoDeterminante
        {
            get { return _TipoDeterminante; }
            set
            {
                if (_TipoDeterminante != value)
                {
                    _TipoDeterminante = value;
                    OnPropertyChanged(TipoDeterminantePropertyName);
                }
            }
        }
        private TipoDeterminanteModel _TipoDeterminante;
        public const string TipoDeterminantePropertyName = "TipoDeterminante";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public TipoDeterminanteModel CheckSave
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
        private TipoDeterminanteModel _CheckSave;
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

            if ((!String.IsNullOrEmpty(this._TipoDeterminante.TipoDeterminanteName)) && (this._TipoDeterminante != null))
            {
                _CanSave = true;
                this._CheckSave = this._TipoDeterminanteRepository.GetTipoDeterminanteAdd(this._TipoDeterminante);

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
            else
            {
                ElementExists = "El elemento ya existe.";
            }
            return _CanSave;
        }
        public void AttemptSave()
        {
            //logica para guardar el registro
            this._TipoDeterminanteRepository.InsertTipoDeterminante(this._TipoDeterminante);
            //Refresca el grid
            this._ParentTipoDeterminante.LoadInfoGrid();

        }


        // ***************************** ***************************** *****************************
        // constructor
        public TipoDeterminanteAddViewModel()
        {
            this._TipoDeterminanteRepository = new GestorDocument.DAL.Repository.TipoDeterminanteRepository();
            this._TipoDeterminante = new TipoDeterminanteModel()
            {
                IdTipoDeterminante = new UNID().getNewUNID(),
                IsActive = true
            };
        }

        public TipoDeterminanteAddViewModel(TipoDeterminanteViewModel TipoDeterminanteViewModel)
        {
            this._ParentTipoDeterminante = TipoDeterminanteViewModel;
            this._TipoDeterminanteRepository = new GestorDocument.DAL.Repository.TipoDeterminanteRepository();
            this._TipoDeterminante = new TipoDeterminanteModel()
            {
                IdTipoDeterminante = new UNID().getNewUNID(),
                IsActive = true
            };
        }
    }
}
