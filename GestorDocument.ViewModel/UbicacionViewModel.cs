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
    public class UbicacionViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private IUbicacion _UbicacionRepository;

        public UbicacionModel SelectedUbicacion
        {
            get { return _SelectedUbicacion; }
            set
            {
                if (_SelectedUbicacion != value)
                {
                    _SelectedUbicacion = value;
                    OnPropertyChanged(SelectedUbicacionPropertyName);
                }
            }
        }
        private UbicacionModel _SelectedUbicacion;
        public const string SelectedUbicacionPropertyName = "SelectedUbicacion";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<UbicacionModel> Ubicacions
        {
            get { return _Ubicacions; }
            set
            {
                if (_Ubicacions != value)
                {
                    _Ubicacions = value;
                    OnPropertyChanged(UbicacionsPropertyName);
                }
            }
        }
        private ObservableCollection<UbicacionModel> _Ubicacions;
        public const string UbicacionsPropertyName = "Ubicacions";


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

            foreach (UbicacionModel p in this.Ubicacions)
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
            List<UbicacionModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.Ubicacions
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._UbicacionRepository.DeleteUbicacion(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public UbicacionViewModel()
        {
            this._UbicacionRepository = new GestorDocument.DAL.Repository.UbicacionRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.Ubicacions = this._UbicacionRepository.GetUbicacions() as ObservableCollection<UbicacionModel>;
        }
    }
}
