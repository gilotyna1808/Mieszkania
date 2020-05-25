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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy UsunMieszkanie.xaml
    /// </summary>
    public partial class UsunMieszkanie : UserControl
    {
        public UsunMieszkanie()
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

        private void btn_Usun_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            DostepPrac dp = new DostepPrac();
            var q = from data in dp.Mieszkanie
                    orderby data.IdMieszkania
                    select data;
            foreach (Mieszkanie m in q)
            {
                if (m.IdMieszkania == temp_id)
                {
                    dp.Mieszkanie.Remove(m);
                }
            }
            dp.SaveChanges();

        }
    }
}
