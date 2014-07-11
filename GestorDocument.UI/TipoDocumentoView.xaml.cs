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
    /// Lógica de interacción para TipoDocumentoView.xaml
    /// </summary>
    public partial class TipoDocumentoView : Window
    {
        public TipoDocumentoView()
        {
            InitializeComponent();
            this.DataContext = new TipoDocumentoViewModel();
        }

        private TipoDocumentoViewModel GetViewModel()
        {
            return this.DataContext as TipoDocumentoViewModel;
        }

        private void BtNuevo_Click(object sender, RoutedEventArgs e)
        {
            TipoDocumentoAddView view = new TipoDocumentoAddView();
            view.ShowDialog();
            this.GetViewModel().LoadInfoGrid();
        }

        private void DataGridTipoDocumento_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedTipoDocumento != null)
            {
                TipoDocumentoModView view = new TipoDocumentoModView();
                TipoDocumentoModViewModel avm = new TipoDocumentoModViewModel(this.GetViewModel().SelectedTipoDocumento);
                view.DataContext = avm;
                view.ShowDialog();
                this.GetViewModel().LoadInfoGrid();
            }
        }

    }
}
