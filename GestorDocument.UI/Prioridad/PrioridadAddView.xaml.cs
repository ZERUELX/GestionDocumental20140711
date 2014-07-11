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

namespace GestorDocument.UI.Prioridad
{
    /// <summary>
    /// Lógica de interacción para PrioridadAddView.xaml
    /// </summary>
    public partial class PrioridadAddView : UserControl
    {
        public PrioridadAddView()
        {
            InitializeComponent();
            this.Loaded += delegate
            {
                Keyboard.Focus(this.textBox1);
                this.textBox1.SelectAll();

            };
            //this.DataContext = new PrioridadAddViewModel();
        }

        private PrioridadAddViewModel GetViewModel()
        {
            return this.DataContext as PrioridadAddViewModel;
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

        public void GetPrioridad(PrioridadViewModel viewModel)
        {
            try
            {
                this.DataContext = new PrioridadAddViewModel(viewModel);
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
