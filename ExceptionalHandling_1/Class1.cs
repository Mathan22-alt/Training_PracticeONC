namespace ExceptionHandlingDemo
{
    public enum ErrorCodes
    {
        NoError = 0,
        VariableNotFound = 1,
        ConstantNotFound = 2,
        Other = 3
    }

    public enum EmployeeType
    {
        Clerk = 0,
        Manager = 1,
        Developer = 2,
        Designer = 3,
        Lead = 4,
        CEO = 5
    }

    public class EmployeeDesignations
    {
        public EmployeeType Designation { get; set; }
    }

    public struct Employee
    {
        int empid;
        string empname;

        public Employee(int Empid, string EmpName)
        {
            this.empid = Empid;
            this.empname = EmpName;
        }

        public void Display(out int employeeid, out string employeename)
        {
            employeeid = empid;
            employeename = empname;
        }
    }
}
