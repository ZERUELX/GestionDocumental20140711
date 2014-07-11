using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class AddDeterminanteAsuntoViewModel : ViewModelBase
    {
        private AsuntoAddViewModel _AsuntoAddViewModel;
        private AsuntoModViewModel _AsuntoModViewModel;
        public List<DeterminanteModel> AddItem = null;
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
        public RelayCommand AddDeterminateCommand
        {
            get
            {
                if (_AddDeterminateCommand == null)
                {
                    _AddDeterminateCommand = new RelayCommand(p => this.AttemptSave(), p => this.CanSave());
                }

                return _AddDeterminateCommand;
            }

        }
        private RelayCommand _AddDeterminateCommand;
        public bool CanSave()
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
        
        /// <summary>
        /// Agrega signatarios seleccionados al asunto.
        /// </summary>
        public void AttemptSave()
        {
            //TODO : agrega a lista temporal
            
            try
            {
                AddItem = (from o in this.Determinantes
                              where o.IsChecked == true
                              select o).ToList();
            }
            catch (Exception)
            {

            }
            //antes de agregar valida que no exista el determinate
            if (this._AsuntoAddViewModel != null)
                this.ValidateDeterminate();
            else
                this.ValidateDeterminateMod();
        }

        public void ValidateDeterminate()
        {
            //se agrega la lista de ids
            List<long> auxUnidsDeterminante = new List<long>();
            if (this._AsuntoAddViewModel.Signatario.Count>0)
            {
                foreach (var r in this._AsuntoAddViewModel.Signatario)
                    auxUnidsDeterminante.Add(r.IdDeterminante);    
            }
            

            //valida con los ids que no exista para agrgar a lista

            foreach (DeterminanteModel item in this.AddItem)
            {
                if (item.IsChecked)
                {
                    if (!auxUnidsDeterminante.Contains(item.IdDeterminante))
                    {
                        //this._AsuntoAddViewModel.Determinante.Add(item);
                        this._AsuntoAddViewModel.Signatario.Add(new SignatarioModel(){ IdDeterminante = item.IdDeterminante, Determinante = item });

                    }
                }
            }
        }

        public void ValidateDeterminateMod()
        {
            //se agrega la lista de ids
            List<long> auxUnidsDeterminante = new List<long>();
            if (this._AsuntoModViewModel.Signatario.Count > 0)
            {
                foreach (var r in this._AsuntoModViewModel.Signatario)
                    auxUnidsDeterminante.Add(r.IdDeterminante);
            }


            //valida con los ids que no exista para agrgar a lista

            foreach (DeterminanteModel item in this.AddItem)
            {
                if (item.IsChecked)
                {
                    if (!auxUnidsDeterminante.Contains(item.IdDeterminante))
                    {
                        //this._AsuntoAddViewModel.Determinante.Add(item);
                        this._AsuntoModViewModel.Signatario.Add(new SignatarioModel() { IdDeterminante = item.IdDeterminante, Determinante = item });
                    }
                }
            }
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddDeterminanteAsuntoViewModel(AsuntoAddViewModel asuntoAddViewModel)
        {
            this._AsuntoAddViewModel = asuntoAddViewModel;
            this._DeterminanteRepository = new GestorDocument.DAL.Repository.DeterminanteRepository();
            this.Determinantes = new ObservableCollection<DeterminanteModel>();
            this.LoadInfoGrid();
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddDeterminanteAsuntoViewModel(AsuntoModViewModel asuntoModViewModel)
        {
            this._AsuntoModViewModel = asuntoModViewModel;
            this._DeterminanteRepository = new GestorDocument.DAL.Repository.DeterminanteRepository();
            this.Determinantes = new ObservableCollection<DeterminanteModel>();
            this.LoadInfoGrid();
        }

        /// <summary>
        /// Carga los determinantes existentes.
        /// </summary>
        public void LoadInfoGrid()
        {
            ObservableCollection<DeterminanteModel> res = this._DeterminanteRepository.GetDeterminantes() as ObservableCollection<DeterminanteModel>;

            (from p in res
             orderby p.PrefijoFolio ascending
             select p).ToList().ForEach(o => this.Determinantes.Add(o));

            //this.Determinantes = this._DeterminanteRepository.GetDeterminantes() as ObservableCollection<DeterminanteModel>;

        }
    }
}
