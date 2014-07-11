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
using MahApps.Metro.Controls;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para AddSignatarioView.xaml
    /// </summary>
    public partial class AddSignatarioView : MetroWindow
    {
        public AddSignatarioView()
        {
            InitializeComponent();
        }

        public void GetAddDeterminante(AsuntoAddViewModel viewModel)
        {
            try
            {
                this.DataContext = new AddDeterminanteAsuntoViewModel(viewModel);
            }
            catch (Exception)
            {
                ;
            }

        }

        public void GetAddDeterminante(AsuntoModViewModel viewModel)
        {
            try
            {
                this.DataContext = new AddDeterminanteAsuntoViewModel(viewModel);
            }
            catch (Exception)
            {
                ;
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
