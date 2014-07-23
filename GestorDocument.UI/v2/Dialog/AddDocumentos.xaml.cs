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
using GestorDocument.ViewModel.v2;

namespace GestorDocument.UI.v2.Dialog
{
    /// <summary>
    /// Lógica de interacción para AddDocumentos.xaml
    /// </summary>
    public partial class AddDocumentos : Window
    {
        public AddDocumentos()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            this.DataContext = new AddDocumentoViewModel();
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
