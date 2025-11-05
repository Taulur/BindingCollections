using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingCollections.Converters
{
    public class AppointmentConvertor : IValueConverter
    {
        private int CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;

            if (currentDate.Month < birthDate.Month ||
                (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }

        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            if (value == null)
                return null;

            

            if (value is ObservableCollection<AppointmentStory> listValue)
            {
                if (listValue.Count > 0)
                {
                    DateTime lastDate = DateTime.MinValue;

                    foreach (var item in listValue)
                    {
                        DateTime.TryParse(item.Date, culture, DateTimeStyles.None, out DateTime convertedDate);
                        if (convertedDate > lastDate)
                        {
                            lastDate = convertedDate;
                        }
                    }
                    return $"Прошло дней с момента последнего приёма : {(DateTime.Now - lastDate).Days}";
                }
                else
                {
                    return "Первый приём";
                }

            }

    
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
