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
    /// Logika interakcji dla klasy ModyfikujRemont.xaml
    /// </summary>
    public partial class ModyfikujRemont : UserControl
    {
        User uzytkownik;
        public ModyfikujRemont(User u)
        {
            uzytkownik = u;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WyswietlRemonty wr = new WyswietlRemonty(uzytkownik);
            wr.ShowDialog();
            int temp_id = 0;
            temp_id = wr.id_w_r;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
                using (var com = new DostepPrac())
                {
                    var i = com.Remonty.Where(s => s.IdRemontu == temp_id);
                    txt_stan.Text = Convert.ToString(i.Select(s => s.Stan).FirstOrDefault());
                    txt_data_p.Text = Convert.ToString(i.Select(s => s.Data_Rozpoczecia).FirstOrDefault());
                    txt_data_k.Text = Convert.ToString(i.Select(s => s.Data_Zakonczenia).FirstOrDefault());
                    txt_koszt.Text = Convert.ToString(i.Select(s => s.Koszt_Remontu).FirstOrDefault());
                    txt_idM.Text = Convert.ToString(i.Select(s => s.IdMieszkania).FirstOrDefault());
                }
                }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            Walidacja w = new Walidacja();
            bool walidacjaKoszt, walidacjaStan, walidacjaDataP, walidacjaDataK, walidacjaIdM;
            string koszt_s, stan, dataP_s, dataK_s, IdM_s;
            koszt_s = txt_koszt.Text;
            stan = txt_stan.Text;
            dataP_s = txt_data_p.Text;
            dataK_s = txt_data_k.Text;
            IdM_s = txt_idM.Text;
            walidacjaKoszt = w.sprawdzKosztRemontu(koszt_s);
            walidacjaStan = w.sprawdzStanRemont(stan);
            walidacjaDataP = w.sprawdzDate(dataP_s);
            walidacjaDataK = w.sprawdzDate(dataK_s);
            walidacjaIdM = w.sprawdzId(IdM_s);
            if (walidacjaKoszt && walidacjaStan && walidacjaDataP && walidacjaDataK && walidacjaIdM)
            {
                using (DostepPrac dp = new DostepPrac())
                {
                    var q = from data in dp.Remonty
                            orderby data.IdRemontu
                            select data;
                    foreach (Remonty r in q)
                    {
                        if (r.IdRemontu == temp_id)
                        {
                            r.Stan = txt_stan.Text;
                            r.Koszt_Remontu = Convert.ToDecimal(txt_koszt.Text);
                            r.Data_Rozpoczecia = Convert.ToDateTime(txt_data_p.Text);
                            r.Data_Zakonczenia = Convert.ToDateTime(txt_data_k.Text);
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
