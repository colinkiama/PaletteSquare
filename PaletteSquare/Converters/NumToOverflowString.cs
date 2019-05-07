using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PaletteSquare.Converters
{
    class NumToOverflowString:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string overflowString = null;
            if (value is int num)
            {
                overflowString = $"+{num}";
            }
            return overflowString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
