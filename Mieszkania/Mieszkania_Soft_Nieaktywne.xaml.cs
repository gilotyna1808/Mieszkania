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
    /// Logika interakcji dla klasy Mieszkania_Soft_Nieaktywne.xaml
    /// </summary>
    public partial class Mieszkania_Soft_Nieaktywne : Window
    {
        public Mieszkania_Soft_Nieaktywne(User u)
        {
            InitializeComponent();
            l1.Content = u.getImie();
            l2.Content = u.getNazwisko();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
