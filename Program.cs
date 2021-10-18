using System;

namespace the_banker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How can we help you today? Select from one of the following...");
            Console.WriteLine("O: Open account");
            Console.WriteLine("L: List accounts");
            Console.WriteLine("S: Show single account information");
            Console.WriteLine("D: Make a deposit");
            Console.WriteLine("W: Make a withdrawl");
            Console.WriteLine("T: Make a transfer");
            string input = Console.ReadLine().ToUpper(); 
        }
    }
}
