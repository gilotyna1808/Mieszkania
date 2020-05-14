﻿using System;
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
            Autoryzacja aut = new Autoryzacja();
            aut.ShowDialog();
            uzytkownik = aut.uzytkownik;
            if (uzytkownik != null)
            {
                Mieszkania_Soft prog = new Mieszkania_Soft(uzytkownik);
                prog.Show();
                this.Close();
            }
        }
    }
}
