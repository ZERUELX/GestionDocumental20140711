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

namespace GestorDocument.UI.StatusAsunto
{
    /// <summary>
    /// Lógica de interacción para StatusAsuntoView.xaml
    /// </summary>
    public partial class StatusAsuntoView : UserControl, IContentControl
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
            Nuevo();
        }

        private void DataGridStatusAsunto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.GetViewModel().SelectedStatusAsunto != null)
            {
                StatusAsunto.StatusAsuntoModView ModView = new StatusAsunto.StatusAsuntoModView();
                ModView.GetStatusAsuntoMod(GetViewModel(), this.GetViewModel().SelectedStatusAsunto);
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
            StatusAsunto.StatusAsuntoAddView view = new StatusAsunto.StatusAsuntoAddView();
            this.GetContentPane().Content = view;
            view.GetStatusAsunto(GetViewModel());

        }

        public void GetStatusAsuntos()
        {
            this.DataContext = new StatusAsuntoViewModel();
        }
    }
}
