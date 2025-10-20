using System;
using System.Collections.Generic;
using System.Globalization;

namespace PBT
{
    // Represents a single transaction (income or expense)
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; } // Positive = income, Negative = expense

        public Transaction(DateTime date, string description, decimal amount)
        {
            Date = date;
            Description = description;
            Amount = amount;
        }

        public override string ToString()
        {
            string type = Amount >= 0 ? "Income" : "Expense";
            return $"{Date.ToShortDateString()} | {type,-7} | {Amount,10:C} | {Description}";
        }
    }

    // Represents the user's account with a list of transactions
    public class Account
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public void RemoveTransaction(int index)
        {
            if (index >= 0 && index < transactions.Count)
            {
                transactions.RemoveAt(index);
            }
        }

        public decimal GetBalance()
        {
            decimal balance = 0;
            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }

        public int TransactionCount => transactions.Count;
    }

    // Handles business logic and user commands
    public class BankService
    {
        private Account account;

        public BankService()
        {
            account = new Account();
        }

        public void AddIncome()
        {
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            decimal amount = GetDecimalInput("Enter income amount: ");

            Transaction transaction = new Transaction(DateTime.Now, description, amount);
            account.AddTransaction(transaction);

            Console.WriteLine("Income added successfully!");
            Pause();
        }

        public void AddExpense()
        {
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            decimal amount = GetDecimalInput("Enter expense amount: ");

            Transaction transaction = new Transaction(DateTime.Now, description, -amount);
            account.AddTransaction(transaction);

            Console.WriteLine("Expense added successfully!");
            Pause();
        }

        public void ShowTransactions()
        {
            var transactions = account.GetAllTransactions();

            Console.WriteLine("\n=== All Transactions ===");
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
            }
            else
            {
                for (int i = 0; i < transactions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {transactions[i]}");
                }
            }

            Pause();
        }

        public void ShowBalance()
        {
            decimal balance = account.GetBalance();
            Console.WriteLine($"\n=== Current Balance ===");
            Console.WriteLine($"Balance: {balance:C}");

            Pause();
        }

        public void RemoveTransaction()
        {
            var transactions = account.GetAllTransactions();

            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions to remove.");
                Pause();
                return;
            }

            ShowTransactions();
            int index = GetIntInput("Enter the number of the transaction to remove: ") - 1;

            if (index >= 0 && index < transactions.Count)
            {
                account.RemoveTransaction(index);
                Console.WriteLine("Transaction removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid transaction number.");
            }

            Pause();
        }

        // Utility methods
        private decimal GetDecimalInput(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out result) && result >= 0)
                    return result;
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }

        private int GetIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result > 0)
                    return result;
                Console.WriteLine("Invalid input. Please enter a positive whole number.");
            }
        }

        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
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
                        bankService.AddIncome();
                        break;
                    case "2":
                        bankService.AddExpense();
                        break;
                    case "3":
                        bankService.ShowTransactions();
                        break;
                    case "4":
                        bankService.ShowBalance();
                        break;
                    case "5":
                        bankService.RemoveTransaction();
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
