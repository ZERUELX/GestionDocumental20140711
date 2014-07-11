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
using GestorDocument.ViewModel.v2;
using GestorDocument.ViewModel;
using GestorDocument.UI.Buscar;
using GestorDocument.Model;

namespace GestorDocument.UI.v2
{
    /// <summary>
    /// Lógica de interacción para HistorialAsuntosDataGrid.xaml
    /// </summary>
    public partial class HistorialAsuntosDataGrid : UserControl
    {

        public AsuntoModel _AsuntoModel;
        public AsuntosDataGridViewModel _AsuntosDatagridModel;
        AsuntosDataGridViewModel vm = new AsuntosDataGridViewModel();
        public HistorialAsuntosDataGrid()
        {
            //ver como recibir aqui el parametro correcto
          
            InitializeComponent();
           
        }

        public void init(string tipoAsunto)
        {
            BrushConverter bc = new BrushConverter();

            //switch (tipoAsunto)
            //{
            //    case "Asuntos Urgentes":
            //        grdAsuntos.Background = (Brush)bc.ConvertFrom("#FE2E2E");
            //        break;
            //    case "Asuntos Pendientes":
            //        grdAsuntos.Background = (Brush)bc.ConvertFrom("#FF8000");
            //        break;
            //    case "Todos los Asuntos":
            //        grdAsuntos.Background = (Brush)bc.ConvertFrom("#80CBC9");
            //        break;
            //    case "Asuntos Atendidos":
            //        grdAsuntos.Background = (Brush)bc.ConvertFrom("#088A08");
            //        break;
            //    case "Asuntos Prioritarios":
            //        grdAsuntos.Background = (Brush)bc.ConvertFrom("#FF8000");
            //        break;
            //    case "Asuntos Ordinarios":
            //        grdAsuntos.Background = (Brush)bc.ConvertFrom("#FF8000");
            //        break;
            //    case "Asuntos Atendidos Dentro de Fecha":
            //        grdAsuntos.Background = (Brush)bc.ConvertFrom("#088A08");
            //        break;
            //    case "Asuntos Atendidos Fuera de Fecha":
            //        grdAsuntos.Background = (Brush)bc.ConvertFrom("#088A08");
            //        break;
            //    default:
            //        break;
            //}

            textBTituloGrid.FontSize = 20;
            textBTituloGrid.Text = tipoAsunto;
            textBTituloGrid.Foreground = Brushes.White;
           
            vm.Init(10, tipoAsunto);
            this.DataContext = vm;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            //AQUI DEBE DE QUITARLE VALOR A LA PILA
            UserControl ucActual = Stock.StockSingleton.Instance.QuitarPila();

            //ASIGNAR VALOR A SELECTEDITEM
            Stock.StockSingleton.Instance.SelectedItem = ucActual;

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (popup1.IsOpen == false)
            {
                popup1.IsOpen = true;
            }
            else
            {
                popup1.IsOpen = false;
            }
        }

        public void btnBuscarTurno_Click(object sender, RoutedEventArgs e)
        {
            BusquedaViewModel viewModel = GetViewModel();
            viewModel.SearchCommand.Execute(null);
            CatResultadoView _CatResultadoView = new CatResultadoView();
            this.GetContentPane().Content = _CatResultadoView;
            _CatResultadoView.GetResultado(viewModel);
        }

        private BusquedaViewModel GetViewModel()
        {
            return this.DataContext as BusquedaViewModel;
        }

        private AsuntoViewModel GetAsuntoViewModel()
        {
            return this.DataContext as AsuntoViewModel;
        }
        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                MainWindow mw = Application.Current.Windows[0] as MainWindow;
                if (mw != null)
                {
                    cc = mw.FindName("CtSubMenu") as ContentControl;
                }
            }
            catch (Exception)
            {

                return cc;
            }

            return cc;
        }

        private void dtgHistorialAsuntos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.dtgHistorialAsuntos.Cursor = Cursors.Wait;
            if (sender != null)
            {
                DataGrid dg = sender as DataGrid;
                if (dg != null && dg.SelectedItems != null && dg.SelectedItems.Count == 1)
                {

                    _AsuntoModel = dg.SelectedItem as AsuntoModel;
                    if (_AsuntoModel != null)
                        GetAsuntoTurno();

                }
            }
        }

        private void GetAsuntoTurno()
        {
            if (_AsuntoModel.Turno.IsTurnado)
            {
                AsuntoTurno.TracingAsuntoConsulta _TracingAsuntoConsulta = new AsuntoTurno.TracingAsuntoConsulta();
                GetContentPane().Content = _TracingAsuntoConsulta;
                _TracingAsuntoConsulta.GetTurnoTrancing(GetAsuntoViewModel(), _AsuntoModel);
            }
            else
            {
                AsuntoTurno.ModifyAsuntoTurnoView ModView = new AsuntoTurno.ModifyAsuntoTurnoView();
                ModView.GetAsuntoMod(GetAsuntoViewModel(), this.GetAsuntoViewModel().SelectedAsunto);
                this.GetContentPane().Content = ModView;
            }
        }

       
    }
}
