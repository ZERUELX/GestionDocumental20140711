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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using GestorDocument.ViewModel.Login;
using System.ComponentModel;
using System.Diagnostics;

namespace GestorDocument.UI.Login
{
    /// <summary>
    /// Lógica de interacción para UserLoginView.xaml
    /// </summary>
    public partial class UserLoginView : Window
    {
        private bool loaded;
        public UserLoginView()
        {
            this.loaded = false;
            InitializeComponent();

            this.Loaded += delegate
            {
                FocusManager.SetFocusedElement(this, this.tbUser);
                Keyboard.Focus(this.tbUser);
                this.tbUser.SelectAll();

            };
        }

        private UserLoginViewModel GetViewModel()
        {
            return this.DataContext as UserLoginViewModel;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Process.GetCurrentProcess().Kill();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!this.loaded)
            {
                if (!DesignerProperties.GetIsInDesignMode(this))
                {
                    UserLoginViewModel ulvm = new UserLoginViewModel();
                    if (ulvm.UserSet())
                    {
                        this.DataContext = ulvm;
                        this.LoginSuccess();
                    }

                    ulvm.PropertyChanged += delegate(object s, PropertyChangedEventArgs args)
                    {
                        if (args.PropertyName == "User")
                        {
                            if (ulvm.User != null && ulvm.User.IsActive)
                            {
                                if ((s as UserLoginViewModel).UserSet())
                                    this.LoginSuccess();
                            }
                        }
                    };
                    this.DataContext = ulvm;
                }
            }
            this.loaded = true;
        }

        public void LoginSuccess()
        {
            (new MainWindow(this.GetViewModel())).Show();  
            this.Close();
        }

        private void MinimizeButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            Process.GetCurrentProcess().Kill();
        }
    }
}
