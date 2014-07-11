using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.DAL;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;
using GestorDocument.ViewModel.PantallaInicio;

namespace GestorDocument.ViewModel
{
    public class TurnoViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private ITurno _TurnoRepository;
        public int _Filtro;
        public int _FiltroUrgentes;
        public int _FiltroAtendidos;
        public int _FiltroPendientes;
        public int _FiltroTodos;

        public TurnoModel SelectedTurno
        {
            get { return _SelectedTurno; }
            set
            {
                if (_SelectedTurno != value)
                {
                    _SelectedTurno = value;
                    OnPropertyChanged(SelectedTurnoPropertyName);
                }
            }
        }
        private TurnoModel _SelectedTurno;
        public const string SelectedTurnoPropertyName = "SelectedTurno";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<TurnoModel> Turnos
        {
            get { return _Turnos; }
            set
            {
                if (_Turnos != value)
                {
                    _Turnos = value;
                    OnPropertyChanged(TurnosPropertyName);
                }
            }
        }
        private ObservableCollection<TurnoModel> _Turnos;
        public const string TurnosPropertyName = "Turnos";


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

            foreach (TurnoModel p in this.Turnos)
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
            List<TurnoModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.Turnos
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._TurnoRepository.DeleteTurno(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public TurnoViewModel()
        {
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.Turnos = new ObservableCollection<TurnoModel>();
            //urgentes
            if (this._Filtro == 1)
            {
                this._FiltroUrgentes = _Filtro;
            }
            //atendidos
            if (this._Filtro == 2)
            {
                this._FiltroAtendidos = _Filtro;
                
            }
            //pendientes
            if (this._Filtro == 3)
            {
                this._FiltroPendientes = _Filtro;
                
            }

            //todos
            if (this._Filtro == 4)
            {
                this._FiltroTodos = _Filtro;
            }
        }
    }
}
