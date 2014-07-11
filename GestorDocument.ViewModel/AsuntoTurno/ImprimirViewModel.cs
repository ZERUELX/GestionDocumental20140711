using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using System.Configuration;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;
using GestorDocument.DAL.Repository;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class ImprimirViewModel : ViewModelBase
    {
        private ISignatarioExterno _SignatarioExternoRepository;

        // DESTINATARIO CCP.
        private IDestinatarioCcp _DestinatarioCcpRepository;

        public AsuntoModel ImprimirAsunto
        {
            get { return _ImprimirAsunto; }
            set
            {
                if (_ImprimirAsunto != value)
                {
                    _ImprimirAsunto = value;
                    OnPropertyChanged(ImprimirAsuntoPropertyName);
                }
            }
        }
        private AsuntoModel _ImprimirAsunto;
        public const string ImprimirAsuntoPropertyName = "ImprimirAsunto";

        public string SuccessPathReporte
        {
            get { return _SuccessPathReporte; }
            set
            {
                if (_SuccessPathReporte != value)
                {
                    _SuccessPathReporte = value;
                    OnPropertyChanged(SuccessPathReportePropertyName);
                }
            }
        }
        private string _SuccessPathReporte;
        public const string SuccessPathReportePropertyName = "SuccessPathReporte";

        public ImprimirViewModel(AsuntoModel imprimirAsunto)
        {
            this.ImprimirAsunto = imprimirAsunto;

            this.LoadInfo();

            this.GetSplitDirectory();
        }

        public void LoadInfo()
        {
            this._SignatarioExternoRepository = new SignatarioExternoRepository();
            this._DestinatarioCcpRepository = new DestinatarioCcpRepository();

            //signaratios externos
            if (this.ImprimirAsunto.SignatarioExterno == null)
                this.ImprimirAsunto.SignatarioExterno = this._SignatarioExternoRepository.GetSignatariosExterno(this.ImprimirAsunto.IdAsunto) as ObservableCollection<SignatarioExternoModel>;
            else
            {
                try
                {
                    int sig = this.ImprimirAsunto.SignatarioExterno.Count();
                    if (sig == 0)
                        this.ImprimirAsunto.SignatarioExterno = this._SignatarioExternoRepository.GetSignatariosExterno(this.ImprimirAsunto.IdAsunto) as ObservableCollection<SignatarioExternoModel>;
                }
                catch (Exception)
                {
                    this.ImprimirAsunto.SignatarioExterno = this._SignatarioExternoRepository.GetSignatariosExterno(this.ImprimirAsunto.IdAsunto) as ObservableCollection<SignatarioExternoModel>;
                }
            }

            //destinatarios externo
            if (this.ImprimirAsunto.DestinatarioCcp == null)
                this.ImprimirAsunto.DestinatarioCcp = this._DestinatarioCcpRepository.GetDestinatariosCcp(this.ImprimirAsunto.IdAsunto) as ObservableCollection<DestinatarioCcpModel>;
            else
            {
                try
                {
                    int des = this.ImprimirAsunto.DestinatarioCcp.Count();
                    if (des ==0)
                        this.ImprimirAsunto.DestinatarioCcp = this._DestinatarioCcpRepository.GetDestinatariosCcp(this.ImprimirAsunto.IdAsunto) as ObservableCollection<DestinatarioCcpModel>;
                }
                catch (Exception)
                {
                    this.ImprimirAsunto.DestinatarioCcp = this._DestinatarioCcpRepository.GetDestinatariosCcp(this.ImprimirAsunto.IdAsunto) as ObservableCollection<DestinatarioCcpModel>;
                }
            }

        }

        public void GetSplitDirectory()
        {

            string nameFolder = ConfigurationManager.AppSettings["LocalReporteApp"].ToString();

            string appDirectory = System.IO.Directory.GetCurrentDirectory();
            string[] directory = System.IO.Directory.GetFileSystemEntries(appDirectory);

            foreach (string ruta in directory)
            {
                string[] _DocumentoPath = ruta.Split('\\');
                if (nameFolder == _DocumentoPath.Last())
                {
                    this.SuccessPathReporte = ruta + "\\Caratula.rdlc";
                    break;
                }
            }
        }
    }
}
