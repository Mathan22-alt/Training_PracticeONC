using System;

namespace Day_9_practice
{
    public class Supplier
    {
        public int supplier_id { get; set; }
        public string supplier_name { get; set; }
        public int category_id { get; set; }
        public string city_name { get; set; }
        public long mobile_num { get; set; }

        public void Validate()
        {
           
            if (supplier_id == 0)
            {
                throw new Exception("Supplier ID should not be zero.");
            }

            if (string.IsNullOrEmpty(supplier_name) || supplier_name.Length < 5 || supplier_name.Length > 10)
            {
                throw new Exception("Supplier name must be between 5 to 10 characters and cannot be empty.");
            }

           
            if (category_id == 0)
            {
                throw new Exception("Category ID should not be zero.");
            }

            
            if (mobile_num.ToString().Length != 10)
            {
                throw new Exception("Mobile number must be exactly 10 digits.");
            }

           // string city = city_name.Trim().ToLower();
           //// if (city != "pune" && city != "chennai" && city != "bangalore")
           // {
           //     throw new Exception("City must be Pune, Chennai, or Bangalore.");
           // }
        }
    }
}
