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
using GestorDocument.ViewModel.PantallaInicio;
using GestorDocument.UI.PlantillasSubMenu;
using GestorDocument.Model;

namespace GestorDocument.UI.Asunto
{
    /// <summary>
    /// Lógica de interacción para AsuntoView.xaml
    /// </summary>
    public partial class AsuntoView : UserControl, IContentControl
    {
        public AsuntoModel _AsuntoModel;

        public AsuntoView()
        {
            InitializeComponent();
        }

        private AsuntoViewModel GetViewModel()
        {
            return this.DataContext as AsuntoViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        private void DataGridAsunto_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedAsunto != null)
            {
                Asunto.AsuntoModView ModView = new Asunto.AsuntoModView();
                ModView.GetAsuntoMod(GetViewModel(), this.GetViewModel().SelectedAsunto);
                this.GetContentPane().Content = ModView;
            }
        }

        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                //cc = ((Grid)((ContentControl)this.Parent).Parent).FindName("CtSubMenu") as ContentControl;
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

        public void Nuevo()
        {
            try
            {
                AsuntoTurno.AsuntoTurnoView view = new AsuntoTurno.AsuntoTurnoView();
                this.GetContentPane().Content = view;
                view.GetAsunto(GetViewModel());
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            
        }

        public void GetAsunto(PantallaInicioViewModel viewModel, int filtro)
        {
            try
            {
                this.DataContext = new AsuntoViewModel(viewModel, filtro);
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

        /// <summary>
        /// Obtiene detalle del Asunto seleccionado.
        /// Si el asunto ya esta turnado obtiene el tracking del asunto, si no, obtiene la vista de captura.
        /// </summary>
        private void GetAsuntoTurno()
        {
            if (_AsuntoModel.Turno.IsTurnado)
            {
                AsuntoTurno.TracingAsuntoConsulta _TracingAsuntoConsulta = new AsuntoTurno.TracingAsuntoConsulta();
                GetContentPane().Content = _TracingAsuntoConsulta;
                _TracingAsuntoConsulta.GetTurnoTrancing(GetViewModel(), _AsuntoModel);
            }
            else
            {
                AsuntoTurno.ModifyAsuntoTurnoView ModView = new  AsuntoTurno.ModifyAsuntoTurnoView();
                ModView.GetAsuntoMod(GetViewModel(), this.GetViewModel().SelectedAsunto);
                this.GetContentPane().Content = ModView;
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

        /// <summary>
        /// Evento doble clic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
