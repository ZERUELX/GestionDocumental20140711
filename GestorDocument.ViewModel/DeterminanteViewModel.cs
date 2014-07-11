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
    public class DeterminanteViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private IDeterminante _DeterminanteRepository;

        public DeterminanteModel SelectedDeterminante
        {
            get { return _SelectedDeterminante; }
            set
            {
                if (_SelectedDeterminante != value)
                {
                    _SelectedDeterminante = value;
                    OnPropertyChanged(SelectedDeterminantePropertyName);
                }
            }
        }
        private DeterminanteModel _SelectedDeterminante;
        public const string SelectedDeterminantePropertyName = "SelectedDeterminante";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<DeterminanteModel> Determinantes
        {
            get { return _Determinantes; }
            set
            {
                if (_Determinantes != value)
                {
                    _Determinantes = value;
                    OnPropertyChanged(DeterminantesPropertyName);
                }
            }
        }
        private ObservableCollection<DeterminanteModel> _Determinantes;
        public const string DeterminantesPropertyName = "Determinantes";


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

            foreach (DeterminanteModel p in this.Determinantes)
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
            List<DeterminanteModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.Determinantes
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._DeterminanteRepository.DeleteDeterminante(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public DeterminanteViewModel()
        {
            this._DeterminanteRepository = new GestorDocument.DAL.Repository.DeterminanteRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.Determinantes = this._DeterminanteRepository.GetDeterminantes() as ObservableCollection<DeterminanteModel>;
        }
    }
}
