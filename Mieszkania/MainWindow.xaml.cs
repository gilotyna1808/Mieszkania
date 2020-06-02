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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_mainLog_Click(object sender, RoutedEventArgs e)
        {
            User uzytkownik=null;
            AutoryzacjaO aut = new AutoryzacjaO();
            aut.ShowDialog();
            uzytkownik = aut.uzytkownik;
            if (uzytkownik != null)
            {
                if (uzytkownik.getAktywny()) 
                {
                    if (uzytkownik.getIdStanowiska()==1)
                    {
                        Mieszkania_Soft_Administrator prog = new Mieszkania_Soft_Administrator(uzytkownik);
                        prog.Show();
                        this.Close();
                    }
                    else
                    {
                        Mieszkania_Soft_Pracownik prog = new Mieszkania_Soft_Pracownik(uzytkownik);
                        prog.Show();
                        this.Close();
                    }
                    
                }
                else
                {
                    Mieszkania_Soft_Nieaktywne prog = new Mieszkania_Soft_Nieaktywne(uzytkownik);
                    prog.Show();
                    this.Close();
                }
                
            }
        }
    }
}
