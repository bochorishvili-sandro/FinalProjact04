using System;
using System.IO;
namespace atm;
class ATM
{
    private string accountFile = "accounts.txt";

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("------------------");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CheckBalance();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine();
        }
    }

    private void CheckBalance()
    {
        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        string[] accountData = GetAccountData(accountNumber);
        if (accountData == null)
        {
            Console.WriteLine("Account not found.");
        }
        else
        {
            decimal balance = decimal.Parse(accountData[1]);
            Console.WriteLine($"Your balance is: {balance:C}");
        }
    }

    private void Deposit()
    {
        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        string[] accountData = GetAccountData(accountNumber);
        if (accountData == null)
        {
            Console.WriteLine("Account not found.");
        }
        else
        {
            Console.Write("Enter the amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                decimal balance = decimal.Parse(accountData[1]);
                balance += amount;
                accountData[1] = balance.ToString();

                SaveAccountData(accountData);
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please try again.");
            }
        }
    }

    private void Withdraw()
    {
        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        string[] accountData = GetAccountData(accountNumber);
        if (accountData == null)
        {
            Console.WriteLine("Account not found.");
        }
        else
        {
            Console.Write("Enter the amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                decimal balance = decimal.Parse(accountData[1]);
                if (balance >= amount)
                {
                    balance -= amount;
                    accountData[1] = balance.ToString();

                    SaveAccountData(accountData);
                    Console.WriteLine("Withdrawal successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please try again.");
            }
        }
    }

    private string[] GetAccountData(string accountNumber)
    {
        string[] lines = File.ReadAllLines(accountFile);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts[0] == accountNumber)
            {
                return parts;
            }
        }

        return null;
    }

    private void SaveAccountData(string[] accountData)
    {
        string accountNumber = accountData[0];
        string balance = accountData[1];

        string[] lines = File.ReadAllLines(accountFile);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts[0] == accountNumber)
            {
                lines[i] = $"{accountNumber},{balance}";
                File.WriteAllLines(accountFile, lines);
                return;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        ATM atm = new ATM();
        atm.Run();
    }
}
