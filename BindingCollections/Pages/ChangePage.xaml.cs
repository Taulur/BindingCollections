using System;
using System.Collections.Generic;
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
using System.IO;

namespace BindingCollections.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangePage.xaml
    /// </summary>
    public partial class ChangePage : Page
    {
        Patient copyPatient;
        Patient _patient;
        public ChangePage(Patient patient)
        {
            _patient = patient;
            copyPatient = new Patient(_patient.Name, _patient.LastName, _patient.MiddleName, _patient.Birthday, _patient.LastAppointment);
            DataContext = copyPatient;
            InitializeComponent();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(copyPatient);
            File.WriteAllText("P_" + copyPatient.Id + ".json", jsonString);
            _patient.Name = copyPatient.Name;
            _patient.LastName = copyPatient.LastName;
            _patient.MiddleName = copyPatient.MiddleName;
            _patient.Birthday = copyPatient.Birthday;
            _patient.LastAppointment = copyPatient.LastAppointment;
            NavigationService.GoBack();
        }
    }
}
