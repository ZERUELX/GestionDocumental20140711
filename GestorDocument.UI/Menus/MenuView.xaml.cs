using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
//using GestorDocument.UI.Pruebas;
using GestorDocument.UI.PlantillasSubMenu;
using GestorDocument.UI.TipoDeterminante;
using GestorDocument.UI.TipoDocumento;
using GestorDocument.UI.Ubicacion;
using GestorDocument.UI.Instruccion;
using GestorDocument.UI.Prioridad;
using GestorDocument.UI.FechaVencimiento;
using GestorDocument.UI.Documentos;
using GestorDocument.UI.Turno;
using GestorDocument.UI.Expediente;
using GestorDocument.UI.StatusAsunto;
using GestorDocument.UI.StatusTurno;
using GestorDocument.UI.Determinante;
using GestorDocument.UI.Signatario;
using GestorDocument.Model;
using GestorDocument.ViewModel;
using GestorDocument.UI.Login;
using System.Diagnostics;
using GestorDocument.ViewModel.Login;
using System.Reflection;

namespace GestorDocument.UI.Menus
{
    /// <summary>
    /// Lógica de interacción para MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl, IContentControl
    {
        public MenuView()
        {
            InitializeComponent();
            this.GetVersion();
        }

        private MainWindowViewModel GetViewModel()
        {
            return this.DataContext as MainWindowViewModel;
        }

        private void LisCatalogos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {

                ListBox dg = sender as ListBox;
                MenuModel view = dg.SelectedItem as MenuModel;
                if (view != null)
                    GetCatalogo(view);
            }
        }

        public void GetCatalogo(MenuModel view)
        {
            switch (view.MenuName)
            {
                case "ASUNTO":
                    //CatAsuntoView _CatAsuntoView = new CatAsuntoView();
                    //this.GetContentPane().Content = _CatAsuntoView;
                    break;
                case "DETERMINANTE":
                    CatDeterminanteView _CatDeterminanteView = new CatDeterminanteView();
                    this.GetContentPane().Content = _CatDeterminanteView;
                    break;
                case "DOCUMENTOS":
                    CatDocumentosView _CatDocumentosView = new CatDocumentosView();
                    this.GetContentPane().Content = _CatDocumentosView;
                    break;
                case "EXPEDIENTE":
                    CatExpedienteView _CatExpedienteView = new CatExpedienteView();
                    this.GetContentPane().Content = _CatExpedienteView;
                    break;
                case "FECHA VENCIMIENTO":
                    CatFechaVencimientoView _CatFechaVencimientoView = new CatFechaVencimientoView();
                    this.GetContentPane().Content = _CatFechaVencimientoView;
                    break;
                case "INSTRUCCION":
                    CatInstruccionView _CatInstruccionView = new CatInstruccionView();
                    this.GetContentPane().Content = _CatInstruccionView;
                    break;
                case "PRIORIDAD":
                    CatPrioridadView _CatPrioridadView = new CatPrioridadView();
                    this.GetContentPane().Content = _CatPrioridadView;
                    break;
                case "SIGNATARIO":
                    CatSignatarioView _CatSignatarioView = new CatSignatarioView();
                    this.GetContentPane().Content = _CatSignatarioView;
                    break;
                case "STATUS ASUNTO":
                    CatStatusAsuntoView _CatStatusAsuntoView = new CatStatusAsuntoView();
                    this.GetContentPane().Content = _CatStatusAsuntoView;
                    break;
                case "STATUS TURNO":
                    CatStatusTurnoView _CatStatusTurnoView = new CatStatusTurnoView();
                    this.GetContentPane().Content = _CatStatusTurnoView;
                    break;
                case "TIPO DETERMINANTE":
                    CatTipoDeterminanteView _CatTipoDeterminanteView = new CatTipoDeterminanteView();
                    this.GetContentPane().Content = _CatTipoDeterminanteView;
                    break;
                case "TIPO DOCUMENTO":
                    CatTipoDocumentoView _CatTipoDocumentoView = new CatTipoDocumentoView();
                    this.GetContentPane().Content = _CatTipoDocumentoView;
                    break;
                case "TURNO":
                    CatTurnoView _CatTurnoView = new CatTurnoView();
                    this.GetContentPane().Content = _CatTurnoView;
                    break;
                case "UBICACION":
                    CatUbicacionView _CatUbicacionView = new CatUbicacionView();
                    this.GetContentPane().Content = _CatUbicacionView;
                    break;                                
                default:
                    break;

            }
        }

        //metodo que pega en el contenedor 
        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                MainWindow mw = Application.Current.Windows[0] as MainWindow;
                if (mw != null)
                {
                    cc = mw.FindName("CtSubMenu") as ContentControl;
                }
                //cc = ((Grid)((ContentControl)this.Parent).Parent).FindName("CtSubMenu") as ContentControl;
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

        public void GetMenu(MenuModel model)
        {
            MainWindowViewModel viewModel = null;
            Asunto.AsuntoView viewAsunto = null;
            switch (model.MenuName)
            {
                case "Turnos":
                    PantallaInicioView _PantallaInicioView = new PantallaInicioView();
                    this.GetContentPane().Content = _PantallaInicioView;
                    break;
                case "Nuevo Asunto":
                    viewModel = this.GetViewModel();
                    viewAsunto = new Asunto.AsuntoView();
                    this.GetContentPane().Content = viewAsunto;
                    viewAsunto.GetAsunto(viewModel.PantallaInicio, 4);
                    viewAsunto.Nuevo();
                    break;
                case "Borrador":
                    this.GetValidedBorrador();
                    break;
                case "Reportes":
                    Reportes.PantallaReportes reportes = new Reportes.PantallaReportes();
                    this.GetContentPane().Content = reportes;
                    break;
                case "Tablero":
                    DashBoard.Tablero2View _TableroView = new DashBoard.Tablero2View();
                    this.GetContentPane().Content = _TableroView;
                    break; 
                default:
                    break;

            }
        }

        private void ListMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                ListBox dg = sender as ListBox;
                MenuModel viewModel = dg.SelectedItem as MenuModel;
                if (viewModel != null)
                    GetMenu(viewModel);
            }
        }

        public void GetValidedBorrador()
        {
            MainWindowViewModel viewModel = null;
            Asunto.AsuntoView viewAsunto = null;
            Asunto.AsuntoNotificacionesView viewAsuntoNotificaciones = null;
            
            long idRol = 10;

            viewModel = this.GetViewModel();

            if (idRol != viewModel.Usuario.Rol.IdRol)
            {
                viewAsuntoNotificaciones = new Asunto.AsuntoNotificacionesView();
                this.GetContentPane().Content = viewAsuntoNotificaciones;
                viewAsuntoNotificaciones.GetAsunto(viewModel.PantallaInicio, 5);
            }
            else
            {
                viewAsunto = new Asunto.AsuntoView();
                this.GetContentPane().Content = viewAsunto;
                viewAsunto.GetAsunto(viewModel.PantallaInicio, 5);
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Esta Seguro de cerrar sesión? ", "¿Cerrar Sesión?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                this.ViewLoging();
        }

        private void ViewLoging()
        {
            UserLoginView login = new UserLoginView();
            //quita el inicio de sesion automatico
            UserLoginViewModel loginViewModel = new UserLoginViewModel(this.GetViewModel().UserLogin.Sesion);

            login.Show();
            this.GetParetWindows().Close();
        }

        public MainWindow GetParetWindows()
        {
            MainWindow res = null;
            try
            {
                object query = Application.Current.Windows[0];
                res = query as MainWindow;
            }
            catch (Exception)
            {
                ;
            }
            return res;
        }

        public void GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.tbVersion.Text = fvi.ProductVersion.ToString();
            this.tbVersion.ToolTip = fvi.ProductVersion.ToString();
        }

    }
}