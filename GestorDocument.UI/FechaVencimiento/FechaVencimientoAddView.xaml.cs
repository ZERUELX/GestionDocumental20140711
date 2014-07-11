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

namespace GestorDocument.UI.FechaVencimiento
{
    /// <summary>
    /// Lógica de interacción para FechaVencimientoAddView.xaml
    /// </summary>
    public partial class FechaVencimientoAddView : UserControl
    {

        public FechaVencimientoAddView()
        {
            InitializeComponent();
            this.Loaded += delegate
            {
                Keyboard.Focus(this.comboBox1);
                //this.comboBox1.SelectAll();

            };
            //this.DataContext = new FechaVencimientoAddViewModel();
        }

        private FechaVencimientoAddViewModel GetViewModel()
        {
            return this.DataContext as FechaVencimientoAddViewModel;
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow res = GetParetWindows();
            if (res != null)
            {
                res.CallNew();
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        public void GetFechaVencimiento(FechaVencimientoViewModel viewModel)
        {
            try
            {
                this.DataContext = new FechaVencimientoAddViewModel(viewModel);
            }
            catch (Exception)
            {
                ;
            }

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

    }
}
