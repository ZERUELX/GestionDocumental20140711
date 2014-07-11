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

namespace GestorDocument.UI.Prioridad
{
    /// <summary>
    /// Lógica de interacción para PrioridadView.xaml
    /// </summary>
    public partial class PrioridadView : UserControl
    {
        public PrioridadView()
        {
            InitializeComponent();
            this.DataContext = new PrioridadViewModel();
        }

        private PrioridadViewModel GetViewModel()
        {
            return this.DataContext as PrioridadViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        private void DataGridPrioridad_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.GetViewModel().SelectedPrioridad != null)
            {
                Prioridad.PrioridadModView ModView = new Prioridad.PrioridadModView();
                ModView.GetPrioridadMod(GetViewModel(), this.GetViewModel().SelectedPrioridad);
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
            Prioridad.PrioridadAddView view = new Prioridad.PrioridadAddView();
            this.GetContentPane().Content = view;
            view.GetPrioridad(GetViewModel());

        }

        public void GetPrioridads()
        {
            this.DataContext = new PrioridadViewModel();
        }

    }
}
