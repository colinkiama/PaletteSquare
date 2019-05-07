using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace PaletteSquare.Converters
{
    class OverflowNumToVisibility:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility isVisible = Visibility.Collapsed;
            if (value is int num)
            {
                if (num > 0)
                {
                    isVisible = Visibility.Visible;
                }
            }
            return isVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
