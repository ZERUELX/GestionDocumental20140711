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
using GestorDocument.UI.Buscar;

namespace GestorDocument.UI.Buscar
{
    /// <summary>
    /// Lógica de interacción para BarraBotonesView.xaml
    /// </summary>
    public partial class BarraBotonesView : UserControl, IContentControl
    {
        public BarraBotonesView()
        {
            InitializeComponent();            
            //this.DataContext = new BusquedaViewModel();
        }

       private BusquedaViewModel GetViewModel()
        {
            return this.DataContext as BusquedaViewModel;
        }

        public void btnBuscarTurno_Click(object sender, RoutedEventArgs e)
        {
            BusquedaViewModel viewModel = GetViewModel();
            viewModel.SearchCommand.Execute(null);
            CatResultadoView _CatResultadoView = new CatResultadoView();
            this.GetContentPane().Content = _CatResultadoView;
            _CatResultadoView.GetResultado(viewModel);
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnNuevoAsunto_Click(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        public void Nuevo()
        {
            AsuntoTurno.AsuntoTurnoView view = new AsuntoTurno.AsuntoTurnoView();
            this.GetContentPane().Content = view;
            //view.GetAsunto(GetViewModel());
        }

    }
}