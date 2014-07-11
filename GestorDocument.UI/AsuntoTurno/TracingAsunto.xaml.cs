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
using GestorDocument.Model;
using GestorDocument.ViewModel;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para TracingAsunto.xaml
    /// </summary>
    public partial class TracingAsunto : UserControl, IContentControl
    {
        public TracingAsunto()
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
                cc = ((Grid)((ContentControl)this.Parent).Parent).FindName("CtSubMenu") as ContentControl;
            }
            catch (Exception)
            {

                return cc;
            }

            return cc;
        }

        public void GetTurnoTrancing(AsuntoNotificacionesViewModel _AsuntoViewModel, AsuntoModel _AsuntoModel)
        {
            try
            {
                Confirmation confirmacion = new Confirmation();
                DownloadFile download = new DownloadFile();
                this.DataContext = new TrancingAsuntoTurnoViewModel(_AsuntoViewModel, _AsuntoModel, confirmacion, download);

            }
            catch (Exception)
            {
                ;
            }

        }

        public void Nuevo()
        {
            throw new NotImplementedException();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoTurnoViewModel viewModel = GetViewModel();

            viewModel.RegresarCommand.Execute(null);

            if (viewModel._Confirmation.Response)
            {

                Asunto.AsuntoNotificacionesView _AsuntoView = new Asunto.AsuntoNotificacionesView();
                this.GetContentPane().Content = _AsuntoView;
                //Asunto
                _AsuntoView.GetAsunto(viewModel._ParentAsunto._PantallaInicioViewModel, viewModel._ParentAsunto._Filtro);
            }

        }

        private void btnAtender_Click(object sender, RoutedEventArgs e)
        {

            TrancingAsuntoTurnoViewModel viewModel = GetViewModel();
            AtenderTurnoView atender = new AtenderTurnoView();
            atender.DataContext = viewModel;
            atender.ShowDialog();


        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoTurnoViewModel viewModel = GetViewModel();

            viewModel.SaveCommand.Execute(null);

            if (viewModel._Confirmation.Response)
            {
                Asunto.AsuntoNotificacionesView _AsuntoView = new Asunto.AsuntoNotificacionesView();
                this.GetContentPane().Content = _AsuntoView;
                //Asunto
                _AsuntoView.GetAsunto(viewModel._ParentAsunto._PantallaInicioViewModel, viewModel._ParentAsunto._Filtro);
            }

        }

        private void btnGuardarTurnar_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoTurnoViewModel viewModel = GetViewModel();

            TurnarAsuntoView turnar = new TurnarAsuntoView();
            turnar.DataContext = viewModel;
            turnar.ShowDialog();

        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoTurnoViewModel viewModel = GetViewModel();

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
