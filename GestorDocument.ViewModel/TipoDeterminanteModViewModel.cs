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
    public class TipoDeterminanteModViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private ITipoDeterminante _TipoDeterminanteRepository;
        private TipoDeterminanteViewModel _ParentTipoDeterminanteMod;

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
        private TipoDeterminanteViewModel view;
        private TipoDeterminanteModel p;
        public bool CanSave()
        {
            bool _CanSave = false;

            if ((this._TipoDeterminante != null) || !String.IsNullOrEmpty(this._TipoDeterminante.TipoDeterminanteName))
            {
                _CanSave = true;
                this._CheckSave = this._TipoDeterminanteRepository.GetTipoDeterminanteMod(this._TipoDeterminante);

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
            this._TipoDeterminanteRepository.UpdateTipoDeterminante(this._TipoDeterminante);
            //Refresca el grid
            this._ParentTipoDeterminanteMod.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public TipoDeterminanteModViewModel(TipoDeterminanteModel p, TipoDeterminanteViewModel TipoDeterminanteViewModel)
        {
            this._ParentTipoDeterminanteMod = TipoDeterminanteViewModel;
            this._TipoDeterminanteRepository = new GestorDocument.DAL.Repository.TipoDeterminanteRepository();
            this._TipoDeterminante = new TipoDeterminanteModel()
            {
                IdTipoDeterminante = p.IdTipoDeterminante,
                TipoDeterminanteName = p.TipoDeterminanteName,
                IsActive = p.IsActive,
            };
        }

    }
}
