using Mieszkania.Wyswietlanie;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy UsunLokatora.xaml
    /// </summary>
    /// 
    public partial class UsunLokatora : UserControl
    {
        User uzytkownik;
        public UsunLokatora(User u)
        {
            uzytkownik = u;
            InitializeComponent();
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlLokator wl = new WyswietlLokator(uzytkownik);
            wl.ShowDialog();
            int temp_id = 0;
            temp_id = wl.id_w_l;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
            }
        }

        private void btn_Usun_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            DostepPrac dp = new DostepPrac();
            var q = from data in dp.Lokator
                    orderby data.IdLokatora
                    select data;
            foreach (Lokator l in q)
            {
                if (l.IdLokatora == temp_id)
                {
                    dp.Lokator.Remove(l);
                }
            }
            dp.SaveChanges();

            /*  using (DostepPrac dp = new DostepPrac())
            {
                var q = from data in dp.Lokator
                        orderby data.IdLokatora
                        select data;
                dp.Lokator.DeleteAllOnSubmit(data);
                foreach (Lokator l in q)
                {
                    if (l.IdLokatora == temp_id)
                    {
                        
                       // SqlCommand polecenie = new SqlCommand("DELETE FROM LOKATOR WHERE IdLokatora");
                      //  DeletedRowInaccessibleException.ReferenceEquals(temp_id, l.IdLokatora);
                    } 
                }
                dp.SaveChanges();

            };*/

        }
    }
}
