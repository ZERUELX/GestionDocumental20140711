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
    /// Lógica de interacción para TurnoView.xaml
    /// </summary>
    public partial class TurnoView : Window
    {
        public TurnoView()
        {
            InitializeComponent();
            this.DataContext = new TurnoViewModel();
        }

        private TurnoViewModel GetViewModel()
        {
            return this.DataContext as TurnoViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            TurnoAddView view = new TurnoAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridTurno_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedTurno != null)
            {
                TurnoModView view = new TurnoModView();
                TurnoModViewModel avm = new TurnoModViewModel(this.GetViewModel().SelectedTurno);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }

    }
}
