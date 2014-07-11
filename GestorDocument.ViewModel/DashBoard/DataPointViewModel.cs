using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.ViewModel.DashBoard
{
    public class DataPointViewModel:ViewModelBase
    {
        public string Label
        {
            get { return _Label; }
            set
            {
                if (_Label != value)
                {
                    _Label = value;
                    OnPropertyChanged(LabelPropertyName);
                }
            }
        }
        private string _Label;
        public const string LabelPropertyName = "Label";

        public double Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    OnPropertyChanged(ValuePropertyName);
                }
            }
        }
        private double _Value;
        public const string ValuePropertyName = "Value";
    }
}
