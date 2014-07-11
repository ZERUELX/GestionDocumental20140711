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

namespace GestorDocument.UI.Expediente
{
    /// <summary>
    /// Lógica de interacción para ExpedienteView.xaml
    /// </summary>
    public partial class ExpedienteView : UserControl, IContentControl
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
            Nuevo();
        }

        private void DataGridExpediente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.GetViewModel().SelectedExpediente != null)
            {
                Expediente.ExpedienteModView ModView = new Expediente.ExpedienteModView();
                ModView.GetExpedienteMod(GetViewModel(), this.GetViewModel().SelectedExpediente);
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
            Expediente.ExpedienteAddView view = new Expediente.ExpedienteAddView();
            this.GetContentPane().Content = view;
            view.GetExpediente(GetViewModel());

        }

        public void GetExpedientes()
        {
            this.DataContext = new ExpedienteViewModel();
        }

    }
}
