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
    /// Lógica de interacción para ReporteEficienciaView.xaml
    /// </summary>
    public partial class ReporteEficienciaView : MetroWindow
    {
        public ReporteEficienciaView()
        {
            InitializeComponent();
            GetViewModel();
        }

        private void GetViewModel()
        {
            this.DataContext = new ReporteEficienciaViewModel();
        }

        public ReporteEficienciaViewModel GetViewModelReport()
        {
            ReporteEficienciaViewModel view = this.DataContext as ReporteEficienciaViewModel;

            return view;
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                _reportViewer.Clear();
                _reportViewer.RefreshReport();
                _reportViewer.Refresh();                              
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                GestorDocument.DAL.Reportes.GestorDocumentDataSet dataset = new DAL.Reportes.GestorDocumentDataSet();
                reportDataSource.Name = "DataSet1";

                ReporteEficienciaViewModel viewModel = GetViewModelReport();

                if (viewModel != null)
                {
                    viewModel.FiltroCommand.Execute(null);

                    reportDataSource.Value = dataset.SP_ReporteEficiencia;
                    _reportViewer.LocalReport.DataSources.Clear();
                    this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
                    this._reportViewer.LocalReport.ReportPath = "Reportes\\Eficiencia.rdlc";
                    GestorDocument.DAL.Reportes.GestorDocumentDataSetTableAdapters.SP_ReporteEficienciaTableAdapter adapter = new DAL.Reportes.GestorDocumentDataSetTableAdapters.SP_ReporteEficienciaTableAdapter();
                    adapter.Fill(dataset.SP_ReporteEficiencia, viewModel.SelectedDest, viewModel.SelectedSign, viewModel.FechaInicio, viewModel.FechaFin);
                    _reportViewer.RefreshReport();
                }
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
    }
}
