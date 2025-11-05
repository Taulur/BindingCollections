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
    public class IsOldConverter : IValueConverter
    {
        private bool CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;

            if (currentDate.Month < birthDate.Month ||
                (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            if (age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
              
        }

        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            if (value == null)
                return null;

      
            if (value is DateTime dateTime)
                return dateTime;

    
            if (value is string stringValue)
            {
                if (DateTime.TryParse(stringValue, culture, DateTimeStyles.None, out DateTime result))
                    return CalculateAge(result);
             
                if (DateTime.TryParseExact(stringValue, "yyyy-MM-dd", culture, DateTimeStyles.None, out result))
                    return CalculateAge(result);

                if (DateTime.TryParseExact(stringValue, "dd.MM.yyyy", culture, DateTimeStyles.None, out result))
                    return CalculateAge(result);

                if (DateTime.TryParseExact(stringValue, "MM/dd/yyyy", culture, DateTimeStyles.None, out result))
                    return CalculateAge(result);
            }
            return DateTime.MinValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            return null;
        }
    }
}
