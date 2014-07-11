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
    /// Lógica de interacción para SignatarioView.xaml
    /// </summary>
    public partial class SignatarioView : Window
    {
        public SignatarioView()
        {
            InitializeComponent();
            this.DataContext = new SignatarioViewModel();
        }

        private SignatarioViewModel GetViewModel()
        {
            return this.DataContext as SignatarioViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            SignatarioAddView view = new SignatarioAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridSignatario_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedSignatario != null)
            {
                SignatarioModView view = new SignatarioModView();
                SignatarioModViewModel avm = new SignatarioModViewModel(this.GetViewModel().SelectedSignatario);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }

    }
}
