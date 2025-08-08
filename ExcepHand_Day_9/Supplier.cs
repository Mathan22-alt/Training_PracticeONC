using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepHand_Day_9
{
    //    public class Supplier
    //    {
    //        public int supplier_id { get; set; }
    //        public string supplier_name { get; set; }
    //        public int category_id { get; set; }
    //        public long mbl_num { get; set; }
    //        public string city_name { get; set; }



    //        public void validate()
    //        {
    //            if (supplier_id <= 0)
    //            {
    //                throw new Exception("Supplier id can't be null");
    //            }
    //            if (string.IsNullOrEmpty(supplier_id) || supplier_id.length < 5 || supplier_id > 10)
    //            {
    //                throw new Exception("Supplier can't be null and exceed the given length");
    //            }
    //            if (category_id == 0)
    //            {
    //                throw new Exception("category id can't be null");
    //            }
    //            if (mbl_num.ToString().Length != 10)
    //            {
    //                throw new Exception("Mbl number should be in 10 characters only");
    //            }
    //            city_name.ToLower().Trim();

    //            if (city_name != "chennai" && city_name != "pune" && city_name != "banaglore")
    //            {
    //                throw new Exception("city must be chennai , bangalore or pune");
    //            }
    //        }
    //    }
    //}
    public class Supplier
    {
        public int supplier_id { get; set; }
        public string supplier_name { get; set; }
        public int category_id { get; set; }
        public long mbl_num { get; set; }
        public string city_name { get; set; }

        public void Validate()  // 👈 Must match exactly
        {
            if (supplier_id <= 0)
                throw new Exception("Supplier ID cannot be null or zero.");

            if (string.IsNullOrWhiteSpace(supplier_name))
                throw new Exception("Supplier name cannot be empty.");

            if (supplier_name.Length < 5 || supplier_name.Length > 10)
                throw new Exception("Supplier name must be between 5 and 10 characters.");

            if (category_id == 0)
                throw new Exception("Category ID cannot be zero.");

            if (mbl_num.ToString().Length != 10)
                throw new Exception("Mobile number must be exactly 10 digits.");

            string city = city_name.Trim().ToLower();
            if (city != "pune" && city != "chennai" && city != "bangalore")
                throw new Exception("City must be Pune, Chennai, or Bangalore.");
        }
    }
