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
using GestorDocument.ViewModel.Login;
using System.Reflection;
using System.Diagnostics;
using GestorDocument.UI.Login;

namespace GestorDocument.UI.v2
{
    /// <summary>
    /// Lógica de interacción para UsuarioInfoView.xaml
    /// </summary>
    public partial class UsuarioInfoView : UserControl
    {
        UserLoginViewModel vm;
        public UsuarioInfoView()
        {
            InitializeComponent();
        }

        public void Init(UserLoginViewModel user)
        {
            this.vm = user;
            this.DataContext = vm;
            GetVersion();
        }

        public void GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.tbVersion.Text = fvi.ProductVersion.ToString();
            this.tbVersion.ToolTip = fvi.ProductVersion.ToString();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            UserLoginView login = new UserLoginView();
            UserLoginViewModel loginViewModel = new UserLoginViewModel(vm.Sesion);
            login.Show();
            this.GetParetWindows().Close();
        }


        public Main GetParetWindows()
        {
            Main res = null;
            try
            {
                object query = Application.Current.Windows[0];
                res = query as Main;
            }
            catch (Exception ex)
            {

            }
            return res;
        }
    }
}
