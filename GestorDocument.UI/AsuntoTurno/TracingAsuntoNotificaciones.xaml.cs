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
using GestorDocument.Model;
using GestorDocument.ViewModel;
using GestorDocument.ViewModel.AsuntoTurno;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para TracingAsuntoNotificaciones.xaml
    /// </summary>
    public partial class TracingAsuntoNotificaciones : UserControl, IContentControl
    {
        public TracingAsuntoNotificaciones()
        {
            InitializeComponent();
        }

        private TrancingAsuntoTurnoReadViewModel GetViewModel()
        {
            return this.DataContext as TrancingAsuntoTurnoReadViewModel;
        }

        public void GetTurnoTrancing(AsuntoNotificacionesViewModel _AsuntoViewModel, AsuntoModel _AsuntoModel)
        {
            try
            {
                Confirmation confirmaion = new Confirmation();
                DownloadFile download = new DownloadFile();
                this.DataContext = new TrancingAsuntoTurnoReadViewModel(_AsuntoViewModel, _AsuntoModel,confirmaion,download);
            }
            catch (Exception)
            {
                
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoTurnoReadViewModel viewModel = GetViewModel();
            Asunto.AsuntoNotificacionesView _AsuntoView = new Asunto.AsuntoNotificacionesView();
            this.GetContentPane().Content = _AsuntoView;
            //Asunto
            _AsuntoView.GetAsunto(viewModel._ParentAsunto._PantallaInicioViewModel, viewModel._ParentAsunto._Filtro);

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

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoTurnoReadViewModel viewModel = GetViewModel();
            if (viewModel !=null)
            {
                viewModel.GetImprimirAsunto();

                ImprimirView view = new ImprimirView();
                view.GetImprimir(viewModel.ImprimirAsunto);
                view.ShowDialog();
               
            }

        }
    }
}
