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
                    txt_czynsz.Text = Convert.ToString(i.Select(s => s.Czynsz).FirstOrDefault());
                    txt_do_kiedy.Text = Convert.ToString(i.Select(s => s.Do_Kiedy).FirstOrDefault());
                    txt_od_kiedy.Text = Convert.ToString(i.Select(s => s.Do_Kiedy).FirstOrDefault());
                    txt_termin_roz.Text = Convert.ToString(i.Select(s => s.Termin_Rozliczenia).FirstOrDefault());
                    txt_idL.Text = Convert.ToString(i.Select(s => s.IdLokatora).FirstOrDefault());
                    txt_idM.Text = Convert.ToString(i.Select(s => s.IdMieszkania).FirstOrDefault());
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            Walidacja w = new Walidacja();
            bool walidacjaCzynsz, walidacjaOplaty, walidacjaDataP, walidacjaDataK, walidacjaDataR, walidacjaIdM, walidacjaIdL;
            string czynsz_s, oplaty_s, dataP_s, dataK_s, dataR_s, idM_s, idL_s;
            czynsz_s = txt_czynsz.Text;
            oplaty_s = txt_coplaty.Text;
            dataP_s = txt_od_kiedy.Text;
            dataK_s = txt_do_kiedy.Text;
            dataR_s = txt_termin_roz.Text;
            idL_s = txt_idL.Text;
            idM_s = txt_idM.Text;
            walidacjaCzynsz = w.sprawdzCzynsz(czynsz_s);
            walidacjaOplaty = w.sprawdzOplaty(oplaty_s);
            walidacjaDataP = w.sprawdzDate(dataP_s);
            walidacjaDataK = w.sprawdzDate(dataK_s);
            walidacjaDataR = w.sprawdzDate(dataR_s);
            walidacjaIdL = w.sprawdzId(idL_s);
            walidacjaIdM = w.sprawdzId(idM_s);
            if (walidacjaCzynsz && walidacjaOplaty && walidacjaDataP && walidacjaDataK && walidacjaDataR && walidacjaIdM && walidacjaIdL)
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
                            u.Czynsz = Convert.ToDecimal(txt_czynsz.Text);
                            u.Oplaty_Stale = Convert.ToDecimal(txt_coplaty.Text);
                            u.Od_Kiedy = Convert.ToDateTime(txt_od_kiedy.Text);
                            u.Do_Kiedy = Convert.ToDateTime(txt_do_kiedy.Text);
                            u.Termin_Rozliczenia = Convert.ToDateTime(txt_termin_roz.Text);
                        }
                    }
                    dp.SaveChanges();
                };
            }
            else
            {
                MessageBox.Show("Zle wprowadzone dane");
            }
        }
    }
}
