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
using GestorDocument.ViewModel.AsuntoTurno;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para CapturaTurnoView.xaml
    /// </summary>
    public partial class CapturaTurnoView : UserControl
    {
        public CapturaTurnoView()
        {
            InitializeComponent();
        }

        private TrancingAsuntoTurnoViewModel GetViewModel()
        {
            return this.DataContext as TrancingAsuntoTurnoViewModel;
        }

        private void btnAgregarDocumento_Click(object sender, RoutedEventArgs e)
        {
            DglAddDocumentoView addDocumentoView = new DglAddDocumentoView();
            addDocumentoView.GetAddDocumento(GetViewModel());
            addDocumentoView.ShowDialog();
        }

        private void btnAgregarDestinatario_Click(object sender, RoutedEventArgs e)
        {

            if (GetViewModel().TipoUnidadNormativa.IdTipoUnidadNormativa ==2)
            {
                DglAddDestinatarioDireccionView addDestinatarioView = new DglAddDestinatarioDireccionView();
                addDestinatarioView.GetAddDestinatario(GetViewModel());
                addDestinatarioView.ShowDialog();   
            }
            else if(GetViewModel().TipoUnidadNormativa.IdTipoUnidadNormativa == 3)
            {
                DglAddDestinatarioAreaView addDestinatarioView = new DglAddDestinatarioAreaView();
                addDestinatarioView.GetAddDestinatario(GetViewModel());
                addDestinatarioView.ShowDialog();
            }


        }
    }
}
