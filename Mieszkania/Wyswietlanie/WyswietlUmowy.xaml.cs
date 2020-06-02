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
    public partial class WyswietlUmowy : Window
    {
        public int id_w_u { get; set; }
        public WyswietlUmowy()
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
            if (dataG.SelectedItems.Count == 1)
            {
                DataGridRow dr = dataG.ItemContainerGenerator.ContainerFromIndex(dataG.SelectedIndex) as DataGridRow;
                DataGridColumn dc = dataG.Columns[0];
                TextBlock cell = dc.GetCellContent(dr) as TextBlock;
                id_w_u = Convert.ToInt32(cell.Text);
            }
            this.Close();
        }
    }
}
