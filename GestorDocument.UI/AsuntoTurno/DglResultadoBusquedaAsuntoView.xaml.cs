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
using System.Windows.Shapes;
using GestorDocument.ViewModel;
using GestorDocument.ViewModel.AsuntoTurno;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para DglResultadoBusquedaAsuntoView.xaml
    /// </summary>
    public partial class DglResultadoBusquedaAsuntoView : Window
    {
        public DglResultadoBusquedaAsuntoView()
        {
            InitializeComponent();
        }

        public void GetResultadoAsuntos(BusquedaAsuntoTurnoViewModel viewModel)
        {
            try
            {
                this.DataContext = new ResultadoBusquedaAsuntoTurnoViewModel(viewModel);
            }
            catch (Exception)
            {
                ;
            }

        }

        private ResultadoBusquedaAsuntoTurnoViewModel GetViewModel()
        {
            return this.DataContext as ResultadoBusquedaAsuntoTurnoViewModel;
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MaximizeButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.MaximizeButton.Text = "2";
                this.MaximizeButton.ToolTip = "Restaurar";
                this.WindowState = System.Windows.WindowState.Maximized;

            }
            else
            {
                this.MaximizeButton.Text = "1";
                this.MaximizeButton.ToolTip = "Maximizar";
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid dg = sender as DataGrid;
                if (dg != null && dg.SelectedItems != null && dg.SelectedItems.Count == 1)
                {
                    ReadAsuntoTurnoView dlgAsunto = new  ReadAsuntoTurnoView();
                    try
                    {
                        ResultadoBusquedaAsuntoTurnoViewModel viewModel = GetViewModel();

                        viewModel.GetDocsDestinatrios();

                        dlgAsunto.DataContext = viewModel;
                        dlgAsunto.Show();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }

        }

        private void DragableGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.gridHeader.Cursor = Cursors.ScrollAll;
                    this.DragMove();
                }
            }
            this.gridHeader.Cursor = null;

        }
    }
}
