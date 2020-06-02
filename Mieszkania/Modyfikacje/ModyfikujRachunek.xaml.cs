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

namespace Mieszkania.Modyfikacje
{
    /// <summary>
    /// Logika interakcji dla klasy ModyfikujRachunek.xaml
    /// </summary>
    public partial class ModyfikujRachunek : UserControl
    {
        User uzytkownik;
        public ModyfikujRachunek(User u)
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
                txt_id.Text= Convert.ToString(dp.Czynsz_Wplywy.Where(s => s.IdCzynszu == temp_id).Select(s => s.IdUmowy).FirstOrDefault());
                txt_Kwota.Text = Convert.ToString(dp.Czynsz_Wplywy.Where(s => s.IdCzynszu == temp_id).Select(s => s.Kwota).FirstOrDefault());
                txt_termin.Text= Convert.ToString(dp.Czynsz_Wplywy.Where(s => s.IdCzynszu == temp_id).Select(s => s.Termin_Rozliczenia).FirstOrDefault());
                cbox_oplacone.SelectedValue = Convert.ToBoolean(dp.Czynsz_Wplywy.Where(s => s.IdCzynszu == temp_id).Select(s => s.Zaplacone).FirstOrDefault());
            };
        }

        private void btn_wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlUmowy wu = new WyswietlUmowy();
            wu.ShowDialog();
            int temp_id = wu.id_w_u;
            txt_id.Text = Convert.ToString(temp_id);
            using (DostepPrac dp = new DostepPrac())
            {
                txt_Kwota.Text = Convert.ToString(dp.Umowa.Where(s => s.IdUmowy == temp_id).Select(s => s.Stawka_Czynsz).FirstOrDefault());
            };
        }
    }
}
