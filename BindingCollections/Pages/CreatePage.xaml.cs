using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingCollections.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        Random rnd = new Random();
        Patient registredPatient = new Patient();
        ObservableCollection<Patient> _patientList;
        public CreatePage(ObservableCollection<Patient> PatientList)
        {
            _patientList = PatientList;
            DataContext = registredPatient;
            InitializeComponent();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            if (registredPatient.Name != "" && registredPatient.LastName != "" && registredPatient.MiddleName != "" && registredPatient.Birthday != null)
            {
                string rndId = "999999";
                string fileName = "null";
                int min = 1000000;
                int max = 9999999;
                List<string> Excludes = new List<string>();
                for (int i = min; i < max; i++)
                {
                    do
                    {
                        rndId = rnd.Next(min, max).ToString();
                    } while (Excludes.Contains(rndId));



                    if (File.Exists(fileName))
                    {
                        Excludes.Add(rndId);
                    }
                    else
                    {
                        fileName = "D_" + rndId + ".json";
                        break;
                    }
                }
                registredPatient.Id = rndId;
                string jsonString = JsonSerializer.Serialize(registredPatient);
                File.WriteAllText(fileName, jsonString);
                _patientList.Add(registredPatient);
                NavigationService.GoBack();
            }
        }
    }
}
