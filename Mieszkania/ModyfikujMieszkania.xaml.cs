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
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
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
                    txt_kod.Text = Convert.ToString(i.Select(s => s.Kod_Pocztowy).FirstOrDefault());
                    txt_miasto.Text = Convert.ToString(i.Select(s => s.Miasto).FirstOrDefault());
                    txt_miesz.Text = Convert.ToString(i.Select(s => s.Mieszkanie1).FirstOrDefault());
                    txt_nr.Text = Convert.ToString(i.Select(s => s.Nr_Domu).FirstOrDefault());
                    txt_status.Text = Convert.ToString(i.Select(s => s.Status_Mieszkania).FirstOrDefault());
                    txt_ul.Text = Convert.ToString(i.Select(s => s.Ulica).FirstOrDefault());

                }
            }
        }

        private void btn_zmien_Click(object sender, RoutedEventArgs e)
        {
            Walidacja w = new Walidacja();
            int temp_id = Convert.ToInt32(txt_id.Text);
            bool walidacjaMiasto, walidacjaMieszkanie, walidacjaNrDomu, walidacjaUlica, walidacjaStatus, walidacjaKod;
            string miasto, mieszkanie, nrDomu, ulica, status, kodPocztowy;
            miasto = txt_miasto.Text;
            mieszkanie = txt_miesz.Text;
            nrDomu = txt_nr.Text;
            ulica = txt_ul.Text;
            status = txt_status.Text;
            kodPocztowy = txt_kod.Text;
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
                            m.Miasto = txt_miasto.Text;
                            m.Kod_Pocztowy = txt_kod.Text;
                            m.Ulica = txt_ul.Text;
                            m.Nr_Domu = txt_nr.Text;
                            m.Mieszkanie1 = txt_miesz.Text;
                            m.Status_Mieszkania = txt_status.Text;
                        }
                    }
                    dp.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Wprowadzono zle dane");
            }
        }
    }
}
