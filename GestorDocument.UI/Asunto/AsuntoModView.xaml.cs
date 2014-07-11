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

namespace GestorDocument.UI.Asunto
{
    /// <summary>
    /// Lógica de interacción para AsuntoModView.xaml
    /// </summary>
    public partial class AsuntoModView : UserControl
    {
        public AsuntoModView()
        {
            InitializeComponent();
        }
    

        public void GetAsuntoMod(AsuntoViewModel viewModel, AsuntoModel p)
        {
            Confirmation confirmacion = new Confirmation();
            this.DataContext = new AsuntoModViewModel(p, viewModel,confirmacion);
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            
        }
}
}