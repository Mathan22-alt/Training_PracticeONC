using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public  class ProductsBAL
    {

        public string _prodname;


        public string ProductName { get { return} }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public string QuantityPerUnit { get; set; }

        public int UnitsInStock { get; set; }
        public int UNitsOnOrder { get; set; }

        public int ReoderLevel {  get; set; }

        public bool Discontinued {  get; set; }

        public List<ProductsBAL> GetProducts()
    }
}
s