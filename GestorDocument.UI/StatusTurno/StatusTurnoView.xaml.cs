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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GestorDocument.ViewModel;
using GestorDocument.Model;

namespace GestorDocument.UI.StatusTurno
{
    /// <summary>
    /// Lógica de interacción para StatusTurnoView.xaml
    /// </summary>
    public partial class StatusTurnoView : UserControl, IContentControl
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
            Nuevo();
        }

        private void DataGridStatusTurno_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.GetViewModel().SelectedStatusTurno != null)
            {
                StatusTurno.StatusTurnoModView ModView = new StatusTurno.StatusTurnoModView();
                ModView.GetStatusTurnoMod(GetViewModel(), this.GetViewModel().SelectedStatusTurno);
                this.GetContentPane().Content = ModView;
            }
        }

        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                cc = ((Grid)((ContentControl)this.Parent).Parent).FindName("ContentPane") as ContentControl;
            }
            catch (Exception)
            {

                return cc;
            }

            return cc;
        }

        public void Nuevo()
        {
            StatusTurno.StatusTurnoAddView view = new StatusTurno.StatusTurnoAddView();
            this.GetContentPane().Content = view;
            view.GetStatusTurno(GetViewModel());

        }

        public void GetStatusTurnos()
        {
            this.DataContext = new StatusTurnoViewModel();
        }

    }
}
