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
    /// Lógica de interacción para FechaVencimientoView.xaml
    /// </summary>
    public partial class FechaVencimientoView : Window
    {
        public FechaVencimientoView()
        {
            InitializeComponent();
            this.DataContext = new FechaVencimientoViewModel();
        }

        private FechaVencimientoViewModel GetViewModel()
        {
            return this.DataContext as FechaVencimientoViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            FechaVencimientoAddView view = new FechaVencimientoAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridFechaVencimiento_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedFechaVencimiento != null)
            {
                FechaVencimientoModView view = new FechaVencimientoModView();
                FechaVencimientoModViewModel avm = new FechaVencimientoModViewModel(this.GetViewModel().SelectedFechaVencimiento);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }

    }
}
