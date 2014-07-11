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
using GestorDocument.ViewModel.AsuntoTurno;
using GestorDocument.ViewModel;
using MahApps.Metro.Controls;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para AddDestinatarioView.xaml
    /// </summary>
    public partial class AddDestinatarioView : MetroWindow
    {
        public AddDestinatarioView()
        {
            InitializeComponent();
        }

        public void GetAddDestinatario(AsuntoAddViewModel viewModel)
        {
            try
            {
                this.DataContext = new AddOrganigramaAsuntoViewModel(viewModel);
            }
            catch (Exception)
            {
                ;
            }

        }

        public void GetAddDestinatario(AsuntoModViewModel viewModel)
        {
            try
            {
                this.DataContext = new AddOrganigramaAsuntoViewModel(viewModel);
            }
            catch (Exception)
            {
                ;
            }

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
