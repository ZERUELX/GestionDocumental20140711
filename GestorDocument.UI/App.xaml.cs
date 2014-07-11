using System;
using System.Windows;
using System.Windows.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GestorDocument.UI.Login;

namespace GestorDocument.UI
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Exception theException = e.Exception;
            string theErrorPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\GeneratorTestbedError.txt";
            using (System.IO.TextWriter theTextWriter = new System.IO.StreamWriter(theErrorPath, true))
            {
                DateTime theNow = DateTime.Now;
                theTextWriter.WriteLine("The error time: " + theNow.ToShortDateString() + " " + theNow.ToShortTimeString());
                while (theException != null)
                {
                    theTextWriter.WriteLine("Exception: " + theException.ToString());
                    theException = theException.InnerException;
                }
            }
            MessageBox.Show("The program crashed.  A stack trace can be found at:\n" + theErrorPath);
            e.Handled = true;
            Application.Current.Shutdown();

        }

        /// <summary>
        /// Abre o maximiza la aplicacion.
        /// </summary>
        private const int SW_SHOWMAXIMIZED = 1;
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            SplashView splash = null;
            int val = this.ValidacionProceso();

            if (val ==0 || val ==1)
            {
                splash = new SplashView();
                splash.ShowDialog();
                
            }
            else
            {
                Process runProcess = this.ValidacionProcesoMaximeze();
                if (runProcess !=null)
                    ShowWindow(runProcess.MainWindowHandle, SW_SHOWMAXIMIZED);
                    
                Application.Current.Shutdown();
                Process.GetCurrentProcess().Kill();

            }

        }

        /// <summary>
        /// Validad si existe un proceso con el mismo nombre, para no ejecutar 2 veces la aplicacion.
        /// </summary>
        /// <returns></returns>
        public int ValidacionProceso()
        {
            Process[] procesos;
            string proceso = System.Configuration.ConfigurationManager.AppSettings["NombreProceso"];
            procesos = Process.GetProcessesByName(proceso);
            return procesos.Length;          
        }

        public Process ValidacionProcesoMaximeze()
        {
            Process[] procesos;

            Process runProcess =null;

            string proceso = System.Configuration.ConfigurationManager.AppSettings["NombreProceso"];
            procesos = Process.GetProcessesByName(proceso);

            foreach (Process p in procesos)
            {
                if (p.ProcessName == proceso)
                {
                    runProcess = p;
                }

            }
            return runProcess;

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
    }
}
