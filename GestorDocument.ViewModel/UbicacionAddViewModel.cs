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
    public class UbicacionAddViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IUbicacion _UbicacionRepository;
        private UbicacionViewModel _ParentUbicacion;

        public UbicacionModel Ubicacion
        {
            get { return _Ubicacion; }
            set
            {
                if (_Ubicacion != value)
                {
                    _Ubicacion = value;
                    OnPropertyChanged(UbicacionPropertyName);
                }
            }
        }
        private UbicacionModel _Ubicacion;
        public const string UbicacionPropertyName = "Ubicacion";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public UbicacionModel CheckSave
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
        private UbicacionModel _CheckSave;
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

            if ( (!String.IsNullOrEmpty(this._Ubicacion.UbicacionName)) && (this._Ubicacion != null) )
            {
                _CanSave = true;
                this._CheckSave = this._UbicacionRepository.GetUbicacionAdd(this._Ubicacion);

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
            this._UbicacionRepository.InsertUbicacion(this._Ubicacion);
            this._ParentUbicacion.LoadInfoGrid();

        }


        // ***************************** ***************************** *****************************
        // constructor
        public UbicacionAddViewModel(UbicacionViewModel UbicacionViewModel)
        {
            this._ParentUbicacion = UbicacionViewModel;
            this._UbicacionRepository = new GestorDocument.DAL.Repository.UbicacionRepository();
            this._Ubicacion = new UbicacionModel()
            {
                IdUbicacion = new UNID().getNewUNID(),
                IsActive = true
            };
        }
    }
}
