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
using GestorDocument.ViewModel.AsuntoTurno;
using GestorDocument.Model;
using Microsoft.Reporting.WinForms;
using System.Collections.ObjectModel;
using System.Configuration;
using MahApps.Metro.Controls;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para ImprimirView.xaml
    /// </summary>
    public partial class ImprimirView : MetroWindow
    {
        public List<ReportParameter> Parametros ;
        public ImprimirView()
        {
            InitializeComponent();
        }

        private ImprimirViewModel GetViewModel()
        {
            return this.DataContext as ImprimirViewModel;
        }

        public void GetImprimir(AsuntoModel imprimirAsunto)
        {
            try
            {
                this.DataContext = new ImprimirViewModel(imprimirAsunto);
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();

                ImprimirViewModel viewModel = this.GetViewModel();

                if (viewModel!=null)
		            this.rvCaratula.LocalReport.ReportPath = viewModel.SuccessPathReporte;
                
                this.GetParametros();

                this.rvCaratula.LocalReport.SetParameters(Parametros);
                this.rvCaratula.RefreshReport();
               
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Envia como parametros la informacion de la caratula al reporte.
        /// </summary>
        public void GetParametros()
        {
            this.Parametros = new List<ReportParameter>();

            ImprimirViewModel viewModel = GetViewModel();
            try
            {
                if (viewModel != null)
                {
                    this.Parametros.Add(new ReportParameter("Folio", viewModel.ImprimirAsunto.Folio));
                    this.Parametros.Add(new ReportParameter("FechaRecibido", string.Format("{0:dd/MM/yyyy}", viewModel.ImprimirAsunto.FechaRecibido)));
                    this.Parametros.Add(new ReportParameter("TipoDocumento", viewModel.ImprimirAsunto.Turno.Documento.First().TipoDocumento.TipoDocumentoName));
                    this.Parametros.Add(new ReportParameter("DeterminanteName", viewModel.ImprimirAsunto.Signatario.First().Determinante.DeterminanteName));
                    this.Parametros.Add(new ReportParameter("DeterminanteClave", viewModel.ImprimirAsunto.Signatario.First().Determinante.PrefijoFolio));
                    this.Parametros.Add(new ReportParameter("Ndoc", viewModel.ImprimirAsunto.ReferenciaDocumento));
                    this.Parametros.Add(new ReportParameter("FechaDoc", string.Format("{0:dd/MM/yyyy}", viewModel.ImprimirAsunto.FechaDocumento)));
                    this.Parametros.Add(new ReportParameter("Titulo", viewModel.ImprimirAsunto.Titulo));
                    this.Parametros.Add(new ReportParameter("Descripcion", viewModel.ImprimirAsunto.Descripcion));
                    this.Parametros.Add(new ReportParameter("Instruccion", viewModel.ImprimirAsunto.Instruccion.InstruccionName));
                    this.Parametros.Add(new ReportParameter("Prioridad", viewModel.ImprimirAsunto.Prioridad.PrioridadName));
                    this.Parametros.Add(new ReportParameter("FechaLimite", string.Format("{0:dd/MM/yyyy}", viewModel.ImprimirAsunto.FechaVencimiento)));
                    this.Parametros.Add(new ReportParameter("FechaTurnado", string.Format("{0:dd/MM/yyyy}", viewModel.ImprimirAsunto.Turno.FechaEnvio)));
                    this.Parametros.Add(new ReportParameter("Anexos", viewModel.ImprimirAsunto.Anexos));

                    this.GetDestinatariosInternoExterno(viewModel);
                    this.GetCcp(viewModel);
                }

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los Destinatarios marcados como CCP. que se mostraran en la caratula.
        /// </summary>
        /// <param name="viewModel"></param>
        private void GetCcp(ImprimirViewModel viewModel)
        {
            int cont;
            int i;
            string[] ccp = new string[3];

            cont = 0;
            foreach (DestinatarioCcpModel d in viewModel.ImprimirAsunto.DestinatarioCcp)
            {
                ccp[cont] = d.Rol.Organigrama.JerarquiaName; 
                cont = cont + 1;
                if (3 == cont)
                    break;
            }

            i = 0;

            foreach (string v in ccp)
            {
                if (string.IsNullOrEmpty(v))
                    ccp[i] = " ";
                i++;

            }

            this.Parametros.Add(new ReportParameter("Ccp", ccp));
        }

        /// <summary>
        /// Obtiene los 3 primeros Destinatarios que se mostraran en la caratula.
        /// </summary>
        /// <param name="viewModel"></param>
        private void GetDestinatariosInternoExterno(ImprimirViewModel viewModel)
        {
            int cont;
            int i;

            string[] destinatarios = new string[3];
            cont = 0;

            if (viewModel.ImprimirAsunto.Turno.Destinatario.Count() != 0)
            {
                foreach (DestinatarioModel d in viewModel.ImprimirAsunto.Turno.Destinatario)
                {
                    destinatarios[cont] = d.Rol.Organigrama.JerarquiaName + " - " + d.Rol.Organigrama.JerarquiaTitular;
                    cont = cont + 1;
                    if (3 == cont)
                        break;
                }
            }
            else
            {
                foreach (var d in viewModel.ImprimirAsunto.SignatarioExterno)
                {
                    destinatarios[cont] = d.Determinante.Area + " - " + d.Determinante.DeterminanteName;
                    cont = cont + 1;
                    if (3 == cont)
                        break;
                }
            }


            i = 0;

            foreach (string v in destinatarios)
            {
                if (string.IsNullOrEmpty(v))
                    destinatarios[i] = " ";

                i++;
            }

            this.Parametros.Add(new ReportParameter("Turnados", destinatarios));
        }

    }
}
