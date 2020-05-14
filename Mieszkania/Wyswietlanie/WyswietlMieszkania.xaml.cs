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

namespace Mieszkania.Wyswietlanie
{
    /// <summary>
    /// Logika interakcji dla klasy WyswietlMieszkania.xaml
    /// </summary>
    public partial class WyswietlMieszkania : Window
    {
        public int id_w_m { get; set; }
        public WyswietlMieszkania()
        {
            InitializeComponent();
            id_w_m = 0;
            var dba = new DostepPrac();
            var querry =
               from a in dba.Mieszkanie
               select new { a.IdMieszkania, a.Kod_Pocztowy, a.Miasto, a.Mieszkanie1, a.Nr_Domu, a.Status_Mieszkania, a.Ulica };
            dataG.ItemsSource = querry.ToList();
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if (dataG.SelectedItems.Count > 0)
            {
                string tes = Convert.ToString(dataG.Items.GetItemAt(dataG.SelectedIndex));
                tes = (tes.Substring(17, 2)).TrimEnd(',');
                id_w_m = Convert.ToInt32(tes);
            }
            this.Close();
        }
    }
}
