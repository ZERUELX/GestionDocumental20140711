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

namespace GestorDocument.UI.Buscar
{
    /// <summary>
    /// Lógica de interacción para ResultadoView.xaml
    /// </summary>
    public partial class ResultadoView : UserControl, IContentControl
    {
        public AsuntoModel _AsuntoModel;

        public ResultadoView()
        {
            InitializeComponent();
        }
            //DataContext = new AsuntoNotificacionesViewModel();

        private AsuntoNotificacionesViewModel GetViewModel()
        {
            return this.DataContext as AsuntoNotificacionesViewModel;
        }

        private AsuntoViewModel GetAsuntoViewModel()
        {
            return this.DataContext as AsuntoViewModel;
        }

        private void ListAsuntos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                ListBox dg = sender as ListBox;
                _AsuntoModel = dg.SelectedItem as AsuntoModel;
                if (_AsuntoModel != null)
                    GetAsuntoTurno();
            }
        }

        private void GetAsuntoTurno()
        {
            if (_AsuntoModel.Turno.IsTurnado)
            {
                AsuntoTurno.TracingAsunto _TracingAsunto = new AsuntoTurno.TracingAsunto();
                GetContentPane().Content = _TracingAsunto;
                _TracingAsunto.GetTurnoTrancing(GetViewModel(), _AsuntoModel);
            }
            else
            {
                AsuntoTurno.ModifyAsuntoTurnoView ModView = new AsuntoTurno.ModifyAsuntoTurnoView();
                ModView.GetAsuntoMod(GetAsuntoViewModel(), _AsuntoModel);
                //AsuntoTurno.ModifyAsuntoTurnoNotificacionesView ModView = new AsuntoTurno.ModifyAsuntoTurnoNotificacionesView();
                //ModView.GetAsuntoMod(GetViewModel(), _AsuntoModel);
                this.GetContentPane().Content = ModView;
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

        public void Nuevo()
        {
            throw new NotImplementedException();
        }
    }
}
