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
    public class StatusAsuntoViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private IStatusAsunto _StatusAsuntoRepository;

        public StatusAsuntoModel SelectedStatusAsunto
        {
            get { return _SelectedStatusAsunto; }
            set
            {
                if (_SelectedStatusAsunto != value)
                {
                    _SelectedStatusAsunto = value;
                    OnPropertyChanged(SelectedStatusAsuntoPropertyName);
                }
            }
        }
        private StatusAsuntoModel _SelectedStatusAsunto;
        public const string SelectedStatusAsuntoPropertyName = "SelectedStatusAsunto";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<StatusAsuntoModel> StatusAsuntos
        {
            get { return _StatusAsuntos; }
            set
            {
                if (_StatusAsuntos != value)
                {
                    _StatusAsuntos = value;
                    OnPropertyChanged(StatusAsuntosPropertyName);
                }
            }
        }
        private ObservableCollection<StatusAsuntoModel> _StatusAsuntos;
        public const string StatusAsuntosPropertyName = "StatusAsuntos";


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

            foreach (StatusAsuntoModel p in this.StatusAsuntos)
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
            List<StatusAsuntoModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.StatusAsuntos
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._StatusAsuntoRepository.DeleteStatusAsunto(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public StatusAsuntoViewModel()
        {
            this._StatusAsuntoRepository = new GestorDocument.DAL.Repository.StatusAsuntoRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.StatusAsuntos = this._StatusAsuntoRepository.GetStatusAsuntos() as ObservableCollection<StatusAsuntoModel>;
        }
    }
}
