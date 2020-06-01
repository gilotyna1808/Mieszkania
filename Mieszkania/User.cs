﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mieszkania
{
    public class User
    {
        private string login,imie,nazwisko;
        private int idPrac;
        private bool aktywny;

        public User(string log,int id,bool aktywny,string imie="",string nazwisko="")
        {
            this.login = log;
            this.idPrac = id;
            this.aktywny = aktywny;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public int getIdPrac()
        {
            return this.idPrac;
        }

        public string getLogin()
        {
            return this.login;
        }
        public string getImie()
        {
            return this.imie;
        }

        public string getNazwisko()
        {
            return this.nazwisko;
        }

        public bool getAktywny()
        {
            return this.aktywny;
        }
    }
}
