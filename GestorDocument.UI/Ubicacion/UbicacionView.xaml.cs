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

namespace GestorDocument.UI.Ubicacion
{
    /// <summary>
    /// Lógica de interacción para UbicacionView.xaml
    /// </summary>
    public partial class UbicacionView : UserControl, IContentControl
    {
        public UbicacionView()
        {
            InitializeComponent();
            this.DataContext = new UbicacionViewModel();
        }

        private UbicacionViewModel GetViewModel()
        {
            return this.DataContext as UbicacionViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        private void DataGridUbicacion_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedUbicacion != null)
            {
                Ubicacion.UbicacionModView ModView = new Ubicacion.UbicacionModView();
                ModView.GetUbicacionMod(GetViewModel(), this.GetViewModel().SelectedUbicacion);
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
            Ubicacion.UbicacionAddView view = new Ubicacion.UbicacionAddView();
            this.GetContentPane().Content = view;
            view.GetUbicacion(GetViewModel());

        }

        public void GetUbicacions()
        {
            this.DataContext = new TipoDeterminanteViewModel();
        }


    }
}
