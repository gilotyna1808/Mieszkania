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
    /// Logika interakcji dla klasy UkryjMieszkanie.xaml
    /// </summary>
    public partial class UkryjMieszkanie : UserControl
    {
        User uzytkownik;
        public UkryjMieszkanie(User u)
        {
            uzytkownik = u;
            InitializeComponent();
            Dictionary<bool, string> d = new Dictionary<bool, string>();
            d.Add(true, "Tak");
            d.Add(false, "Nie");
            cbox_pos.ItemsSource = d;
        }

        private void btn_modyfikuj_Click(object sender, RoutedEventArgs e)
        {
            int temp_id=Convert.ToInt32((txt_id.Text));
            using (DostepPrac dp = new DostepPrac())
            {
                var querry = from data in dp.Mieszkanie
                             orderby data.IdMieszkania
                             select data;
                foreach (Mieszkanie m in querry)
                {
                    if (m.IdMieszkania == temp_id)
                    {
                        m.Posiadane = false;
                    }
                }
                dp.SaveChanges();
            }
        }

        private void btn_wybierz_Click_1(object sender, RoutedEventArgs e)
        {
            WyswietlMieszkania wm = new WyswietlMieszkania(uzytkownik);
            wm.ShowDialog();
            int temp_id = 0;
            temp_id = wm.id_w_m;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
                using (var com = new DostepPrac())
                {
                    var i = com.Mieszkanie.Where(s => s.IdMieszkania == temp_id);
                    txt_Kod.Text = Convert.ToString(i.Select(s => s.Kod_Pocztowy).FirstOrDefault());
                    txt_Miasto.Text = Convert.ToString(i.Select(s => s.Miasto).FirstOrDefault());
                    txt_Mieszkanie.Text = Convert.ToString(i.Select(s => s.Nr_Mieszkania).FirstOrDefault());
                    txt_Nr.Text = Convert.ToString(i.Select(s => s.Nr_Domu).FirstOrDefault());
                    txt_status.Text = Convert.ToString(i.Select(s => s.Status_Mieszkania).FirstOrDefault());
                    txt_Ul.Text = Convert.ToString(i.Select(s => s.Ulica).FirstOrDefault());
                    cbox_pos.SelectedValue = Convert.ToBoolean(i.Select(s => s.Posiadane).FirstOrDefault());
                }
            }
        }
    }
}

