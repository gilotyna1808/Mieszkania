using System;
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

        public User(string log,int id,string imie="",string nazwisko="")
        {
            this.login = log;
            this.idPrac = id;
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
    }
}
