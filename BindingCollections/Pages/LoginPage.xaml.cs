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
        Doctor doctor;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (idLogin.Text != "" && passwordLogin.Text != "")
            {
                string fileName = "D_" + idLogin.Text + ".json";
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllText(fileName);
                    Doctor jsonAnswer = JsonSerializer.Deserialize<Doctor>(jsonString);
                    if (jsonAnswer.Password == passwordLogin.Text)
                    {
                        doctor = JsonSerializer.Deserialize<Doctor>(jsonString);

                       
                        idLogin.Text = string.Empty;
                        passwordLogin.Text = string.Empty;

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
