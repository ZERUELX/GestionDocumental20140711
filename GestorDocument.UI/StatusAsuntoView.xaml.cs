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
    /// Lógica de interacción para StatusAsuntoView.xaml
    /// </summary>
    public partial class StatusAsuntoView : Window
    {
        public StatusAsuntoView()
        {
            InitializeComponent();
            this.DataContext = new StatusAsuntoViewModel();
        }

        private StatusAsuntoViewModel GetViewModel()
        {
            return this.DataContext as StatusAsuntoViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            StatusAsuntoAddView view = new StatusAsuntoAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridStatusAsunto_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedStatusAsunto != null)
            {
                StatusAsuntoModView view = new StatusAsuntoModView();
                StatusAsuntoModViewModel avm = new StatusAsuntoModViewModel(this.GetViewModel().SelectedStatusAsunto);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }
    }
}
