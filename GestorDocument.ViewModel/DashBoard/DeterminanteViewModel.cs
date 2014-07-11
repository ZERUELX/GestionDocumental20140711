using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using GestorDocument.DAL.Repository;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using GestorDocument.Model.DashBoardModel;

namespace GestorDocument.ViewModel.DashBoard
{
    public class DeterminanteViewModel:ViewModelBase
    {
        private const int MAX_CHAR_COMBO_TITLE = 200;
        private bool DisableAllDeterminantes;

        #region Instancias.
        private IDashBoard oDashBoardRepository ;

        #endregion

        #region Propiedades.
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

        private bool _IsTodosDeterminantes;
        public bool IsTodosDeterminantes
        {
            get { return _IsTodosDeterminantes; }
            set
            {
                if (_IsTodosDeterminantes != value)
                {
                    _IsTodosDeterminantes = value;

                    try
                    {
                        this.DisableAllDeterminantes = true;
                        (from d in this.Determinantes
                         select d).ToList().ForEach(d => d.IsChecked = _IsTodosDeterminantes);
                        if (value)
                            AllDeterminantes();
                        else
                            this.DeterminantesText = "";

                        this.DisableAllDeterminantes = false;
                    }
                    catch (System.Exception)
                    {
                        ;
                    }
                    OnPropertyChanged(IsTodosSignatariosPropertyName);

                }
            }
        }
        private const string IsTodosSignatariosPropertyName = "IsTodosDeterminantes";

        private string _DeterminantesText;
        public string DeterminantesText
        {
            get { return _DeterminantesText; }
            set
            {
                if (_DeterminantesText != value)
                {
                    _DeterminantesText = value;
                    OnPropertyChanged(SignatariosTextPropertyName);
                }
            }
        }
        private const string SignatariosTextPropertyName = "DeterminantesText";

        
        #endregion

        #region Constructor
        public DeterminanteViewModel()
        {
            this.DisableAllDeterminantes = false;
            oDashBoardRepository = new DashBoardRepository();
            GetDeterminantes();
            IsTodosDeterminantes = true;
        }
        #endregion

        #region Metodos.
        private void GetDeterminantes()
        {
            Determinantes = oDashBoardRepository.GetDeterminante() as ObservableCollection<DeterminanteModel>;
            foreach (DeterminanteModel item in this.Determinantes)
            {
                item.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(item_PropertyChanged);
            }
        }


        private void item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "IsChecked" && !this.DisableAllDeterminantes)
            {
                this.AllDeterminantes();
            }
        }

         public void AllDeterminantes()
        {
            string text = "";
            foreach (DeterminanteModel item in this.Determinantes)
            {
                if (item.IsChecked)
                {
                    text += item.DeterminanteName + ",";
                    if (text.Length > MAX_CHAR_COMBO_TITLE)
                    {
                        break;
                    } 
                }
            }

            if (text.Length > 0)
            {
                text = text.Substring(0, text.Length - 1);
            }

            DeterminantesText = text;                
        }

        /// <summary>
        /// Obtener los determinantes (signatarios) seleccionados
        /// </summary>
         /// <returns>ObservableCollection de determinanates. Regresa una colleccion.count = 0 si no hay seleccionados.</returns>
         public ObservableCollection<DeterminanteModel> GetSelectedDeterminanates()
         {
             ObservableCollection<DeterminanteModel> selectedDeterminanates = new ObservableCollection<DeterminanteModel>();

             foreach (DeterminanteModel item in this.Determinantes)
             {
                 if(item.IsChecked)
                    selectedDeterminanates.Add(item);
             }

             return selectedDeterminanates;
         }        
        #endregion
    }
}
