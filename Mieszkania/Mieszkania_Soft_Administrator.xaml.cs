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
            UsunPracownika up = new UsunPracownika(uztykownik);
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(up);
        }

        private void btn_WyswietlPrac_Click(object sender, RoutedEventArgs e)
        {
            WyswietlPracownika wp = new WyswietlPracownika();
            PanelWidok.Children.Clear();
            PanelWidok.Children.Add(wp);
        }
    }
}
