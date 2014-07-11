
namespace GestorDocument.Model.DashBoardModel
{
    public class DashBoardGraphModel:ModelBase
    {
        public MesModel Mes
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
        private MesModel _Mes;
        public const string MesPropertyName = "Mes";

        public AnioModel Anio
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
        private AnioModel _Anio;
        public const string AnioPropertyName = "Anio";

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
    }
}
