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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Random rnd = new Random();
        Doctor registredDoctor = new Doctor();

        public RegistrationPage()
        {
            DataContext = registredDoctor;
            InitializeComponent();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            if (registredDoctor.Name != "" && registredDoctor.LastName != "" && registredDoctor.MiddleName != "" && registredDoctor.Specialisation != "" && registredDoctor.Password != "" && (Confirmation.Text == registredDoctor.Password))
            {

                string rndId = "99999";
                string fileName = "null";
                int min = 10000;
                int max = 99999;
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
                registredDoctor.Id = Convert.ToInt32(rndId);
                string jsonString = JsonSerializer.Serialize(registredDoctor);
                File.WriteAllText(fileName, jsonString);
                Confirmation.Text = string.Empty;
                MessageBox.Show($"Пользователь с именем {registredDoctor.Name}\nУникальным Id {registredDoctor.Id}\nУспешно зарегистрирован");

                NavigationService.Navigate(new MainPage(registredDoctor));
            }
        }
    }
}
