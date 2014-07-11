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
using GestorDocument.ViewModel.DashBoard;
using System.Collections.ObjectModel;
using GestorDocument.Model;

namespace GestorDocument.UI.DashBoard
{
    /// <summary>
    /// Lógica de interacción para PendientesView.xaml
    /// </summary>
    public partial class PendientesView : UserControl
    {
        public PendientesView()
        {
            InitializeComponent();
            //this.DataContext = new PendientesViewModel();
        }
                
    }
}
