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
    /// Lógica de interacción para AddSignatarioExternoView.xaml
    /// </summary>
    public partial class AddSignatarioExternoView : MetroWindow
    {
        public AddSignatarioExternoView()
        {
            InitializeComponent();
        }

        public void GetAddDeterminante(AsuntoAddViewModel viewModel)
        {
            try
            {
                this.DataContext = new AddDeterminanteExternoAsuntoViewModel(viewModel);
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
                this.DataContext = new AddDeterminanteExternoAsuntoViewModel(viewModel);
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
