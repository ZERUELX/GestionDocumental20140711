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
    public class DeterminanteAddViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IDeterminante _DeterminanteRepository;
        private DeterminanteViewModel _ParentDeterminante;

        public DeterminanteModel Determinante
        {
            get { return _Determinante; }
            set
            {
                if (_Determinante != value)
                {
                    _Determinante = value;
                    OnPropertyChanged(DeterminantePropertyName);
                }
            }
        }
        private DeterminanteModel _Determinante;
        public const string DeterminantePropertyName = "Determinante";

        // ***************************** ***************************** *****************************

        private ITipoDeterminante _TipoDeterminanteRepository;

        public ObservableCollection<TipoDeterminanteModel> TipoDeterminantes
        {
            get { return _TipoDeterminantes; }
            set
            {
                if (_TipoDeterminantes != value)
                {
                    _TipoDeterminantes = value;
                    OnPropertyChanged(TipoDeterminantesPropertyName);
                }
            }
        }
        private ObservableCollection<TipoDeterminanteModel> _TipoDeterminantes;
        public const string TipoDeterminantesPropertyName = "TipoDeterminantes";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public DeterminanteModel CheckSave
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
        private DeterminanteModel _CheckSave;
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
                (!String.IsNullOrEmpty(this._Determinante.DeterminanteName)) &&
                (this._Determinante.CveDeterminante != 0) &&
                (!String.IsNullOrEmpty(this._Determinante.Area)) &&
                (!String.IsNullOrEmpty(this._Determinante.PrefijoFolio)) &&
                (this._Determinante.TipoDeterminante != null) &&
                (this._Determinante != null)                
                )
            {
                _CanSave = true;
                this._CheckSave = this._DeterminanteRepository.GetDeterminanteAdd(this._Determinante);

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
            this._DeterminanteRepository.InsertDeterminante(this._Determinante);
            this._ParentDeterminante.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public DeterminanteAddViewModel(DeterminanteViewModel DeterminanteViewModel)
        {
            this._ParentDeterminante = DeterminanteViewModel;
            this._DeterminanteRepository = new GestorDocument.DAL.Repository.DeterminanteRepository();
            this._TipoDeterminanteRepository = new GestorDocument.DAL.Repository.TipoDeterminanteRepository();
            this._Determinante = new DeterminanteModel()
            {
                IdDeterminante = new UNID().getNewUNID(),
                IsActive = true
            };
            this.LoadInfo();
        }

        public void LoadInfo()
        {
            this.TipoDeterminantes = this._TipoDeterminanteRepository.GetTipoDeterminantes() as ObservableCollection<TipoDeterminanteModel>;
        }

    }
}
