using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.DashBoardModel
{
    public class PendienteIndicadorModel:ModelBase
    {
        public int Vencidos
        {
            get { return _Vencidos; }
            set
            {
                if (_Vencidos != value)
                {
                    _Vencidos = value;
                    OnPropertyChanged(VencidosPropertyName);
                }
            }
        }
        private int _Vencidos;
        public const string VencidosPropertyName = "Vencidos";

        public int PorVencer
        {
            get { return _PorVencer; }
            set
            {
                if (_PorVencer != value)
                {
                    _PorVencer = value;
                    OnPropertyChanged(PorVencerPropertyName);
                }
            }
        }
        private int _PorVencer;
        public const string PorVencerPropertyName = "PorVencer";
    }
}
