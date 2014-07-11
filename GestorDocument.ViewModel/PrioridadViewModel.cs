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
    public class PrioridadViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private IPrioridad _PrioridadRepository;

        public PrioridadModel SelectedPrioridad
        {
            get { return _SelectedPrioridad; }
            set
            {
                if (_SelectedPrioridad != value)
                {
                    _SelectedPrioridad = value;
                    OnPropertyChanged(SelectedPrioridadPropertyName);
                }
            }
        }
        private PrioridadModel _SelectedPrioridad;
        public const string SelectedPrioridadPropertyName = "SelectedPrioridad";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<PrioridadModel> Prioridads
        {
            get { return _Prioridads; }
            set
            {
                if (_Prioridads != value)
                {
                    _Prioridads = value;
                    OnPropertyChanged(PrioridadsPropertyName);
                }
            }
        }
        private ObservableCollection<PrioridadModel> _Prioridads;
        public const string PrioridadsPropertyName = "Prioridads";


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

            foreach (PrioridadModel p in this.Prioridads)
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
            List<PrioridadModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.Prioridads
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._PrioridadRepository.DeletePrioridad(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public PrioridadViewModel()
        {
            this._PrioridadRepository = new GestorDocument.DAL.Repository.PrioridadRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.Prioridads = this._PrioridadRepository.GetPrioridads() as ObservableCollection<PrioridadModel>;
        }
    }
}
