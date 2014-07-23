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
using GestorDocument.UI.AsuntoTurno;

namespace GestorDocument.UI.v2.Buscar
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

        public void Init(UsuarioModel Usuario)
        {
            BusquedaAsuntoTurnoViewModel batvm = new BusquedaAsuntoTurnoViewModel(Usuario.Rol);
            this.DataContext = batvm;
        }

        public object GetViewModel()
        {
            object viewModel = this.DataContext;

            return viewModel;
        }

        private void btnBuscarAsunto_Click(object sender, RoutedEventArgs e)
        {
            GetBusqueda();
        }

        public void GetBusqueda()
        {
            BusquedaAsuntoTurnoViewModel vm = GetViewModel() as BusquedaAsuntoTurnoViewModel;

            if (vm != null)
            {
                vm.SearchCommand.Execute(null);

                if (vm.ResultadoBusqueda.Count != 0)
                {
                    ResultadoBusquedaAsuntoView dialog = new ResultadoBusquedaAsuntoView();
                    dialog.GetResultadoAsuntos(vm);
                    dialog.ShowDialog();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("No se encontraron asuntos similares", "Mensaje de busqueda", MessageBoxButton.OK, MessageBoxImage.Information);
                }


            }

            //BusquedaAsuntoTurnoViewModel asuntoModViewModel = GetViewModel() as BusquedaAsuntoTurnoViewModel;

            //if (asuntoModViewModel != null)
            //{
            //    asuntoModViewModel.Busqueda.SearchCommand.Execute(null);

            //    if (asuntoModViewModel.Busqueda.ResultadoBusqueda.Count != 0)
            //    {
            //        ResultadoBusquedaAsuntoView dialog = new ResultadoBusquedaAsuntoView();
            //        dialog.GetResultadoAsuntos(asuntoModViewModel.Busqueda);
            //        dialog.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBoxResult result = MessageBox.Show("No se encontraron asuntos similares", "Mensaje de busqueda", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //}
        }
    }
}
