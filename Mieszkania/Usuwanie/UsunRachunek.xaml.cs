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

namespace Mieszkania.Usuwanie
{
    /// <summary>
    /// Logika interakcji dla klasy UsunRachunek.xaml
    /// </summary>
    public partial class UsunRachunek : UserControl
    {
        User uzytkownik;
        public UsunRachunek(User u)
        {
            uzytkownik = u;
            InitializeComponent();
            Dictionary<bool, string> d = new Dictionary<bool, string>();
            d.Add(true, "Tak");
            d.Add(false, "Nie");
            cbox_oplacone.ItemsSource = d;
        }

        private void btn_wybierzrach_Click(object sender, RoutedEventArgs e)
        {
            WyswietlRachunki wr = new WyswietlRachunki(uzytkownik);
            wr.ShowDialog();
            int temp_id = wr.id_w_r;
            txt_idrach.Text = Convert.ToString(temp_id);
            using (DostepPrac dp = new DostepPrac())
            {
                txt_id.Text = Convert.ToString(dp.Czynsz_Wplywy.Where(s => s.IdCzynszu == temp_id).Select(s => s.IdUmowy).FirstOrDefault());
                txt_Kwota.Text = Convert.ToString(dp.Czynsz_Wplywy.Where(s => s.IdCzynszu == temp_id).Select(s => s.Kwota).FirstOrDefault());
                txt_termin.Text = Convert.ToString(dp.Czynsz_Wplywy.Where(s => s.IdCzynszu == temp_id).Select(s => s.Termin_Rozliczenia).FirstOrDefault());
                cbox_oplacone.SelectedValue = Convert.ToBoolean(dp.Czynsz_Wplywy.Where(s => s.IdCzynszu == temp_id).Select(s => s.Zaplacone).FirstOrDefault());
            };
        }

        private void btn_usun_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_idrach.Text);
            DostepPrac dp = new DostepPrac();
            var q = from data in dp.Czynsz_Wplywy
                    orderby data.IdCzynszu
                    select data;
            foreach (Czynsz_Wplywy l in q)
            {
                if (l.IdCzynszu == temp_id)
                {
                    dp.Czynsz_Wplywy.Remove(l);
                }
            }
            dp.SaveChanges();
        }
    }
}
