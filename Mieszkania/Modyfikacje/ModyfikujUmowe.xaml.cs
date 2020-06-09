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
    /// Logika interakcji dla klasy ModyfikujUmowe.xaml
    /// </summary>
    public partial class ModyfikujUmowe : UserControl
    {
        public ModyfikujUmowe()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WyswietlUmowy wu = new WyswietlUmowy();
            wu.ShowDialog();
            int temp_id = 0;
            temp_id = wu.id_w_u;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
                using (var com = new DostepPrac())
                {
                    var i = com.Umowa.Where(s => s.IdUmowy == temp_id);
                    txt_coplaty.Text = Convert.ToString(i.Select(s => s.Oplaty_Stale).FirstOrDefault());
                    txt_czynsz.Text = Convert.ToString(i.Select(s => s.Stawka_Czynsz).FirstOrDefault());
                    txt_od_kiedy.Text = Convert.ToString(i.Select(s => s.Od_Kiedy).FirstOrDefault());
                    txt_do_kiedy.Text = Convert.ToString(i.Select(s => s.Do_Kiedy).FirstOrDefault());
                    txt_idL.Text = Convert.ToString(i.Select(s => s.IdLokatora).FirstOrDefault());
                    txt_idM.Text = Convert.ToString(i.Select(s => s.IdMieszkania).FirstOrDefault());
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            Walidacja w = new Walidacja();
            bool walidacjaCzynsz, walidacjaOplaty, walidacjaDataP, walidacjaDataK, walidacjaIdM, walidacjaIdL;
            string czynsz_s, oplaty_s, dataP_s, dataK_s, idM_s, idL_s;
            czynsz_s = txt_czynsz.Text;
            oplaty_s = txt_coplaty.Text;
            dataP_s = txt_od_kiedy.Text;
            dataK_s = txt_do_kiedy.Text;
            idL_s = txt_idL.Text;
            idM_s = txt_idM.Text;
            walidacjaCzynsz = w.sprawdzCzynsz(czynsz_s);
            walidacjaOplaty = w.sprawdzOplaty(oplaty_s);
            walidacjaDataP = w.sprawdzDate(dataP_s);
            walidacjaDataK = w.sprawdzDate(dataK_s);
            walidacjaIdL = w.sprawdzId(idL_s);
            walidacjaIdM = w.sprawdzId(idM_s);
            if (txt_do_kiedy.Text == "")
            {
                walidacjaDataK = true;
            }
            
            if (walidacjaCzynsz && walidacjaOplaty && walidacjaDataP && walidacjaDataK && walidacjaIdM && walidacjaIdL)
            {
                using (DostepPrac dp = new DostepPrac())
                {
                    var q = from data in dp.Umowa
                            orderby data.IdUmowy
                            select data;

                    foreach (Umowa u in q)
                    {
                        if (u.IdUmowy == temp_id)
                        {
                            u.Stawka_Czynsz = Convert.ToDecimal(txt_czynsz.Text);
                            u.Oplaty_Stale = Convert.ToDecimal(txt_coplaty.Text);
                            u.Od_Kiedy = Convert.ToDateTime(txt_od_kiedy.Text);
                            if(txt_do_kiedy.Text != "")
                            {
                                u.Do_Kiedy = Convert.ToDateTime(txt_do_kiedy.Text);
                            }
                            else
                            {
                                u.Do_Kiedy = null;
                            }
                            
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
                MessageBox.Show("Zle wprowadzone dane");
            }
        }

        private void txt_czynsz_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzCzynsz(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_coplaty_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzOplaty(x.Text))
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
