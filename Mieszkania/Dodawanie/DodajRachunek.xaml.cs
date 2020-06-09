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

namespace Mieszkania.Dodawanie
{
    /// <summary>
    /// Logika interakcji dla klasy DodajRachunek.xaml
    /// </summary>
    public partial class DodajRachunek : UserControl
    {
        public DodajRachunek()
        {
            InitializeComponent();
            Dictionary<bool, string> d = new Dictionary<bool, string>();
            d.Add(true, "Tak");
            d.Add(false, "Nie");
            cbox_oplacone.ItemsSource = d;
        }

        private void btn_wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlUmowy wu = new WyswietlUmowy();
            wu.ShowDialog();
            int temp_id = wu.id_w_u;
            txt_id.Text=Convert.ToString(temp_id);
            using (DostepPrac dp =new DostepPrac())
            {
                txt_Kwota.Text = Convert.ToString(dp.Umowa.Where(s => s.IdUmowy == temp_id).Select(s => s.Stawka_Czynsz).FirstOrDefault());
            };
        }

        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Walidacja w = new Walidacja();
            bool id_w, kwota_w, termin_w;
            string id, kwota, termin;
            id = txt_id.Text;
            kwota = txt_Kwota.Text;
            termin = txt_termin.Text;
            id_w = w.sprawdzId(id);
            kwota_w = w.sprawdzCzynsz(kwota);
            termin_w = w.sprawdzDate(termin);

            if(id_w && kwota_w && termin_w)
            {
                using (DostepPrac dp = new DostepPrac())
                {
                    Czynsz_Wplywy cw = new Czynsz_Wplywy()
                    {
                        IdUmowy = Convert.ToInt32(id),
                        Kwota = Convert.ToDecimal(kwota),
                        Termin_Rozliczenia = Convert.ToDateTime(termin),
                        Zaplacone = Convert.ToBoolean(cbox_oplacone.SelectedValue)
                    };
                    dp.Czynsz_Wplywy.Add(cw);
                    var flagaPowDod = dp.SaveChanges();
                    if (flagaPowDod == 1)
                    {
                        MessageBox.Show("Dodawanie zakonczone pomyślnie");
                    }
                };
            }
            else
            {
                MessageBox.Show("Błędne dane");
            }

        }

        private void txt_Kwota_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzCzynsz(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }
    }
}
