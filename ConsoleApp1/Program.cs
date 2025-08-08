// See https://aka.ms/new-console-template for more information
using System.Transactions;

Console.WriteLine("Hello, World!");
//Console.WriteLine("Enter the mark one : ");
//int s1 = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter the mark 2 : ");
//int s2 = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter the mark 3 :  ");
//int s3  = int.Parse(Console.ReadLine());

//int ans = (s1 + s2 + s3) / 3;
//Console.WriteLine(ans);

//int mark = 0;
//int ans = 0;
//int num = 0;
//int i = 1;
//while (true)
//{

//    Console.WriteLine("Enter the number : " + i);
//     num = int.Parse(Console.ReadLine());
//    mark += num;
//    if(num == 0)
//    {
//        ans = mark / i; break;
//    }
//    i++;


//}
//Console.WriteLine(ans);

//for(int i = 1; i <= 3; i++)
//{
//    Console.WriteLine("eneter thre num : " + i);
//    mark += int.Parse(Console.ReadLine());

//}
//ans = mark / 3;
//Console.WriteLine(ans);

//using System;

//class BankInterestCalculator
//{
//    static void Main()
//    {
//        double InitBalance, Interest = 0;
//        int accountType;

//        Console.Write("Enter your initial balance: ");
//        InitBalance = double.Parse(Console.ReadLine());

//        Console.WriteLine("Select Account Type:");
//        Console.WriteLine("1. Savings Account");
//        Console.WriteLine("2. Current Account");
//        Console.WriteLine("3. FD Account");
//        Console.Write("Enter your choice (1-3): ");
//        accountType = int.Parse(Console.ReadLine());

//        switch (accountType)
//        {
//            case 1:
//                Console.WriteLine("Savings Account");
//                Interest = InitBalance * 0.65;
//                break;
//            case 2:
//                Console.WriteLine("Current Account");
//                Interest = InitBalance * 0.55;
//                break;
//            case 3:
//                Console.WriteLine("FD Account");
//                Interest = InitBalance * 0.9;
//                break;
//            default:
//                Console.WriteLine("Invalid Option");
//                return; // Exit the program if invalid
//        }

//        Console.WriteLine("Calculated Interest: " + Interest);
//    }
//}

String num = "4567";
int power = 1;
double ans  = 0;

for(int i = 0; i < num.Length; i++)
{
  int val= int.Parse(num[i].ToString());
    ans += Math.Pow(val, power);
    power++;
}
Console.WriteLine(ans.ToString());