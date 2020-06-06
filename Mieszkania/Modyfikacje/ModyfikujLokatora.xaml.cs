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
using System.Windows.Shapes;

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy ModyfikujLokatora.xaml
    /// </summary>
    public partial class ModyfikujLokatora : UserControl
    {
        User uzytkownik;
        public ModyfikujLokatora(User u)
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
                    txt_tel.Text= Convert.ToString(i.Select(s => s.Nr_Telefonu).FirstOrDefault());
                    txt_pesel.Text = Convert.ToString(i.Select(s => s.Pesel).FirstOrDefault());
                    txt_adresk.Text = Convert.ToString(i.Select(s => s.Adres_Korespondecyjny).FirstOrDefault());
                    txt_mail.Text = Convert.ToString(i.Select(s => s.Adres_Mailowy).FirstOrDefault());
                }
            }
        }

        private void btn_Modyfikuj_Click(object sender, RoutedEventArgs e)
        {
            Walidacja w = new Walidacja();
            bool walidacjaImie = true;
            bool walidacjaNazw = true;
            bool walidacjaTel = true;
            bool walidacjaPesel = true;
            bool walidacjaAdresK = true;
            bool walidacjaAdresE = true;
            string imie = txt_imie.Text;
            string nazwisko = txt_naz.Text;
            string nrTel = txt_tel.Text;
            string pesel = txt_pesel.Text;
            string adresk = txt_adresk.Text;
            string mail = txt_mail.Text;
            walidacjaImie = w.sprawdzImie(imie);
            walidacjaNazw = w.sprawdzNazwisko(nazwisko);
            walidacjaTel = w.sprawdzTelefon(nrTel);
            walidacjaPesel = w.SprawdzPesel(pesel);
            walidacjaAdresE = w.SprawdzAdresEmail(mail);
            int flag = 0;
            if (mail == "")
            {
                walidacjaAdresE = true;
                flag = 1;
            }
            if (adresk == "")
            {
                walidacjaAdresK = true;
                if (flag == 1) { flag = 3; }
                else { flag = 2; }
            }
            int temp_id = Convert.ToInt32(txt_id.Text);
            if (walidacjaImie && walidacjaNazw && walidacjaTel && walidacjaPesel && walidacjaAdresE && walidacjaAdresK)
            {
                using (DostepPrac dp = new DostepPrac())
                {
                    var querry = from data in dp.Lokator
                                 orderby data.IdLokatora
                                 select data;
                    foreach (Lokator l in querry)
                    {
                        if (l.IdLokatora == temp_id)
                        {
                            l.Imie = imie;
                            l.Nazwisko = nazwisko;
                            l.Pesel = pesel;
                            l.Nr_Telefonu = nrTel;
                            if (flag == 1 && flag == 3) { l.Adres_Mailowy = null; } else { l.Adres_Mailowy = mail; }
                            if (flag == 2 && flag == 3) { l.Adres_Korespondecyjny = null; } else { l.Adres_Korespondecyjny = adresk; }

                        }
                    }
                    dp.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Nie spelniono zasad");
            }
        }

    }
}
