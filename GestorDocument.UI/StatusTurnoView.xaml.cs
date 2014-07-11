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
    /// Lógica de interacción para StatusTurnoView.xaml
    /// </summary>
    public partial class StatusTurnoView : Window
    {
        public StatusTurnoView()
        {
            InitializeComponent();
            this.DataContext = new StatusTurnoViewModel();
        }

        private StatusTurnoViewModel GetViewModel()
        {
            return this.DataContext as StatusTurnoViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            StatusTurnoAddView view = new StatusTurnoAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridStatusTurno_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedStatusTurno != null)
            {
                StatusTurnoModView view = new StatusTurnoModView();
                StatusTurnoModViewModel avm = new StatusTurnoModViewModel(this.GetViewModel().SelectedStatusTurno);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }
    }
}
