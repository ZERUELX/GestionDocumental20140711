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
    public class SignatarioAddViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private ISignatario _SignatarioRepository;
        private SignatarioViewModel _ParentSignatario;

        public SignatarioModel Signatario
        {
            get { return _Signatario; }
            set
            {
                if (_Signatario != value)
                {
                    _Signatario = value;
                    OnPropertyChanged(SignatarioPropertyName);
                }
            }
        }
        private SignatarioModel _Signatario;
        public const string SignatarioPropertyName = "Signatario";

        // ***************************** ***************************** *****************************

        //COMBO ASUNTOS.
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

        // COMBO DETERMINANTE.
        private IDeterminante _DeterminanteRepository;
        public ObservableCollection<DeterminanteModel> Determinantes
        {
            get { return _Determinantes; }
            set
            {
                if (_Determinantes != value)
                {
                    _Determinantes = value;
                    OnPropertyChanged(DeterminantesPropertyName);
                }
            }
        }
        private ObservableCollection<DeterminanteModel> _Determinantes;
        public const string DeterminantesPropertyName = "Determinantes";
        

        // ***************************** ***************************** *****************************
        // auxiliar.
        public SignatarioModel CheckSave
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
        private SignatarioModel _CheckSave;
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
                (this._Signatario.Asunto != null) &&
                (this._Signatario.Determinante != null) &&
                (this._Signatario.Fecha != null) &&
                (this._Signatario != null)
                )
            {
                _CanSave = true;
                this._CheckSave = this._SignatarioRepository.GetSignatarioAdd(this._Signatario);

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
            //this._SignatarioRepository.InsertSignatario(this._Signatario);
            this._ParentSignatario.LoadInfoGrid();

        }


        // ***************************** ***************************** *****************************
        // constructor
        public SignatarioAddViewModel(SignatarioViewModel SignatarioViewModel)
        {
            this._ParentSignatario = SignatarioViewModel;
            this._SignatarioRepository = new GestorDocument.DAL.Repository.SignatarioRepository();
            this._AsuntoRepository = new GestorDocument.DAL.Repository.AsuntoRepository();
            this._DeterminanteRepository = new GestorDocument.DAL.Repository.DeterminanteRepository();
            this.LoadInfo();

            this._Signatario = new SignatarioModel()
            {
                IdSignatario = new UNID().getNewUNID(),
                Fecha = DateTime.Now,
                IsActive = true
            };
        }

        public void LoadInfo()
        {
            this.Asuntos = this._AsuntoRepository.GetAsuntos() as ObservableCollection<AsuntoModel>;
            this.Determinantes = this._DeterminanteRepository.GetDeterminantes() as ObservableCollection<DeterminanteModel>;
        }
    }
}
