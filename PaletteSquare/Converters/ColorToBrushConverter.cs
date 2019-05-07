using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace PaletteSquare.Converters
{
    class ColorToBrushConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush brush = new SolidColorBrush();
            if (value is Color color)
            {
                brush.Color = color;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Color color = new Color();
            
            if (value is SolidColorBrush brush)
            {
                color = brush.Color;

            }

            return color;
        }
    }
}
