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
    /// Lógica de interacción para UbicacionView.xaml
    /// </summary>
    public partial class UbicacionView : Window
    {
        public UbicacionView()
        {
            InitializeComponent();
            this.DataContext = new UbicacionViewModel();
        }

        private UbicacionViewModel GetViewModel()
        {
            return this.DataContext as UbicacionViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            UbicacionAddView view = new UbicacionAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridUbicacion_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedUbicacion != null)
            {
                UbicacionModView view = new UbicacionModView();
                UbicacionModViewModel avm = new UbicacionModViewModel(this.GetViewModel().SelectedUbicacion);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }

    }
}
