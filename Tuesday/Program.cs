class MainClass{

    public static void Main(string[] args){
        Book bookObject = new Book();
        bookObject.title = "Master and Margharita";
        bookObject.language = "EN";

        Book bookObject2 = new Book("Alkimisti","AL");
        
        Console.WriteLine("Object 1:" + bookObject.title);
        Console.WriteLine("Object 2:" + bookObject2.title);

        Book book3 = new Book("test","test","test",3);
        Console.WriteLine(book3.authorName);
        
        bookObject.print();
        book3.print();


        

    }
}

class Book 
{
   // attributes

   public int numberOfPages{get; set;}

   public string title{get; set;}

   public string language{get; set;}

   public Author author{get; set;}

  public string authorEmail{get; set;}





   public Book(string titleInput, string languageInput){
    title = titleInput;
    language = languageInput;
   }
   
   public Book(){

   }

   public Book ( string authorName, string language, string title, int numberOfPages){
    this.language = language;
    this.title = title;
    this.numberOfPages = numberOfPages;
    this.authorName = authorName;
   }
   public void print(){
    Console.WriteLine(title);
    Console.WriteLine(language);
    Console.WriteLine(authorName);
    Console.WriteLine(numberOfPages);
   }
}
