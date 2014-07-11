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
    public class UbicacionModViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IUbicacion _UbicacionRepository;
        private UbicacionViewModel _ParentUbicacionMod;

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

            if ((this._Ubicacion != null) || !String.IsNullOrEmpty(this._Ubicacion.UbicacionName))
            {
                _CanSave = true;
                this._CheckSave = this._UbicacionRepository.GetUbicacionMod(this._Ubicacion);

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
            this._UbicacionRepository.UpdateUbicacion(this._Ubicacion);
            this._ParentUbicacionMod.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public UbicacionModViewModel(UbicacionModel p, UbicacionViewModel UbicacionViewModel)
        {
            this._ParentUbicacionMod = UbicacionViewModel;
            this._UbicacionRepository = new GestorDocument.DAL.Repository.UbicacionRepository();
            this._Ubicacion = new UbicacionModel()
            {
                IdUbicacion = p.IdUbicacion,
                UbicacionName = p.UbicacionName,
                IsActive = p.IsActive,
            };
        }

    }
}
