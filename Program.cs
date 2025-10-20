namespace PBT
{
    public class Transaction
    {
        // Represents a single transaction (income or expense)
        static void Main(string[] args)
        {
            // Properties to be added:
            // - DateTime Date
            // - string Description
            // - decimal Amount
        }
        // Represents the user's account with a list of transactions
    }
    public class Account
        {
            // Fields or properties to be added:
            // - List<Transaction> Transactions

            // Methods to implement:
            // - void AddTransaction(Transaction transaction)
            // - void RemoveTransaction(int index)
            // - decimal GetBalance()
            // - List<Transaction> GetAllTransactions()
        }
        // Handles business logic and user commands
    public class BankService
        {
            private Account account;

            public BankService()
            {
                account = new Account();
            }

            // Methods to implement:
            // - void AddIncome()
            // - void AddExpense()
            // - void ShowTransactions()
            // - void ShowBalance()
            // - void RemoveTransaction()
        }

    // Entry point with simple menu navigation
    class Program
    {
        static void Main(string[] args)
        {
            BankService bankService = new BankService();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Banking Account Console App ===");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. View All Transactions");
                Console.WriteLine("4. View Balance");
                Console.WriteLine("5. Remove Transaction");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // bankService.AddIncome();
                        break;
                    case "2":
                        // bankService.AddExpense();
                        break;
                    case "3":
                        // bankService.ShowTransactions();
                        break;
                    case "4":
                        // bankService.ShowBalance();
                        break;
                    case "5":
                        // bankService.RemoveTransaction();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
.

