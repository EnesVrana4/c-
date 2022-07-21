// See https://aka.ms/new-console-template for more information
using System;

    class Program{
    static public void Main(string[] args){
        Human flogert =new Human("flogert",2,2,3,7);
        Human human2 = new Human("Enes",2,3,5,1);
        Human wizard2 = new Wizard("magjistar",4,5);
        wizard2.Attack(human2);

        flogert.Attack(human2);
        Console.WriteLine(human2.Health);


    }
}

