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

namespace GestorDocument.UI.TipoDocumento
{
    /// <summary>
    /// Lógica de interacción para TipoDocumentoView.xaml
    /// </summary>
    public partial class TipoDocumentoView : UserControl, IContentControl
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
            Nuevo();
        }

        private void DataGridTipoDocumento_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedTipoDocumento != null)
            {
                TipoDocumento.TipoDocumentoModView ModView = new TipoDocumento.TipoDocumentoModView();
                ModView.GetTipoDocumentoMod(GetViewModel(), this.GetViewModel().SelectedTipoDocumento);
                this.GetContentPane().Content = ModView;
            }
        }

        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                cc = ((Grid)((ContentControl)this.Parent).Parent).FindName("ContentPane") as ContentControl;
            }
            catch (Exception)
            {

                return cc;
            }

            return cc;
        }

        public void Nuevo()
        {
            TipoDocumento.TipoDocumentoAddView view = new TipoDocumento.TipoDocumentoAddView();
            this.GetContentPane().Content = view;
            view.GetTipoDocumento(GetViewModel());

        }

        public void GetTipoDocumentos()
        {
            this.DataContext = new TipoDeterminanteViewModel();
        }

    }
}
