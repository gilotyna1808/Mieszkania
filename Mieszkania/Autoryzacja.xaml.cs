﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data.Entity.Core.Objects;
namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy Autoryzacja.xaml
    /// </summary>dd
    public partial class Autoryzacja : Window
    {
        DostepAut dostepM = new DostepAut();
        public User uzytkownik { get; set; }
        public Autoryzacja()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string log = Convert.ToString(autLogin.Text);
            string pass = Convert.ToString(autPass.Password);
            int id;
            string im="", naz="";
            var querry =
                from a in dostepM.Autoryzacja
                where (a.Login == log && a.Haslo == pass)
                select new { a.Haslo, a.IdPracownika };
            if (querry.Count() == 1)
            {
                id = ((Convert.ToInt32(querry.ToList().Last().IdPracownika)));
                
                this.Close();
                using (var com = new DostepPrac())
                {
                    var i = com.Pracownicy.Where(s => s.IdPracownika == id);
                    im= Convert.ToString(i.Select(s => s.Imie).FirstOrDefault());
                    naz = Convert.ToString(i.Select(s => s.Nazwisko).FirstOrDefault());
                }
                uzytkownik = new User(log, id,im,naz);
            }

            else
            {
                MessageBox.Show("Podano zle dane logowania");
            }
        }
    }
}
