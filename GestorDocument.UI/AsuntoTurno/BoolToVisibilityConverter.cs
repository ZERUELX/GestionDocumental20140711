using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GestorDocument.UI.AsuntoTurno
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object res = System.Windows.Visibility.Visible;

            if ((value as bool?) != null)
            {
                res = (bool)value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
