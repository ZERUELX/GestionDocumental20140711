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
using System.Windows.Markup;

namespace GestorDocument.UI
{
    /// <summary>
    /// Lógica de interacción para DeterminanteAddView.xaml
    /// </summary>
    public partial class DeterminanteAddView : Window
    {
        public DeterminanteAddView()
        {
            InitializeComponent();
            this.DataContext = new DeterminanteAddViewModel();
        }

        private DeterminanteAddViewModel GetViewModel()
        {
            return this.DataContext as DeterminanteAddViewModel;
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
