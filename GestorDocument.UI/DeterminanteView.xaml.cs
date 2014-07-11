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
using System.Windows.Markup;

namespace GestorDocument.UI
{
    /// <summary>
    /// Lógica de interacción para DeterminanteView.xaml
    /// </summary>
    public partial class DeterminanteView : Window
    {
        public DeterminanteView()
        {
            InitializeComponent();
            this.DataContext = new DeterminanteViewModel();
        }

        private DeterminanteViewModel GetViewModel()
        {
            return this.DataContext as DeterminanteViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            DeterminanteAddView view = new DeterminanteAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridDeterminante_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedDeterminante != null)
            {
                DeterminanteModView view = new DeterminanteModView();
                DeterminanteModViewModel avm = new DeterminanteModViewModel(this.GetViewModel().SelectedDeterminante);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }
    }
}
