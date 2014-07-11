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

namespace GestorDocument.UI.Signatario
{
    /// <summary>
    /// Lógica de interacción para SignatarioAddView.xaml
    /// </summary>
    public partial class SignatarioAddView : UserControl
    {

        public SignatarioAddView()
        {
            InitializeComponent();
            this.Loaded += delegate
            {
                Keyboard.Focus(this.comboBox1);
                //this.textBox1.SelectAll();

            };
            //this.DataContext = new SignatarioAddViewModel();
        }

        private SignatarioAddViewModel GetViewModel()
        {
            return this.DataContext as SignatarioAddViewModel;
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

        public void GetSignatario(SignatarioViewModel viewModel)
        {
            try
            {
                this.DataContext = new SignatarioAddViewModel(viewModel);
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
