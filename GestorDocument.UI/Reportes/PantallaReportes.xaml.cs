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

namespace GestorDocument.UI.Reportes
{
    /// <summary>
    /// Lógica de interacción para PantallaReportes.xaml
    /// </summary>
    public partial class PantallaReportes : UserControl
    {
        public PantallaReportes()
        {
            InitializeComponent();
        }
        private void btnRepor1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Reportes reporte = new Reportes();
            reporte.ShowDialog();
        }

        private void btnRepor2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ReporteEficienciaView report = new ReporteEficienciaView();
            report.ShowDialog();
        }
    }
}
