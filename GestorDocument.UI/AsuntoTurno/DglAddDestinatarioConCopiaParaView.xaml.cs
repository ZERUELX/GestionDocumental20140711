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
    /// Lógica de interacción para DglAddDestinatarioConCopiaParaView.xaml
    /// </summary>
    public partial class DglAddDestinatarioConCopiaParaView : Window
    {
        public DglAddDestinatarioConCopiaParaView()
        {
            InitializeComponent();
        }

        public void GetAddDestinatario(AsuntoAddViewModel viewModel)
        {
            try
            {
                this.DataContext = new AddDestinatarioCcpViewModel(viewModel);
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
                this.DataContext = new AddDestinatarioCcpViewModel(viewModel);
            }
            catch (Exception)
            {
                ;
            }

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

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
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
