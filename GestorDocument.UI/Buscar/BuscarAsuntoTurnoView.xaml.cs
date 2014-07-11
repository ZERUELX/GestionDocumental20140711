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
using GestorDocument.UI.AsuntoTurno;

namespace GestorDocument.UI.Buscar
{
    /// <summary>
    /// Lógica de interacción para BuscarAsuntoTurnoView.xaml
    /// </summary>
    public partial class BuscarAsuntoTurnoView : UserControl
    {
        public BuscarAsuntoTurnoView()
        {
            InitializeComponent();
        }

        public object GetViewModel()
        {
            object viewModel = this.DataContext;

            return viewModel;
        }

        private void btnBuscarAsunto_Click(object sender, RoutedEventArgs e)
        {
            this.GetBusqueda();
        }

        public void GetBusqueda()
        {
            AsuntoAddViewModel asuntoAddViewModel = GetViewModel() as AsuntoAddViewModel;

            if (asuntoAddViewModel != null)
            {
                asuntoAddViewModel.Busqueda.SearchCommand.Execute(null);

                if (asuntoAddViewModel.Busqueda.ResultadoBusqueda.Count != 0)   
                {
                    ResultadoBusquedaAsuntoView dialog = new ResultadoBusquedaAsuntoView();
                    dialog.GetResultadoAsuntos(asuntoAddViewModel.Busqueda);
                    dialog.ShowDialog();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("No se encontraron asuntos similares", "Mensaje de busqueda", MessageBoxButton.OK, MessageBoxImage.Information);
                }


            }

            AsuntoModViewModel asuntoModViewModel = GetViewModel() as AsuntoModViewModel;

            if (asuntoModViewModel != null)
            {
                asuntoModViewModel.Busqueda.SearchCommand.Execute(null);

                if (asuntoModViewModel.Busqueda.ResultadoBusqueda.Count != 0)
                {
                    ResultadoBusquedaAsuntoView dialog = new ResultadoBusquedaAsuntoView();
                    dialog.GetResultadoAsuntos(asuntoModViewModel.Busqueda);
                    dialog.ShowDialog();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("No se encontraron asuntos similares", "Mensaje de busqueda", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
