// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//string EmpName;
//Console.WriteLine("Please Enter your Name:  ");
//EmpName =Console.ReadLine();
//Console.WriteLine("your name is  " + EmpName);

//int age;
//Console.WriteLine("Enter your age : ");
//age = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("your age is : " + age);

double salary;
Console.WriteLine("Enter your base salary: ");
string StrAge = Console.ReadLine();
salary=double.Parse(StrAge);
double netsalary = 0;
netsalary = salary * (1 - 0.13);
Console.WriteLine("Your NEtSalary is ;" + netsalary);
double pf = salary * .13;
netsalary = salary - pf;
Console.WriteLine("your netsalaray is :" + netsalary + "your pf is :" + pf);


