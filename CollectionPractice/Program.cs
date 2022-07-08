//////Three Basic Arrays////

/////////////// Create an array to hold integer values 0 through 9 /////////////////////
int[] arrayOfInts = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};


for(int i = 0; i<= 9;i++){
    Console.WriteLine(arrayOfInts[i]);
}

Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("---------------------------------------------------------");








////////////// Create an array of the names "Tim", "Martin", "Nikki", & "Sara" /////////////////////
string[] arrayOfNames = { "Tim", "Martin", "Nikki", "Sara"};

for(int i = 0; i < arrayOfNames.Length ;i++){
    Console.WriteLine(arrayOfNames[i]);
}

Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("---------------------------------------------------------");











////////////// Create an array of length 10 that alternates between true and false values, starting with true ////
bool[] arrayOfBoolean = new bool[10];

for(int i = 0; i <= 9; i++){
    if(i % 2 == 0){
        arrayOfBoolean[i] = true;
    }
    else{
        arrayOfBoolean[i] = false;
    }
}

for(int i = 0; i <= 9 ;i++){

    Console.WriteLine(arrayOfBoolean[i]);
    
}

Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("---------------------------------------------------------");









////         List of Flavors            ////
 

///////////// Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!) /////
List<string> IceCream = new List<string>();
IceCream.Add("Vanilla");
IceCream.Add("Matcha");
IceCream.Add("Chocolate");
IceCream.Add("Coconut");
IceCream.Add("Strawberry");
IceCream.Add("Banana");
IceCream.Add("Oreo");

for(int i = 0; i < IceCream.Count ;i++){

    Console.WriteLine(IceCream[i]);
    
}

Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("---------------------------------------------------------");

////// Output the length of this list after building it ///////////

Console.WriteLine(IceCream.Count);

Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("---------------------------------------------------------");


////// Output the third flavor in the list, then remove this value  //////////////

Console.WriteLine(IceCream[2]);
IceCream.RemoveAt(2);

Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("---------------------------------------------------------");


///////  Output the new length of the list (It should just be one fewer!)  /////////////



Console.WriteLine(IceCream.Count);


Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("---------------------------------------------------------");





////       User Info Dictionary           /////

//////  Create a dictionary that will store both string keys as well as string values  /////////




Dictionary<string, string> NameFlavor = new Dictionary<string, string>();


//////  Add key/value pairs to this dictionary where:
///////         each key is a name from your names array
///////         each value is a randomly elected flavor from your flavors list.
Random rand = new Random();
for( int i = 0; i< arrayOfNames.Length; i++){
    NameFlavor.Add(arrayOfNames[i],IceCream[rand.Next(0,IceCream.Count-1)]);
}

////// Loop through the dictionary and print out each user's name and their associated ice cream flavor /////

foreach (var entry in NameFlavor)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}