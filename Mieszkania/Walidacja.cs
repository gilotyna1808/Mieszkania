using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Mieszkania
{
    class Walidacja
    {
        public bool SpradzCzyZaDlugie(string text, int maxDlugosc)
        {
            if (text.Length <= maxDlugosc) return true;
            return false;
        }
        public bool sprawdzImie(string s)
        {
            Regex imie= new Regex(@"^[A-z]+$");
            if (imie.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzNazwisko(string s)
        {
            Regex nazw = new Regex(@"^([A-z]+.?)+$");
            if (nazw.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzTelefon(string s)
        {
            Regex tel = new Regex(@"^[+]?[0-9]{9,12}$");
            if (tel.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzMiasto(string s)
        {
            //Regex miasto = new Regex(@".{1,45}");
            if (SpradzCzyZaDlugie(s, 45))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzNrDomu(string s)
        {
           Regex nrDomu = new Regex(@"^[A-z]*[0-9]+[A-z]*$");
            if (nrDomu.IsMatch(s))
            {
                return true;
            }
            return false;
        }
        public bool sprawdzUlice(string s)
        {
            //Regex ulica = new Regex(@".{1,45}");
            if (SpradzCzyZaDlugie(s,45))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzStatusMieszkanie(string s)
        {
            //Regex mieszkanie = new Regex(@".{1,45}");
            if (SpradzCzyZaDlugie(s, 45))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzKodPocztowy(string s)
        {
            Regex kod = new Regex(@"^[0-9]{2}-[0-9]{3}$");
            if (kod.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzCzynsz(string s)
        {
            Regex czynsz = new Regex(@"^[0-9]+\,?[0-9]{1,2}[0]{0,2}$");
            if (czynsz.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzOplaty(string s)
        {
            Regex oplaty = new Regex(@"^[0-9]+[\,]?[0-9]{1,2}[0]{0,2}$");
            if (oplaty.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzDate(string s)
        {
            Regex data = new Regex(@"^[0-9]{1,2}[\.][0-9]{1,2}[\.][0-9]{4}$");
            if (data.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzId(string s)
        {
            Regex id = new Regex(@"^[0-9]+$");
            if (id.IsMatch(s))
            {
                return true;
            }
            return false;
        }
        public bool sprawdzKosztRemontu(string s)
        {
            Regex koszt = new Regex(@"^[0-9]+[\,]?[0-9]{1,2}$");
            if (koszt.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzStanRemont(string s)
        {
            //Regex stan = new Regex(@"^[0-9]+$");
            if (SpradzCzyZaDlugie(s,45))
            {
                return true;
            }
            return false;
        }

        public bool SprawdzPesel(string s)
        {
            Regex pesel = new Regex(@"^[0-9]{11}$");
            if(pesel.IsMatch(s)) return true;
            else return false;
        }

        public bool SprawdzAdres(string s)
        {
            if (SpradzCzyZaDlugie(s, 45))
            {
                return true;
            }
            return false;
        }

        public bool SprawdzAdresEmail(string s)
        {
            Regex mail = new Regex(@".+\@[A-z]{1,5}\.[A-z]{1,3}$");
            if (mail.IsMatch(s))
            {
                return true;
            }
            return false;
        }
    }
}
