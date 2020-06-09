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
    /// Logika interakcji dla klasy DodajLokatora.xaml
    /// </summary>
    public partial class DodajLokatora : UserControl
    {
        private int temp = 0;
        public int id { get; set; }
        public DodajLokatora()
        {
            InitializeComponent();
        }

        public DodajLokatora(int x)
        {
            temp = x;
            InitializeComponent();
        }

        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            var flagaPowDod=1;
            Walidacja w= new Walidacja();
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
                else {flag = 2; }
            } 
            if (walidacjaImie && walidacjaNazw && walidacjaTel && walidacjaPesel && walidacjaAdresE && walidacjaAdresK)
            {
                using (var db = new DostepPrac())
                {
                    if (flag == 0)
                    {
                        var m = new Lokator()
                        {
                            Imie = imie,
                            Nazwisko = nazwisko,
                            Nr_Telefonu = nrTel,
                            Pesel = pesel,
                            Adres_Korespondecyjny = adresk,
                            Adres_Mailowy = mail
                        };
                        db.Lokator.Add(m);
                        flagaPowDod=db.SaveChanges();
                    }
                    else if (flag == 1)
                    {
                        var m = new Lokator()
                        {
                            Imie = imie,
                            Nazwisko = nazwisko,
                            Nr_Telefonu = nrTel,
                            Pesel = pesel,
                            Adres_Korespondecyjny = adresk,
                            Adres_Mailowy = null
                        };
                        db.Lokator.Add(m);
                        flagaPowDod=db.SaveChanges();
                    }
                    else if (flag == 2)
                    {
                        var m = new Lokator()
                        {
                            Imie = imie,
                            Nazwisko = nazwisko,
                            Nr_Telefonu = nrTel,
                            Pesel = pesel,
                            Adres_Korespondecyjny = null,
                            Adres_Mailowy = mail
                        };
                        db.Lokator.Add(m);
                        flagaPowDod=db.SaveChanges();
                    }
                    else if(flag==3){
                        var m = new Lokator()
                        {
                            Imie = imie,
                            Nazwisko = nazwisko,
                            Nr_Telefonu = nrTel,
                            Pesel = pesel,
                            Adres_Korespondecyjny = null,
                            Adres_Mailowy = null
                        };
                        db.Lokator.Add(m);
                        flagaPowDod = db.SaveChanges();
                        
                    }
                    if (flagaPowDod == 1)
                    {
                        MessageBox.Show("Dodawanie zakonczone pomyślnie");
                    }
                   
                }
                if (temp == 1)
                {
                    var db = new DostepPrac();
                    var querry =
                    from a in db.Lokator
                    where (a.Imie == imie && a.Nazwisko == nazwisko && a.Nr_Telefonu == nrTel)
                    select new { a.IdLokatora };
                    if (querry.Count() == 1)
                    {
                        id = ((Convert.ToInt32(querry.ToList().Last().IdLokatora)));
                    }
                }
            }
            else
            {
                MessageBox.Show("Nie spelniono zasad");
            }
        }

        private void txt_imie_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzImie(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_naz_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzNazwisko(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_tel_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzTelefon(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_pesel_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.SprawdzPesel(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_adresk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.SprawdzAdres(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.SprawdzAdresEmail(x.Text))
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
