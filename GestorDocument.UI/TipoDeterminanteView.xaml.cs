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
    /// Lógica de interacción para TipoDeterminanteView.xaml
    /// </summary>
    public partial class TipoDeterminanteView : Window
    {
        public TipoDeterminanteView()
        {
            InitializeComponent();
            this.DataContext = new TipoDeterminanteViewModel();
        }

        private TipoDeterminanteViewModel GetViewModel()
        {
            return this.DataContext as TipoDeterminanteViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            TipoDeterminanteAddView view = new TipoDeterminanteAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridTipoDeterminante_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedTipoDeterminante != null)
            {
                TipoDeterminanteModView view = new TipoDeterminanteModView();
                TipoDeterminanteModViewModel avm = new TipoDeterminanteModViewModel(this.GetViewModel().SelectedTipoDeterminante);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }

    }
}
