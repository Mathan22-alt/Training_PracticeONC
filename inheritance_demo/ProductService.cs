using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance_demo
{
    internal interface ProductService
    {
        void AddCustomer(Customers customer);
        void DeleteCustomer(int cust_id);
        void FindCustomer(int cust_id);
    
    
    }
}
