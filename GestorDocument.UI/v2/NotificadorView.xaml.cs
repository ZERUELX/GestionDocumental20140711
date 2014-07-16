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
using GestorDocument.ViewModel.v2;
using GestorDocument.UI.v2.Stock;

namespace GestorDocument.UI.v2
{
    /// <summary>
    /// Lógica de interacción para NotificadorView.xaml
    /// </summary>
    public partial class NotificadorView : UserControl
    {
        TableroViewModel tvm = new TableroViewModel();
        public NotificadorView()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            tvm.Init(10);
            this.DataContext = tvm;
        }

        private void txtUrgentes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HistorialAsuntosDataGrid ha;
            e.Handled = true;
            ////AU = Asuntos Urgentes
            if (!StockSingleton.Instance.DictionaryControl.ContainsKey("AU"))
            {
                ha = new HistorialAsuntosDataGrid();
                ha.init("Asuntos Urgentes");
                StockSingleton.Instance.DictionaryControl.Add("AU", ha);
            }
            StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["AU"];

            //e.Handled = true;
            ////AU = Asuntos Urgentes
            //if (!StockSingleton.Instance.DictionaryControl.ContainsKey("AU"))
            //{
            //    StockSingleton.Instance.DictionaryControl.Add("AU", ha);
            //    StockSingleton.Instance.AgregarAPila("AU");
            //    StockSingleton.Instance.SelectedItem = ha;
            //}
            //else
            //{
            //    StockSingleton.Instance.AgregarAPila("AU");
            //    StockSingleton.Instance.SelectedItem = ha;
            //}

        }

        private void TodosAsuntos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HistorialAsuntosDataGrid ha;
            //TA = Todos Asuntos
            if (!StockSingleton.Instance.DictionaryControl.ContainsKey("TA"))
            {
                ha = new HistorialAsuntosDataGrid();
                ha.init("Todos los Asuntos");
                StockSingleton.Instance.DictionaryControl.Add("TA", ha);
            }
            StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["TA"];
        }

        private void txtAsuntosAtendidos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HistorialAsuntosDataGrid ha;
            e.Handled = true;
            ////AU = Asuntos Urgentes
            if (!StockSingleton.Instance.DictionaryControl.ContainsKey("AA"))
            {
                ha = new HistorialAsuntosDataGrid();
                ha.init("Asuntos Atendidos");
                StockSingleton.Instance.DictionaryControl.Add("AA", ha);
            }
            StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["AA"];
        }

        private void txtAsuntosPendientes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HistorialAsuntosDataGrid ha;
            //AP = Asuntos Pendientes
            e.Handled = true;
            if (!StockSingleton.Instance.DictionaryControl.ContainsKey("AP"))
            {
                ha = new HistorialAsuntosDataGrid();
                ha.init("Asuntos Pendientes");
                StockSingleton.Instance.DictionaryControl.Add("AP", ha);
            }

            StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["AP"];
        }


    }
}
