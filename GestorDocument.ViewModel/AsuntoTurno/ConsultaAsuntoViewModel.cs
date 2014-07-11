using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class ConsultaAsuntoViewModel  : ViewModelBase
    {
        public AsuntoModel ReadAsunto
        {
            get { return _ReadAsunto; }
            set
            {
                if (_ReadAsunto != value)
                {
                    _ReadAsunto = value;
                    OnPropertyChanged(ReadAsuntoPropertyName);
                }
            }
        }
        private AsuntoModel _ReadAsunto;
        public const string ReadAsuntoPropertyName = "ReadAsunto";

        public bool IsVisibleDestinatarioExterno
        {
            get { return _IsVisibleDestinatarioExterno; }
            set
            {
                _IsVisibleDestinatarioExterno = value;
                OnPropertyChanged(IsVisibleDestinatarioExternoPropertyName);
            }
        }
        private bool _IsVisibleDestinatarioExterno;
        public const string IsVisibleDestinatarioExternoPropertyName = "IsVisibleDestinatarioExterno";

        public bool IsVisibleDestinatarioInterno
        {
            get { return _IsVisibleDestinatarioInterno; }
            set
            {
                _IsVisibleDestinatarioInterno = value;
                OnPropertyChanged(IsVisibleDestinatarioInternoPropertyName);
            }
        }
        private bool _IsVisibleDestinatarioInterno;
        public const string IsVisibleDestinatarioInternoPropertyName = "IsVisibleDestinatarioInterno";

        #region CONTRUCTOR
        public ConsultaAsuntoViewModel(AsuntoModel asuntoTurno)
        {
            this.ReadAsunto = asuntoTurno;

            this.GetVisible();
        }

        public void GetVisible()
        {
            if (this.ReadAsunto.Turno.Destinatario.Count() != 0)
            {
                this.IsVisibleDestinatarioInterno = true;
                this.IsVisibleDestinatarioExterno = false;
            }
            else
            {
                this.IsVisibleDestinatarioExterno = true;
                this.IsVisibleDestinatarioInterno = false;
            }
        }
        #endregion
    }
}
