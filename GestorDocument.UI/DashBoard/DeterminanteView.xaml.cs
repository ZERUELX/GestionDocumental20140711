using System.Windows.Controls;
using GestorDocument.ViewModel.DashBoard;

namespace GestorDocument.UI.DashBoard
{
    /// <summary>
    /// Lógica de interacción para DeterminanteView.xaml
    /// </summary>
    public partial class DeterminanteView : UserControl
    {
        public DeterminanteView()
        {
            InitializeComponent();
            //this.DataContext = new DeterminanteViewModel();
        }

        private void cbxSignatarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxSignatarios.SelectedItem = null;
        }
    }
}
