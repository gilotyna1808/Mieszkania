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
    /// Logika interakcji dla klasy WyswietlPrac.xaml
    /// </summary>
    public partial class WyswietlPrac : Window
    {
        public int id_w_p { get; set; }
        public WyswietlPrac()
        {
            InitializeComponent();
            var dba = new DostepPrac();
            var querry =
               from a in dba.Pracownicy
               select new {a.IdPracownika,a.Imie,a.Nazwisko,a.NrTel };
            dataG.ItemsSource = querry.ToList();
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if(dataG.SelectedItems.Count == 1)
            {
                DataGridRow dr = dataG.ItemContainerGenerator.ContainerFromIndex(dataG.SelectedIndex) as DataGridRow;
                DataGridColumn dc = dataG.Columns[0];
                TextBlock cell = dc.GetCellContent(dr) as TextBlock;
                id_w_p = Convert.ToInt32(cell.Text);
            }
            this.Close();
        }
    }
}
