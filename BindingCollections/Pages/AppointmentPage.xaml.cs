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
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        public Patient Patient { get; set; }
        public AppointmentStory? SelectedAppointment { get; set; }
        AppointmentStory changedAppointment;
        public AppointmentStory? CopyAppointment { get; set; } = new AppointmentStory();

        public AppointmentPage(Patient _patient)
        {
            InitializeComponent();
            Patient = _patient;
            DataContext = this;

        }

        private void Return(object sender, RoutedEventArgs e)
        {
           
            NavigationService.GoBack();
        }

        private void ListView_Selected(object sender, RoutedEventArgs e)
        {

            
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            var originalAppointment = Patient.LastAppointment.FirstOrDefault(a =>
       a.Date == changedAppointment.Date &&
       a.Doctor?.Id == changedAppointment.Doctor?.Id &&
       a.Diagnosis == changedAppointment.Diagnosis &&
       a.Recomendations == changedAppointment.Recomendations);

            if (originalAppointment != null)
            {
                Patient.LastAppointment.Remove(originalAppointment);
                Patient.LastAppointment.Add(CopyAppointment);
                string jsonString = JsonSerializer.Serialize(Patient);
                File.WriteAllText("P_" + Patient.Id + ".json", jsonString);
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedAppointment != null)
            {
                CopyAppointment.Date = SelectedAppointment.Date;
                CopyAppointment.Doctor = SelectedAppointment.Doctor;
                CopyAppointment.Diagnosis = SelectedAppointment.Diagnosis;
                CopyAppointment.Recomendations = SelectedAppointment.Recomendations;
                changedAppointment = new AppointmentStory(SelectedAppointment.Date,SelectedAppointment.Doctor,SelectedAppointment.Diagnosis,SelectedAppointment.Recomendations);

            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
             if (CopyAppointment.Diagnosis != "" && CopyAppointment.Recomendations != "")
            {
                Patient.LastAppointment.Add(CopyAppointment);
                string jsonString = JsonSerializer.Serialize(Patient);
                File.WriteAllText("P_" + Patient.Id + ".json", jsonString);
                CopyAppointment = new AppointmentStory();
            }
        }

        private void ListView_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }


    }
}
