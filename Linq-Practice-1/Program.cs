//using System;

//namespace Linq_Practice_1
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            //Console.WriteLine("Hello, World!");


//        }
//    }
//    public class Student
//    {
//        public int StudentId { get; set; }
//        public string StudentName { get; set; }

//        public int StudentAge { get; set; }
//        public List<string> Subjects { get; set; }
//    }

//    public class Score
//    {

//    }
//}

using System;
using System.Collections.Generic;

class Program
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Subjects { get; set; }
    }

    class Score
    {
        public int StudentId { get; set; }
        public int Marks { get; set; }
    }

    static void Main()
    {
        // Numbers
        List<int> numbers = new List<int> { 1, 5, 8, 3, 10, 2, 5, 8 };

        // Names
        List<string> names = new List<string> { "John", "Sara", "Mike", "Sara" };

        // Students
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John", Age = 25, Subjects = new List<string> { "Math", "Science" } },
            new Student { Id = 2, Name = "Sara", Age = 22, Subjects = new List<string> { "English", "History" } },
            new Student { Id = 3, Name = "Mike", Age = 25, Subjects = new List<string> { "Science", "History" } }
        };

        // Scores
        List<Score> scores = new List<Score>
        {
            new Score { StudentId = 1, Marks = 90 },
            new Score { StudentId = 2, Marks = 80 },
            new Score { StudentId = 3, Marks = 85 }
        };

        // Your LINQ practice goes here

        //Where Query
        var evenos = numbers.Where(n => n % 2 == 0);
        Console.WriteLine(string.Join( ",", evenos));

        //Distinct Query
        var uniqnam = names.Distinct();//.ToList();
        Console.WriteLine(string.Join(",", uniqnam));

        //select Query
        var stdname = students.Select(n => n.Name);
        Console.WriteLine(string.Join ( ",", stdname));

        //SelectMany Query
        var subname = students.SelectMany(s=> s.Subjects).Distinct();
        Console.WriteLine(string.Join(",",subname));

        var oldstd = students.Where(s => s.Age > 23).Select(s => s.Name);
        Console.WriteLine(string.Join(" ", oldstd));
    }
}
