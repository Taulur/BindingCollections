using BindingCollections.Pages;
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
using System.IO;

namespace BindingCollections
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Count count = new Count();

        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = count;
            MainFrame.Navigate(new LoginPage());
            count.Refresh();
        }
    }
}
