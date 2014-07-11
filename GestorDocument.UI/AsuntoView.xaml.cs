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
    /// Lógica de interacción para AsuntoView.xaml
    /// </summary>
    public partial class AsuntoView : Window
    {
        public AsuntoView()
        {
            InitializeComponent();
            this.DataContext = new AsuntoViewModel();
        }

        private AsuntoViewModel GetViewModel()
        {
            return this.DataContext as AsuntoViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            AsuntoAddView view = new AsuntoAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridAsunto_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedAsunto != null)
            {
                AsuntoModView view = new AsuntoModView();
                AsuntoModViewModel avm = new AsuntoModViewModel(this.GetViewModel().SelectedAsunto);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }

    }
}
