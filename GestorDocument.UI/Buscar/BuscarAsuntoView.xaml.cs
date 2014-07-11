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

namespace GestorDocument.UI.Buscar
{
    /// <summary>
    /// Lógica de interacción para BuscarAsuntoView.xaml
    /// </summary>
    public partial class BuscarAsuntoView : UserControl
    {
        public BuscarAsuntoView()
        {
            InitializeComponent();
        }
        public AsuntoViewModel GetViewModel()
        {
            AsuntoViewModel view = this.DataContext as AsuntoViewModel;

            return view;
        }

        public AsuntoNotificacionesViewModel GetViewModel2()
        {
            AsuntoNotificacionesViewModel view = this.DataContext as AsuntoNotificacionesViewModel;

            return view;
        }

        private void btnBuscarTurno_Click(object sender, RoutedEventArgs e)
        {
            AsuntoViewModel viewModel = GetViewModel();

            if (viewModel !=null)
            {
                viewModel.Busqueda.SearchCommand.Execute(null);

                viewModel.LoadInfoGridBusqueda();

                if (viewModel.Busqueda.ResultadoBusqueda.Count ==0)
                {
                    MessageBox.Show("No se encontraron registros de la busqueda.", "Mensaje de busqueda", MessageBoxButton.OK, MessageBoxImage.Information);
                }
   
            }

            AsuntoNotificacionesViewModel viewModel2 = GetViewModel2();

            if (viewModel2 != null)
            {
                viewModel2.Busqueda.SearchCommand.Execute(null);

                viewModel2.LoadInfoGridBusqueda();

                if (viewModel2.Busqueda.ResultadoBusqueda.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros de la busqueda.", "Mensaje de busqueda", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            

        }
    }
}
