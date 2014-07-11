using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace GestorDocument.UI.DashBoard.MultiChartControl
{
    public class SeriesTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Eficiencia { get; set; }
        public DataTemplate Productividad { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            //if (item is GraphSeries)
            //{
            //   GraphSeries GraphSerie = item as GraphSeries;

            //    if (GraphSerie.Nombre == "Productividad")
            //    {
            //        return Productividad;
            //    }
            //    else
            //    {
            //        return Eficiencia;
            //    }
            //}
            
            return null;

        }
    }
}
