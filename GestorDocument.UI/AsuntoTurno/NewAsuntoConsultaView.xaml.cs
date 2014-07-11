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

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para NewAsuntoConsultaView.xaml
    /// </summary>
    public partial class NewAsuntoConsultaView : UserControl, IContentControl
    {
        public NewAsuntoConsultaView()
        {
            InitializeComponent();
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
            throw new NotImplementedException();
        }
    }
}
