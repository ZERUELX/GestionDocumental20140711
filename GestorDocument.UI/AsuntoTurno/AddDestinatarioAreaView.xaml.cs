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
using GestorDocument.ViewModel.TreeViewDireccion;
using MahApps.Metro.Controls;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para AddDestinatarioAreaView.xaml
    /// </summary>
    public partial class AddDestinatarioAreaView : MetroWindow
    {
        public AddDestinatarioAreaView()
        {
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void GetAddDestinatario(TrancingAsuntoTurnoViewModel viewModel)
        {
            try
            {
                this.DataContext = new DestinatarioAreaTreeViewModel(viewModel, null);
            }
            catch (Exception)
            {
                ;
            }

        }
    }
}
