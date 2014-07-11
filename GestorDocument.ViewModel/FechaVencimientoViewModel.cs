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
    public class FechaVencimientoViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private IFechaVencimiento _FechaVencimientoRepository;

        public FechaVencimientoModel SelectedFechaVencimiento
        {
            get { return _SelectedFechaVencimiento; }
            set
            {
                if (_SelectedFechaVencimiento != value)
                {
                    _SelectedFechaVencimiento = value;
                    OnPropertyChanged(SelectedFechaVencimientoPropertyName);
                }
            }
        }
        private FechaVencimientoModel _SelectedFechaVencimiento;
        public const string SelectedFechaVencimientoPropertyName = "SelectedFechaVencimiento";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<FechaVencimientoModel> FechaVencimientos
        {
            get { return _FechaVencimientos; }
            set
            {
                if (_FechaVencimientos != value)
                {
                    _FechaVencimientos = value;
                    OnPropertyChanged(FechaVencimientosPropertyName);
                }
            }
        }
        private ObservableCollection<FechaVencimientoModel> _FechaVencimientos;
        public const string FechaVencimientosPropertyName = "FechaVencimientos";


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

            foreach (FechaVencimientoModel p in this.FechaVencimientos)
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
            List<FechaVencimientoModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.FechaVencimientos
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._FechaVencimientoRepository.DeleteFechaVencimiento(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public FechaVencimientoViewModel()
        {
            this._FechaVencimientoRepository = new GestorDocument.DAL.Repository.FechaVencimientoRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.FechaVencimientos = this._FechaVencimientoRepository.GetFechaVencimientos() as ObservableCollection<FechaVencimientoModel>;
        }
    }
}
