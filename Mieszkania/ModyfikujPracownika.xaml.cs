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
        public ModyfikujPracownika()
        {
            InitializeComponent();
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
                    txt_telPrac.Text = Convert.ToString(i.Select(s => s.NrTel).FirstOrDefault());
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
            bool imie_w = true, naz_w = true, nrT_w = true;
            imie_w = w.sprawdzImie(imie);
            naz_w = w.sprawdzNazwisko(naz);
            nrT_w = w.sprawdzTelefon(nrTelPrac);
            if (imie_w && naz_w && nrT_w)
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
                            p.Imie = txt_imiePrac.Text;
                            p.Nazwisko = txt_nazPrac.Text;
                            p.NrTel = txt_telPrac.Text;
                        }
                    }
                    dp.SaveChanges();
                };
            }
            else
            {
                MessageBox.Show("Wprowadzono zle dane");
            }
        }
    }
}
