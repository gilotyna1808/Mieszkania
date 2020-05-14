using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mieszkania
{
    public class User
    {
        private string login;
        private int idPrac;
        public User(string log,int id)
        {
            this.login = log;
            this.idPrac = id;
        }

        public int getIdPrac()
        {
            return this.idPrac;
        }

        public string getLogin()
        {
            return this.login;
        }
    }
}
