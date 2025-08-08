
using Microsoft.VisualBasic;
using System;
using System.Globalization;

namespace inheritance_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Electronicproduct p = new Electronicproduct();
            //p.name = "Test";
            //p.id = 1;

            //Console.WriteLine("Name: " + p.name);
            //Console.WriteLine("ID: " + p.id);
            //Console.WriteLine("Price: " + p.price);

            //Console.ReadLine(); 

            //Customer customer = new Customer(12,"mathan","CHENNAI");
            //Console.WriteLine($"City: {customer.city_name}, ID: {customer.cust_id}, Name: {customer.cust_name}");

            //Console.WriteLine(customer);
            //
            DateTime dt = new DateTime(2025, 07, 25, 2, 36,0);

            // DateTime dty = DateTime.Now;

            Console.WriteLine($"{dt:d}");
            Console.WriteLine($"{dt:D}");
            Console.WriteLine($"{dt:T}");
            Console.WriteLine($"{dt:F}");
            Console.WriteLine($"{dt:t}");

            CultureInfo t = new CultureInfo("hi-IN");
            string dt1  = dt.ToString("D", t);
            Console.OutputEncoding=System.Text.Encoding.UTF8;
            Console.WriteLine($"Date is = {dt1}");

           // Console.WriteLine($"price is ={price.ToString("C",t)}");


        }
    }
}
