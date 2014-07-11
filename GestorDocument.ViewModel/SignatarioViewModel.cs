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
    public class SignatarioViewModel : ViewModelBase
    {

        // ***************************** ***************************** *****************************
        // Repository.
        private ISignatario _SignatarioRepository;

        public SignatarioModel SelectedSignatario
        {
            get { return _SelectedSignatario; }
            set
            {
                if (_SelectedSignatario != value)
                {
                    _SelectedSignatario = value;
                    OnPropertyChanged(SelectedSignatarioPropertyName);
                }
            }
        }
        private SignatarioModel _SelectedSignatario;
        public const string SelectedSignatarioPropertyName = "SelectedSignatario";


        // ***************************** ***************************** *****************************
        // Coleccion para extraer los datos para el grid.
        public ObservableCollection<SignatarioModel> Signatarios
        {
            get { return _Signatarios; }
            set
            {
                if (_Signatarios != value)
                {
                    _Signatarios = value;
                    OnPropertyChanged(SignatariosPropertyName);
                }
            }
        }
        private ObservableCollection<SignatarioModel> _Signatarios;
        public const string SignatariosPropertyName = "Signatarios";


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

            foreach (SignatarioModel p in this.Signatarios)
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
            List<SignatarioModel> DeleteItem = null;
            try
            {
                DeleteItem = (from o in this.Signatarios
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {
            }

            this._SignatarioRepository.DeleteSignatario(DeleteItem);
            this.LoadInfoGrid();
        }


        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public SignatarioViewModel()
        {
            this._SignatarioRepository = new GestorDocument.DAL.Repository.SignatarioRepository();
            this.LoadInfoGrid();
        }

        public void LoadInfoGrid()
        {
            this.Signatarios = this._SignatarioRepository.GetSignatarios() as ObservableCollection<SignatarioModel>;
        }
    }
}
