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
    public class DocumentosViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private IDocumentos _DocumentosRepository;

        public DocumentosModel SelectedDocumentos
        {
            get { return _SelectedDocumentos; }
            set
            {
                if (_SelectedDocumentos != value)
                {
                    _SelectedDocumentos = value;
                    OnPropertyChanged(SelectedDocumentosPropertyName);
                }
            }
        }
        private DocumentosModel _SelectedDocumentos;
        public const string SelectedDocumentosPropertyName = "SelectedDocumentos";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<DocumentosModel> Documentos
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
        private ObservableCollection<DocumentosModel> _Documentos;
        public const string DocumentosPropertyName = "Documentos";


        // ***************************** ***************************** *****************************
        // ELiminar.
        public RelayCommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand(p => this.AttemptDelete(), p => this.CanDelete());
                }

                return _DeleteCommand;
            }

        }
        private RelayCommand _DeleteCommand;
        public bool CanDelete()
        {
            bool _CanDelete = false;

            foreach (DocumentosModel p in this.Documentos)
            {
                if (p.IsChecked)
                {
                    _CanDelete = true;
                    break;

                }
            }

            return _CanDelete;
        }
        public void AttemptDelete()
        {
            //TODO : Delete to database
            List<DocumentosModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.Documentos
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._DocumentosRepository.DeleteDocumentos(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public DocumentosViewModel()
        {
            this._DocumentosRepository = new GestorDocument.DAL.Repository.DocumentosRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.Documentos = this._DocumentosRepository.GetDocumentos() as ObservableCollection<DocumentosModel>;
        }
    }
}
