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
using GestorDocument.UI.v2.Stock;
using GestorDocument.ViewModel.Login;

namespace GestorDocument.UI.v2
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            //Init();            
        }
        
        public void Init(UserLoginViewModel user)
        {
            TableroView control;
            if (!StockSingleton.Instance.DictionaryControl.ContainsKey("CUADRANTE"))
            {
                control = new TableroView();                
                StockSingleton.Instance.DictionaryControl.Add("CUADRANTE", control);                       
            }
            else
            {
                control = StockSingleton.Instance.DictionaryControl["CUADRANTE"] as TableroView;
            }            
            StockSingleton.Instance.SelectedItem = control;

            if (!StockSingleton.Instance.StackControls.Contains("CUADRANTE"))
            {
                StockSingleton.Instance.AgregarAPila("CUADRANTE");            
            }            
            this.ctnPrincipal.DataContext = StockSingleton.Instance;

            control.Init(user);
            ucNotificador.Init(user);
            ucMenu.Init(user);
            ucUsuarioInfo.Init(user);
        }
    }
}
