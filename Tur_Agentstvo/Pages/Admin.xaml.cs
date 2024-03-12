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

namespace Tur_Agentstvo.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
      
        public Admin(string im, string fam, string otches, string vremya)
        {
            InitializeComponent();
            GetPrivets(im, fam, otches, vremya);
        }

        public string GetPrivets(string im, string fam, string otches, string vremya)
        {
            DateTime time = DateTime.Parse(vremya);
            if (time.TimeOfDay >= new TimeSpan(10, 0, 0) && time.TimeOfDay < new TimeSpan(12, 0, 0))
            {

                return Privetsvie.Text = "Доброе утро! " + fam + " " + im + " " + otches;
            }
            else if (time.TimeOfDay >= new TimeSpan(12, 0, 1) && time.TimeOfDay < new TimeSpan(18, 0, 0))
            {
                return Privetsvie.Text = "Добрый День! " + fam + " " + im + " " + otches;
            }
            else if (time.TimeOfDay >= new TimeSpan(18, 0, 1) && time.TimeOfDay < new TimeSpan(20, 0, 0))
            {

                return Privetsvie.Text = "Добрый вечер! " + fam + " " + im + " " + otches;

            }
            else
            {
                return Privetsvie.Text = "Доброй ночи! " + fam + " " + im + " " + otches;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/spisok.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/dobavit.xaml", UriKind.Relative));
        }
    }
}
