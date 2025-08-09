using System;
using System.Collections.Generic;
using System.Linq;
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
namespace OOPs_Basics_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Payment baaay = new Creditpayment();
            baaay.pay(20000);
            baaay = new Creditpayment();
            baaay.pay(5000);

        }
    }


    class Payment
    {
        public virtual void pay(double amount)
        {
            Console.WriteLine($"the double amount is {amount}");
        }
    }
    class Creditpayment : Payment
    {
        public override void pay(double amount)
        {
            Console.WriteLine($"The creditcard payment is {amount}");
        }
    }
    class UPIPayment : Payment
    {
        public override void pay(double amount)
        {
            Console.WriteLine($"the amount of Upi spend is {amount}");
        }
    }
}