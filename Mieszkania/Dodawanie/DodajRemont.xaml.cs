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
    /// Logika interakcji dla klasy DodajRemont.xaml
    /// </summary>
    public partial class DodajRemont : UserControl
    {
        private User uzytkowik;
        public DodajRemont(User u)
        {
            uzytkowik = u;
            InitializeComponent();
        }

        private void btn_dodaj_r_Click(object sender, RoutedEventArgs e)
        {
            Walidacja w = new Walidacja();
            bool walidacjaKoszt, walidacjaStan, walidacjaDataP, walidacjaDataK, walidacjaIdM;
            string koszt_s, stan, dataP_s, dataK_s, IdM_s;
            koszt_s = txt_Koszt.Text;
            stan = txt_stan.Text;
            dataP_s = txt_data_p.Text;
            dataK_s = txt_data_k.Text;
            IdM_s = txt_id_m.Text;
            walidacjaKoszt = w.sprawdzKosztRemontu(koszt_s);
            walidacjaStan = w.sprawdzStanRemont(stan);
            walidacjaDataP = w.sprawdzDate(dataP_s);
            walidacjaDataK = w.sprawdzDate(dataK_s);
            walidacjaIdM = w.sprawdzId(IdM_s);
            if (walidacjaKoszt && walidacjaStan && walidacjaDataP && walidacjaDataK && walidacjaIdM) {
                decimal koszt = Convert.ToDecimal(koszt_s);
                System.DateTime dataP = Convert.ToDateTime(dataP_s);
                System.DateTime dataK = Convert.ToDateTime(dataK_s);
                int id_m = Convert.ToInt32(IdM_s);
                using (var db = new DostepPrac())
                {
                    var dodaj = new Remonty()
                    {
                        Stan = stan,
                        Koszt_Remontu = koszt,
                        Data_Rozpoczecia = dataP,
                        Data_Zakonczenia = dataK,
                        IdMieszkania = id_m
                    };
                    db.Remonty.Add(dodaj);
                    var flagaPowDod = db.SaveChanges();
                    if (flagaPowDod == 1)
                    {
                        MessageBox.Show("Dodawanie zakonczone pomyślnie");
                    }
                }
            }
            else
            {
                MessageBox.Show("Wprowadzone złe dane");
            }
        }
        private void btn_wybierz_mieszkanie_Click(object sender, RoutedEventArgs e)
        {
            WyswietlMieszkania wm = new WyswietlMieszkania(uzytkowik);
            wm.ShowDialog();
            int temp_id = 0;
            temp_id = wm.id_w_m;
            if (temp_id != 0)
            {
                txt_id_m.Text = Convert.ToString(temp_id);
            }
        }

        private void txt_stan_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzStanRemont(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_Koszt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzKosztRemontu(x.Text))
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
