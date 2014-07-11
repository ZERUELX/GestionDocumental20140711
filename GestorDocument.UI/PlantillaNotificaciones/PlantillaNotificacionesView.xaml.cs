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
using GestorDocument.UI.AsuntoTurno;

namespace GestorDocument.UI.PlantillaNotificaciones
{
    /// <summary>
    /// Lógica de interacción para PlantillaNotificacionesView.xaml
    /// </summary>
    public partial class PlantillaNotificacionesView : UserControl, IContentControl
    {
        private int _Filtro = 0;
        public PlantillaNotificacionesView()
        {
            InitializeComponent();
        }

        private MainWindowViewModel GetViewModel()
        {
            return this.DataContext as MainWindowViewModel; ;
        }

        private void borderUrgentes_MouseUp(object sender, MouseButtonEventArgs e)
        {

            int filtroUrgente = 1;
            _Filtro = filtroUrgente;

            this.GetFiltro();
        }

        private void borderAtendidos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int filtroAtendidos = 2;

            _Filtro = filtroAtendidos;

            this.GetFiltro();
        }

        private void borderPendientes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int filtroPendientes = 3;

            _Filtro = filtroPendientes;

            this.GetFiltro();
        }

        private void borderTodos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int filtroTodos = 4;

            _Filtro = filtroTodos;

            this.GetFiltro();
        }

        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                MainWindow mw = Application.Current.Windows[0] as MainWindow;
                if(mw !=null)
                {
                    cc= mw.FindName("CtSubMenu") as ContentControl;
                }
               
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void GetFiltro()
        {
            MainWindowViewModel viewModel = this.GetViewModel();
            if (viewModel != null)
            {
                //oficialia de partes
                if (viewModel.Usuario.Rol.IdRol == 10)
                {
                    Asunto.AsuntoView view = new Asunto.AsuntoView();
                    this.GetContentPane().Content = view;
                    view.GetAsunto(viewModel.PantallaInicio, _Filtro);
                }
                //cualquier otra unidad normativa
                else
                {
                    Asunto.AsuntoNotificacionesView view = new Asunto.AsuntoNotificacionesView();
                    this.GetContentPane().Content = view;
                    view.GetAsunto(viewModel.PantallaInicio, _Filtro);
                }
            }
        }
    }
}
