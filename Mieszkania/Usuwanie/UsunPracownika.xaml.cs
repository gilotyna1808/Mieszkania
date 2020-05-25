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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy UsunPracownika.xaml
    /// </summary>
    public partial class UsunPracownika : UserControl
    {
        User uzytkownik;
        public UsunPracownika(User u)
        {
            uzytkownik = u;
            InitializeComponent();
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlPrac wp = new WyswietlPrac();
            wp.ShowDialog();
            int temp_id = 0;
            temp_id = wp.id_w_p;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
            }
        }

        private void btn_Usun_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            DostepPrac dp = new DostepPrac();
            var q = from data in dp.Pracownicy
                    orderby data.IdPracownika
                    select data;
            foreach (Pracownicy p in q)
            {
                if (p.IdPracownika == temp_id)
                {
                    dp.Pracownicy.Remove(p);
                }
            }
            dp.SaveChanges();
        }
    }
}
