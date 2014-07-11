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
    public class ExpedienteViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private IExpediente _ExpedienteRepository;

        public ExpedienteModel SelectedExpediente
        {
            get { return _SelectedExpediente; }
            set
            {
                if (_SelectedExpediente != value)
                {
                    _SelectedExpediente = value;
                    OnPropertyChanged(SelectedExpedientePropertyName);
                }
            }
        }
        private ExpedienteModel _SelectedExpediente;
        public const string SelectedExpedientePropertyName = "SelectedExpediente";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<ExpedienteModel> Expedientes
        {
            get { return _Expedientes; }
            set
            {
                if (_Expedientes != value)
                {
                    _Expedientes = value;
                    OnPropertyChanged(ExpedientesPropertyName);
                }
            }
        }
        private ObservableCollection<ExpedienteModel> _Expedientes;
        public const string ExpedientesPropertyName = "Expedientes";


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

            foreach (ExpedienteModel p in this.Expedientes)
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
            List<ExpedienteModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.Expedientes
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._ExpedienteRepository.DeleteExpediente(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public ExpedienteViewModel()
        {
            this._ExpedienteRepository = new GestorDocument.DAL.Repository.ExpedienteRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.Expedientes = this._ExpedienteRepository.GetExpedientes() as ObservableCollection<ExpedienteModel>;
        }
    }
}
