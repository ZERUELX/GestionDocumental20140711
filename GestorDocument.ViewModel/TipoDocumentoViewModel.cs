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
    public class TipoDocumentoViewModel : ViewModelBase
    {


        // ***************************** ***************************** *****************************
        // Repository.
        private ITipoDocumento _TipoDocumentoRepository;

        public TipoDocumentoModel SelectedTipoDocumento
        {
            get { return _SelectedTipoDocumento; }
            set
            {
                if (_SelectedTipoDocumento != value)
                {
                    _SelectedTipoDocumento = value;
                    OnPropertyChanged(SelectedTipoDocumentoPropertyName);
                }
            }
        }
        private TipoDocumentoModel _SelectedTipoDocumento;
        public const string SelectedTipoDocumentoPropertyName = "SelectedTipoDocumento";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
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

            foreach (TipoDocumentoModel p in this.TipoDocumentos)
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
            List<TipoDocumentoModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.TipoDocumentos
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._TipoDocumentoRepository.DeleteTipoDocumento(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public TipoDocumentoViewModel()
        {
            this._TipoDocumentoRepository = new GestorDocument.DAL.Repository.TipoDocumentoRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.TipoDocumentos = this._TipoDocumentoRepository.GetTipoDocumentos() as ObservableCollection<TipoDocumentoModel>;
        }
    }
}
