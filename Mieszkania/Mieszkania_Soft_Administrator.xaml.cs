using Mieszkania.Dodawanie;
using Mieszkania.Ukryj;
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
    }
}
