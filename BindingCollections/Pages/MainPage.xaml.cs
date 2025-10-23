using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace BindingCollections.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public Patient? selectedPatient { get; set; }
        public Doctor Doctor { get; set; }
        public static ObservableCollection<Patient> PatientList { get; set; } = new ObservableCollection<Patient>();

        public static void Refresh()
        {

            List<string> patients = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.json", SearchOption.TopDirectoryOnly)
                            .Where(file => Path.GetFileName(file).Contains("P_")).ToList();

            PatientList.Clear();
            foreach (string fileName in patients)
            {
                string jsonString = File.ReadAllText(fileName);
                Patient pat = JsonSerializer.Deserialize<Patient>(jsonString);
                PatientList.Add(pat);
             
            }

          
        }

        public MainPage(Doctor _doctor)
        {
 

            

            InitializeComponent();
            DataContext = this;
            Doctor = _doctor;
            Refresh();



        }

        private void Create(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreatePage());
        }

        private void Appointment(object sender, RoutedEventArgs e)
        {
            if (selectedPatient != null)
            {
                NavigationService.Navigate(new AppointmentPage(selectedPatient,Doctor));
            }
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            if (selectedPatient != null)
            {
                NavigationService.Navigate(new ChangePage(selectedPatient));
            }
            
        }
    }
}
