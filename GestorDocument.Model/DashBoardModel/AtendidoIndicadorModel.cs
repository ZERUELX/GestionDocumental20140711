using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.DashBoardModel
{
    public class AtendidoIndicadorModel:ModelBase
    {
        public int Dentro
        {
            get { return _Dentro; }
            set
            {
                if (_Dentro != value)
                {
                    _Dentro = value;
                    OnPropertyChanged(DentroPropertyName);
                }
            }
        }
        private int _Dentro;
        public const string DentroPropertyName = "Dentro";

        public int Fuera
        {
            get { return _Fuera; }
            set
            {
                if (_Fuera != value)
                {
                    _Fuera = value;
                    OnPropertyChanged(FueraPropertyName);
                }
            }
        }
        private int _Fuera;
        public const string FueraPropertyName = "Fuera";
    }
}
