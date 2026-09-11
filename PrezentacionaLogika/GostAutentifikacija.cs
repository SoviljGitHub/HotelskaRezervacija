using SlojPodataka.DBUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrezentacionaLogika
{
    public class GostAutentifikacija
    {
        private readonly GostRepozitorijum repo = new GostRepozitorijum();

        public bool PrijaviGosta(string jmbg, string email)
        {
            return repo.DaLiPostojiGostSaJmbgIEmailom(jmbg, email);
        }
    }
}
