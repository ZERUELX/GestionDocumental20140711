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
    public class StatusTurnoViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private IStatusTurno _StatusTurnoRepository;

        public StatusTurnoModel SelectedStatusTurno
        {
            get { return _SelectedStatusTurno; }
            set
            {
                if (_SelectedStatusTurno != value)
                {
                    _SelectedStatusTurno = value;
                    OnPropertyChanged(SelectedStatusTurnoPropertyName);
                }
            }
        }
        private StatusTurnoModel _SelectedStatusTurno;
        public const string SelectedStatusTurnoPropertyName = "SelectedStatusTurno";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<StatusTurnoModel> StatusTurnos
        {
            get { return _StatusTurnos; }
            set
            {
                if (_StatusTurnos != value)
                {
                    _StatusTurnos = value;
                    OnPropertyChanged(StatusTurnosPropertyName);
                }
            }
        }
        private ObservableCollection<StatusTurnoModel> _StatusTurnos;
        public const string StatusTurnosPropertyName = "StatusTurnos";


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

            foreach (StatusTurnoModel p in this.StatusTurnos)
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
            List<StatusTurnoModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.StatusTurnos
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._StatusTurnoRepository.DeleteStatusTurno(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public StatusTurnoViewModel()
        {
            this._StatusTurnoRepository = new GestorDocument.DAL.Repository.StatusTurnoRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.StatusTurnos = this._StatusTurnoRepository.GetStatusTurnos() as ObservableCollection<StatusTurnoModel>;
        }
    }
}
