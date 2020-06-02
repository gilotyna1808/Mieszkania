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
    /// Logika interakcji dla klasy WyswietlUmowy.xaml
    /// </summary>
    public partial class Kon_WyswietlUmowy : UserControl
    {
        public int id_w_u { get; set; }
        public Kon_WyswietlUmowy()
        {
            InitializeComponent();
           var dba = new DostepPrac();
           var querry =
              from a in dba.Umowa
              select new {a.IdUmowy,a.Od_Kiedy,a.Do_Kiedy,a.Stawka_Czynsz,a.Oplaty_Stale,a.IdMieszkania,a.IdLokatora};
           dataG.ItemsSource = querry.ToList();
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if (dataG.SelectedItems.Count > 0)
            {
                string tes = Convert.ToString(dataG.Items.GetItemAt(dataG.SelectedIndex));
                tes = (tes.Substring(11, 3)).TrimEnd(',');
                id_w_u = Convert.ToInt32(tes);
            }
        }
    }
}
