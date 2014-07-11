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
using System.Windows.Threading;
using System.Windows.Media.Animation;
using SyncService.ViewModel;
using System.ComponentModel;
using System.Configuration;
using GestorDocument.ViewModel.SyncDocs;
using GestorDocument.ViewModel.PantallaInicio;
using GestorDocument.ViewModel;
using System.Diagnostics;

namespace GestorDocument.UI
{
    /// <summary>
    /// Lógica de interacción para MainWindowsHeaderView.xaml
    /// </summary>
    public partial class MainWindowsHeaderView : UserControl
    {
        DispatcherTimer dTimerUploadProcess;
        Storyboard _ImgSync;
        int IsUpdated = 0;
        public DispatcherTimer DTimerUploadProcess
        {
            get { return dTimerUploadProcess; }
            set { dTimerUploadProcess = value; }
        }

        public MainWindowsHeaderView()
        {
            
            InitializeComponent();
            int SyncTimer = Int32.Parse(ConfigurationManager.AppSettings["SyncTimer"].ToString());
            int SyncDocs = Int32.Parse(ConfigurationManager.AppSettings["SyncDocs"].ToString());
            this._ImgSync = (Storyboard)this.FindResource("rotateImg");

            //DTimerUploadProcess = new DispatcherTimer();
            //DTimerUploadProcess.Tick += new EventHandler(DTimerUploadProcess_Tick);
            //DTimerUploadProcess.Interval = new TimeSpan(0, 0, SyncTimer);
            //DTimerUploadProcess.Start();
            
        }

        private void CloseButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.GetParetWindows().Close();
            Application.Current.Shutdown();
            Process.GetCurrentProcess().Kill();
        }

        private void MaximizeButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.GetParetWindows().WindowState == System.Windows.WindowState.Normal)
            {
                this.MaximizeButton.Text = "2";
                this.MaximizeButton.ToolTip = "Restaurar";
                this.GetParetWindows().WindowState = System.Windows.WindowState.Maximized;

            }
            else
            {
                this.MaximizeButton.Text = "1";
                this.MaximizeButton.ToolTip = "Maximizar";
                this.GetParetWindows().WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeButtonMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.GetParetWindows().WindowState = WindowState.Minimized;
        }

        private void DragableGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.BorderMainHader.Cursor = Cursors.ScrollAll;
                    this.GetParetWindows().DragMove();
                }
            }
            this.BorderMainHader.Cursor = null;

        }

        public void ShowImgSync()
        {
            this.cnvTmpRot.Visibility = Visibility.Visible;
            this.cnvTmpRot2.Visibility = Visibility.Collapsed;
            _ImgSync.Begin(this);
        }

        public void HideImgSync()
        {
            this.cnvTmpRot.Visibility = Visibility.Collapsed;
            this.cnvTmpRot2.Visibility = Visibility.Visible;
        }

        public void SetImgSyncMsg(string msg)
        {
            this.imgSyncFiles.ToolTip = msg;
            this.imgSyncFiles2.ToolTip = msg;
        }

        private void imgSyncFiles_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.DTimerUploadProcess_Tick(null, new EventArgs());
        }
        
        /// <summary>
        /// Evento del timer que ejecuta la sincronizacion nada N tiempo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DTimerUploadProcess_Tick(object sender, EventArgs e)
        {
            //Sincronizacion de catalogos                         
            if (!SyncViewModel.IsRunning)
            {
                System.Windows.Threading.Dispatcher dispatcher = Application.Current.Dispatcher;
                PantallaInicioViewModel pantallaInicioViewModel = this.GetViewModel().PantallaInicio;
                string v = ConfigurationManager.AppSettings["Assembly"].ToString();
                SyncViewModel svm = new SyncViewModel(dispatcher, pantallaInicioViewModel, v);

                svm.PropertyChanged += delegate(object sndr, PropertyChangedEventArgs args)
                {
                    if (args.PropertyName.ToLower() == "jobdone")
                    {
                        if (!((SyncViewModel)sndr).JobDone)
                        {
                            Action a = () => this.ShowImgSync();
                            this.Dispatcher.BeginInvoke(a);
                        }
                        else
                        {
                            Action ab = () => this.HideImgSync();
                            this.Dispatcher.BeginInvoke(ab);
                        }
                    }

                    if (args.PropertyName.ToLower() == "message")
                    {
                        Action ac = () => this.SetImgSyncMsg(((SyncViewModel)sndr).Message);
                        this.Dispatcher.BeginInvoke(ac);
                    }
                };

                svm.start();
            }
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

        private MainWindowViewModel GetViewModel()
        {
            return this.DataContext as MainWindowViewModel;
        }
    }
}
