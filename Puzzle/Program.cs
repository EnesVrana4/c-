/////// Random Array    ///////////// 


static int[] RandomArray()
{
    Random rand = new Random();

    int[] arr = new int[10];
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rand.Next(5, 25);
    }

    return arr;


}

int[] myArr = RandomArray();

int max = myArr[0];
int min = myArr[0];
int sum = 0;
foreach (var item in myArr)
{
    if (item > max)
    {
        max = item;
    }
    else if (item < min)
    {
        min = item;
    }
    sum += item;

}
Console.WriteLine("The maximum number is " + max + " and the minimum number is " + min);
Console.WriteLine("The sum of the array is " + sum);


Console.WriteLine("=======================================================");
Console.WriteLine("=======================================================");



///////////    Coin Flip     ////////////////////////
static string TossCoin()
{
    Random rand = new Random();
    Console.WriteLine("Tossing a Coin!");
    string heads = "Heads";
    string tails = "Tails";

    if (rand.Next(0, 2) == 1)
    {
        Console.WriteLine(heads);
        return heads;
    }
    else
    {
        Console.WriteLine(tails);
        return tails;
    }
}

TossCoin();


static double TossMultipleCoins(double num)
{
    double ratio;
    double counter = 0;
    for (int i = 0; i < num; i++)
    {
        if (TossCoin() == "Heads")
        {
            counter++;
        }

    }
    ratio = num / counter;
    Console.WriteLine("The ratio of head toss to total toss is " + ratio);
    return ratio;
}
double b = 5;
TossMultipleCoins(b);


//////// Names //////////////////

static List<string> Names()
{
    List<string> names = new List<string>();
    names.Add("Todd");
    names.Add("Tiffany");
    names.Add("Geneva");
    names.Add("Sydney");
    names.Add("Charlie");


    for (int i = 0; i< names.Count; i++)
    {
        if (names[i].Length <= 5)
        {
            names.Remove(names[i]);
        }
    }
    for (int i = 0; i<names.Count; i++)
    {
        Console.WriteLine(names[i]);

    }
    return names;
}
Names();
