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
    public class TipoDeterminanteViewModel : ViewModelBase
    {


        // ***************************** ***************************** *****************************
        // Repository.
        private ITipoDeterminante _TipoDeterminanteRepository;

        public TipoDeterminanteModel SelectedTipoDeterminante
        {
            get { return _SelectedTipoDeterminante; }
            set
            {
                if (_SelectedTipoDeterminante != value)
                {
                    _SelectedTipoDeterminante = value;
                    OnPropertyChanged(SelectedTipoDeterminantePropertyName);
                }
            }
        }
        private TipoDeterminanteModel _SelectedTipoDeterminante;
        public const string SelectedTipoDeterminantePropertyName = "SelectedTipoDeterminante";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<TipoDeterminanteModel> TipoDeterminantes
        {
            get { return _TipoDeterminantes; }
            set
            {
                if (_TipoDeterminantes != value)
                {
                    _TipoDeterminantes = value;
                    OnPropertyChanged(TipoDeterminantesPropertyName);
                }
            }
        }
        private ObservableCollection<TipoDeterminanteModel> _TipoDeterminantes;
        public const string TipoDeterminantesPropertyName = "TipoDeterminantes";


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

            foreach (TipoDeterminanteModel p in this.TipoDeterminantes)
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
            List<TipoDeterminanteModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.TipoDeterminantes
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._TipoDeterminanteRepository.DeleteTipoDeterminante(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public TipoDeterminanteViewModel()
        {
            this._TipoDeterminanteRepository = new GestorDocument.DAL.Repository.TipoDeterminanteRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.TipoDeterminantes = this._TipoDeterminanteRepository.GetTipoDeterminantes() as ObservableCollection<TipoDeterminanteModel>;
        }
    }
}
