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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GestorDocument.ViewModel;
using Microsoft.Win32;


namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para AsuntoTurnoView.xaml
    /// </summary>
    public partial class AsuntoTurnoView : UserControl, IContentControl
    {
        public AsuntoTurnoView()
        {
            InitializeComponent();
            this.Loaded += delegate
            {
                Keyboard.Focus(this.tbReferencia);
                this.tbReferencia.SelectAll();
                
            };
        }

        // Accede a los controles de la pantalla principal.
        public MainWindow GetParetWindows()
        {
            MainWindow res = null;
            try
            {
                object query = Application.Current.Windows[0];
                res = query as MainWindow;
            }
            catch (Exception)
            {
                ;
            }
            return res;
        }

        public void GetAsunto(AsuntoViewModel viewModel)
        {
            try
            {
                Confirmation confirmacion = new Confirmation();
                this.DataContext = new AsuntoAddViewModel(viewModel,confirmacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private AsuntoAddViewModel GetViewModel()
        {
            return this.DataContext as AsuntoAddViewModel;
        }

        private void btnAgregarSignatario_Click(object sender, RoutedEventArgs e)
        {
            AddSignatarioView addSignatarioView = new AddSignatarioView();
            addSignatarioView.GetAddDeterminante(GetViewModel());
            addSignatarioView.ShowDialog();
        }

        private void btnAgregarDestinatraio_Click(object sender, RoutedEventArgs e)
        {
            AsuntoAddViewModel viewModel = GetViewModel();

            AddDestinatarioView addDestinatarioView = new AddDestinatarioView();
            addDestinatarioView.GetAddDestinatario(viewModel);
            addDestinatarioView.ShowDialog();
        }

        private void btnAgregarExpedinete_Click(object sender, RoutedEventArgs e)
        {
            AddDocumentosView addDocumento = new AddDocumentosView();
            addDocumento.GetAddDocumento(GetViewModel());
            addDocumento.ShowDialog();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {

            AsuntoAddViewModel viewModel = GetViewModel();

            viewModel.RegresarCommand.Execute(null);

            if (viewModel._Confirmation.Response)
            {
                Asunto.AsuntoView _AsuntoView = new Asunto.AsuntoView();
                this.GetContentPane().Content = _AsuntoView;
                //Asunto
                _AsuntoView.GetAsunto(viewModel._ParentAsunto._PantallaInicioViewModel, viewModel._ParentAsunto._Filtro);
            }
        }

        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                cc = ((Grid)((ContentControl)this.Parent).Parent).FindName("CtSubMenu") as ContentControl;
            }
            catch (Exception)
            {

                return cc;
            }

            return cc;
        }

        public void Nuevo()
        {
            throw new NotImplementedException();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            AsuntoAddViewModel viewModel = GetViewModel();

            viewModel.SaveCommand.Execute(null);

            if (viewModel._Confirmation.Response)
            {
                Asunto.AsuntoView _AsuntoView = new Asunto.AsuntoView();
                this.GetContentPane().Content = _AsuntoView;
                //Asunto
                _AsuntoView.GetAsunto(viewModel._ParentAsunto._PantallaInicioViewModel, viewModel._ParentAsunto._Filtro);
            }
        }

        private void BtnGuardarTurnar_Click(object sender, RoutedEventArgs e)
        {
            AsuntoAddViewModel viewModel = GetViewModel();

            viewModel.SaveTurnarCommand.Execute(null);

            if (viewModel._Confirmation.Response)
            {
                Asunto.AsuntoView _AsuntoView = new Asunto.AsuntoView();
                this.GetContentPane().Content = _AsuntoView;
                //Asunto
                _AsuntoView.GetAsunto(viewModel._ParentAsunto._PantallaInicioViewModel, viewModel._ParentAsunto._Filtro);
            }
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            AsuntoAddViewModel viewModel = GetViewModel();

            if (viewModel!=null)
            {
                viewModel.GetImprimirAsunto();
                ImprimirView view = new ImprimirView();
                view.GetImprimir(viewModel.ImprimirAsunto);
                view.ShowDialog();
            }
        }

        private void cbIntruccion_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (!string.IsNullOrWhiteSpace(cb.Text))
            {
                AsuntoAddViewModel viewModel = GetViewModel();
                if (viewModel != null)
                {
                    viewModel.GetExistInstruccion(cb.Text);
                }
                
            }
            

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (popup1.IsOpen == false)
            {
                popup1.IsOpen = true;
            }
            else
            {
                popup1.IsOpen = false;
            }
        }

        private void btnAgregarDestinatraioCcp_Click(object sender, RoutedEventArgs e)
        {
            AsuntoAddViewModel viewModel = GetViewModel();
            AddDestinatarioConCopiaParaView addDestinatarioView = new AddDestinatarioConCopiaParaView();
            addDestinatarioView.GetAddDestinatario(viewModel);
            addDestinatarioView.ShowDialog();

        }

        private void btnAgregarDestinatraioExternos_Click(object sender, RoutedEventArgs e)
        {
            AddSignatarioExternoView addSignatarioExternoView = new AddSignatarioExternoView();
            addSignatarioExternoView.GetAddDeterminante(GetViewModel());
            addSignatarioExternoView.ShowDialog();
        }
    }
}
