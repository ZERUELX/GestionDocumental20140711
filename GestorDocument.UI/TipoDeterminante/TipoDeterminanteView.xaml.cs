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

namespace GestorDocument.UI.TipoDeterminante
{
    /// <summary>
    /// Lógica de interacción para TipoDeterminanteView.xaml
    /// </summary>
    public partial class TipoDeterminanteView : UserControl, IContentControl
    {
        public TipoDeterminanteView()
        {
            InitializeComponent();
            this.DataContext = new TipoDeterminanteViewModel();
        }

        private TipoDeterminanteViewModel GetViewModel()
        {
            return this.DataContext as TipoDeterminanteViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo();   
        }

        private void DataGridTipoDeterminante_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.GetViewModel().SelectedTipoDeterminante != null)
            {
                TipoDeterminante.TipoDeterminanteModView ModView = new TipoDeterminante.TipoDeterminanteModView();
                ModView.GetTipoDeterminanteMod(GetViewModel(), this.GetViewModel().SelectedTipoDeterminante);
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
            TipoDeterminante.TipoDeterminanteAddView view = new TipoDeterminante.TipoDeterminanteAddView();
            this.GetContentPane().Content = view;
            view.GetTipoDeterminante(GetViewModel());

        }

        public void GetTipoDeterminantes()
        {
            this.DataContext = new TipoDeterminanteViewModel();
        }

    }
}
