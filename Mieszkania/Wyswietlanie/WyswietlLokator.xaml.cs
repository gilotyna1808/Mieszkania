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
    /// Logika interakcji dla klasy WyswietlLokator.xaml
    /// </summary>
    public partial class WyswietlLokator : Window
    {
        public int id_w_l { get; set; }
        public WyswietlLokator()
        {
            InitializeComponent();
            id_w_l = 0;
            var dba = new DostepPrac();
            var querry =
               from a in dba.Lokator
               select new {a.IdLokatora,a.Imie,a.Nazwisko,a.Nr_Telefonu};
            dataG.ItemsSource = querry.ToList();
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if (dataG.SelectedItems.Count > 0)
            {
                string tes = Convert.ToString(dataG.Items.GetItemAt(dataG.SelectedIndex));
                tes = (tes.Substring(14, 2)).TrimEnd(',');
                id_w_l = Convert.ToInt32(tes);
            }
            this.Close();
        }
    }
}
