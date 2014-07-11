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

namespace GestorDocument.UI.StatusAsunto
{
    /// <summary>
    /// Lógica de interacción para StatusAsuntoAddView.xaml
    /// </summary>
    public partial class StatusAsuntoAddView : UserControl
    {
        public StatusAsuntoAddView()
        {
            InitializeComponent();
            this.Loaded += delegate
            {
                Keyboard.Focus(this.textBox1);
                this.textBox1.SelectAll();

            };
            //this.DataContext = new StatusAsuntoAddViewModel();
        }

        private StatusAsuntoAddViewModel GetViewModel()
        {
            return this.DataContext as StatusAsuntoAddViewModel;
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

        public void GetStatusAsunto(StatusAsuntoViewModel viewModel)
        {
            try
            {
                this.DataContext = new StatusAsuntoAddViewModel(viewModel);
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
