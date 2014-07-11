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
using System.Windows.Shapes;
using GestorDocument.ViewModel;

namespace GestorDocument.UI
{
    /// <summary>
    /// Lógica de interacción para SignatarioAddView.xaml
    /// </summary>
    public partial class SignatarioAddView : Window
    {
        public SignatarioAddView()
        {
            InitializeComponent();
            this.DataContext = new SignatarioAddViewModel();
        }

        private SignatarioAddViewModel GetViewModel()
        {
            return this.DataContext as SignatarioAddViewModel;
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
