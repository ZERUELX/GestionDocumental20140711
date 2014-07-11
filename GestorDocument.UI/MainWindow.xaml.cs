using System;
using System.Configuration;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using GestorDocument.UI.PlantillasSubMenu;
using GestorDocument.ViewModel;
using GestorDocument.ViewModel.Login;
using GestorDocument.UI.v2;

namespace GestorDocument.UI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentControl
    {
        
        public MainWindow()
        {
            //this.DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
		
		public MainWindow(UserLoginViewModel userLogin)
        {
            InitializeComponent();
            ConfigurationManager.AppSettings["Assembly"] = int.Parse((Assembly.GetExecutingAssembly().GetName().Version.ToString()).Replace(".", "")).ToString();
            this.DataContext = new MainWindowViewModel(userLogin);
        }

        private MainWindowViewModel GetViewModel()
        {
            return this.DataContext as MainWindowViewModel;
        }

        public void CallNew()
        {
            ContentControl cc = null;
            try
            {

                cc = this.FindName("ContentPaneSubMenu") as ContentControl;
                IContentControl view = cc.Content as IContentControl;
                if (view !=null)
                    view.Nuevo();
               
            }
            catch (Exception)
            {

                ;
            }

        }

        public ContentControl GetContentPane()
        {
            ContentControl cc = null;
            try
            {
                cc=(ContentControl)this.FindName("CtSubMenu");
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

        /// <summary>
        /// Obtiene el tablero de los cuadrantes
        /// </summary>
        public void GetPantallaInicio()
        {
            //PantallaInicioView _PantallaInicioView = new PantallaInicioView();
            //this.GetContentPane().Content = _PantallaInicioView;
            TableroView tablero = new TableroView();
            this.GetContentPane().Content = tablero;
        }

        private void PantallaPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            this.GetPantallaInicio();    
        }

    }
}
