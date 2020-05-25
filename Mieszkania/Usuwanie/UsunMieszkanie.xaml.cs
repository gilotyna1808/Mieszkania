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
        User uzytkownik;
        public UsunMieszkanie(User u)
        {
            uzytkownik = u;
            InitializeComponent();
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlMieszkania wm = new WyswietlMieszkania(uzytkownik);
            wm.ShowDialog();
            int temp_id = 0;
            temp_id = wm.id_w_m;
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

        public static implicit operator UsunMieszkanie(UsunLokatora v)
        {
            throw new NotImplementedException();
        }
    }
}
