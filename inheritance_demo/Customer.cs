using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance_demo
{
    public class Customer
    {
        public int cust_id { get; set; }
        public string cust_name { get; set; }
        public string city_name { get; set; }

        public string CityName
        {
            get { return city_name; }
            set
            {
                if (value.ToLower() == "chennai")
                {
                    city_name = value;
                }
                else
                {
                    Console.WriteLine("Invalid City name");
                    //  city_name = "Unknown"; 
                }
            }
        }
        public Customer(int id, string name, string city)
        {
            cust_id = id;
            cust_name = name;
            CityName = city;
        }





        //public override string ToString()
        //{
        //    return $"Customer ID: {cust_id}, Name: {cust_name}, City: {CityName}";
        //}
    }
}
