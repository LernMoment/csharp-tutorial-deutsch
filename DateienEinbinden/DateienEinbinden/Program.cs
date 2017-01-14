using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateienEinbinden
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateiName = "Testdaten/KistenVorrat.txt";
            string[] eingeleseneKistenBeschreibung;
            IEnumerable<Kiste> kisten;

            eingeleseneKistenBeschreibung = KistenEinlesenAusDatei(dateiName);
            kisten = KistenErstellen(eingeleseneKistenBeschreibung);

            foreach (Kiste kiste in kisten)
            {
                Console.WriteLine(kiste);
            }

            Console.ReadLine();
        }

        static private string[] KistenEinlesenAusDatei(string dateiName)
        {
            string[] kistenAusDatei = null;

            try
            {
                kistenAusDatei = File.ReadAllLines(dateiName, Encoding.Default);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                throw e;
            }

            return kistenAusDatei;
        }

        static private IEnumerable<Kiste> KistenErstellen(string[] kistenBeschreibungen)
        {
            List<Kiste> kisten = new List<Kiste>();

            foreach (string beschreibung in kistenBeschreibungen)
            {
                string[] eigenschaften = beschreibung.Split(',');
                Kiste neueKiste = new Kiste(int.Parse(eigenschaften[0]));
                neueKiste.ZielOrt = (Zimmer) Enum.Parse(typeof(Zimmer), eigenschaften[1]);
                neueKiste.Inhalt = eigenschaften[2];

                kisten.Add(neueKiste);
            }

            return kisten;
        }
    }
}
