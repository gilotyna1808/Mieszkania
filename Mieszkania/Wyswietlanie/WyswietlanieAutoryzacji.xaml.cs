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
    /// Logika interakcji dla klasy WyswietlanieAutoryzacji.xaml
    /// </summary>
    public partial class WyswietlanieAutoryzacji : Window
    {
        public int id_w_a { get; set; }
        public WyswietlanieAutoryzacji()
        {
            InitializeComponent();
            var dba = new DostepPrac();
            var querry =
               from a in dba.Autoryzacja
               select new { a.IdPracownika,a.Login,a.Haslo,a.Aktywne };
            dataG.ItemsSource = querry.ToList();
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if (dataG.SelectedItems.Count == 1)
            {
                DataGridRow dr = dataG.ItemContainerGenerator.ContainerFromIndex(dataG.SelectedIndex) as DataGridRow;
                DataGridColumn dc = dataG.Columns[0];
                TextBlock cell = dc.GetCellContent(dr) as TextBlock;
                id_w_a = Convert.ToInt32(cell.Text);
            }
            this.Close();
        }
    }
}
