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
using MahApps.Metro.Controls;
using GestorDocument.ViewModel;
using GestorDocument.ViewModel.AsuntoTurno;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para ResultadoBusquedaAsuntoView.xaml
    /// </summary>
    public partial class ResultadoBusquedaAsuntoView : MetroWindow
    {
        public ResultadoBusquedaAsuntoView()
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

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGridResultado_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid dg = sender as DataGrid;
                if (dg != null && dg.SelectedItems != null && dg.SelectedItems.Count == 1)
                {
                    ConsultaAsuntoReadView dlgAsunto = new ConsultaAsuntoReadView();
                    try
                    {
                        ResultadoBusquedaAsuntoTurnoViewModel viewModel = GetViewModel();

                        viewModel.GetDocsDestinatrios();
                        dlgAsunto.GetAsunto(viewModel);
                        dlgAsunto.ShowDialog();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }


    }
}
