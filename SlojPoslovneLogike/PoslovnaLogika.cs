using System;
using System.IO;
using System.Xml;

namespace SlojPoslovneLogike
{
    public class PoslovnaLogika
    {
        // Učitavanje INT vrednosti iz XML-a (sa podrazumevanom vrednošću)
        private static int UcitajIntIzXml(string nodeName, int defaultValue = 0)
        {
            try
            {
                string putanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PoslovnaLogika.xml");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(putanja);

                XmlNode node = xmlDoc.SelectSingleNode("//" + nodeName);
                if (node != null && int.TryParse(node.InnerText, out int value))
                    return value;

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        // --- PRAVILO: Minimalne godine iz XML-a ---
        public static void ProveriStarost(DateTime datumRodjenja)
        {
            int minGodine = UcitajIntIzXml("MinimalneGodine", 18);

            int godine = DateTime.Now.Year - datumRodjenja.Year;
            if (DateTime.Now.Date < datumRodjenja.Date.AddYears(godine))
                godine--;

            if (godine < minGodine)
                throw new InvalidOperationException("Zabranjena registracija maloletne dece.");
        }

        // Validacija trajanja boravka preko XML-a
        public static bool DaLiJeBoravakValidan(int brojDana)
        {
            int minDana = UcitajIntIzXml("MinDanaBoravka", 1);
            int maxDana = UcitajIntIzXml("MaxDanaBoravka", 30);
            return brojDana >= minDana && brojDana <= maxDana;
        }

        // Popust u % na osnovu broja dana (pragovi fiksni, procenti iz XML-a)
        public static decimal IzracunajPopustProcenat(int brojDana)
        {
            int prag7 = 7;
            int prag15 = 15;
            int popust7 = UcitajIntIzXml("Popust7", 10);
            int popust15 = UcitajIntIzXml("Popust15", 20);

            if (brojDana > prag15) return popust15;
            if (brojDana > prag7) return popust7;
            return 0;
        }

        // Glavna metoda: izračunavanje ukupne cene (sa automatskim popustom)
        public static decimal IzracunajUkupnuCenu(decimal cenaPoNoci, int brojDana)
        {
            if (!DaLiJeBoravakValidan(brojDana))
                throw new InvalidOperationException("Boravak nije dozvoljen (mora biti u opsegu Min/Max dana iz konfiguracije).");

            decimal popustProcenat = IzracunajPopustProcenat(brojDana);
            decimal ukupno = cenaPoNoci * brojDana;

            if (popustProcenat > 0)
                ukupno -= ukupno * (popustProcenat / 100m);

            return ukupno;
        }
        
    }
}
