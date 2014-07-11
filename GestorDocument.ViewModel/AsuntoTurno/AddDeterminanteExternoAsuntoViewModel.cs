using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class AddDeterminanteExternoAsuntoViewModel : ViewModelBase
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

        private ITipoDeterminante _TipoDeterminanteRepository;

        public void ValidateDeterminate()
        {
            //se agrega la lista de ids
            List<long> auxUnidsDeterminante = new List<long>();
            if (this._AsuntoAddViewModel.SignatarioExterno.Count>0)
            {
                foreach (var r in this._AsuntoAddViewModel.SignatarioExterno)
                    auxUnidsDeterminante.Add(r.IdDeterminante);    
            }
            

            //valida con los ids que no exista para agrgar a lista

            foreach (DeterminanteModel item in this.AddItem)
            {
                if (item.IsChecked)
                {
                    if (!auxUnidsDeterminante.Contains(item.IdDeterminante))
                        this._AsuntoAddViewModel.SignatarioExterno.Add(new SignatarioExternoModel(){ IdDeterminante = item.IdDeterminante, Determinante = item });
                }
            }
        }

        public void ValidateDeterminateMod()
        {
            //se agrega la lista de ids
            List<long> auxUnidsDeterminante = new List<long>();
            if (this._AsuntoModViewModel.SignatarioExterno.Count > 0)
            {
                foreach (var r in this._AsuntoModViewModel.SignatarioExterno)
                    auxUnidsDeterminante.Add(r.IdDeterminante);
            }


            //valida con los ids que no exista para agrgar a lista

            foreach (DeterminanteModel item in this.AddItem)
            {
                if (item.IsChecked)
                {
                    if (!auxUnidsDeterminante.Contains(item.IdDeterminante))         
                        this._AsuntoModViewModel.SignatarioExterno.Add(new SignatarioExternoModel() { IdDeterminante = item.IdDeterminante, Determinante = item });
                }
            }
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddDeterminanteExternoAsuntoViewModel(AsuntoAddViewModel asuntoAddViewModel)
        {
            this._AsuntoAddViewModel = asuntoAddViewModel;
            this._DeterminanteRepository = new GestorDocument.DAL.Repository.DeterminanteRepository();
            this._TipoDeterminanteRepository = new GestorDocument.DAL.Repository.TipoDeterminanteRepository();
            this.Determinantes = new ObservableCollection<DeterminanteModel>();
            this.TipoDeterminantes = new ObservableCollection<TipoDeterminanteModel>();
            this.LoadInfoGrid();
        }

        // ***************************** ***************************** *****************************
        // Constructor y carga de elementos.
        public AddDeterminanteExternoAsuntoViewModel(AsuntoModViewModel asuntoModViewModel)
        {
            this._AsuntoModViewModel = asuntoModViewModel;
            this._DeterminanteRepository = new GestorDocument.DAL.Repository.DeterminanteRepository();
            this._TipoDeterminanteRepository = new GestorDocument.DAL.Repository.TipoDeterminanteRepository();
            this.Determinantes = new ObservableCollection<DeterminanteModel>();
            this.TipoDeterminantes = new ObservableCollection<TipoDeterminanteModel>();
            this.LoadInfoGrid();
        }

       public void LoadInfoGrid()
        {
            this.TipoDeterminantes = this._TipoDeterminanteRepository.GetTipoDeterminantes() as ObservableCollection<TipoDeterminanteModel>;

            this.SelectedTipoDeterminante = this.TipoDeterminantes.LastOrDefault();

            ObservableCollection<DeterminanteModel> res = this._DeterminanteRepository.GetDeterminantes() as ObservableCollection<DeterminanteModel>;

            (from p in res
             orderby p.PrefijoFolio ascending
             where p.IdTipoDeterminante ==this.SelectedTipoDeterminante.IdTipoDeterminante
             select p).ToList().ForEach(o => this.Determinantes.Add(o));

        }
    }
}
