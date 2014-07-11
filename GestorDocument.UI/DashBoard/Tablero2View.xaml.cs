using System.Windows.Controls;
using System.Windows.Input;
using GestorDocument.ViewModel.DashBoard;

namespace GestorDocument.UI.DashBoard
{
    /// <summary>
    /// Lógica de interacción para Tablero2View.xaml
    /// </summary>
    public partial class Tablero2View : UserControl
    {
        public Tablero2View()
        {
            InitializeComponent();
            TableroViewModel vm = new TableroViewModel();
            this.DataContext = vm;
            this.anioMesView1.DataContext = vm.CombosAnioMesViewModel;
            this.Determinantes.DataContext = vm.ComboDeterminantesViewModel;

            this.TodosGraphView.init(vm.TodosGraphViewModel,vm.CombosAnioMesViewModel,vm.TodosDBTViewModel);
            this.TodosGraphView.Refresh(vm.TodosGraphViewModel);

            this.UrgentesGraphView.init(vm.UrgenteGraphViewModel, vm.CombosAnioMesViewModel, vm.UrgenteDBTViewModel);
            this.UrgentesGraphView.Refresh(vm.UrgenteGraphViewModel);

            this.PrioritariosGraphView.init(vm.PrioritariosGraphViewModel, vm.CombosAnioMesViewModel, vm.PrioritariosDBTViewModel);
            this.PrioritariosGraphView.Refresh(vm.PrioritariosGraphViewModel);
            
            this.IndicadorAtendidos.DataContext = vm.TableroAtendidosViewModel;
            this.IndicadorPendientes.DataContext = vm.TableroPendientesViewModel;

            this.TodosDBTView.DataContext = vm.TodosDBTViewModel;
            this.UrgentesDBTView.DataContext = vm.UrgenteDBTViewModel;
            this.PrioritariosDBTView.DataContext = vm.PrioritariosDBTViewModel;

        }

        private void FilterImg_MouseEnter(object sender, MouseEventArgs e)
        {
            FilterPopup.IsOpen = true;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            FilterPopup.IsOpen = false;
        }

    }
}
