using System.Windows.Controls;
using Visifire.Charts;
using System;
using GestorDocument.ViewModel.DashBoard;
using System.Collections.ObjectModel;
using System.Windows;

namespace GestorDocument.UI.DashBoard
{
    /// <summary>
    /// Lógica de interacción para DashBoardGraphView.xaml
    /// </summary>
    public partial class DashBoardGraphView : UserControl
    {

        private LoadGraphClass c;
        private DashBoardGraphViewModel DashBoardGraph;
        private AnioMesViewModel AnioMesView;
        private DashBoardTableViewModel DashBoradTable;
     
        public DashBoardGraphView()
        {
            InitializeComponent();            
        }

     
        public void init(DashBoardGraphViewModel vm,AnioMesViewModel AnioMes,DashBoardTableViewModel table)
        {
            DashBoardGraph = vm;
            AnioMesView = AnioMes;
            DashBoradTable=table;
            c = new LoadGraphClass();
            DashBoardGraph.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DashBoardGraph_PropertyChanged);
            lblAnio.Content = AnioMesView.SelectedAnio.Anio;
            lblMes.Content = AnioMesView.SelectedMes.MesName;
            try
            {
                lblDireccion.Text =DashBoradTable.SelectedItem.Organigrama.JerarquiaName;
            }
            catch (Exception)
            {
                lblDireccion.Text = "OCAVM";
            }
            
        }

        private void DashBoardGraph_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Datos")
            {
                this.Refresh(sender);
            }
        }

        public void Refresh(object sender)
        {
            Layout.Children.Clear();
            MultiChartControl.MultiChart MyChart = new MultiChartControl.MultiChart();
            DashBoardGraphViewModel vm = (DashBoardGraphViewModel)sender;
            MyChart.Series.Clear();

            for (int i = 0; i < vm.Datos.Count; i++)
            {
                MyChart.Series.Add(c.GetSerie(DashBoardGraph)[i]);
            }
            MyChart.Style = (Style)FindResource("ChartStyle");
            Axis a = new Axis();
            a.ValueFormatString = "0%";
            MyChart.AxesY.Add(a);
            Layout.Children.Add(MyChart);
            lblAnio.Content = AnioMesView.SelectedAnio.Anio;
            lblMes.Content = AnioMesView.SelectedMes.MesName;
            try
            {
                lblDireccion.Text = DashBoradTable.SelectedItem.Organigrama.JerarquiaName;
            }
            catch (Exception)
            {
                lblDireccion.Text = "OCAVM";
            }
        }
        
    }    
    public class LoadGraphClass:GestorDocument.ViewModelBase
    {        

        

        #region Constructor.
        public LoadGraphClass()
        {                                 
        }

        #endregion

        #region Metodos.                
        public ObservableCollection<DataSeries> GetSerie(DashBoardGraphViewModel dash)
        {
            ObservableCollection<DataSeries> DatosSeries = new ObservableCollection<DataSeries>();            
            try
            {
                DataSeries Series = new DataSeries();            
                foreach (var item in dash.Datos)
                {
                    Series = new DataSeries();
                    Series.Name = item.SerieName;
                    Series.RenderAs = RenderAs.Line;
                    foreach (var i in item.SerieValues)
                    {
                        DataPoint p = new DataPoint();
                        p.YValue = i.Value;                        
                        p.AxisXLabel = i.Label;                        
                        Series.DataPoints.Add(p);                                                                        
                    }
                    DatosSeries.Add(Series);
                }
            }
            catch (Exception)
            {

            }
            return DatosSeries;
        }
        
        #endregion
    }
}


 