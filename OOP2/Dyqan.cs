using System;

namespace RecapC_{
    class Dyqan : Building
    {
        public string Biznes;
        public int Vjetersia;
        public int NrPunetoreve;

        public Dyqan(string lloji , string ngjyra, int NumriKateve) : base(ngjyra,NumriKateve)
        {
            Biznes = lloji;
            Vjetersia = 3;
            NrPunetoreve = 2;
        }

    }
}