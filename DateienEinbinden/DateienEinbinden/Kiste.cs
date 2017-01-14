using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateienEinbinden
{
    public enum Zimmer
    {
        Wohnzimmer,
        Küche,
        Kinderzimmer,
        Schlafzimmer,
        Bad,
        Keller
    }

    class Kiste
    {
        public Kiste(int nummer)
        {
            Nummer = nummer;
        }

        public int Nummer { get; private set; }
        public string Inhalt { get; set; }
        public Zimmer ZielOrt { get; set; }

        public override string ToString()
        {
            return "KISTE: " + Nummer + ", " + ZielOrt + ", " + Inhalt;
        }
    }
}
