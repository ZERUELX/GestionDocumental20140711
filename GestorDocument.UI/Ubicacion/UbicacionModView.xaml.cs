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
    /// Lógica de interacción para UbicacionModView.xaml
    /// </summary>
    public partial class UbicacionModView : UserControl
    {
        public UbicacionModView()
        {
            InitializeComponent();
        }

        public void GetUbicacionMod(UbicacionViewModel viewModel, UbicacionModel p)
        {
            this.DataContext = new UbicacionModViewModel(p, viewModel);
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
