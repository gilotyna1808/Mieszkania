﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy DodajMieszkanie.xaml
    /// </summary>
    public partial class DodajMieszkanie : UserControl
    {
        
       
        public DodajMieszkanie()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Walidacja w = new Walidacja();
            bool walidacjaMiasto,walidacjaMieszkanie,walidacjaNrDomu,walidacjaUlica,walidacjaStatus,walidacjaKod;
            string miasto, mieszkanie,nrDomu, ulica, status, kodPocztowy;
            miasto = txt_Miasto.Text;
            mieszkanie = txt_Mieszkanie.Text;
            nrDomu = txt_Nr.Text;
            ulica = txt_Ul.Text;
            status = txt_status.Text;
            kodPocztowy = txt_Kod.Text;
            walidacjaMiasto = w.sprawdzMiasto(miasto);
            walidacjaMieszkanie = w.sprawdzMiasto(mieszkanie);//Specjalnie spradzane jak miasto Pole do mozliwego usuniecia
            walidacjaNrDomu = w.sprawdzNrDomu(nrDomu);
            walidacjaUlica = w.sprawdzUlice(ulica);
            walidacjaStatus = w.sprawdzStatusMieszkanie(status);
            walidacjaKod = w.sprawdzKodPocztowy(kodPocztowy);
            if (walidacjaMiasto && walidacjaMieszkanie && walidacjaNrDomu && walidacjaUlica && walidacjaStatus && walidacjaKod) {
                using (var db = new DostepPrac())
                {
                    var m = new Mieszkanie()
                    {
                        Miasto=miasto,
                        Nr_Mieszkania=mieszkanie,
                        Nr_Domu=nrDomu,
                        Ulica=ulica,
                        Status_Mieszkania=status,
                        Kod_Pocztowy=kodPocztowy
                    };
                    db.Mieszkanie.Add(m);
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Nie spelniono wymagan");
            }
            //Do testów 
            /*var dba = new DostepPrac();
            var querry =
               from a in dba.Mieszkanie
               select new {a.IdMieszkania,a.Kod_Pocztowy,a.Miasto,a.Mieszkanie1,a.Nr_Domu,a.Status_Mieszkania,a.Ulica};
            dataG.ItemsSource = querry.ToList();*/
        }
    }
}