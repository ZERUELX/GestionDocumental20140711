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
    /// Lógica de interacción para DocumentosView.xaml
    /// </summary>
    public partial class DocumentosView : Window
    {
        public DocumentosView()
        {
            InitializeComponent();
            this.DataContext = new DocumentosViewModel();
        }

        private DocumentosViewModel GetViewModel()
        {
            return this.DataContext as DocumentosViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            DocumentosAddView view = new DocumentosAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridDocumentos_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedDocumentos != null)
            {
                DocumentosModView view = new DocumentosModView();
                DocumentosModViewModel avm = new DocumentosModViewModel(this.GetViewModel().SelectedDocumentos);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }

    }
}
