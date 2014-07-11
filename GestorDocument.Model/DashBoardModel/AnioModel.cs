using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.DashBoardModel
{
    public class AnioModel:ModelBase
    {
        public int Anio
        {
            get { return _Anio; }
            set
            {
                if (_Anio != value)
                {
                    _Anio = value;
                    OnPropertyChanged(AnioPropertyName);
                }
            }
        }
        private int _Anio;
        public const string AnioPropertyName = "Anio";
    }
}
