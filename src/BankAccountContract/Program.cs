namespace BankAccountContract;

public static class Program
{
    public static void Main()
    {
        bool applicationRunning = true;

        while (applicationRunning)
        {
            Console.WriteLine("===== SELECT ACCOUNT TYPE =====");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an account: ");

            string? accountChoice = Console.ReadLine();

            if (accountChoice == "3")
            {
                Console.WriteLine("Thank you for using the SG Bank Account App!");
                applicationRunning = false;
                break;
            }

            IBankAccount account;

            switch (accountChoice)
            {
                case "1":
                    account = new SavingsAccount(1000m);
                    break;

                case "2":
                    account = new CurrentAccount(1000m);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Savings Account selected by default.");
                    account = new SavingsAccount(1000m);
                    break;
            }

            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("===== BANK ACCOUNT MENU =====");
                Console.WriteLine($"Current Balance: R{account.Balance}");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.WriteLine("5. Restart Account");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter amount to deposit: R");
                            decimal depositAmount = decimal.Parse(Console.ReadLine()!);
                            account.Deposit(depositAmount);
                            Console.WriteLine("Deposit successful!");
                            break;

                        case "2":
                            Console.Write("Enter amount to withdraw: R");
                            decimal withdrawAmount = decimal.Parse(Console.ReadLine()!);
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine("Withdrawal successful!");
                            break;

                        case "3":
                            Console.WriteLine($"Current Balance: R{account.Balance}");
                            break;

                        case "4":
                            running = false;
                            Console.WriteLine("Returning to account selection...");
                            break;

                        case "5":
                            account = new SavingsAccount(1000m);
                            Console.WriteLine("Account has been restarted.");
                            Console.WriteLine($"New Balance: R{account.Balance}");
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please choose between 1 and 5.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid numeric amount.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}