using System;
using System.Collections.Generic;
using System.Linq;
namespace Bank
{

    class Account
    {
        public string AccountHolder { get; private set; }
        public string AccountName { get; private set; }
        public int AccountNumber { get; private set; }
        public double AccountBalance { get; private set; }

        public Account(List<Account> accounts, string accountHolder, string accountName, double accountBalance)
        {
            int accNumber;
            try
            {
                accNumber = accounts.Max(t => t.AccountNumber) + 1;
            }
            catch (InvalidOperationException)
            {
                accNumber = 1;
            }

            AccountHolder = accountHolder;
            AccountName = accountName;
            AccountBalance = accountBalance;
            AccountNumber = accNumber;
        }

        public double Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                this.AccountBalance += amount;
                return this.AccountBalance;
            }
        }

        public double Withdraw(double amount)
        {
            if (amount <= 0 || (this.AccountBalance - amount) < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                this.AccountBalance -= amount;
                return this.AccountBalance;
            }
        }

        public void Transfer(Account to, double transferAmount)
        {
            if (this.AccountBalance <= 0)
            {
                throw new ArgumentException("The account you are transferring from is at 0");

            }
            else if(this.AccountNumber == to.AccountNumber){
                throw new ArgumentException("You can not transfer to the same accounts");
            }
            else if((this.AccountBalance-transferAmount)<0){
                throw new ArgumentException("This will make the account you are transferring from negative");
            }else{
                
                this.AccountBalance -= transferAmount;
                to.AccountBalance += transferAmount;

            }

        }
    }
}