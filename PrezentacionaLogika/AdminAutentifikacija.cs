using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrezentacionaLogika
{
    public class AdminAutentifikacija
    {
        public bool ProveriAdmina(string korisnickoIme, string lozinka)
        {
            return korisnickoIme == "nemanja" && lozinka == "admin";
        }
    }
}
