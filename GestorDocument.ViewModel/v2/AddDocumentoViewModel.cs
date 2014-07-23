using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model;
using GestorDocument.DAL.Repository.v2;

namespace GestorDocument.ViewModel.v2
{
    public class AddDocumentoViewModel:ViewModelBase
    {

        public AddDocumentoViewModel()
        {
            Init();
        }

        #region Instancias.

        TipoDocumentoRepository tipoDocumentoRepository = new TipoDocumentoRepository();
        #endregion

        #region Propiedades.
        
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

        public TipoDocumentoModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    OnPropertyChanged(SelectedItemPropertyName);
                }
            }
        }
        private TipoDocumentoModel _SelectedItem;
        public const string SelectedItemPropertyName = "SelectedItem";

        public string DocumentoPath
        {
            get { return _DocumentoPath; }
            set
            {
                if (_DocumentoPath != value)
                {
                    _DocumentoPath = value;
                    OnPropertyChanged(DocumentoPathPropertyName);
                }
            }
        }
        private string _DocumentoPath;
        public const string DocumentoPathPropertyName = "DocumentoPath";

        public RelayCommand AddDocument
        {
            get {
                if (_AddDocument == null)
                {
                    _AddDocument = new RelayCommand(atp => AttmpAddDocument(), can => CanAddDocument());
                }
                return _AddDocument; 
            }            
        }
        private RelayCommand _AddDocument;
        public const string AddDocumentPropertyName = "AddDocument";

        #endregion


        #region Metodos.

        public bool CanAddDocument()
        {
            return (SelectedItem != null && !String.IsNullOrEmpty(DocumentoPath)) ? true : false;
        }
        public void AttmpAddDocument()
        {

        }

        public void Init()
        {
            this.TipoDocumentos = new ObservableCollection<TipoDocumentoModel>(tipoDocumentoRepository.GetTipoDocumentos());
        }
        #endregion

    }
}
