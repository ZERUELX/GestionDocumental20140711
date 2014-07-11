using System.Windows.Controls;
using GestorDocument.ViewModel.v2;

namespace GestorDocument.UI.v2
{
    /// <summary>
    /// Lógica de interacción para MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        MenuViewModel mvm = new MenuViewModel();
        public MenuView()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            mvm.Init(10);
            this.DataContext = mvm;
        }
    }
}
