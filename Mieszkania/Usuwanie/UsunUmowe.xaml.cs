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
    /// Logika interakcji dla klasy UsunUmowe.xaml
    /// </summary>
    public partial class UsunUmowe : UserControl
    {
        User uzytkownik;
        public UsunUmowe(User u)
        {
            uzytkownik = u;
            InitializeComponent();
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlUmowy wu = new WyswietlUmowy();
            wu.ShowDialog();
            int temp_id = 0;
            temp_id = wu.id_w_u;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
                using (var com = new DostepPrac())
                {
                    var i = com.Umowa.Where(s => s.IdUmowy == temp_id);
                    txt_coplaty.Text = Convert.ToString(i.Select(s => s.Oplaty_Stale).FirstOrDefault());
                    txt_czynsz.Text = Convert.ToString(i.Select(s => s.Stawka_Czynsz).FirstOrDefault());
                    txt_od_kiedy.Text = Convert.ToString(i.Select(s => s.Od_Kiedy).FirstOrDefault());
                    txt_do_kiedy.Text = Convert.ToString(i.Select(s => s.Do_Kiedy).FirstOrDefault());
                    txt_idL.Text = Convert.ToString(i.Select(s => s.IdLokatora).FirstOrDefault());
                    txt_idM.Text = Convert.ToString(i.Select(s => s.IdMieszkania).FirstOrDefault());
                }
            }
        }

        private void btn_Usun_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            DostepPrac dp = new DostepPrac();
            var q = from data in dp.Umowa
                    orderby data.IdUmowy
                    select data;

            foreach (Umowa u in q)
            {
                if (u.IdUmowy == temp_id)
                {
                    dp.Umowa.Remove(u);
                }
            }
            dp.SaveChanges();

        }

    }
}
