using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using GestorDocument.DAL;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel
{
    public class TipoDocumentoAddViewModel : ViewModelBase
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

            if ((!String.IsNullOrEmpty(this._TipoDocumento.TipoDocumentoName)) && (this._TipoDocumento != null))
            {
                _CanSave = true;
                this._CheckSave = this._TipoDocumentoRepository.GetTipoDocumentoAdd(this._TipoDocumento);

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
            this._TipoDocumentoRepository.InsertTipoDocumento(this._TipoDocumento);
            //Refresca el grid
            this._ParentTipoDocumento.LoadInfoGrid();

        }


        // ***************************** ***************************** *****************************
        // constructor
        public TipoDocumentoAddViewModel(TipoDocumentoViewModel TipoDocumentoViewModel)
        {
            this._ParentTipoDocumento = TipoDocumentoViewModel;
            this._TipoDocumentoRepository = new GestorDocument.DAL.Repository.TipoDocumentoRepository();
            this._TipoDocumento = new TipoDocumentoModel()
            {
                IdTipoDocumento = new UNID().getNewUNID(),
                IsActive = true
            };
        }
    }
}
