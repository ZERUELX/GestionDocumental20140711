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
using GestorDocument.Model;

namespace GestorDocument.UI.Instruccion
{
    /// <summary>
    /// Lógica de interacción para InstruccionView.xaml
    /// </summary>
    public partial class InstruccionView : UserControl, IContentControl
    {
        public InstruccionView()
        {
            InitializeComponent();
            this.DataContext = new InstruccionViewModel();
        }

        private InstruccionViewModel GetViewModel()
        {
            return this.DataContext as InstruccionViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo();  
        }

        private void DataGridInstruccion_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedInstruccion != null)
            {
                Instruccion.InstruccionModView ModView = new Instruccion.InstruccionModView();
                ModView.GetInstruccionMod(GetViewModel(), this.GetViewModel().SelectedInstruccion);
                this.GetContentPane().Content = ModView;
            }
        }

        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                cc = ((Grid)((ContentControl)this.Parent).Parent).FindName("ContentPane") as ContentControl;
            }
            catch (Exception)
            {

                return cc;
            }

            return cc;
        }

        public void Nuevo()
        {
            Instruccion.InstruccionAddView view = new Instruccion.InstruccionAddView();
            this.GetContentPane().Content = view;
            view.GetInstruccion(GetViewModel());

        }

        public void GetInstruccions()
        {
            this.DataContext = new InstruccionViewModel();
        }
    }
}
