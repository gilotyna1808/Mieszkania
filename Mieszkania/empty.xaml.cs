using Mieszkania.Dodawanie;
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
    /// Logika interakcji dla klasy empty.xaml
    /// </summary>
    public partial class empty : Window
    {
        public int id { get; set; }
        public empty()
        {
            InitializeComponent();
        }

        public empty(string s)
        {
            id = 0;
            InitializeComponent();
            if (s == "lokator")
            {
                DodajLokatora dodajLokatora = new DodajLokatora(1);
                panel.Children.Add(dodajLokatora);
                id = dodajLokatora.id;

            }
        }
    }
}
