using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public Patient? selectedPatient { get; set; }
        public Doctor Doctor { get; set; }
        public ObservableCollection<Patient> PatientList { get; set; } = new ObservableCollection<Patient>();

        public MainPage(Doctor _doctor)
        {


            Doctor = _doctor;
            
            PatientList.Add(new Patient("Анна", "Смирнова", "Викторовна", "12.05.1978",new ObservableCollection<AppointmentStory> { new AppointmentStory("17.06.2001", Doctor, "Смерть", "Ей ничего не поможет") }));
            PatientList.Add(new Patient("Игорь", "Петров", "Сергеевич", "15.11.1985", new ObservableCollection<AppointmentStory> { new AppointmentStory("12.03.2024", Doctor, "Гипертонический криз", "Назначена суточная тонометрия, коррекция терапии") }));
            PatientList.Add(new Patient("Мария", "Котовская", "Львовна", "03.07.1992", new ObservableCollection<AppointmentStory> { new AppointmentStory("28.02.2024", Doctor, "Острый бронхит", "Выписан больничный на 7 дней, антибиотикотерапия") }));
            PatientList.Add(new Patient("Артем", "Васильев", "Игоревич", "22.09.1978", new ObservableCollection<AppointmentStory> { new AppointmentStory("15.03.2024", Doctor, "Послеоперационный осмотр", "Швы сняты, заживление без осложнений") }));
            PatientList.Add(new Patient("Ольга", "Никитина", "Александровна", "30.04.1988", new ObservableCollection<AppointmentStory> { new AppointmentStory("05.03.2024", Doctor, "Мигрень", "Назначен новый препарат для профилактики приступов") }));

            InitializeComponent();
            DataContext = this;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreatePage(PatientList));
        }

        private void Appointment(object sender, RoutedEventArgs e)
        {
            if (selectedPatient != null)
            {
                NavigationService.Navigate(new AppointmentPage(selectedPatient));
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
