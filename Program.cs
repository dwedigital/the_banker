using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Account> Accounts = new List<Account>();

            Console.WriteLine("How can we help you today? Select from one of the following...");

            while (true)
            {
                Console.WriteLine("O: Open account");
                Console.WriteLine("L: List accounts");
                Console.WriteLine("S: Show single account information");
                Console.WriteLine("D: Make a deposit");
                Console.WriteLine("W: Make a withdrawl");
                Console.WriteLine("T: Make a transfer");
                Console.WriteLine("C: Create overdraft facility");
                Console.WriteLine("X: Leave the bank");
                string input = Console.ReadLine().ToUpper();
                if (input != "X")
                {

                    switch (input)
                    {
                        case "O":
                            Accounts.Add(openAccount(Accounts));
                            break;
                        case "L":
                            listAccounts(Accounts);
                            break;
                        case "S":
                            accountDetails(Accounts);
                            break;
                        case "D":
                            Deposit(Accounts);
                            break;
                        case "W":
                            Withdraw(Accounts);
                            break;
                        case "T":
                            Transfer(Accounts);
                            break;
                        case "C":
                            Overdraft(Accounts);
                            break;
                        case "X":
                            break;
                    }
                }
                else
                {
                    break;
                }
            }


        }

        static public Account openAccount(List<Account> Accounts)
        {
            Console.WriteLine("Account holder...");
            string accountHolder = Console.ReadLine();
            Console.WriteLine("Account name...");
            string accountName = Console.ReadLine();
            Console.WriteLine("Account opening balance...");
            double accountBalance = Convert.ToDouble(Console.ReadLine());
            Account account = new Account(Accounts, accountHolder, accountName, accountBalance);
            return account;
        }

        static public void listAccounts(List<Account> Accounts)
        {
            foreach (Account account in Accounts)
            {
                Console.WriteLine($"Account holder: {account.AccountHolder} | Acc #: {account.AccountNumber} | Name: {account.AccountName} | Amount: {account.AccountBalance} | Overdraft: {account.Overdraft}");
            }
        }

        static public void accountDetails(List<Account> Accounts)
        {
            Console.WriteLine("Please enter account number...");
            int accNumber = Convert.ToInt16(Console.ReadLine());
            Account account = Accounts.Find(x => x.AccountNumber == accNumber);

            Console.WriteLine($"Account holder: {account.AccountHolder} | Acc #: {account.AccountNumber} | Name: {account.AccountName} | Amount: {account.AccountBalance} | Overdraft: {account.Overdraft}");

        }

        static public void Deposit(List<Account> Accounts)
        {
            Console.WriteLine("Please enter account number...");
            int accNumber = Convert.ToInt16(Console.ReadLine());

            try
            {
                Account account = Accounts.Find(x => x.AccountNumber == accNumber);
                Console.WriteLine("How much do you want to deposit?");
                double amount = Convert.ToDouble(Console.ReadLine());
                account.Deposit(amount);
                Console.WriteLine($"Account #{account.AccountNumber}'s new balance is {account.AccountBalance}");

            }
            catch (NullReferenceException)
            {

                Console.WriteLine("Not a valid account number");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Amount must be greater than 0");
            }
        }

        static public void Withdraw(List<Account> Accounts)
        {
            Console.WriteLine("Please enter account number...");
            int accNumber = Convert.ToInt16(Console.ReadLine());

            try
            {
                // Not happy with how this whole section is within a try block - ideally want to split both inputs to give instant feedback
                Account account = Accounts.Find(x => x.AccountNumber == accNumber);
                Console.WriteLine("How much do you want to withdraw?");
                double amount = Convert.ToDouble(Console.ReadLine());
                account.Withdraw(amount);
                Console.WriteLine($"Account #{account.AccountNumber}'s new balance is {account.AccountBalance}");

            }
            catch (NullReferenceException)
            {

                Console.WriteLine("Not a valid account number");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Amount must be greater than 0 and account can not be negative");
            }
        }

        static public void Transfer(List<Account> Accounts)
        {
            Console.WriteLine("Please enter account number to transfer from...");
            int fromAcc = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please enter account number to transfer to...");
            int toAcc = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please enter transfer amount...");
            double amount = Convert.ToInt16(Console.ReadLine());

            Account FromAcc = Accounts.Find(x => x.AccountNumber == fromAcc);
            Account ToAcc = Accounts.Find(x => x.AccountNumber == toAcc);

            FromAcc.Transfer(ToAcc, amount);
        }

        static public void Overdraft(List<Account> Accounts)
        {
            Console.WriteLine("Please enter account number you want to apply overdraft to...");
            int account = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please enter overdraft amount...");
            double amount = Convert.ToInt16(Console.ReadLine());

            Account Acc = Accounts.Find(x => x.AccountNumber == account);

            double overdraftAmount = Acc.SetOverdraft(amount); 
            Console.WriteLine($"New overdraft amount: {overdraftAmount}");
        }
    }
}
