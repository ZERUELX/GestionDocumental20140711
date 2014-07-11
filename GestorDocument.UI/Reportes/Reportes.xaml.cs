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
using GestorDocument.ViewModel;
using MahApps.Metro.Controls;



namespace GestorDocument.UI.Reportes
{
    /// <summary>
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class Reportes : MetroWindow
    {
        
        public Reportes()
        {
            InitializeComponent();
            GetViewModel();            
        }

        

        private void GetViewModel()
        {
            this.DataContext = new ReportesViewModel();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string inicio = "";
                string fin = "";
                if (dpInicio.SelectedDate != null & dpFin.SelectedDate != null)
                {
                    inicio = String.Format("{0:MM/dd/yyyy}", dpInicio.SelectedDate.Value);
                    fin = String.Format("{0:MM/dd/yyyy}", dpFin.SelectedDate.Value);
                    //inicio = dpInicio.SelectedDate.Value.Date;
                    //fin = dpFin.SelectedDate.Value.Date;
                }
                _reportViewer.Clear();                                
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                GestorDocument.DAL.Reportes.GestorDocumentDataSet dataset = new DAL.Reportes.GestorDocumentDataSet();
                reportDataSource.Name = "DataSet1";                                
                reportDataSource.Value = dataset.SP_ReporteDetalle;
                _reportViewer.LocalReport.DataSources.Clear();
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
                this._reportViewer.LocalReport.ReportPath = "Reportes\\ReportDetalle.rdlc";
                GestorDocument.DAL.Reportes.GestorDocumentDataSetTableAdapters.SP_ReporteDetalleTableAdapter adapter = new DAL.Reportes.GestorDocumentDataSetTableAdapters.SP_ReporteDetalleTableAdapter();
                adapter.Fill(dataset.SP_ReporteDetalle, txbSignatario.Text, txbDestinatario.Text, txbTurnos.Text, txbPrioridad.Text, dpInicio.SelectedDate.Value, dpFin.SelectedDate.Value);
                _reportViewer.RefreshReport();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxDestinatario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxDestinatario.SelectedItem = null;            
        }

        private void cbxSignatario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxSignatario.SelectedItem = null;
        }

        private void cbxTurnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxTurnos.SelectedItem = null;
        }

        private void cbxPrioridad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxPrioridad.SelectedItem = null;
        }

    }
}
