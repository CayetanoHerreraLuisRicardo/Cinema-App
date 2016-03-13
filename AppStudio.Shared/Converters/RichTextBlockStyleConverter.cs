using System;
using AppStudio.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace AppStudio.Controls
{
    public class RichTextBlockStyleConverter : IValueConverter
    {
        public Style LargeStyle { get; set; }
        public Style NormalStyle { get; set; }
        public Style SmallStyle { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is FontSizes)
            {
                switch ((FontSizes)value)
                {
                    case FontSizes.Big:
                        return LargeStyle;
                    case FontSizes.Normal:
                        return NormalStyle;
                    case FontSizes.Small:
                        return SmallStyle;
                }
            }
            return NormalStyle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
