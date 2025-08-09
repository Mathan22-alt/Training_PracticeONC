using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



///  1..Inheritance  //

//namespace OOPs_Basics_1
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            Manager mng = new Manager
//            {
//                salary = 5000,
//                name ="sairam",
//                department= "finance"
//            };
//            mng.Display();
//            mng.LeaveApproval();
//        }
//    }

//    class Employeee
//    {
//        public int salary { get; set; }
//        public string name { get; set; }

//        public void Display()
//        {
//            Console.WriteLine($"name of the employee is {name},salary of the employee is {salary}");
//        }
//    }
//    class Manager : Employeee
//    {
//        public string department { get; set; }

//        public void LeaveApproval()
//        {
//            Console.WriteLine($"Leave approved for the {name},from the {department}");
//        }
//    }
//}

/// 2...Polymorphism, MethodOverloading ///
///// 
//namespace OOPs_Basics_1
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            Payment baaay = new Creditpayment();
//            baaay.pay(20000);
//            baaay = new Creditpayment();
//            baaay.pay(5000);

//        }
//    }


//    class Payment
//    {
//        public virtual void pay(double amount)
//        {
//            Console.WriteLine($"the double amount is {amount}");
//        }
//    }
//    class Creditpayment : Payment
//    {
//        public override void pay(double amount)
//        {
//            Console.WriteLine($"The creditcard payment is {amount}");
//        }
//    }
//    class UPIPayment : Payment
//    {
//        public override void pay(double amount)
//        {
//            Console.WriteLine($"the amount of Upi spend is {amount}");
//        }
//    }
//}


/// 3... Abstraction /////
/// 
//namespace OOPs_Basics_1
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            report rp = new Salesreport();
//            rp.printheader();
//            rp.generate();
//        }
//    }

//   abstract class report
//    {
//        public abstract void generate(); // no boddy , must be implemented ;

//        public void printheader()
//        {
//            Console.WriteLine("=====print header =====");
//        }
//    }
//    class Salesreport : report
//    {
//        public override void generate()
//        {
//            Console.WriteLine("slaes repprt is generating : ");
//        }
//    }
//}

///// 4... Encapsulation ////

//namespace OOPs_Basics_1
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            bankAccount acc = new bankAccount();
//            acc.Balance = 500;
//            Console.WriteLine(acc.Balance);
//            acc.deposit(400);
//        }
//    }

//    class bankAccount
//    {
//        private double balance;
//        public double Balance
//        {
//            get { return balance; }

//            set
//            {
//                if (value >= 0)
//                {
//                    balance = value;
//                }
//                else
//                {
//                    Console.WriteLine("balance is in negative state :....");
//                }
//            }

//        }
//            public void deposit(double amount)
//        {
//            Balance += amount;
//            Console.WriteLine($"the balance amout is {Balance}");
//        }
//    }



//}


// 5... Interfaces ...////

//namespace OOPs_Basics_1
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            Multiparent ma = new Multiparent();
//            ma.print();
//            ma.scann();
//        }
//    }

//    interface Iprinter
//    {
//         void print();
//    }

//    interface Iscanner
//    {
//         void scann();
//    }
//    class Multiparent : Iprinter, Iscanner
//    {
//        public void print()
//        {
//            Console.WriteLine("the printer is printing....");
//        }
//        public void scann()
//        {
//            Console.WriteLine("the scanner is scanning...");
//        }
//    }

//}


/// 6...Constructor Overloading ... ///
/// 
namespace OOPs_Basics_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            book bk = new book("c#");
            book bkl = new book("faf", "zara");
            bk.showinfo();
            bkl.showinfo();
        }
    }

    class book
    {
        public string Title;
        public string Author;

        public  book(string title)
        {
            Title = title;
        Author = "unknow";
        }
        public book(string title, string author) {
            Title = title;
            Author = author;
        }
        public void showinfo()
        {
            Console.WriteLine($"bookname is {Title},and the auhtor name is {Author}");
        }
    }
}