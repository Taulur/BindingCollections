using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingCollections.Converters
{
    public class NumberConverter : IValueConverter
    {
       

        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            string phone = value.ToString();

            // Форматируем
            return $"+7 ({phone.Substring(0, 3)}) {phone.Substring(3, 3)} {phone.Substring(6, 2)} {phone.Substring(8, 2)}";
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            return null;
        }
    }
}
