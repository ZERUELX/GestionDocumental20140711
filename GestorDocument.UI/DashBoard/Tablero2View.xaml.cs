using System.Windows.Controls;
using System.Windows.Input;
using GestorDocument.ViewModel.DashBoard;
using System.Threading;
using System;

namespace GestorDocument.UI.DashBoard
{
    /// <summary>
    /// Lógica de interacción para Tablero2View.xaml
    /// </summary>
    public partial class Tablero2View : UserControl
    {
        TableroViewModel vm = new TableroViewModel();
        Thread hilo;
        public Tablero2View()
        {
            InitializeComponent();
            hilo = new Thread(Init);
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void FilterImg_MouseEnter(object sender, MouseEventArgs e)
        {
            FilterPopup.IsOpen = true;
        }


        public void Refresh()
        {
            this.TodosGraphView.Refresh(vm.TodosGraphViewModel);
            this.UrgentesGraphView.Refresh(vm.UrgenteGraphViewModel);
            this.PrioritariosGraphView.Refresh(vm.PrioritariosGraphViewModel);
        }

        private void Init()
        {
            App.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.DataContext = vm;
                this.anioMesView1.DataContext = vm.CombosAnioMesViewModel;
                this.Determinantes.DataContext = vm.ComboDeterminantesViewModel;

                this.TodosGraphView.init(vm.TodosGraphViewModel, vm.CombosAnioMesViewModel, vm.TodosDBTViewModel);
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
            }));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            FilterPopup.IsOpen = false;
        }

        

    }
}
