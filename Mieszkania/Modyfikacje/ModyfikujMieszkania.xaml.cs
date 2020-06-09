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

namespace Mieszkania.Wyswietlanie
{
    /// <summary>
    /// Logika interakcji dla klasy ModyfikujMieszkania.xaml
    /// </summary>
    public partial class ModyfikujMieszkania : UserControl
    {
        private User uzytkownik;
        public ModyfikujMieszkania(User u)
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
            Walidacja w = new Walidacja();
            int temp_id = Convert.ToInt32(txt_id.Text);
            bool walidacjaMiasto, walidacjaMieszkanie, walidacjaNrDomu, walidacjaUlica, walidacjaStatus, walidacjaKod;
            string miasto, mieszkanie, nrDomu, ulica, status, kodPocztowy;
            miasto = txt_Miasto.Text;
            mieszkanie = txt_Mieszkanie.Text;
            nrDomu = txt_Nr.Text;
            ulica = txt_Ul.Text;
            status = txt_status.Text;
            kodPocztowy = txt_Kod.Text;
            walidacjaMiasto = w.sprawdzMiasto(miasto);
            walidacjaMieszkanie = w.sprawdzMiasto(mieszkanie);//Specjalnie spradzane jak miasto Pole do mozliwego usuniecia
            walidacjaNrDomu = w.sprawdzNrDomu(nrDomu);
            walidacjaUlica = w.sprawdzUlice(ulica);
            walidacjaStatus = w.sprawdzStatusMieszkanie(status);
            walidacjaKod = w.sprawdzKodPocztowy(kodPocztowy);
            if (walidacjaMiasto && walidacjaMieszkanie && walidacjaNrDomu && walidacjaUlica && walidacjaStatus && walidacjaKod)
            {
                using (DostepPrac dp = new DostepPrac())
                {
                    var querry = from data in dp.Mieszkanie
                                 orderby data.IdMieszkania
                                 select data;
                    foreach (Mieszkanie m in querry)
                    {
                        if (m.IdMieszkania == temp_id)
                        {
                            m.Miasto = miasto;
                            m.Kod_Pocztowy = kodPocztowy;
                            m.Ulica = ulica;
                            m.Nr_Domu = nrDomu;
                            m.Nr_Mieszkania = mieszkanie;
                            m.Status_Mieszkania = status;
                            m.Posiadane = Convert.ToBoolean(cbox_pos.SelectedValue);
                        }
                    }
                    var flagaPowDod = dp.SaveChanges();
                    if (flagaPowDod == 1)
                    {
                        MessageBox.Show("Modyfikowanie zakonczone pomyślnie");
                    }
                }
            }
            else
            {
                MessageBox.Show("Wprowadzono zle dane");
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

        private void txt_Miasto_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzMiasto(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_Kod_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzKodPocztowy(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_Ul_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzUlice(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_Nr_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzNrDomu(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_Mieszkanie_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzNrDomu(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_status_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzStatusMieszkanie(x.Text))
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
