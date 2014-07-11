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
using GestorDocument.ViewModel.AsuntoTurno;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para ConsultaAsuntoReadView.xaml
    /// </summary>
    public partial class ConsultaAsuntoReadView : MetroWindow
    {
        public ConsultaAsuntoReadView()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void GetAsunto(TrancingAsuntoTurnoViewModel viewModel)
        {
            try
            {
                Confirmation confirmacion = new Confirmation();
                this.DataContext = new ConsultaAsuntoViewModel(viewModel.ReadAsunto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void GetAsunto(TrancingAsuntoViewModel viewModel)
        {
            try
            {
                Confirmation confirmacion = new Confirmation();
                this.DataContext = new ConsultaAsuntoViewModel(viewModel.ReadAsunto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void GetAsunto(TrancingAsuntoTurnoReadViewModel viewModel)
        {
            try
            {
                Confirmation confirmacion = new Confirmation();
                this.DataContext = new ConsultaAsuntoViewModel(viewModel.ReadAsunto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void GetAsunto(ResultadoBusquedaAsuntoTurnoViewModel viewModel)
        {
            try
            {
                Confirmation confirmacion = new Confirmation();
                this.DataContext = new ConsultaAsuntoViewModel(viewModel.ReadAsunto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
