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
    public class DocumentosModViewModel : ViewModelBase
    {
        // ***************************** ***************************** *****************************
        // Repository.
        private IDocumentos _DocumentosRepository;
        private DocumentosViewModel _ParentDocumentos;

        public DocumentosModel Documentos
        {
            get { return _Documentos; }
            set
            {
                if (_Documentos != value)
                {
                    _Documentos = value;
                    OnPropertyChanged(DocumentosPropertyName);
                }
            }
        }
        private DocumentosModel _Documentos;
        public const string DocumentosPropertyName = "Documentos";

        // ***************************** ***************************** *****************************
        // COMBO TIPODOCUMENTOS.
        private ITipoDocumento _TipoDocumentoRepository;
        public ObservableCollection<TipoDocumentoModel> TipoDocumentos
        {
            get { return _TipoDocumentos; }
            set
            {
                if (_TipoDocumentos != value)
                {
                    _TipoDocumentos = value;
                    OnPropertyChanged(TipoDocumentosPropertyName);
                }
            }
        }
        private ObservableCollection<TipoDocumentoModel> _TipoDocumentos;
        public const string TipoDocumentosPropertyName = "TipoDocumentos";


        // ***************************** ***************************** *****************************
        // auxiliar.
        public DocumentosModel CheckSave
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
        private DocumentosModel _CheckSave;
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
                (!String.IsNullOrEmpty(this._Documentos.DocumentoName)) &&
                (!String.IsNullOrEmpty(this._Documentos.DocumentoPath)) &&
                (!String.IsNullOrEmpty(this._Documentos.Extencion)) &&
                (this._Documentos.Fecha != null) &&
                (this._Documentos.TipoDocumento != null) &&
                (this._Documentos != null)
                )
            {
                _CanSave = true;
                this._CheckSave = this._DocumentosRepository.GetDocumentosMod(this._Documentos);

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
            this._DocumentosRepository.UpdateDocumentos(this._Documentos);
            this._ParentDocumentos.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // constructor
        public DocumentosModViewModel(DocumentosModel p, DocumentosViewModel DocumentosViewModel)
        {
            this._ParentDocumentos = DocumentosViewModel;
            this._DocumentosRepository = new GestorDocument.DAL.Repository.DocumentosRepository();
            this._TipoDocumentoRepository = new GestorDocument.DAL.Repository.TipoDocumentoRepository();
            this.LoadGrid();

            this._Documentos = new DocumentosModel()
            {
                IdDocumento = p.IdDocumento,
                DocumentoName = p.DocumentoName,
                DocumentoPath = p.DocumentoPath,
                Extencion = p.Extencion,
                IsActive = p.IsActive,
                IdTurno = p.IdTurno,
                Fecha = p.Fecha,
                IdExpediente = p.IdExpediente,
                TipoDocumento = new TipoDocumentoModel
                {
                    IdTipoDocumento = p.IdTipoDocumento,
                    TipoDocumentoName = p.TipoDocumento.TipoDocumentoName
                },
                IsDocumentoOriginal = p.IsDocumentoOriginal
            };

            var i = 0;
            foreach (TipoDocumentoModel v in this.TipoDocumentos)
            {
                i++;
                if (v.IdTipoDocumento == this._Documentos.TipoDocumento.IdTipoDocumento)
                {
                    this._Documentos.TipoDocumento = this.TipoDocumentos[i - 1];
                    break;
                }
            }
        }

        public void LoadGrid()
        {
            this.TipoDocumentos = this._TipoDocumentoRepository.GetTipoDocumentos() as ObservableCollection<TipoDocumentoModel>;
        }

    }
}
