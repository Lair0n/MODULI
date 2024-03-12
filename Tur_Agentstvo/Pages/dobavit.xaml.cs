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
    /// Логика взаимодействия для dobavit.xaml
    /// </summary>
    public partial class dobavit : Page
    {
        List<Avtorizacia> Avtorizacia;
        public dobavit(int ID_Sotrudnika)
        {
            InitializeComponent();
            Init(ID_Sotrudnika);
        }
        public dobavit()
        {

        }
        public void Init(int ID_Sotrudnika)
        {
            Sotrudnik Sotrudnik = Helper.getContext().Sotrudnik.Where(t => t.ID_Sotrudnika == ID_Sotrudnika).FirstOrDefault();
            List<Doljnost> Doljnost = Helper.getContext().Doljnost.ToList();
            Avtorizacia = Helper.getContext().Avtorizacia.ToList();
            string naimenovanieDol = Doljnost.Where(t => t.ID_Doljnost == Sotrudnik.ID_Doljnost).FirstOrDefault().Doljnost1;
            cmbDol.DisplayMemberPath = "NaimenovanieRoli";
            cmbDol.ItemsSource = Doljnost;
            tbLogin.Text = Avtorizacia.Where(t => t.ID_Avtorizacii == Sotrudnik.ID_Avtorizacii).FirstOrDefault().Login;
            //tbparol.Text = authorizacia.Where(t => t.KodAuthorizacii == Polzovatel.KodParolia).FirstOrDefault().Parol;
            
            tbFamilia.Text = Sotrudnik.Familia;
            tbImia.Text = Sotrudnik.Imya;
            tbOtchestvo.Text = Sotrudnik.Otchestvo;
            tbNomerTelefona.Text = Sotrudnik.Contactniy_telephone;
            
            btSave.Content = "Сохранить";
            btSave.Click += saveUser;
            cmbDol.Text = naimenovanieDol;
            
        }

        private void saveUser(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
