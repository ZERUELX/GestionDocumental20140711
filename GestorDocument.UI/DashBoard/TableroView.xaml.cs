using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GestorDocument.ViewModel.DashBoard;


namespace GestorDocument.UI.DashBoard
{
    /// <summary>
    /// Lógica de interacción para TableroView.xaml
    /// </summary>
    public partial class TableroView : Window
    {
        public TableroView()
        {
            InitializeComponent();
            TableroViewModel vm = new TableroViewModel();
            this.DataContext = vm;
            this.anioMesView1.DataContext = vm.CombosAnioMesViewModel;
            this.Determinantes.DataContext = vm.ComboDeterminantesViewModel;            
            
            //this.TodosGraphView.init(vm.TodosGraphViewModel);
            //this.UrgentesGraphView.init(vm.UrgenteGraphViewModel);
            //this.PrioritariosGraphView.init(vm.PrioritariosGraphViewModel);

            this.TableroAtendidos.DataContext = vm.TableroAtendidosViewModel;
            this.TableroPendientes.DataContext = vm.TableroPendientesViewModel;

            this.TodosDBTView.DataContext = vm.TodosDBTViewModel;
            this.UrgentesDBTView.DataContext = vm.UrgenteDBTViewModel;
            this.PrioritariosDBTView.DataContext = vm.PrioritariosDBTViewModel;

        }
    }
}
