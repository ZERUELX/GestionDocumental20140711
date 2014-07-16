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
    /// Lógica de interacción para TableroView.xaml
    /// </summary>
    public partial class TableroView : UserControl
    {
        TableroViewModel tvm = new TableroViewModel();
        public TableroView()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            tvm.Init(10);
            this.DataContext = tvm;
        }

        private void grdUrgentes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            #region Codigo Viejo
            //HistorialAsuntosDataGrid control=null;
            //if (StockSingleton.Instance.DictionaryControl.ContainsKey("HAU"))
            //    control = StockSingleton.Instance.DictionaryControl["HAU"] as HistorialAsuntosDataGrid;
            //else
            //{
            //    control = new HistorialAsuntosDataGrid();
            //    StockSingleton.Instance.DictionaryControl.Add("HAU", control);
            //}
            //StockSingleton.Instance.AddStack("HAU", control);
            //control = new HistorialAsuntosDataGrid("Asuntos pendientes");
            #endregion

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
            //else
            //{
            //    StockSingleton.Instance.AgregarAPila("AU");
            //    StockSingleton.Instance.SelectedItem = ha;
            //}

        }

        private void grdAtendidos_MouseUp(object sender, MouseButtonEventArgs e)
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

        private void grdPendientes_MouseUp(object sender, MouseButtonEventArgs e)
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

        private void grdTodos_MouseUp(object sender, MouseButtonEventArgs e)
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

        private void GridPrioritarios_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HistorialAsuntosDataGrid ha;
            //APR = Asuntos PRioritarios
            e.Handled = true;
            if (!StockSingleton.Instance.DictionaryControl.ContainsKey("APR"))
            {
                ha = new HistorialAsuntosDataGrid();
                ha.init("Asuntos Prioritarios");
                StockSingleton.Instance.DictionaryControl.Add("APR", ha);

            }
            StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["APR"];
        }

        private void GridOrdinarios_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HistorialAsuntosDataGrid ha;
            //AO = Asuntos Ordinarios
            e.Handled = true;
            if (!StockSingleton.Instance.DictionaryControl.ContainsKey("AO"))
            {
                ha = new HistorialAsuntosDataGrid();
                ha.init("Asuntos Ordinarios");
                StockSingleton.Instance.DictionaryControl.Add("AO", ha);

            }
            StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["AO"];
        }

        private void GridDetroFechaLimite_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HistorialAsuntosDataGrid ha;
            //AADF = Asuntos Atendidos Dentro Fecha
            e.Handled = true;

            if (!StockSingleton.Instance.DictionaryControl.ContainsKey("AADF"))
            {
                ha = new HistorialAsuntosDataGrid();
                ha.init("Asuntos Atendidos Dentro de Fecha");
                StockSingleton.Instance.DictionaryControl.Add("AADF", ha);

            }
            StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["AADF"];
        }

        private void GridFueraFechaLimite_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HistorialAsuntosDataGrid ha;

            //AAFF = Asuntos Atendidos Fuera Fecha
            e.Handled = true;
            if (!StockSingleton.Instance.DictionaryControl.ContainsKey("AAFF"))
            {
                ha = new HistorialAsuntosDataGrid();
                ha.init("Asuntos Atendidos Fuera de Fecha");
                StockSingleton.Instance.DictionaryControl.Add("AAFF", ha);

            }
            StockSingleton.Instance.SelectedItem = StockSingleton.Instance.DictionaryControl["AAFF"];
        }
    }
}
