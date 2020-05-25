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

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy Powitanie.xaml
    /// </summary>
    public partial class Powitanie : UserControl
    {
        public Powitanie(User u)
        {
            InitializeComponent();
            lbl1.Content = u.getImie();
            lbl2.Content = u.getNazwisko();
        }
    }
}
