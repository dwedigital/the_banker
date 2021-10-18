using System;
using System.Collections.Generic;
using System.Linq;
namespace Bank{

    class Account{
        string AccountHolder{ get;  set; }
        string AccountName{ get;  set; }
        public int AccountNumber{  get; private set; }
        double AccountBalance{ get;  set; }

        public Account(List<Account> Accounts){
            int maxAccount;
            try{
             maxAccount = Accounts.Max(t => t.AccountNumber)+1;
            }
            catch(InvalidOperationException){
                maxAccount = 1;
            }

            OpenAccount(maxAccount);
        }

        private void OpenAccount(int accountNumber){
            Console.WriteLine("Account Holder...");
            AccountHolder = Console.ReadLine();
            Console.WriteLine("Account Name...");
            AccountName = Console.ReadLine();
            Console.WriteLine("Account Balance...");
            AccountBalance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Account Number...");
            AccountNumber = accountNumber;

        }
    }
}