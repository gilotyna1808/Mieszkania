using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mieszkania
{
    class Walidacja
    {
        public bool sprawdzImie(string s)
        {
            Regex imie= new Regex(@"[A-z]+");
            if (imie.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzNazwisko(string s)
        {
            Regex nazw = new Regex(@"([A-z]+.?)+");
            if (nazw.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        public bool sprawdzTelefon(string s)
        {
            Regex tel = new Regex(@"[+]?[0-9]{9,12}");
            if (tel.IsMatch(s))
            {
                return true;
            }
            return false;
        }
    }
}
