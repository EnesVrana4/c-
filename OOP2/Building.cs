using System;
namespace RecapC_{

    

    class Building{
        public int NumriKateve;
        private string ngjyra;
        public string Vendodhja{get;set;}
        public Building(int kat){
            NumriKateve = kat;
            ngjyra = "red";
            Vendodhja = "astir";
        }
        public string tregoNgjyren(){
            return ngjyra;
        }
        public int shtoKat(){
            return NumriKateve++;
        }

        public int shtoKat(int kati){
            if (kati == 0){
                Console.WriteLine("Te lutem vendos Kat tjeter");
                string nrDyte = Console.ReadLine();
                int nrFinal = Int16.Parse(nrDyte);
                shtoKat(nrFinal);

            }
             NumriKateve += kati;
            Console.WriteLine(NumriKateve);
            return NumriKateve;
        }
    }
}