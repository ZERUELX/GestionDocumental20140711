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
            Init();            
        }

        public void Init()
        {
            //TableroView control = null;
            //if (StockSingleton.Instance.DictionaryControl.ContainsKey("TV"))
            //    control = StockSingleton.Instance.DictionaryControl["TV"] as TableroView;
            //else
            //{
            //    control = new TableroView();
            //    StockSingleton.Instance.DictionaryControl.Add("TV", control);
            //}
            //StockSingleton.Instance.AddStack("TV", control);
           // this.ctnPrincipal.Content = control;

         
            TableroView control = new TableroView();
            control.Init();
            StockSingleton.Instance.SelectedItem = control;

            StockSingleton.Instance.AgregarAPila("CUADRANTE");
            StockSingleton.Instance.DictionaryControl.Add("CUADRANTE", control);
           
            //HistorialAsuntosDataGrid dt = new HistorialAsuntosDataGrid();
            this.ctnPrincipal.DataContext = StockSingleton.Instance;
           // this.ctnPrincipal.Content = dt;
        }
    }
}
