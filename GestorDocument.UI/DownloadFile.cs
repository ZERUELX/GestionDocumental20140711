using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.ViewModel;
using GestorDocument.UI.DlgModal;
using System.Windows;
using System.Net;

namespace GestorDocument.UI
{
    public class DownloadFile : IDownloadFile
    {
        public ViewModel.AsuntoTurno.TrancingAsuntoViewModel vm;
        public ViewModel.AsuntoTurno.TrancingAsuntoTurnoViewModel vm2;
        public ViewModel.AsuntoTurno.TrancingAsuntoTurnoReadViewModel vm3;

        public void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (vm !=null)
            {
                //vm.OpenDoc();
                vm.SetOpenDoc();
                vm.start();    
            }
            if (vm2 !=null)
            {
                //vm2.OpenDoc();
                vm2.SetOpenDoc();
                vm2.start();    
            }

            if (vm3 != null)
            {
                //vm3.OpenDoc();
                vm3.SetOpenDoc();
                vm3.start();
            }

            
        }

        public void Show(ViewModel.AsuntoTurno.TrancingAsuntoViewModel viewModel)
        {
            if (viewModel != null)
            {
                this.vm = viewModel;
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    DlgDownloadFile dlg = new DlgDownloadFile();

                    WebClient we = new WebClient();
                    we.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadFileCompleted);
                    viewModel.DescargandoDocumento();
                    dlg.DataContext = viewModel;

                    if (viewModel.Descarga != null)
                    {
                        we.DownloadFileAsync(viewModel.Descarga, viewModel.SuccessPath + viewModel.SelectedExpedienteDocumento.Documento.IdDocumento + "." + viewModel.SelectedExpedienteDocumento.Documento.Extencion);

                        dlg.Owner = Application.Current.Windows[0];
                        dlg.ShowDialog();
                    }
                    else
                    {
                        viewModel._Download.Msg = "No se encuentra el documento el servidor";
                        viewModel._Download.ShowOk();
                        viewModel.CierraDlg();
                    }
                }));   
            }
        }

        public void Show(ViewModel.AsuntoTurno.TrancingAsuntoTurnoViewModel viewModel)
        {
            if (viewModel != null)
            {
                this.vm2 = viewModel;
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    DlgDownloadFile dlg = new DlgDownloadFile();

                    WebClient we = new WebClient();
                    we.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadFileCompleted);
                    viewModel.DescargaDocumento();

                    dlg.DataContext = viewModel;

                    if (viewModel.Descarga != null)
                    {
                        we.DownloadFileAsync(viewModel.Descarga, viewModel.SuccessPath + viewModel.SelectedExpedienteDocumento.Documento.IdDocumento + "." + viewModel.SelectedExpedienteDocumento.Documento.Extencion);

                        dlg.Owner = Application.Current.Windows[0];
                        dlg.ShowDialog();
                    }
                    else
                    {
                        viewModel._Download.Msg = "No se encuentra el documento el servidor";
                        viewModel._Download.ShowOk();
                        viewModel.CierraDlg();
                    }
                }));
            }
        }

        public void Show(ViewModel.AsuntoTurno.TrancingAsuntoTurnoReadViewModel viewModel)
        {
            if (viewModel != null)
            {
                this.vm3 = viewModel;
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    DlgDownloadFile dlg = new DlgDownloadFile();

                    WebClient we = new WebClient();
                    we.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadFileCompleted);
                    viewModel.DescargaDocumento();

                    dlg.DataContext = viewModel;
                    if (viewModel.Descarga != null)
                    {
                        we.DownloadFileAsync(viewModel.Descarga, viewModel.SuccessPath + viewModel.SelectedExpedienteDocumento.Documento.IdDocumento + "." + viewModel.SelectedExpedienteDocumento.Documento.Extencion);

                        dlg.Owner = Application.Current.Windows[0];
                        dlg.ShowDialog();
                    }
                    else
                    {
                        viewModel._Download.Msg = "No se encuentra el documento el servidor";
                        viewModel._Download.ShowOk();
                        viewModel.CierraDlg();
                    }
                }));
            }
        }

        public string Msg
        {
            get
            {
                return _Msg;
            }
            set
            {
                _Msg = value;
            }
        }
        private string _Msg;

        public bool Response
        {
            get
            {
                return _Response;
            }
            set
            {
                _Response = value;
            }
        }
        private bool _Response;

        public void ShowOk()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(Msg, "Mensaje de sistema", MessageBoxButton.OK, MessageBoxImage.Warning);
                }));
        }
    }
}
