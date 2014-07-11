using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GestorDocument.Model.DashBoardModel;
using GestorDocument.Model;
using GestorDocument.Model.IRepository;
using GestorDocument.DAL.Repository;


namespace GestorDocument.ViewModel.DashBoard
{
    public class DashBoardGraphViewModel : ViewModelBase
    {
        #region Instancias.

        public GraphSeriesViewModel oGraphSeriesViewModel;
        public IDashBoard oDashBoardRepository;
        #endregion

        public ObservableCollection<GraphSeriesViewModel> Datos
        {
            get { return _Datos; }
            set
            {
                if (_Datos != value)
                {
                    _Datos = value;
                    OnPropertyChanged(DatosPropertyName);
                }
            }
        }
        private ObservableCollection<GraphSeriesViewModel> _Datos;
        public const string DatosPropertyName = "Datos";

        public ObservableCollection<DataPointViewModel> DataPoints
        {
            get { return _DataPoints; }
            set
            {
                if (_DataPoints != value)
                {
                    _DataPoints = value;
                    OnPropertyChanged(DataPointsPropertyName);
                }
            }
        }
        private ObservableCollection<DataPointViewModel> _DataPoints;
        public const string DataPointsPropertyName = "DataPoints";

        public DashBoardGraphViewModel(string Prioridad, AnioModel Anio, MesModel Mes, ObservableCollection<DeterminanteModel> Determinantes, DashBoardTableViewModel TableViewModel)//string Prioridad, AnioModel Anio, MesModel Mes, ObservableCollection<DeterminanteModel> Determinantes, DashBoardTableViewModel TableViewModel
        {
            Datos = new ObservableCollection<GraphSeriesViewModel>();
            oGraphSeriesViewModel = new GraphSeriesViewModel();
            this.oDashBoardRepository = new DashBoardRepository();
            DataPoints = new ObservableCollection<DataPointViewModel>();
            LoadGraphData(Prioridad, Anio, Mes, Determinantes, TableViewModel);
        }

        public DashBoardGraphViewModel()
        {
            Datos = new ObservableCollection<GraphSeriesViewModel>();
            oGraphSeriesViewModel = new GraphSeriesViewModel();
            this.oDashBoardRepository = new DashBoardRepository();
            DataPoints = new ObservableCollection<DataPointViewModel>();
        }


        public void LoadGraphData(string Prioridad, AnioModel Anio, MesModel Mes, ObservableCollection<DeterminanteModel> Determinantes, DashBoardTableViewModel TableViewModel)
        {
            ObservableCollection<GraphSeriesViewModel> _Datos = new ObservableCollection<GraphSeriesViewModel>();
            string direcciones = "";
            try
            {
                if (TableViewModel.SelectedItem.Organigrama.JerarquiaName == "OCAVM")
                {
                    //TODO: Generar CSV 
                    foreach (var item in TableViewModel.DashBoardTableDetalle)
                    {
                        direcciones += item.Organigrama.IdJerarquia.ToString() + ",";
                    }

                    direcciones = (direcciones.Length > 0) ? direcciones.Remove(direcciones.Length - 1) : direcciones;
                }
                else
                {
                    direcciones = TableViewModel.SelectedItem.Organigrama.IdJerarquia.ToString();
                }
            }
            catch (Exception)
            {
                direcciones = "1,10,12,13,15,16,17,18,19,101,102,110,111,112,121,122,123,141,171,172,173,174,175,176,177,181,182,183,184,185,186,187,188,189,191,192,193,194,195,196,1101,1102,1103,1104,1105,1106,1110,1111,1112,1121,1122,1123,1124,1201,1301,1302,1501,1502,1601,1810,1811,1812,1813,1814,1815,1902,11010,11011,11012,11201,11202,12001,12021,14101,15001,15002,17001,18001,19001,110001";
            }

            DataPoints = new ObservableCollection<DataPointViewModel>();
            foreach (var item in oDashBoardRepository.GetGraphData(Anio, Mes, Determinantes, Prioridad, direcciones))
            {
                DataPoints.Add(new DataPointViewModel()
                {
                    Label = item.Mes.MesName,
                    Value = item.Eficiencia
                });
            }

            _Datos.Add(new GraphSeriesViewModel()
            {
                SerieName = "Eficiencia",
                SerieValues = DataPoints

            });


            DataPoints = new ObservableCollection<DataPointViewModel>();
            foreach (var item in oDashBoardRepository.GetGraphData(Anio, Mes, Determinantes, Prioridad, direcciones))
            {
                DataPoints.Add(new DataPointViewModel()
                {
                    Label = item.Mes.MesName,
                    Value = item.Productividad
                });
            }

            _Datos.Add(new GraphSeriesViewModel()
            {
                SerieName = "Productividad",
                SerieValues = DataPoints

            });

            this.Datos = _Datos;
        }
    }
}


