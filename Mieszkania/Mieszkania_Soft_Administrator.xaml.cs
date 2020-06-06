using Mieszkania.Dodawanie;
using Mieszkania.Modyfikacje;
using Mieszkania.Ukryj;
using Mieszkania.Usuwanie;
using Mieszkania.Wyswietlanie;
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
using System.Windows.Shapes;

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy Mieszkania_Soft_Administrator.xaml
    /// </summary>
    public partial class Mieszkania_Soft_Administrator : Window
    {
        User uztykownik;
        public Mieszkania_Soft_Administrator(User u)
        {
            uztykownik = u;
            InitializeComponent();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void btn_DodajPrac_Click(object sender, RoutedEventArgs e)
        {
            DodajPracownika dp = new DodajPracownika();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dp);
        }

        private void btn_Modyfikuj_Prac_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujPracownika mp = new ModyfikujPracownika();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mp);
        }

        private void btn_UsunPrac_Click(object sender, RoutedEventArgs e)
        {
            UkryjPracownika up = new UkryjPracownika(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(up);
        }

        private void btn_WyswietlPrac_Click(object sender, RoutedEventArgs e)
        {
            Kon_WyswietlPracownika wp = new Kon_WyswietlPracownika();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(wp);
        }

        private void btn_temp1_Click(object sender, RoutedEventArgs e)
        {
            WyswietlanieAutoryzacji wa = new WyswietlanieAutoryzacji();
            wa.Show();
        }

        private void btn_DodajMieszkanie_Click(object sender, RoutedEventArgs e)
        {
            DodajMieszkanie dm = new DodajMieszkanie();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dm);
        }

        private void btn_ModyfikujMieszkanie_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujMieszkania mm = new ModyfikujMieszkania(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mm);
        }

        private void btn_UsunMieszkanie_Click(object sender, RoutedEventArgs e)
        {
            UkryjMieszkanie um = new UkryjMieszkanie(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(um);
        }

        private void btn_WyswietlMieszkanie_Click(object sender, RoutedEventArgs e)
        {
            Kon_WyswietlMieszkanie um = new Kon_WyswietlMieszkanie(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(um);
        }

        private void btn_Przydzialy_Click(object sender, RoutedEventArgs e)
        {
            DodajPracownikowOdp dpo = new DodajPracownikowOdp();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dpo);
        }

        private void btn_DodajRemont_Click(object sender, RoutedEventArgs e)
        {
            DodajRemont dr = new DodajRemont(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dr);
        }

        private void btn_ModyfikujRemont_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujRemont mr = new ModyfikujRemont(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mr);
        }

        private void btn_UkryjRemont_Click(object sender, RoutedEventArgs e)
        {
            UsunRemont ur = new UsunRemont(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(ur);
        }

        private void btn_wyswietlRemonty_Click(object sender, RoutedEventArgs e)
        {
            Kon_WyswietlRemonty wr = new Kon_WyswietlRemonty();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(wr);
        }

        private void btn_DodajUmowe_Click(object sender, RoutedEventArgs e)
        {
            DodajUmowe du = new DodajUmowe(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(du);
        }

        private void btn_ModyfikujUmowe_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujUmowe mu = new ModyfikujUmowe();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mu);
        }

        private void btn_UkryjUmowe_Click(object sender, RoutedEventArgs e)
        {
            UsunUmowe uu = new UsunUmowe(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(uu);
        }

        private void btn_WyswietlUmowe_Click(object sender, RoutedEventArgs e)
        {
            Kon_WyswietlUmowy wu = new Kon_WyswietlUmowy();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(wu);
        }

        private void btn_DodajRachunek_Click(object sender, RoutedEventArgs e)
        {
            DodajRachunek dr = new DodajRachunek();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dr);
        }

        private void btn_WyswietlRachunki_Click(object sender, RoutedEventArgs e)
        {
            Kon_WyswietlRachunki wr = new Kon_WyswietlRachunki(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(wr);
        }

        private void btn_ModyfikujRachunek_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujRachunek mr = new ModyfikujRachunek(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mr);
        }

        private void btn_UsunRachunek_Click(object sender, RoutedEventArgs e)
        {
            UsunRachunek ur = new UsunRachunek(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(ur);
        }

        private void btn_DodaLokatora_Click(object sender, RoutedEventArgs e)
        {
            DodajLokatora dl = new DodajLokatora();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dl);
        }

        private void btn_ModyfikujLokatora_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujLokatora ml = new ModyfikujLokatora(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(ml);
        }

        private void btn_UkryjLokatora_Click(object sender, RoutedEventArgs e)
        {
            UkryjLokatora ul = new UkryjLokatora(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(ul);
        }

        private void btn_WyswietlLokatora_Click(object sender, RoutedEventArgs e)
        {
            Kon_WyswietlLokator wl = new Kon_WyswietlLokator(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(wl);
        }

        private void btn_konta_mod_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujKonto mk = new ModyfikujKonto();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mk);
        }
    }
}
