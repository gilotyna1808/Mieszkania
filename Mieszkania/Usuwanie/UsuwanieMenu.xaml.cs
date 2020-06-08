using Mieszkania.Raporty;
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

namespace Mieszkania.Usuwanie
{
    /// <summary>
    /// Logika interakcji dla klasy UsuwanieMenu.xaml
    /// </summary>
    public partial class UsuwanieMenu : UserControl
    {
        User uzytkownik;
        Mieszkania_Soft_Pracownik baze;
        public UsuwanieMenu(Mieszkania_Soft_Pracownik w, User u)
        {
            baze = w;
            uzytkownik = u;
            InitializeComponent();
        }


        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            UsunLokatora us = new UsunLokatora(uzytkownik);
            baze.PanelWidok.Children.Clear();
            baze.PanelWidok.Children.Add(us);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            UsunMieszkanie us = new UsunMieszkanie(uzytkownik);
            baze.PanelWidok.Children.Clear();
            baze.PanelWidok.Children.Add(us);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            UsunPracownika us = new UsunPracownika(uzytkownik);
            baze.PanelWidok.Children.Clear();
            baze.PanelWidok.Children.Add(us);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            UsunRemont us = new UsunRemont(uzytkownik);
            baze.PanelWidok.Children.Clear();
            baze.PanelWidok.Children.Add(us);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            UsunUmowe us = new UsunUmowe(uzytkownik);
            baze.PanelWidok.Children.Clear();
            baze.PanelWidok.Children.Add(us);
        }

    }
}
