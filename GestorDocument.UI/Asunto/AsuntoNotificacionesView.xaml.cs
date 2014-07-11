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
using GestorDocument.UI.PlantillaNotificaciones;
using GestorDocument.UI.PlantillasSubMenu;
using GestorDocument.ViewModel;
using GestorDocument.ViewModel.PantallaInicio;

namespace GestorDocument.UI.Asunto
{
    /// <summary>
    /// Lógica de interacción para AsuntoNotificacionesView.xaml
    /// </summary>
    public partial class AsuntoNotificacionesView : UserControl, IContentControl
    {
        public AsuntoModel _AsuntoModel;

        public AsuntoNotificacionesView()
        {
            InitializeComponent();
        }

        private AsuntoNotificacionesViewModel GetViewModel()
        {
            return this.DataContext as AsuntoNotificacionesViewModel;
        }

        public void GetAsunto(PantallaInicioViewModel viewModel, int filtro)
        {
            try
            {
                this.DataContext = new AsuntoNotificacionesViewModel(viewModel, filtro);
            }
            catch (Exception)
            {
                ;
            }
        }
        
        private void BtRegresar_Click(object sender, RoutedEventArgs e)
        {
            PantallaInicioView _PantallaInicioView = new PantallaInicioView();
            this.GetContentPane().Content = _PantallaInicioView;
        }

        //private void ListAsuntos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    this.ListAsuntos.Cursor = Cursors.Wait;
        //    if (sender != null)
        //    {
        //        ListBox dg = sender as ListBox;
        //        _AsuntoModel = dg.SelectedItem as AsuntoModel;
        //        if (_AsuntoModel != null)
        //            GetAsuntoTurno();
        //    }
        //}

        private void GetAsuntoTurno()
        {
            if (_AsuntoModel.Turno!=null)
            {
                if (_AsuntoModel.Turno.IsTurnado || _AsuntoModel.Turno.IsAtendido)
                {
                    AsuntoTurno.TracingAsuntoNotificaciones _TracingAsunto = new AsuntoTurno.TracingAsuntoNotificaciones();
                    GetContentPane().Content = _TracingAsunto;
                    _TracingAsunto.GetTurnoTrancing(GetViewModel(), this.GetViewModel().SelectedAsunto);
                }
                else
                {
                    AsuntoTurno.TracingAsunto ModView = new AsuntoTurno.TracingAsunto();
                    this.GetContentPane().Content = ModView;
                    ModView.GetTurnoTrancing(this.GetViewModel(), this.GetViewModel().SelectedAsunto);
                }    
            }
            else
            {
                AsuntoTurno.TracingAsuntoNotificaciones _TracingAsunto = new AsuntoTurno.TracingAsuntoNotificaciones();
                GetContentPane().Content = _TracingAsunto;
                _TracingAsunto.GetTurnoTrancing(GetViewModel(), this.GetViewModel().SelectedAsunto);
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

        private void dataGridAsuntos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            this.dataGridAsuntos.Cursor = Cursors.Wait;
            if (sender != null)
            {
                DataGrid dg = sender as DataGrid;
                if (dg != null && dg.SelectedItems != null && dg.SelectedItems.Count == 1)
                {

                    _AsuntoModel = dg.SelectedItem as AsuntoModel;
                    if (_AsuntoModel != null)
                        GetAsuntoTurno();

                }
            }

        }
    }
}
