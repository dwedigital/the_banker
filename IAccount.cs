namespace Bank
{

    interface IAccount
    
            {
        string AccountHolder { get;}
        string AccountName { get; }
        int AccountNumber { get; }
        double AccountBalance { get; }

        double Overdraft { get; }

        double Deposit(double amount);

        double Withdraw(double amount);

        void Transfer(Account to, double transferAmount);

        double SetOverdraft(double amount);

    }
}
