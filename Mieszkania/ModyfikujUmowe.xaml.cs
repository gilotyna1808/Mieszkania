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
    public partial class ModyfikujUmowe : Window
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
            //   temp_id = 
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            using (DostepPrac dp = new DostepPrac())
            {
                var q = from data in dp.Umowa
                        orderby data.IdUmowy
                        select data;

                foreach(Umowa u in q)
                {
                    if(u.IdUmowy == temp_id)
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
    }
}
