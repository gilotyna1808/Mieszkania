using Mieszkania.Dodawanie;
using Mieszkania.Wyswietlanie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy Mieszkania_Soft.xaml
    /// </summary>
    public partial class Mieszkania_Soft : Window
    {
        User u;
        public Mieszkania_Soft(User uzytkonik)
        {
            u = uzytkonik;
            Powitanie powi = new Powitanie(u);
            InitializeComponent();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(powi);
        }

        private void btn_DodajMie_Click(object sender, RoutedEventArgs e)
        {
            DodajMieszkanie dm = new DodajMieszkanie();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dm);
        }

        private void btn_DodajRemont_Click(object sender, RoutedEventArgs e)
        {
            DodajRemont dr = new DodajRemont(u);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dr);
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void btn_wyswietlanie_Click(object sender, RoutedEventArgs e)
        {
            Wyswietlanie_Menu wm = new Wyswietlanie_Menu(u);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(wm);
        }

        private void btn_dodajLok_Click(object sender, RoutedEventArgs e)
        {
            DodajLokatora dl = new DodajLokatora();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dl);
        }

        private void btn_dodajUmowe_Click(object sender, RoutedEventArgs e)
        {
            DodajUmowe du = new DodajUmowe(u);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(du);
        }

        private void btn_ModyfikujM_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujMieszkania mm = new ModyfikujMieszkania(u);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mm);
        }

        private void btn_DodajP_Click(object sender, RoutedEventArgs e)
        {
            DodajPracownika dp = new DodajPracownika();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(dp);
        }

        private void btn_ModyfikujL_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujLokatora ml = new ModyfikujLokatora();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(ml);
        }

        private void btn_ModyfikujP_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujPracownika mp = new ModyfikujPracownika();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mp);
        }

        private void btn_ModyfikujR_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujRemont mr = new ModyfikujRemont();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mr);
        }

        private void btn_ModyfikujU_Click(object sender, RoutedEventArgs e)
        {
            ModyfikujUmowe mr = new ModyfikujUmowe();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(mr);
        }
    }
}
