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
            if (amount <= 0 || (this.AccountBalance-amount) < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                this.AccountBalance -= amount;
                return this.AccountBalance;
            }
        }

    }
}