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
    /// Logika interakcji dla klasy WyswietlRemonty.xaml
    /// </summary>
    public partial class Kon_WyswietlRemonty : UserControl
    {
        public int id_w_r { get; set; }
        public Kon_WyswietlRemonty()
        {
            InitializeComponent();
            var dba = new DostepPrac();
            var querry =
               from a in dba.Remonty
               select new {a.IdRemontu ,a.IdMieszkania,a.Koszt_Remontu,a.Stan,a.Data_Rozpoczecia,a.Data_Zakonczenia};
            dataG.ItemsSource = querry.ToList();
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if (dataG.SelectedItems.Count > 0)
            {
                string tes = Convert.ToString(dataG.Items.GetItemAt(dataG.SelectedIndex));
                tes = (tes.Substring(13, 3)).TrimEnd(',');
                id_w_r = Convert.ToInt32(tes);
            }
        }
    }
}
