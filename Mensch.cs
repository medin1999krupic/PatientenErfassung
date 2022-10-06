using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenschKlasse
{
    public class Mensch
    {
        public string Vorname;
        public string Nachname { get; set; }
        public int Alter;
        public int GewichtInKG;
        public double GroesseInM;
        public string Wohnort;
        public int AnzahlBeine = 2;
        public int AnzahlArme = 2;
        public string UnfallHergang;


        public bool HatteUnfall
        {
            get
            {
                bool unfall = true;
                if (UnfallHergang == "kein" || UnfallHergang == "Kein")
                {
                    unfall = false;
                }

                return unfall;
            }
        }

        public Mensch()
        {

        }

        public Mensch(DataRow row)
        {
            Vorname = row["Vorname"].ToString();
            Nachname = row["Nachname"].ToString();
            Alter = Convert.ToInt32(row["Alter"]);
            GewichtInKG = Convert.ToInt32(row["GewichtInKG"]);
            GroesseInM = Convert.ToDouble(row["GroesseInM"]);
            Wohnort = row["Wohnort"].ToString();
            AnzahlBeine = Convert.ToInt32(row["AnzahlBeine"]);
            AnzahlArme = Convert.ToInt32(row["AnzahlArme"]);
            UnfallHergang = row["UnfallHergang"].ToString();
        }

        public Mensch(string vorname, string nachname, int alter, int gewichtInKG, double groesseInM, string wohnort, int anzahlBeine, int anzahlArme, string unfallHergang)
        {
            Vorname = vorname;
            Nachname = nachname;
            Alter = alter;
            GewichtInKG = gewichtInKG;
            GroesseInM = groesseInM;
            Wohnort = wohnort;
            AnzahlBeine = anzahlBeine;
            AnzahlArme = anzahlArme;
            UnfallHergang = unfallHergang;
        }

        public override string ToString()
        {
            string anzeigeName = Vorname + " " + Nachname;
            return anzeigeName;
        }

    }
}
