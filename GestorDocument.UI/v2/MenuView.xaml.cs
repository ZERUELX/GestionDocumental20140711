using System.Windows.Controls;
using GestorDocument.ViewModel.v2;
using GestorDocument.UI.v2.Stock;
using GestorDocument.UI.Reportes;
using GestorDocument.UI.DashBoard;
using GestorDocument.ViewModel.Login;
using GestorDocument.UI.AsuntoTurno;

namespace GestorDocument.UI.v2
{
    /// <summary>
    /// Lógica de interacción para MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        MenuViewModel mvm = new MenuViewModel();
        UserLoginViewModel Usuario;
        public MenuView()
        {
            InitializeComponent();
            //Init();
        }

        public void Init(UserLoginViewModel user)
        {
            this.Usuario = user;
            mvm.Init(user.User.Rol.IdRol);
            this.DataContext = mvm;
        }

        public void GetSelectedItem()
        {
            switch (mvm.SelectedItem.MenuName)
            {
                case "Turnos":
                    TableroView control;
                    if (!StockSingleton.Instance.DictionaryControl.ContainsKey("CUADRANTE"))
                    {
                        control = new TableroView();
                        StockSingleton.Instance.DictionaryControl.Add("CUADRANTE", control);
                    }
                    StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["CUADRANTE"];
                    break;
                case "Nuevo Asunto":
                    NuevoAsuntoTurnoView nuevoTurno;
                    if (!StockSingleton.Instance.DictionaryControl.ContainsKey("NT"))
                    {
                        nuevoTurno = new NuevoAsuntoTurnoView();
                        StockSingleton.Instance.DictionaryControl.Add("NT", nuevoTurno);
                        //StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["NT"];
                    }
                    nuevoTurno = StockSingleton.Instance.DictionaryControl["NT"] as NuevoAsuntoTurnoView;
                    nuevoTurno.Init(Usuario.User);
                    StockSingleton.Instance.SelectedItem = nuevoTurno;
                    break;
                case "Borrador":
                    HistorialAsuntosDataGrid grid = new HistorialAsuntosDataGrid();
                    grid.init("Borrador");
                    StockSingleton.Instance.SelectedItem = grid;
                    break;
                case "Reportes":
                    PantallaReportes reportes;
                    if (!StockSingleton.Instance.DictionaryControl.ContainsKey("REPORTES"))
                    {
                        reportes = new PantallaReportes();
                        StockSingleton.Instance.DictionaryControl.Add("REPORTES", reportes);
                    }
                    StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["REPORTES"];
                    break;
                case "Tablero":
                    Tablero2View tablero;
                    if (!StockSingleton.Instance.DictionaryControl.ContainsKey("TABLERO"))
                    {
                        tablero = new Tablero2View();
                        StockSingleton.Instance.DictionaryControl.Add("TABLERO", tablero);
                    }
                    else
                    {
                        tablero = StockSingleton.Instance.DictionaryControl["TABLERO"] as Tablero2View;
                        tablero.Refresh();
                    }
                    StockSingleton.Instance.SelectedItem = tablero;                    
                    break;
                default:
                    break;
            }
        }

        private void ListMenu_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                if (mvm.SelectedItem != null)
                {
                    GetSelectedItem();
                }

            }
        }
    }
}
