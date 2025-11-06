using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Doctor loginedDoctor = new Doctor();
        Doctor doctor;
 

        public LoginPage()
        {
            InitializeComponent();
            DataContext = loginedDoctor;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (loginedDoctor.Id != "" && loginedDoctor.Password != "")
            {
                string fileName = "D_" + loginedDoctor.Id + ".json";
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllText(fileName);
                    Doctor jsonAnswer = JsonSerializer.Deserialize<Doctor>(jsonString);
                    if (jsonAnswer.Password == loginedDoctor.Password)
                    {
                        doctor = JsonSerializer.Deserialize<Doctor>(jsonString);

                        loginedDoctor = new Doctor();

                        NavigationService.Navigate(new MainPage(doctor));
                    }
                }
            }


            
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
