using System;
using System.Diagnostics;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace AppStudio.Controls
{
    public class GridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            GridLength gridLength = GridLength.Auto;

            double length = 200;
            double.TryParse(parameter as string, out length);
            if (value is bool)
            {
                gridLength = new GridLength((bool)value ? length : 0);
            }

            return gridLength;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
