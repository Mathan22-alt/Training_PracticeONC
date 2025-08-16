namespace OOPs_Basics_practice__1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    abstract class LibraryItem
    {
        public string Tittle{ get; set; }
        public string Author { get; set; }
        private int CopiesAvail {  get; set; }

        public LibraryItem(string title,string author,int copies) {
         Tittle = title;
            Author = author;
            CopiesAvail = copies;
        }

        public int Getcopies()
        {
            return CopiesAvail;
        }
        public  void Updatecopies(int count)
        {
            CopiesAvail += count;
            if (CopiesAvail <= 0)
            {
                CopiesAvail = 0;
            }
            else
            {
                Console.WriteLine($"The total number of copies available is {CopiesAvail} copies");
            }
        }
        public abstract void Borrow();
        public abstract void Return();
    }
    class Book : LibraryItem
    {
        public Book(string title, string author, int copies) : base(title, author, copies) { }

        public override void Borrow()
        {


        }

}
