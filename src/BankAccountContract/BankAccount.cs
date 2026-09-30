using System.Diagnostics;

namespace BankAccountContract;

public class BankAccount
{
    private decimal balance;

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentException("Initial balance cannot be negative.");
        }

        balance = initialBalance;

        CheckInvariant();
    }

    public void Deposit(decimal amount)
    {
        CheckInvariant();

        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than R0.00.");
        }

        decimal startingBalance = balance;

        balance += amount;

        Debug.Assert(
            balance == startingBalance + amount,
            "Deposit Postcondition Failed: Final balance must equal starting balance plus deposit amount."
        );

        CheckInvariant();
    }

    public void Withdraw(decimal amount)
    {
        CheckInvariant();

        if (amount <= 0 || amount > balance)
        {
            throw new ArgumentException("Invalid withdrawal amount.");
        }

        decimal startingBalance = balance;

        balance -= amount;

        Debug.Assert(
            balance == startingBalance - amount,
            "Withdrawal Postcondition Failed: Final balance must equal starting balance minus withdrawal amount."
        );

        CheckInvariant();
    }

    public decimal GetBalance()
    {
        return balance;
    }

    private void CheckInvariant()
    {
        Debug.Assert(
            balance >= 0,
            "Class Invariant Failed: Balance cannot be negative."
        );
    }
}