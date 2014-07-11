using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.DashBoardModel
{
    public class DashBoardTableModel:ModelBase
    {
        public OrganigramaModel Organigrama
        {
            get { return _Organigrama; }
            set
            {
                if (_Organigrama != value)
                {
                    _Organigrama = value;
                    OnPropertyChanged(OrganigramaPropertyName);
                }
            }
        }
        private OrganigramaModel _Organigrama;
        public const string OrganigramaPropertyName = "Organigrama";

        public double Productividad
        {
            get { return _Productividad; }
            set
            {
                if (_Productividad != value)
                {
                    _Productividad = value;
                    OnPropertyChanged(ProductividadPropertyName);
                }
            }
        }
        private double _Productividad;
        public const string ProductividadPropertyName = "Productividad";

        public double Eficiencia
        {
            get { return _Eficiencia; }
            set
            {
                if (_Eficiencia != value)
                {
                    _Eficiencia = value;
                    OnPropertyChanged(EficienciaPropertyName);
                }
            }
        }
        private double _Eficiencia;
        public const string EficienciaPropertyName = "Eficiencia";

        public string SemaforoImgPath
        {
            get { return _SemaforoImgPath; }
            set
            {
                if (_SemaforoImgPath != value)
                {
                    _SemaforoImgPath = value;
                    OnPropertyChanged(SemaforoImgPathPropertyName);
                }
            }
        }
        private string _SemaforoImgPath;
        public const string SemaforoImgPathPropertyName = "SemaforoImgPath";
    }
}
