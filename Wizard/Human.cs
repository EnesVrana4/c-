class Human
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Health { get; set; }
     
 
     
    public Human(string name, int str, int dex,int intel,int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        Health = hp;
    }
    
     
    // Build Attack method
    public virtual int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
}


class Wizard : Human 
{
    public Wizard(string name, int str, int dex) : base(name, str, dex, 25, 50)
    {
    }
    public override int Attack(Human target)
    {

        base.Attack(target);
        Console.WriteLine("sulmova serish");
        int dmg = Intelligence * 5;
        target.Health -= dmg;
        Health += dmg;
        return target.Health;
    }
    public int Heal(Human target){
        target.Health = 10 * Intelligence;
        return target.Health;
    }

    
}

class Ninja : Human
{
    public Ninja(string name, int str,int intel,int hp) :base(name,str,intel,175,hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = 175;
        Health = hp;
    }
    public override int Attack(Human target){
        Random rand = new Random();
        int dmg = Dexterity * 5;
        if(rand.Next(1,6)==1){
            target.Health -= dmg + 10;
        }
        else {
            target.Health -= dmg;
        }
        return target.Health;
    }
    public int Steal(Human target)
    {
        target.Health -= 5;
        Health += 5;
        return target.Health;
        
    }
}

class Samurai : Human
{
    public Samurai(string name, int str, int dex,int intel) : base(name,str,dex,intel,200)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        Health = 200;
    }
    public override int Attack(Human target)
    {
        
        if (target.Health < 50)
        {
            target.Health = 0;
            Console.WriteLine("you died");
        }
        else
        {
            target.Health -= Strength;
        }
        return target.Health;
    }
    public int Meditate()
    {
        Health = 200;
        return Health;
    }
}