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
using Tur_Agentstvo.Models;

namespace Tur_Agentstvo.Pages
{
    /// <summary>
    /// Логика взаимодействия для spisok.xaml
    /// </summary>
    public partial class spisok : Page
    {
        List<Sotrudnik> sotr;
        public spisok()
        {
            InitializeComponent();
            var Sotrudniki = Helper.getContext().Sotrudnik.ToList();
            LbSpisok.ItemsSource = Sotrudniki;
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var sotr = Helper.getContext().Sotrudnik.ToList();
            int ind = LbSpisok.SelectedIndex;
            int kod_sotrudnika = sotr[ind].ID_Sotrudnika;
            dobavit tecushiyPolzovatel = new dobavit(kod_sotrudnika);
            this.NavigationService.Navigate(tecushiyPolzovatel);
            //this.NavigationService.Navigate(new Uri("Pages/TecushiyPolzovatel.xaml", UriKind.Relative));
        }
        private void btn_sort_Click(object sender, RoutedEventArgs e)
        {
            sotr = Helper.getContext().Sotrudnik.Where(t => t.Imya.Contains(txt_filter.Text) || t.Familia.Contains(txt_filter.Text) || t.Familia.Contains(txt_filter.Text)).ToList();

            if (cmb_filter.Text == "По возрастанию")
            {
                if (cmb_filter2.Text == "По имени")
                {
                    sotr.OrderByDescending(t => t.Imya);
                }
                if (cmb_filter2.Text == "По фамилии")
                {
                    sotr.OrderByDescending(t => t.Familia);
                }
            }
            if (cmb_filter.Text == "По убыванию")
            {
                if (cmb_filter2.Text == "По имени")
                {
                    sotr.OrderByDescending(t => t.Imya);
                }
                if (cmb_filter2.Text == "По фамилии")
                {
                    sotr.OrderByDescending(t => t.Familia);
                }
                sotr.Reverse();
            }
            LbSpisok.ItemsSource = sotr;
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            sotr = Helper.getContext().Sotrudnik.ToList();
            LbSpisok.ItemsSource = sotr;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/TecushiyPolzovatel.xaml", UriKind.Relative));
        }
    }
}
    

