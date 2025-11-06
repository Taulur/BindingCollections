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
                        DateTime.TryParseExact(item.Date, "dd.MM.yyyy", culture, DateTimeStyles.None, out DateTime convertedDate);
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

    
           
            return DateTime.MinValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            return null;
        }
    }
}
