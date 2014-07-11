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
    /// Lógica de interacción para InstruccionView.xaml
    /// </summary>
    public partial class InstruccionView : Window
    {
        public InstruccionView()
        {
            InitializeComponent();
            this.DataContext = new InstruccionViewModel();
        }

        private InstruccionViewModel GetViewModel()
        {
            return this.DataContext as InstruccionViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            InstruccionAddView view = new InstruccionAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridInstruccion_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedInstruccion != null)
            {
                InstruccionModView view = new InstruccionModView();
                InstruccionModViewModel avm = new InstruccionModViewModel(this.GetViewModel().SelectedInstruccion);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }
    }
}
