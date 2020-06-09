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
    /// Logika interakcji dla klasy DodajPracownikow.xaml
    /// </summary>
    public partial class DodajPracownika : UserControl
    {
        private DataGrid dg = new DataGrid();
        private bool test = false;
        private int temp = 0;
        public int id { get; set; }
        
        public DodajPracownika()
        {
            test = false;
            InitializeComponent();
            var dba = new DostepPrac();
            var querry =
               from a in dba.Stanowiska
               select new { a.IdStanowiska, a.Nazwa_Stanowiska };

            dataG.ItemsSource = querry.ToList();
            Dictionary<bool, string> d = new Dictionary<bool, string>();
            d.Add(true, "Tak");
            d.Add(false, "Nie");
            cbox_zatrudniony.ItemsSource = d;

        }
        public DodajPracownika(int x)
        {
            temp = x;
            InitializeComponent();
        }
        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Walidacja w = new Walidacja();
            string imie = txt_imiePrac.Text;
            string naz = txt_nazPrac.Text;
            string nrTelPrac = txt_telPrac.Text;
            string pesel = txt_Pesel.Text;
            string miasto = txt_miasto.Text;
            string adres = txt_adres.Text;
            bool imie_w=true, naz_w=true, nrT_w=true,pesel_w=true,miasto_w=true,adres_w=true;
            imie_w = w.sprawdzImie(imie);
            naz_w = w.sprawdzNazwisko(naz);
            nrT_w = w.sprawdzTelefon(nrTelPrac);
            pesel_w = w.SprawdzPesel(pesel);
            miasto_w = w.sprawdzMiasto(miasto);
            adres_w = w.SprawdzAdres(adres);
            if (imie_w && naz_w && nrT_w && pesel_w && miasto_w && adres_w)
            {
                using (var v = new DostepPrac())
                {
                    var p = new Pracownicy()
                    {
                        Imie = imie,
                        Nazwisko = naz,
                        NrTel = nrTelPrac,
                        Pesel = pesel,
                        Miasto_Zamieszkania = miasto,
                        Adres_Zamieszkania = adres,
                        IdStanowisko= Convert.ToInt32(cbox_stanowisko.SelectedValue),
                        Zatrudniony = Convert.ToBoolean(cbox_zatrudniony.SelectedValue)
                    };
                    v.Pracownicy.Add(p);
                    v.SaveChanges();
                    var i = v.Pracownicy.Where(s => s.Pesel == pesel);
                    int tempId = Convert.ToInt32(i.Select(s=>s.IdPracownika).FirstOrDefault());
                    var a = new Autoryzacja()
                    {
                        IdPracownika = tempId,
                        Login = pesel,
                        Haslo = naz
                    };
                    v.Autoryzacja.Add(a);
                    var flagaPowDod = v.SaveChanges();
                    if (flagaPowDod == 1)
                    {
                        MessageBox.Show("Dodawanie zakonczone pomyślnie");
                    }
                }
            }
            else
            {
                MessageBox.Show("Wprowadzono zle dane");
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            Dictionary<int, string> stan = new Dictionary<int, string>();
            for (int i = 0; i < dataG.Items.Count; i++)
            {
                DataGridRow dr = dataG.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                TextBlock id = dataG.Columns[0].GetCellContent(dr) as TextBlock;
                TextBlock nazwa = dataG.Columns[1].GetCellContent(dr) as TextBlock;
                stan.Add(Convert.ToInt32(id.Text), nazwa.Text);
            }
            if (test == false)
            {
                cbox_stanowisko.ItemsSource = stan;
                test = true;
            }
        }

        private void txt_imiePrac_TextChanged(object sender, TextChangedEventArgs e)
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

        private void txt_nazPrac_TextChanged(object sender, TextChangedEventArgs e)
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

        private void txt_telPrac_TextChanged(object sender, TextChangedEventArgs e)
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

        private void txt_Pesel_TextChanged(object sender, TextChangedEventArgs e)
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

        private void txt_miasto_TextChanged(object sender, TextChangedEventArgs e)
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

        private void txt_adres_TextChanged(object sender, TextChangedEventArgs e)
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
    }
}
