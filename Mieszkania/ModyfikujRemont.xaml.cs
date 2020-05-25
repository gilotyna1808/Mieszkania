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
        public ModyfikujRemont()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WyswietlRemonty wr = new WyswietlRemonty();
            wr.ShowDialog();
            int temp_id = 0;
            //temp_id = 
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
                var q = from data in dp.Remonty
                        orderby data.IdRemontu
                        select data;
                foreach(Remonty r in q)
                {
                    if(r.IdRemontu == temp_id)
                    {
                        r.Stan = txt_stan.Text;
                        r.Koszt_Remontu = Convert.ToDecimal(txt_koszt.Text);
                        r.Data_Rozpoczecia = Convert.ToDateTime(txt_data_p.Text);
                        r.Data_Zakonczenia = Convert.ToDateTime(txt_data_k.Text);
                    }
                }
                dp.SaveChanges();
            };
        }
    }
}
