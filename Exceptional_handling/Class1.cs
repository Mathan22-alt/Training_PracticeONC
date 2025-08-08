using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptional_handling
{
    public struct Employee
    {

        int empid;
        string empname;

        public Employee(int Empid, string EmpName)
        {
            this.empid = Empid;
            this.empname = EmpName;
        }
        public void Display(out int employeeid,
            out string employeename)
        {
            employeeid = empid;
            employeename = empname;
        }

    }
}