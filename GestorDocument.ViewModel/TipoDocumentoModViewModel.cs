using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;

namespace GestorDocument.ViewModel
{
    public class TipoDocumentoModViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private ITipoDocumento _TipoDocumentoRepository;
        private TipoDocumentoViewModel _ParentTipoDocumento;

        public TipoDocumentoModel TipoDocumento
        {
            get { return _TipoDocumento; }
            set
            {
                if (_TipoDocumento != value)
                {
                    _TipoDocumento = value;
                    OnPropertyChanged(TipoDocumentoPropertyName);
                }
            }
        }
        private TipoDocumentoModel _TipoDocumento;
        public const string TipoDocumentoPropertyName = "TipoDocumento";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public TipoDocumentoModel CheckSave
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
        private TipoDocumentoModel _CheckSave;
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

            if ((this._TipoDocumento != null) || !String.IsNullOrEmpty(this._TipoDocumento.TipoDocumentoName))
            {
                _CanSave = true;
                this._CheckSave = this._TipoDocumentoRepository.GetTipoDocumentoMod(this._TipoDocumento);

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
            this._TipoDocumentoRepository.UpdateTipoDocumento(this._TipoDocumento);
            this._ParentTipoDocumento.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public TipoDocumentoModViewModel(TipoDocumentoModel p, TipoDocumentoViewModel TipoDocumentoViewModel)
        {
            this._ParentTipoDocumento = TipoDocumentoViewModel;
            this._TipoDocumentoRepository = new GestorDocument.DAL.Repository.TipoDocumentoRepository();
            this._TipoDocumento = new TipoDocumentoModel()
            {
                IdTipoDocumento = p.IdTipoDocumento,
                TipoDocumentoName = p.TipoDocumentoName,
                IsActive = p.IsActive,
            };
        }

    }
}
