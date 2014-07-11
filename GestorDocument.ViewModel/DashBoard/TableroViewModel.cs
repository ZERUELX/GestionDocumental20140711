using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model.DashBoardModel;


namespace GestorDocument.ViewModel.DashBoard
{
    public class TableroViewModel:ViewModelBase
    {
        public  string PRIORIDAD_TODOS = "20130611175614758,20130611175650143,20130611175702903";
        private const string PRIORIDAD_URGENTE = "20130611175650143";
        private const string PRIORIDAD_ORDINARIO_PENDIENTE = "20130611175614758,20130611175702903";

        #region Constructor.
        public TableroViewModel()
        {
            this.ComboDeterminantesViewModel = new DeterminanteViewModel();
            this.CombosAnioMesViewModel = new AnioMesViewModel();
            
            this.TodosDBTViewModel = new DashBoardTableViewModel();
            this.TodosDBTViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(TodosDBTViewModel_PropertyChanged);

            this.UrgenteDBTViewModel = new DashBoardTableViewModel();
            this.UrgenteDBTViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(UrgenteDBTViewModel_PropertyChanged);
            
            this.PrioritariosDBTViewModel = new DashBoardTableViewModel();
            this.PrioritariosDBTViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PrioritariosDBTViewModel_PropertyChanged);
            
            this.TodosGraphViewModel = new DashBoardGraphViewModel();
            this.UrgenteGraphViewModel = new DashBoardGraphViewModel();
            this.PrioritariosGraphViewModel = new DashBoardGraphViewModel();
            
            this.TableroAtendidosViewModel = new AtendidosViewModel();
            this.TableroPendientesViewModel = new PendientesViewModel();
            AttemptFiltrar();
        }

        private void PrioritariosDBTViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
            {
                //TODO: Acción para filtrar y actualizar grafica.
                this.PrioritariosGraphViewModel.LoadGraphData(PRIORIDAD_ORDINARIO_PENDIENTE, this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates(), this.TodosDBTViewModel);
            }
        }

        private void UrgenteDBTViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
            {
                //TODO: Acción para filtrar y actualizar grafica.                                
                this.UrgenteGraphViewModel.LoadGraphData(PRIORIDAD_URGENTE, this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates(), this.TodosDBTViewModel);
            }
        }

        private void TodosDBTViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
            {
                //TODO: Acción para filtrar y actualizar grafica.                                
                this.TodosGraphViewModel.LoadGraphData(PRIORIDAD_TODOS,this.CombosAnioMesViewModel.SelectedAnio,this.CombosAnioMesViewModel.SelectedMes,this.ComboDeterminantesViewModel.GetSelectedDeterminanates(),this.TodosDBTViewModel);                
            }
        }



        #endregion

           #region Instancias.
           public AtendidosViewModel TableroAtendidosViewModel;
           public PendientesViewModel TableroPendientesViewModel;
           public AnioMesViewModel CombosAnioMesViewModel;
           public DeterminanteViewModel ComboDeterminantesViewModel;           
           public DashBoardTableViewModel TodosDBTViewModel;
           public DashBoardTableViewModel UrgenteDBTViewModel;
           public DashBoardTableViewModel PrioritariosDBTViewModel;
           
           public DashBoardGraphViewModel TodosGraphViewModel;
           public DashBoardGraphViewModel UrgenteGraphViewModel;
           public DashBoardGraphViewModel PrioritariosGraphViewModel;
           
           #endregion

           #region Propiedades.           

           public RelayCommand FiltrarCommand
           {
               get
               {
                   if (_FiltrarCommand == null)
                   {
                       _FiltrarCommand = new RelayCommand(t => this.AttemptFiltrar(), p => this.CanFiltrar());
                   }
                   return _FiltrarCommand;
               }
           }
           private RelayCommand _FiltrarCommand;
           public const string RelayPropertyName = "FiltrarCommand";
           

        #endregion

        #region Metodos.

           public void AttemptFiltrar()
           {
               //------------------------Tabla Todos
               this.TodosDBTViewModel.GetTotal("Todos", this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates());
               this.TodosDBTViewModel.GetDetalle("Todos", this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates());
               //------------------------Tabla Urgentes
               UrgenteDBTViewModel.GetTotal("Urgente", this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates());
               UrgenteDBTViewModel.GetDetalle("Urgente", this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates());
               //------------------------Tabla Prioritarios Ordinarios
               PrioritariosDBTViewModel.GetTotal("Prioritario", this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates());
               PrioritariosDBTViewModel.GetDetalle("Prioritario", this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates());
               //------------------------Tableros Atendido y Pendientes
               this.TableroAtendidosViewModel.GetAtendidos(this.ComboDeterminantesViewModel.GetSelectedDeterminanates());
               this.TableroPendientesViewModel.GetPendientes(this.ComboDeterminantesViewModel.GetSelectedDeterminanates());
               //------------------------Grafica Todos
               this.TodosGraphViewModel.LoadGraphData(PRIORIDAD_TODOS, this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates(), this.TodosDBTViewModel);
               //------------------------Grafica Urgentes
               this.UrgenteGraphViewModel.LoadGraphData(PRIORIDAD_URGENTE, this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates(), this.TodosDBTViewModel);
               //------------------------Grafica Prioritarios Ordinarios
               this.PrioritariosGraphViewModel.LoadGraphData(PRIORIDAD_ORDINARIO_PENDIENTE, this.CombosAnioMesViewModel.SelectedAnio, this.CombosAnioMesViewModel.SelectedMes, this.ComboDeterminantesViewModel.GetSelectedDeterminanates(), this.TodosDBTViewModel);


           }

           

           public bool CanFiltrar()
           {
               bool x = false;
               try
               {
                   if (this.ComboDeterminantesViewModel.GetSelectedDeterminanates().Count>0  && this.CombosAnioMesViewModel.SelectedAnio != null && this.CombosAnioMesViewModel.SelectedMes != null)
                   {                                              
                       x = true;
                   }
               }
               catch (Exception ex)
               {
                   throw;                   
               }
               return x;
           }

                      
        #endregion


    }
}
