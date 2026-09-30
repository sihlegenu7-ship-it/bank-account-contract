namespace BankAccountContract;

public class CurrentAccount : BankAccount, IBankAccount
{
    public CurrentAccount(decimal initialBalance)
        : base(initialBalance)
    {
        Console.WriteLine("Current Account created.");
    }

    public decimal Balance => GetBalance();
}