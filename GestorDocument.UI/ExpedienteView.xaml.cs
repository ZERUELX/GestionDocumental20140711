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
    /// Lógica de interacción para ExpedienteView.xaml
    /// </summary>
    public partial class ExpedienteView : Window
    {
        public ExpedienteView()
        {
            InitializeComponent();
            this.DataContext = new ExpedienteViewModel();
        }

        private ExpedienteViewModel GetViewModel()
        {
            return this.DataContext as ExpedienteViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            ExpedienteAddView view = new ExpedienteAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridExpediente_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            //if (this.GetViewModel().SelectedExpediente != null)
            //{
            //    ExpedienteModView view = new ExpedienteModView();
            //    ExpedienteModViewModel avm = new ExpedienteModViewModel(this.GetViewModel().SelectedExpediente);
            //    view.DataContext = avm;
            //    view.ShowDialog();
            //    this.GetViewModel().LoadInfoGrid();
            //}
        }

    }
}
