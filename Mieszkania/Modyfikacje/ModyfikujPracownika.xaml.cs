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
    /// Logika interakcji dla klasy ModyfikujPracownika.xaml
    /// </summary>
    public partial class ModyfikujPracownika : UserControl
    {
        private DataGrid dg = new DataGrid();
        private bool test = false;
        public ModyfikujPracownika()
        {
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

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlPrac wp = new WyswietlPrac();
            wp.ShowDialog();
            int temp_id = 0;
            temp_id = wp.id_w_p;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
                using (var com = new DostepPrac())
                {
                    var i = com.Pracownicy.Where(s => s.IdPracownika == temp_id);
                    txt_imiePrac.Text = Convert.ToString(i.Select(s => s.Imie).FirstOrDefault());
                    txt_nazPrac.Text = Convert.ToString(i.Select(s => s.Nazwisko).FirstOrDefault());
                    txt_Pesel.Text = Convert.ToString(i.Select(s => s.Pesel).FirstOrDefault());
                    txt_telPrac.Text = Convert.ToString(i.Select(s => s.NrTel).FirstOrDefault());
                    txt_miasto.Text = Convert.ToString(i.Select(s => s.Miasto_Zamieszkania).FirstOrDefault());
                    txt_adres.Text = Convert.ToString(i.Select(s => s.Adres_Zamieszkania).FirstOrDefault());
                    cbox_stanowisko.SelectedValue=Convert.ToInt32(i.Select(s => s.IdStanowisko).FirstOrDefault());
                    cbox_zatrudniony.SelectedValue = Convert.ToBoolean(i.Select(s => s.Zatrudniony).FirstOrDefault());
                }
                }
        }

        private void btn_Modyfikuj_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            Walidacja w = new Walidacja();
            string imie = txt_imiePrac.Text;
            string naz = txt_nazPrac.Text;
            string nrTelPrac = txt_telPrac.Text;
            string pesel = txt_Pesel.Text;
            string miasto = txt_miasto.Text;
            string adres = txt_adres.Text;
            bool imie_w = true, naz_w = true, nrT_w = true, pesel_w = true, miasto_w = true, adres_w = true;
            imie_w = w.sprawdzImie(imie);
            naz_w = w.sprawdzNazwisko(naz);
            nrT_w = w.sprawdzTelefon(nrTelPrac);
            pesel_w = w.SprawdzPesel(pesel);
            miasto_w = w.sprawdzMiasto(miasto);
            adres_w = w.SprawdzAdres(adres);
            if (imie_w && naz_w && nrT_w && pesel_w && miasto_w && adres_w)
            {
                using (DostepPrac dp = new DostepPrac())
                {
                    var q = from data in dp.Pracownicy
                            orderby data.IdPracownika
                            select data;
                    foreach (Pracownicy p in q)
                    {
                        if (p.IdPracownika == temp_id)
                        {
                            p.Imie = imie;
                            p.Nazwisko = naz;
                            p.NrTel = nrTelPrac;
                            p.Pesel = pesel;
                            p.Miasto_Zamieszkania = miasto;
                            p.Adres_Zamieszkania = adres;
                            p.IdStanowisko = Convert.ToInt32(cbox_stanowisko.SelectedValue);
                            p.Zatrudniony = Convert.ToBoolean(cbox_zatrudniony.SelectedValue);
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
