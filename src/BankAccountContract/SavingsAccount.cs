namespace BankAccountContract;

public class SavingsAccount : BankAccount, IBankAccount
{
    public SavingsAccount(decimal initialBalance)
        : base(initialBalance)
    {
        Console.WriteLine("Savings Account created.");
    }

    public decimal Balance => GetBalance();
}