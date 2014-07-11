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
    /// Lógica de interacción para DglAddDocumentoView.xaml
    /// </summary>
    public partial class DglAddDocumentoView : Window
    {
        public DglAddDocumentoView()
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

        public void GetAddDocumento(AsuntoModViewModel viewModel)
        {
            try
            {
                Confirmation confirmacion = new Confirmation();
                this.DataContext = new AddDocumentoAsuntoViewModel(viewModel,confirmacion);
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
                this.DataContext = new AddDocumentoAsuntoViewModel(viewModel,confirmacion);
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

        private void CloseButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
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
