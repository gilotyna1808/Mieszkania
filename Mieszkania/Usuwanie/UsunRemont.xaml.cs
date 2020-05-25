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
    /// Logika interakcji dla klasy UsunRemont.xaml
    /// </summary>
    public partial class UsunRemont : UserControl
    {
        User uzytkownik;
        public UsunRemont(User u)
        {
            uzytkownik=u;
            InitializeComponent();
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlRemonty wr = new WyswietlRemonty();
            wr.ShowDialog();
            int temp_id = 0;
            temp_id = wr.id_w_r;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
            }
        }

        private void btn_Usun_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            DostepPrac dp = new DostepPrac();
            var q = from data in dp.Remonty
                    orderby data.IdRemontu
                    select data;
            foreach (Remonty r in q)
            {
                if (r.IdRemontu == temp_id)
                {
                    dp.Remonty.Remove(r);
                }
            }
            dp.SaveChanges();
        }
    }
}
