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

namespace GestorDocument.UI.Signatario
{
    /// <summary>
    /// Lógica de interacción para SignatarioView.xaml
    /// </summary>
    public partial class SignatarioView : UserControl, IContentControl
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
            Nuevo();
        }

        private void DataGridSignatario_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (this.GetViewModel().SelectedSignatario != null)
            {
                Signatario.SignatarioModView ModView = new Signatario.SignatarioModView();
                ModView.GetSignatarioMod(GetViewModel(), this.GetViewModel().SelectedSignatario);
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
            Signatario.SignatarioAddView view = new Signatario.SignatarioAddView();
            this.GetContentPane().Content = view;
            view.GetSignatario(GetViewModel());

        }

        public void GetSignatarios()
        {
            this.DataContext = new SignatarioViewModel();
        }

    }
}
