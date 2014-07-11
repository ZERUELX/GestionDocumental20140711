using System.Windows.Controls;
using GestorDocument.ViewModel.DashBoard;
using System.Collections.ObjectModel;
using GestorDocument.Model.DashBoardModel;
using GestorDocument.Model;

namespace GestorDocument.UI.DashBoard
{
    /// <summary>
    /// Lógica de interacción para DashBoardTableView.xaml
    /// </summary>
    public partial class DashBoardTableView : UserControl
    {
        public DashBoardTableView()
        {
            InitializeComponent();
            //this.DataContext = new DashBoardTableViewModel();
        }        
    }
}
