using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        public Patient Patient { get; set; }
        public AppointmentStory? SelectedAppointment { get; set; }
        public AppointmentStory? ChangedAppointment { get; set; }

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
            ChangedAppointment = new AppointmentStory(SelectedAppointment.Date,SelectedAppointment.Doctor,SelectedAppointment.Diagnosis,SelectedAppointment.Recomendations);

        }

        private void Change(object sender, RoutedEventArgs e)
        {
            if (ChangedAppointment != null)
            {
                SelectedAppointment = ChangedAppointment;
            }
        }
    }
}
