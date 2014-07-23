using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using GestorDocument.DAL;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using GestorDocument.ViewModel.v2;


namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class AddDocumentoAsuntoViewModel : ViewModelBase
    {
        public IConfirmation _Confirmation;
        public AsuntoAddViewModel AsuntoAddViewModel
        {
            get { return _AsuntoAddViewModel; }
            set
            {
                if (_AsuntoAddViewModel != value)
                {
                    _AsuntoAddViewModel = value;
                    OnPropertyChanged(AsuntoModViewModelPropertyName);
                }
            }
        }
        private AsuntoAddViewModel _AsuntoAddViewModel;
        public const string AsuntoModViewModelPropertyName = "AsuntoModViewModel";
        //private AsuntoAddViewModel _AsuntoAddViewModel;
        private AsuntoModViewModel _AsuntoModViewModel;
        private TrancingAsuntoTurnoViewModel _TrancingAsuntoTurnoViewModel;
       

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

        public string SuccessPathCopy
        {
            get { return _SuccessPathCopy; }
            set
            {
                if (_SuccessPathCopy != value)
                {
                    _SuccessPathCopy = value;
                    OnPropertyChanged(SuccessPathCopyPropertyName);
                }
            }
        }
        private string _SuccessPathCopy;
        public const string SuccessPathCopyPropertyName = "SuccessPathCopy";

        public bool ExistDoc
        {
            get { return _ExistDoc; }
            set
            {
                if (_ExistDoc != value)
                {
                    _ExistDoc = value;
                    OnPropertyChanged(ExistDocPropertyName);
                }
            }
        }
        private bool _ExistDoc;
        public const string ExistDocPropertyName = "ExistDoc";

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
        // boton para abrir documento.
        public RelayCommand AddDocCommand
        {
            get
            {
                if (_AddDocCommand == null)
                {
                    _AddDocCommand = new RelayCommand(p => this.AttemptOppen(), p => this.CanOpen());
                }
                return _AddDocCommand;
            }
        }
        private RelayCommand _AddDocCommand;
        public bool CanOpen()
        {
            bool _CanSave = true;
            return _CanSave;
        }

        /// <summary>
        /// Attempt de AddDocCommand. OpenFileDialog()
        /// </summary>
        public void AttemptOppen()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C\\";
            dialog.Title = "Adjuntar Documento";
            dialog.Filter =
                "Documentos Word|*.doc;*.docx;" +
                "|Documentos Excel|*.xls;*.xlsx;" +
                "|Documentos PowerPoint|*.ppt;*.pptx;" +
                "|Documentos Office|*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx;" +
                "|Archivos txt|*.txt" +
                "|Archivos Pdf|*.pdf" +
                "|Todo|*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx;*.txt;*.pdf";
            dialog.FilterIndex = 7;
            dialog.ShowDialog();
            this._Documentos.DocumentoPath = dialog.FileName;

            if (!String.IsNullOrEmpty(this._Documentos.DocumentoPath))
                this.GetSplitDocumento();

        }

        // ***************************** ***************************** *****************************
        // boton para agregar documento al asunto.
        public RelayCommand AddAgregarCommand
        {
            get
            {
                if (_AddAgregarCommand == null)
                {
                    _AddAgregarCommand = new RelayCommand(p => this.AttemptAgregar(), p => this.CanAgregar());
                }
                return _AddAgregarCommand;
            }
        }
        private RelayCommand _AddAgregarCommand;
        public bool CanAgregar()
        {
            bool _CanSave = true;

            return _CanSave;
        }

        /// <summary>
        /// Attempt de AddAgregarCommand. Ejecuta el metodo GetAdjuntarDoc().
        /// </summary>
        public void AttemptAgregar()
        {
            this.GetAdjuntarDoc();       
        }

        public RelayCommand ValidarAgregarCommand
        {
            get
            {
                if (_ValidarAgregarCommand == null)
                {
                    _ValidarAgregarCommand = new RelayCommand(p => this.AttemptValida(), p => this.CanValida());
                }
                return _ValidarAgregarCommand;
            }
        }
        private RelayCommand _ValidarAgregarCommand;
        public bool CanValida()
        {
            bool _CanSave = false;

            if (
                (!String.IsNullOrEmpty(this._Documentos.DocumentoName)) &&
                (!String.IsNullOrEmpty(this._Documentos.DocumentoPath)) &&
                (!String.IsNullOrEmpty(this._Documentos.Extencion)) &&
                (this._Documentos.TipoDocumento != null)
               )
            {
                _CanSave = true;
            }
            return _CanSave;
        }
        public void AttemptValida()
        {
            //solo Valida
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddDocumentoAsuntoViewModel(AsuntoAddViewModel asuntoAddViewModel, IConfirmation confirmation)
        {
            this._Confirmation = confirmation;
            this.AsuntoAddViewModel = asuntoAddViewModel;
            this._TipoDocumentoRepository = new GestorDocument.DAL.Repository.TipoDocumentoRepository();

            this.GetNewDoc();

            this.LoadGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddDocumentoAsuntoViewModel(AsuntoModViewModel asuntoModViewModel, IConfirmation confirmation)
        {
            this._Confirmation = confirmation;
            this._AsuntoModViewModel = asuntoModViewModel;
            this._TipoDocumentoRepository = new GestorDocument.DAL.Repository.TipoDocumentoRepository();

            this.GetNewDoc();

            this.LoadGrid();
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddDocumentoAsuntoViewModel(TrancingAsuntoTurnoViewModel trancingAsuntoTurnoViewModel, IConfirmation confirmation)
        {
            this._Confirmation = confirmation;
            this._TrancingAsuntoTurnoViewModel = trancingAsuntoTurnoViewModel;
            this._TipoDocumentoRepository = new GestorDocument.DAL.Repository.TipoDocumentoRepository();

            this.GetNewDoc();

            this.LoadGrid();
        }

        public void LoadGrid()
        {
            this.TipoDocumentos = this._TipoDocumentoRepository.GetTipoDocumentos() as ObservableCollection<TipoDocumentoModel>;

            this.GetSplitDirectory();
        }

        public void GetSplitDocumento()
        {
            string[] _DocumentoPath = this._Documentos.DocumentoPath.Split('\\');

            //NOMBRE Y EXTENCION
            string _DocumentoNameExtencion = _DocumentoPath.Last();
            
            string[] _NameDocExtencion = _DocumentoNameExtencion.Split('.');

            //EXTENCION 
            this._Documentos.Extencion = _NameDocExtencion.Last();

            //NOMBRE
            string nameDoc = _DocumentoNameExtencion.Replace("."+this._Documentos.Extencion,string.Empty);

            this._Documentos.DocumentoName = nameDoc;
            
        }

        public void ValidateDocumento()
        {
            //se agrega la lista de docmentos para validar 
            List<DocumentosModel> auxDoc = new List<DocumentosModel>();
            if (this._AsuntoAddViewModel.Documentos.Count > 0)
            {
                foreach (var r in this._AsuntoAddViewModel.Documentos)
                    auxDoc.Add(r);   
            }


            //valida con los ids que no exista para agregar a lista
            if (auxDoc.Count > 0)
            {
                foreach (DocumentosModel item in auxDoc)
                {

                    if (!item.DocumentoName.Contains(this._Documentos.DocumentoName))
                    {
                        this._AsuntoAddViewModel.Documentos.Add(this.Documentos);
                    }
                }   
            }
            else
                this._AsuntoAddViewModel.Documentos.Add(this.Documentos);
        }

        public void ValidateDocumentoMod()
        {
            //se agrega la lista de docmentos para validar 
            List<DocumentosModel> auxDoc = new List<DocumentosModel>();
            if (this._AsuntoModViewModel.Documentos.Count > 0)
            {
                foreach (var r in this._AsuntoModViewModel.Documentos)
                    auxDoc.Add(r);
            }


            //valida con los ids que no exista para agregar a lista
            if (auxDoc.Count > 0)
            {
                int contador = 0;
                foreach (DocumentosModel item in auxDoc)
                {
                    if (!item.DocumentoPath.Contains(this.Documentos.DocumentoPath))
                    {
                        this._AsuntoModViewModel.Documentos.Add(this.Documentos);
                    }
                }
                if (contador ==0)
                {
                    this._AsuntoModViewModel.Documentos.Add(this.Documentos);
                }
                contador = 0;
            }
            else
                this._AsuntoModViewModel.Documentos.Add(this.Documentos);
        }

        /// <summary>
        /// Valida que exista la ruta donde se guardaran los documentos(localmente).
        /// </summary>
        public void GetSplitDirectory()
        {
            string nameFolder = ConfigurationManager.AppSettings["LocalDocsApp"].ToString();

            string appDirectory = System.IO.Directory.GetCurrentDirectory();
            string[] directory = System.IO.Directory.GetFileSystemEntries(appDirectory);

            foreach (string ruta in directory)
            {
                string[] _DocumentoPath = ruta.Split('\\');
                if (nameFolder == _DocumentoPath.Last())
                {
                    this.SuccessPathCopy = ruta + "\\";
                    break;
                }
            }

            
        }

        /// <summary>
        /// Valida que exista el documento seleccionado.
        /// </summary>
        /// <returns></returns>
        public bool GetValidarCopyDocs()
        {
            this.ExistDoc = true;
            if (!File.Exists(this.Documentos.DocumentoPath))
            {
                _Confirmation.Msg = "No se pudo adjunatar archivo:  " + this.Documentos.DocumentoName +"."+ this.Documentos.Extencion;
                _Confirmation.ShowOk();
                this.ExistDoc= false;
            }

            return this.ExistDoc;
        }

        /// <summary>
        /// Copia el documento seleccionado a las carpetas de la aplicacion.
        /// </summary>
        public void GetCopyDocumentos()
        {
            File.Copy(this.Documentos.DocumentoPath, this.SuccessPathCopy + this.Documentos.IdDocumento + "." + this.Documentos.Extencion);
        }

        public void GetNewDoc()
        {
            this._Documentos = new DocumentosModel()
            {
                IdDocumento = new UNID().getNewUNID()
                ,
                Fecha = DateTime.Now
                ,
                IsActive = true
            };
        }

        /// <summary>
        /// Agrega 
        /// </summary>
        public void GetAdjuntarDoc()
        {
            //agregar al asunto
            if (this._AsuntoAddViewModel != null)
            {
                if (this.GetValidarCopyDocs())
                {
                    this.GetCopyDocumentos();
                    this.AsuntoAddViewModel.Documentos.Add(this.Documentos);
                }
            }
            else if (this._AsuntoModViewModel != null)
            {
                if (this.GetValidarCopyDocs())
                {
                    this.GetCopyDocumentos();

                    this._AsuntoModViewModel.Documentos.Add(this.Documentos);
                    
                }
            }
            else
            {
                if (this.GetValidarCopyDocs())
                {
                    this.GetCopyDocumentos();

                    this._TrancingAsuntoTurnoViewModel.Documentos.Add(this.Documentos);
                }
            }
        }
    }
}

