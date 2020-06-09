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
    /// Logika interakcji dla klasy ModyfikujKonto.xaml
    /// </summary>
    public partial class ModyfikujKonto : UserControl
    {
        public ModyfikujKonto()
        {
            InitializeComponent();
            Dictionary<bool, string> d = new Dictionary<bool, string>();
            d.Add(true, "Tak");
            d.Add(false, "Nie");
            cbox_aktywne.ItemsSource = d;
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlanieAutoryzacji wp = new WyswietlanieAutoryzacji();
            wp.ShowDialog();
            int temp_id = 0;
            temp_id = wp.id_w_a;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
                using (var com = new DostepPrac())
                {
                    var i = com.Autoryzacja.Where(s => s.IdPracownika == temp_id);
                    txt_log.Text = Convert.ToString(i.Select(s => s.Login).FirstOrDefault());
                    txt_haslo.Text = Convert.ToString(i.Select(s => s.Haslo).FirstOrDefault());
                    cbox_aktywne.SelectedValue= Convert.ToBoolean(i.Select(s => s.Aktywne).FirstOrDefault());
                }
            }
        }

        private void btn_Modyfikuj_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            Walidacja w = new Walidacja();
            string log = txt_log.Text;
            string haslo = txt_haslo.Text;
            bool log_w, haslo_w;
            log_w = w.SpradzCzyZaDlugie(log,25);
            haslo_w = w.SpradzCzyZaDlugie(haslo,25);
            if (log_w && haslo_w)
            {
                using (DostepPrac dp = new DostepPrac())
                {
                    var q = from data in dp.Autoryzacja
                            orderby data.IdPracownika
                            select data;
                    foreach (Autoryzacja p in q)
                    {
                        if (p.IdPracownika == temp_id)
                        {
                            p.Login = log;
                            p.Haslo = haslo;
                            p.Aktywne = Convert.ToBoolean(cbox_aktywne.SelectedValue);

                        }
                    }
                    var flagaPowDod = dp.SaveChanges();
                    if (flagaPowDod == 1)
                    {
                        MessageBox.Show("Modyfikowanie zakonczone pomyślnie");
                    }
                };
            }
            else
            {
                MessageBox.Show("Wprowadzono zle dane");
            }
        }
    }
}
