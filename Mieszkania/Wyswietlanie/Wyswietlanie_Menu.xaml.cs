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

namespace Mieszkania.Wyswietlanie
{
    /// <summary>
    /// Logika interakcji dla klasy Wyswietlanie_Menu.xaml
    /// </summary>
    public partial class Wyswietlanie_Menu : UserControl
    {
        public Wyswietlanie_Menu()
        {
            InitializeComponent();
        }

        private void btn_p_Click(object sender, RoutedEventArgs e)
        {
            WyswietlPrac p = new WyswietlPrac();
            p.Show();
        }

        private void btn_u_Click(object sender, RoutedEventArgs e)
        {
            WyswietlUmowy u = new WyswietlUmowy();
            u.Show();
        }

        private void btn_m_Click(object sender, RoutedEventArgs e)
        {
            WyswietlMieszkania m = new WyswietlMieszkania();
            m.Show();
        }

        private void btn_l_Click(object sender, RoutedEventArgs e)
        {
            WyswietlLokator l = new WyswietlLokator();
            l.Show();
        }

        private void btn_r_Click(object sender, RoutedEventArgs e)
        {
            WyswietlRemonty r = new WyswietlRemonty();
            r.Show();
        }
    }
}
