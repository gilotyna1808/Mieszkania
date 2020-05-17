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

namespace Mieszkania.Wyswietlanie
{
    /// <summary>
    /// Logika interakcji dla klasy ModyfikujMieszkania.xaml
    /// </summary>
    public partial class ModyfikujMieszkania : UserControl
    {
        public ModyfikujMieszkania()
        {
            InitializeComponent();
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlMieszkania wm = new WyswietlMieszkania();
            wm.ShowDialog();
            int temp_id = 0;
            temp_id = wm.id_w_m;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
            }
        }

        private void btn_zmien_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            using(DostepPrac dp = new DostepPrac())
            {
                var querry = from data in dp.Mieszkanie
                             orderby data.IdMieszkania
                             select data;
                foreach(Mieszkanie m in querry)
                {
                    if(m.IdMieszkania == temp_id)
                    {
                        if ((bool)(c_miast.IsChecked)) m.Miasto = txt_miasto.Text;
                        if ((bool)c_kod.IsChecked) m.Kod_Pocztowy = txt_kod.Text;
                        if ((bool)c_ul.IsChecked) m.Ulica = txt_ul.Text;
                        if ((bool)c_nr.IsChecked) m.Nr_Domu = txt_nr.Text;
                        if ((bool)c_miesz.IsChecked) m.Mieszkanie1 = txt_miesz.Text;
                        if ((bool)c_status.IsChecked) m.Status_Mieszkania = txt_status.Text;
                    }
                }
                dp.SaveChanges();
            }
        }
    }
}
