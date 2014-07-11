using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.DashBoardModel
{
    public class MesModel:ModelBase
    {
        public int Mes
        {
            get { return _Mes; }
            set
            {
                if (_Mes != value)
                {
                    _Mes = value;
                    OnPropertyChanged(MesPropertyName);
                }
            }
        }
        private int _Mes;
        public const string MesPropertyName = "Mes";

        public string MesName
        {
            get { return _MesName; }
            set
            {
                if (_MesName != value)
                {
                    _MesName = value;
                    OnPropertyChanged(MesNamePropertyName);
                }
            }
        }
        private string _MesName;
        public const string MesNamePropertyName = "MesName";
    }
}
