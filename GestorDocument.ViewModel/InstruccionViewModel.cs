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
    public class InstruccionViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private IInstruccion _InstruccionRepository;

        public InstruccionModel SelectedInstruccion
        {
            get { return _SelectedInstruccion; }
            set
            {
                if (_SelectedInstruccion != value)
                {
                    _SelectedInstruccion = value;
                    OnPropertyChanged(SelectedInstruccionPropertyName);
                }
            }
        }
        private InstruccionModel _SelectedInstruccion;
        public const string SelectedInstruccionPropertyName = "SelectedInstruccion";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<InstruccionModel> Instruccions
        {
            get { return _Instruccions; }
            set
            {
                if (_Instruccions != value)
                {
                    _Instruccions = value;
                    OnPropertyChanged(InstruccionsPropertyName);
                }
            }
        }
        private ObservableCollection<InstruccionModel> _Instruccions;
        public const string InstruccionsPropertyName = "Instruccions";


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

            foreach (InstruccionModel p in this.Instruccions)
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
            List<InstruccionModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.Instruccions
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._InstruccionRepository.DeleteInstruccion(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public InstruccionViewModel()
        {
            this._InstruccionRepository = new GestorDocument.DAL.Repository.InstruccionRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.Instruccions = this._InstruccionRepository.GetInstruccions() as ObservableCollection<InstruccionModel>;
        }
    }
}
