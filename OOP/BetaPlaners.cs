namespace OOP2
{
    class BetaPlaners
    {
        public string Name;
        public int Age;
        public string Gender;
        public bool FinishedHS;
        public string Birthlace;
    
    
        public BetaPlaners(string name, int age, string gender, string birthplace){

            Name = name;
            Age = age;
            Gender = gender;
            FinishedHS = true;
            birthplace = birthplace;
        }
    }
    
    public class Student : BetaPlaners{
        public string BootCamp;
        public bool Yellowbelt;
        public string HS;

        public Student(string bootcamp, string hs,string name, int age, string gender, string birthplace) : base(name, age, gender, birthplace){
            BootCamp = bootcamp;
            Yellowbelt = true;
            HS = hs;
        }
    }
    
    
    
    
}