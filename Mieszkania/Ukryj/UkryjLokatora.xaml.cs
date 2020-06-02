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

namespace Mieszkania.Ukryj
{
    /// <summary>
    /// Logika interakcji dla klasy UkryjLokatora.xaml
    /// </summary>
    public partial class UkryjLokatora : UserControl
    {
        User uzytkownik;
        public UkryjLokatora(User u)
        {
            uzytkownik = u;
            InitializeComponent();
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlLokator wl = new WyswietlLokator(uzytkownik);
            wl.ShowDialog();
            int temp_id = 0;
            temp_id = wl.id_w_l;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
                using (var com = new DostepPrac())
                {
                    var i = com.Lokator.Where(s => s.IdLokatora == temp_id);
                    txt_imie.Text = Convert.ToString(i.Select(s => s.Imie).FirstOrDefault());
                    txt_naz.Text = Convert.ToString(i.Select(s => s.Nazwisko).FirstOrDefault());
                    txt_tel.Text = Convert.ToString(i.Select(s => s.Nr_Telefonu).FirstOrDefault());
                    txt_pesel.Text = Convert.ToString(i.Select(s => s.Pesel).FirstOrDefault());
                    txt_adresk.Text = Convert.ToString(i.Select(s => s.Adres_Korespondecyjny).FirstOrDefault());
                    txt_mail.Text = Convert.ToString(i.Select(s => s.Adres_Mailowy).FirstOrDefault());
                }
            }
        }

        private void btn_Usun_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            using (DostepPrac dp = new DostepPrac())
            {
                var querry = from data in dp.Lokator
                             orderby data.IdLokatora
                             select data;
                foreach (Lokator l in querry)
                {
                    if (l.IdLokatora == temp_id)
                    {
                        l.Mieszka = false;

                    }
                }
                dp.SaveChanges();
            }
        }
    }
}
