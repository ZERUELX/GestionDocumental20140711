using GestorDocument.Model.IRepository;
using GestorDocument.Model;
using System.Collections.ObjectModel;
using GestorDocument.Model.DashBoardModel;
using System.Text;
using System.Collections.Generic;
using GestorDocument.DAL.Repository;
using System.Linq;

namespace GestorDocument.ViewModel.DashBoard
{
    public class GraphSeriesViewModel:ViewModelBase
    {
               
        #region Propiedades.
        public string SerieName
        {
            get { return _SerieName; }
            set
            {
                if (_SerieName != value)
                {
                    _SerieName = value;
                    OnPropertyChanged(SerieNamePropertyName);
                }
            }
        }
        private string _SerieName;
        public const string SerieNamePropertyName = "SerieName";

        public ObservableCollection<DataPointViewModel> SerieValues
        {
            get { return _SerieValues; }
            set
            {
                if (_SerieValues != value)
                {
                    _SerieValues = value;
                    OnPropertyChanged(SerieValuesPropertyName);
                }
            }
        }
        private ObservableCollection<DataPointViewModel> _SerieValues;
        public const string SerieValuesPropertyName = "SerieValues"; 
        #endregion

        #region Constructor.
        public GraphSeriesViewModel()
        {            
            SerieValues = new ObservableCollection<DataPointViewModel>();
        }
        
        #endregion

        
    }
}
