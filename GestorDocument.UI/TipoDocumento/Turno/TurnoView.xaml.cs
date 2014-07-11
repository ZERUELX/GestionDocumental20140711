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

namespace GestorDocument.UI.Turno
{
    /// <summary>
    /// Lógica de interacción para TurnoView.xaml
    /// </summary>
    public partial class TurnoView : UserControl, IContentControl
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
            Nuevo();
        }

        private void DataGridTurno_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedTurno != null)
            {
                Turno.TurnoModView ModView = new Turno.TurnoModView();
                ModView.GetTurnoMod(GetViewModel(), this.GetViewModel().SelectedTurno);
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
            Turno.TurnoAddView view = new Turno.TurnoAddView();
            this.GetContentPane().Content = view;
            view.GetTurno(GetViewModel());

        }

        public void GetTurnos()
        {
            this.DataContext = new TurnoViewModel();
        }

    }
}
