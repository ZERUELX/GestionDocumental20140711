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
using GestorDocument.ViewModel.v2;
using GestorDocument.Model;
using GestorDocument.UI.AsuntoTurno;
using GestorDocument.UI.v2.Dialog;

namespace GestorDocument.UI.v2
{
    /// <summary>
    /// Lógica de interacción para NuevoAsuntoTurnoView.xaml
    /// </summary>
    public partial class NuevoAsuntoTurnoView : UserControl
    {
        NuevoAsuntoTurnoViewModel natvm = new NuevoAsuntoTurnoViewModel();
        public NuevoAsuntoTurnoView()
        {
            InitializeComponent();

        }

        public void Init(UsuarioModel user)
        {
            natvm.Init(user);
            this.DataContext = natvm;
            batvBuscar.Init(user);            
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (popup1.IsOpen == false)
            {
                popup1.IsOpen = true;
            }
            else
            {
                popup1.IsOpen = false;
            }
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            ImprimirView view = new ImprimirView();
            view.GetImprimir(natvm.Asunto);
            view.ShowDialog();
        }

        private void btnAgregarExpedinete_Click(object sender, RoutedEventArgs e)
        {
            AddDocumentos view = new AddDocumentos();
            //view.Owner = 
            view.ShowDialog();

            //AddDocumentosView addDocumento = new AddDocumentosView();
            //addDocumento.GetAddDocumento(natvm);
            //addDocumento.ShowDialog();
        }

    }
}
