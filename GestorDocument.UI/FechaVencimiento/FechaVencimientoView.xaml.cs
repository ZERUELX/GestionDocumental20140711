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

namespace GestorDocument.UI.FechaVencimiento
{
    /// <summary>
    /// Lógica de interacción para FechaVencimientoView.xaml
    /// </summary>
    public partial class FechaVencimientoView : UserControl, IContentControl
    {
        public FechaVencimientoView()
        {
            InitializeComponent();
            this.DataContext = new FechaVencimientoViewModel();
        }

        private FechaVencimientoViewModel GetViewModel()
        {
            return this.DataContext as FechaVencimientoViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        private void DataGridFechaVencimiento_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedFechaVencimiento != null)
            {
                FechaVencimiento.FechaVencimientoModView ModView = new FechaVencimiento.FechaVencimientoModView();
                ModView.GetFechaVencimientoMod(GetViewModel(), this.GetViewModel().SelectedFechaVencimiento);
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
            FechaVencimiento.FechaVencimientoAddView view = new FechaVencimiento.FechaVencimientoAddView();
            this.GetContentPane().Content = view;
            view.GetFechaVencimiento(GetViewModel());

        }

        public void GetFechaVencimientos()
        {
            this.DataContext = new FechaVencimientoViewModel();
        }

    }
}
