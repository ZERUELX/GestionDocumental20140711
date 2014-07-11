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
using System.Windows.Markup;

namespace GestorDocument.UI.Determinante
{
    /// <summary>
    /// Lógica de interacción para DeterminanteView.xaml
    /// </summary>
    public partial class DeterminanteView : UserControl, IContentControl
    {
        public DeterminanteView()
        {
            InitializeComponent();
            this.DataContext = new DeterminanteViewModel();
        }

        private DeterminanteViewModel GetViewModel()
        {
            return this.DataContext as DeterminanteViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        private void DataGridDeterminante_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedDeterminante != null)
            {
                Determinante.DeterminanteModView ModView = new Determinante.DeterminanteModView();
                ModView.GetDeterminanteMod(GetViewModel(), this.GetViewModel().SelectedDeterminante);
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
            Determinante.DeterminanteAddView view = new Determinante.DeterminanteAddView();
            this.GetContentPane().Content = view;
            view.GetDeterminante(GetViewModel());

        }

        public void GetDeterminantes()
        {
            this.DataContext = new DeterminanteViewModel();
        }
    }
}
