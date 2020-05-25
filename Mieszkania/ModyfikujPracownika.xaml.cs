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
    public partial class ModyfikujPracownika : Window
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
            //do czego przyrównac temp_id?
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
            }
        }

        private void btn_Modyfikuj_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            using(DostepPrac dp = new DostepPrac())
            {
                var q = from data in dp.Pracownicy
                             orderby data.IdPracownika
                             select data;
                foreach(Pracownicy p in q)
                {
                    if(p.IdPracownika == temp_id)
                    {
                        p.Imie = txt_imiePrac.Text;
                        p.Nazwisko = txt_nazPrac.Text;
                        p.NrTel = txt_telPrac.Text;
                    }
                }
                dp.SaveChanges();
            };
        }
    }
}
