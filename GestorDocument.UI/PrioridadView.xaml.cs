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
using GestorDocument.ViewModel;

namespace GestorDocument.UI
{
    /// <summary>
    /// Lógica de interacción para PrioridadView.xaml
    /// </summary>
    public partial class PrioridadView : Window
    {
        public PrioridadView()
        {
            InitializeComponent();
            this.DataContext = new PrioridadViewModel();
        }

        private PrioridadViewModel GetViewModel()
        {
            return this.DataContext as PrioridadViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            PrioridadAddView view = new PrioridadAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridPrioridad_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedPrioridad != null)
            {
                PrioridadModView view = new PrioridadModView();
                PrioridadModViewModel avm = new PrioridadModViewModel(this.GetViewModel().SelectedPrioridad);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }

    }
}
