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
        public ModyfikujLokatora()
        {
            InitializeComponent();
        }
        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlLokator wl = new WyswietlLokator();
            wl.ShowDialog();
            int temp_id = 0;
            temp_id = wl.id_w_l;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
                using (var com = new DostepPrac())
                {
                    var i = com.Lokator.Where(s => s.IdLokatora == temp_id);
                    txt_imieLok.Text = Convert.ToString(i.Select(s => s.Imie).FirstOrDefault());
                    txt_nazLok.Text = Convert.ToString(i.Select(s => s.Nazwisko).FirstOrDefault());
                    txt_telLok.Text= Convert.ToString(i.Select(s => s.NrTelefonu).FirstOrDefault());

                }
            }
        }
        private void btn_Modyfikuj_Click(object sender, RoutedEventArgs e)
        {
            Walidacja w = new Walidacja();
            int temp_id = Convert.ToInt32(txt_id.Text);
            string imie=txt_imieLok.Text;
            string naz= txt_nazLok.Text;
            string nrT= txt_telLok.Text;
            bool imie_w = true, nazw_w = true, nrT_w = true, id_w = true;
            imie_w = w.sprawdzImie(imie);
            nazw_w = w.sprawdzNazwisko(naz);
            nrT_w = w.sprawdzTelefon(nrT);
            id_w = w.sprawdzId(txt_id.Text);
            if (imie_w && nazw_w && nrT_w && id_w) {
                using (DostepPrac dp = new DostepPrac())
                {
                    var q = from data in dp.Lokator
                            orderby data.IdLokatora
                            select data;
                    foreach (Lokator l in q)
                    {
                        if (l.IdLokatora == temp_id)
                        {
                            l.Imie = imie;
                            l.Nazwisko = naz;
                            l.NrTelefonu = nrT;
                        }
                    }
                    dp.SaveChanges();
                };
            }
            else
            {
                MessageBox.Show("Wprowadzono nieprawidłowe dane");
            }
        }

    }
}
