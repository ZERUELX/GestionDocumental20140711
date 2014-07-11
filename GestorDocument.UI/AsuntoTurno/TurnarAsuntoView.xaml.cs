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
    /// Lógica de interacción para TurnarAsuntoView.xaml
    /// </summary>
    public partial class TurnarAsuntoView  : MetroWindow
    {
        public TurnarAsuntoView()
        {
            InitializeComponent();
        }

        private TrancingAsuntoTurnoViewModel GetViewModel()
        {
            return this.DataContext as TrancingAsuntoTurnoViewModel;
        }

        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                MainWindow mw = Application.Current.Windows[0] as MainWindow;
                if (mw != null)
                {
                    cc = mw.FindName("CtSubMenu") as ContentControl;
                }

            }
            catch (Exception)
            {

                return cc;
            }

            return cc;
        }

        private void btnAgregarDocumentos_Click(object sender, RoutedEventArgs e)
        {
            AddDocumentosView addDocumento = new AddDocumentosView();
            addDocumento.GetAddDocumento(GetViewModel());
            addDocumento.ShowDialog();
        }

        private void btnAgregarDestinatarios_Click(object sender, RoutedEventArgs e)
        {
            //DIRECCION
            if (GetViewModel().TipoUnidadNormativa.IdTipoUnidadNormativa == 2)
            {
                AddDestinatarioDireccionView addDestinatarioDireccionView = new AddDestinatarioDireccionView();
                addDestinatarioDireccionView.GetAddDestinatario(GetViewModel());
                addDestinatarioDireccionView.ShowDialog();
            }
            //SUBGERENCIA
            else if (GetViewModel().TipoUnidadNormativa.IdTipoUnidadNormativa == 3)
            {
                AddDestinatarioAreaView addDestinatarioView = new AddDestinatarioAreaView();
                addDestinatarioView.GetAddDestinatario(GetViewModel());
                addDestinatarioView.ShowDialog();
            }
        }

        private void btnTurnarAsunto_Click(object sender, RoutedEventArgs e)
        {

            TrancingAsuntoTurnoViewModel viewModel = GetViewModel();

            viewModel.SaveTurnarCommand.Execute(null);

            if (viewModel._Confirmation.Response)
            {
                Asunto.AsuntoNotificacionesView _AsuntoView = new Asunto.AsuntoNotificacionesView();
                this.GetContentPane().Content = _AsuntoView;
                //Asunto
                _AsuntoView.GetAsunto(viewModel._ParentAsunto._PantallaInicioViewModel, viewModel._ParentAsunto._Filtro);
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
