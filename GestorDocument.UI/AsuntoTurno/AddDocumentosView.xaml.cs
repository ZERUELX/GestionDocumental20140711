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
using GestorDocument.ViewModel;
using GestorDocument.ViewModel.v2;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para AddDocumentosView.xaml
    /// </summary>
    public partial class AddDocumentosView : MetroWindow
    {
        public AddDocumentosView()
        {
            InitializeComponent();
        }

        private AddDocumentoAsuntoViewModel GetViewModel()
        {
            return this.DataContext as AddDocumentoAsuntoViewModel;
        }

        public void GetAddDocumento(AsuntoAddViewModel viewModel)
        {
            try
            {
                Confirmation confirmacion = new Confirmation();
                this.DataContext = new AddDocumentoAsuntoViewModel(viewModel, confirmacion);
            }
            catch (Exception)
            {
                ;
            }

        }        

        public void GetAddDocumento(TrancingAsuntoTurnoViewModel viewModel)
        {
            try
            {
                Confirmation confirmacion = new Confirmation();
                this.DataContext = new AddDocumentoAsuntoViewModel(viewModel, confirmacion);
            }
            catch (Exception)
            {
                ;
            }

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            AddDocumentoAsuntoViewModel viewModel = GetViewModel();

            viewModel.AddAgregarCommand.Execute(null);
            if (viewModel.ExistDoc)
                this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
