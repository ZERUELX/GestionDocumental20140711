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

namespace GestorDocument.UI.Documentos
{
    /// <summary>
    /// Lógica de interacción para DocumentosView.xaml
    /// </summary>
    public partial class DocumentosView : UserControl, IContentControl
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
            Nuevo();
        }

        private void DataGridDocumentos_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedDocumentos != null)
            {
                Documentos.DocumentosModView ModView = new Documentos.DocumentosModView();
                ModView.GetDocumentosMod(GetViewModel(), this.GetViewModel().SelectedDocumentos);
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
            Documentos.DocumentosAddView view = new Documentos.DocumentosAddView();
            this.GetContentPane().Content = view;
            view.GetDocumentos(GetViewModel());

        }

        public void GetDocumentoss()
        {
            this.DataContext = new DocumentosViewModel();
        }

    }
}
