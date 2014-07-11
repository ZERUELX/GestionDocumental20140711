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
using GestorDocument.ViewModel.AsuntoTurno;
using GestorDocument.ViewModel;
using GestorDocument.Model;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para TracingAsuntoConsulta.xaml
    /// </summary>
    public partial class TracingAsuntoConsulta : UserControl,  IContentControl
    {
        public TracingAsuntoConsulta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Retorna el ViewModel de la vista.
        /// </summary>
        /// <returns></returns>
        private TrancingAsuntoViewModel GetViewModel()
        {
            return this.DataContext as TrancingAsuntoViewModel;
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
 
        }

        public void GetTurnoTrancing(AsuntoViewModel _AsuntoViewModel, AsuntoModel _AsuntoModel)
        {
            Confirmation confirmacion = new Confirmation();
            DownloadFile download = new DownloadFile();
            this.DataContext = new TrancingAsuntoViewModel(_AsuntoViewModel, _AsuntoModel, confirmacion, download);

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoViewModel viewModel = GetViewModel();
            Asunto.AsuntoView _AsuntoView = new Asunto.AsuntoView();
            this.GetContentPane().Content = _AsuntoView;
            //Asunto
            _AsuntoView.GetAsunto(viewModel._ParentAsunto._PantallaInicioViewModel, viewModel._ParentAsunto._Filtro);
        }

        private void btnCerrarAsunto_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoViewModel viewModel = GetViewModel();
            
            viewModel.CerrarTurnoCommand.Execute(null);

            if (viewModel.Response)
            {
                Asunto.AsuntoView _AsuntoView = new Asunto.AsuntoView();
                this.GetContentPane().Content = _AsuntoView;
                //Asunto
                _AsuntoView.GetAsunto(viewModel._ParentAsunto._PantallaInicioViewModel, viewModel._ParentAsunto._Filtro);   
            }
            
        }


        /// <summary>
        /// Evento clic del boton Imprimir Caratula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoViewModel viewModel = GetViewModel();

            if (viewModel != null)
            {
                viewModel.GetImprimirAsunto();
                ImprimirView view = new ImprimirView();
                view.GetImprimir(viewModel.ImprimirAsunto);
                view.ShowDialog();
            }
        }


    }
}
