using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;
using GestorDocument.Model;
using System.Configuration;
using System.IO;

namespace GestorDocument.ViewModel.SyncDocs
{
    public class SyncDocsViewModel :ViewModelBase
    {
        
        #region PRPOPIEDADES DE DOCUMENTOS
        // ***************************** ***************************** *****************************
        public string[] FilesDocumetos
        {
            get { return _FilesDocumetos; }
            set
            {
                if (_FilesDocumetos != value)
                {
                    _FilesDocumetos = value;
                    OnPropertyChanged(FilesDocumetosPropertyName);
                }
            }
        }
        private string[] _FilesDocumetos;
        public const string FilesDocumetosPropertyName = "FilesDocumetos";

        // ***************************** ***************************** *****************************
        public string SuccessPath
        {
            get { return _SuccessPath; }
            set
            {
                if (_SuccessPath != value)
                {
                    _SuccessPath = value;
                    OnPropertyChanged(SuccessPathPropertyName);
                }
            }
        }
        private string _SuccessPath;
        public const string SuccessPathPropertyName = "SuccessPath";

        // ***************************** ***************************** *****************************
        public string PathDocumento
        {
            get { return _PathDocumento; }
            set
            {
                if (_PathDocumento != value)
                {
                    _PathDocumento = value;
                    OnPropertyChanged(PathDocumentoPropertyName);
                }
            }
        }
        private string _PathDocumento;
        public const string PathDocumentoPropertyName = "PathDocumento";

        // ***************************** ***************************** *****************************
        public string SuccessPathServer
        {
            get { return _SuccessPathServer; }
            set
            {
                if (_SuccessPathServer != value)
                {
                    _SuccessPathServer = value;
                    OnPropertyChanged(SuccessPathServerPropertyName);
                }
            }
        }
        private string _SuccessPathServer;
        public const string SuccessPathServerPropertyName = "SuccessPathServer";

        // ***************************** ***************************** *****************************
        // Repository. SYNC_DOC
        private ISyncDocs _SyncDocsRepository;

        // ***************************** ***************************** *****************************
        // SYNC_DOC. 
        public ObservableCollection<SyncDocsModel> SyncDocs
        {
            get { return _SyncDocs; }
            set
            {
                if (_SyncDocs != value)
                {
                    _SyncDocs = value;
                    OnPropertyChanged(SyncDocsPropertyName);
                }
            }
        }
        private ObservableCollection<SyncDocsModel> _SyncDocs;
        public const string SyncDocsPropertyName = "SyncDocs";

        // ***************************** ***************************** *****************************
        public ObservableCollection<SyncDocsModel> UpdateSyncDocs
        {
            get { return _UpdateSyncDocs; }
            set
            {
                if (_UpdateSyncDocs != value)
                {
                    _UpdateSyncDocs = value;
                    OnPropertyChanged(UpdateSyncDocsPropertyName);
                }
            }
        }
        private ObservableCollection<SyncDocsModel> _UpdateSyncDocs;
        public const string UpdateSyncDocsPropertyName = "UpdateSyncDocs";
        #endregion

        #region METODO DE SINCRONIZACION DE  DOCUMENTOS

        public void UploadSyncDocs()
        {

            this.GetSyncDocsServer();

            if (this.UpdateSyncDocs.Count != 0)
                this.GetUpdateStatusDocs();
        }

        #endregion

        #region Constructor
        public SyncDocsViewModel()
        {
            LoadPropiedades();
            
        }
        #endregion

        #region Metodo para Carga de propiedades 
        private void LoadPropiedades()
        {
            this._SyncDocsRepository = new GestorDocument.DAL.Repository.SyncDocsRepository();
            this.SyncDocs = new ObservableCollection<SyncDocsModel>();
            this.UpdateSyncDocs = new ObservableCollection<SyncDocsModel>();

            this.SuccessPathServer = ConfigurationManager.AppSettings["ServerDocsFolder"].ToString();

            this.GetSplitDirectory();
        }
        #endregion

        #region METODOS
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
                    this.SuccessPath = ruta + "\\";
                    break;
                }
            }
        }

        public void GetSyncDocsServer()
        {
            this.SyncDocs = this._SyncDocsRepository.GetSyncDocs() as ObservableCollection<SyncDocsModel>;

            if (this.SyncDocs.Count !=0)
            {
                foreach (SyncDocsModel doc in this.SyncDocs)
                {
                    try
                    {
                        this.PathDocumento = this.SearchDocumento(doc.IdDocumento);

                        if (!String.IsNullOrEmpty(this.PathDocumento))
                            File.Copy(PathDocumento, this.SuccessPathServer + doc.IdDocumento +"."+doc.Extencion);  

                        this.UpdateSyncDocsStatus(doc);
                    }
                    catch (Exception ex)
                    {
                        this.UpdateSyncDocsStatus(doc,ex);
                    }

                }
            }
        }

        public void UpdateSyncDocsStatus(SyncDocsModel doc)
        {
            if (doc !=null)
            {
                SyncDocsModel syncDoc = new SyncDocsModel() 
                {
                    IdDocumento = doc.IdDocumento
                    ,
                    BanderaStatus = true
                    ,
                    FechaCarga = DateTime.Now
                    ,
                    Extencion = doc.Extencion
                    ,
                    StatusDoc = "ENVIADO"
                };

                this.UpdateSyncDocs.Add(syncDoc);
            }
        }

        public void UpdateSyncDocsStatus(SyncDocsModel doc, Exception exception)
        {
            if (doc != null && exception !=null)
            {
                SyncDocsModel syncDoc = new SyncDocsModel()
                {
                    IdDocumento = doc.IdDocumento
                    ,
                    BanderaStatus = doc.BanderaStatus
                    ,
                    FechaCarga = doc.FechaCarga
                    ,
                    Extencion = doc.Extencion
                    ,
                    StatusDoc = doc.StatusDoc
                    ,
                    Exception = exception.Message
                    
                };

                this.UpdateSyncDocs.Add(syncDoc);
            }
        }

        public void GetUpdateStatusDocs()
        {
            this._SyncDocsRepository.UpdateSyncDocs(this.UpdateSyncDocs);
        }

        private string SearchDocumento(long idDocumento)
        {
            string resPathDoc = null;
            try
            {
                if (!String.IsNullOrEmpty(this.SuccessPath))
                    this.FilesDocumetos = Directory.GetFiles(SuccessPath, "*.*", SearchOption.AllDirectories);

                foreach (string item in this.FilesDocumetos)
                {
                    string[] _DocumentoPath = item.Split('\\');
                    string _Documento = _DocumentoPath.Last();
                    string[] _IdDoc = _Documento.Split('.');
                    long IdDocumento = long.Parse(_IdDoc.First());

                    if (idDocumento == IdDocumento)
                    {
                        resPathDoc = item;
                        break;
                    }
                        
                }
            }
            catch (Exception)
            {
                ;
            }
            return resPathDoc;
        }

        #endregion

    }
}
