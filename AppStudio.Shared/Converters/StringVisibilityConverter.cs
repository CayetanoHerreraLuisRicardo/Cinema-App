using AppStudio;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace AppStudio.Controls
{
    public class StringVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = Visibility.Visible;
            try
            {
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    visibility = Visibility.Collapsed;
                }
                if (parameter != null)
                {
                    bool InvertResult;
                    bool.TryParse(parameter.ToString(), out InvertResult);
                    if (InvertResult == true)
                    {
                        if (visibility == Visibility.Visible)
                        {
                            visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            visibility = Visibility.Visible;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("Visibility.Convert", ex);
            }
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
