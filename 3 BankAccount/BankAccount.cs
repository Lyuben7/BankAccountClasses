using System.Globalization;
using _3_BankAccount;

public class BankAccount
{
    private static int idCounter = 1;
    private static double interestRate = 0.02;

    public int Id { get; }
    public double Balance { get; private set; }

    public BankAccount()
    {
        this.Id = idCounter++;
        this.Balance = 0;
    }

    public static void SetInterestRate(double interest)
    {
        interestRate = interest;
    }

    public double GetInterest(int years)
    {
        return this.Balance * interestRate * years;
    }

    public void Deposit(double amount)
    {
        this.Balance += amount;
    }
}

public class Program
{
    public static void Main()
    {
        Person firstPerson = new Person();
        Person secondPerson = new Person();

        firstPerson.Name = "Sbiracis";
        firstPerson.Age = 15;

        secondPerson.Name = "Kamboracis";
        secondPerson.Age = 15;



        firstPerson.IntroduceYurself();
        secondPerson.IntroduceYurself();

        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        string command;

        Console.WriteLine("Welcome to the Bank Account Manager!");
        Console.WriteLine("Available commands: Create, Deposit {Id} {Amount}, SetInterest {Interest}, GetInterest {Id} {Years}, End");
        Console.WriteLine("Enter your commands below:");

        while (true)
        {
            Console.Write("> ");
            command = Console.ReadLine();

            if (command == "End")
            {
                Console.WriteLine("Program ended. Goodbye!");
                break;
            }

            string[] cmdArgs = command.Split();
            string cmdType = cmdArgs[0];

            if (cmdType == "Create")
            {
                BankAccount account = new BankAccount();
                accounts.Add(account.Id, account);
                Console.WriteLine($"Account ID{account.Id} created.");
            }
            else if (cmdType == "Deposit")
            {
                if (cmdArgs.Length < 3)
                {
                    Console.WriteLine("Invalid command. Usage: Deposit {Id} {Amount}");
                    continue;
                }

                int id = int.Parse(cmdArgs[1]);
                double amount = double.Parse(cmdArgs[2], CultureInfo.InvariantCulture);

                if (accounts.ContainsKey(id))
                {
                    accounts[id].Deposit(amount);
                    Console.WriteLine($"Deposited {amount} to ID{id}. New balance: {accounts[id].Balance:F2}");
                }
                else
                {
                    Console.WriteLine("Account does not exist.");
                }
            }
            else if (cmdType == "SetInterest")
            {
                if (cmdArgs.Length < 2)
                {
                    Console.WriteLine("Invalid command. Usage: SetInterest {Interest}");
                    continue;
                }

                double interest = double.Parse(cmdArgs[1], CultureInfo.InvariantCulture);
                BankAccount.SetInterestRate(interest);
                Console.WriteLine($"Interest rate set to {interest:P2}.");
            }
            else if (cmdType == "GetInterest")
            {
                if (cmdArgs.Length < 3)
                {
                    Console.WriteLine("Invalid command. Usage: GetInterest {Id} {Years}");
                    continue;
                }

                int id = int.Parse(cmdArgs[1]);
                int years = int.Parse(cmdArgs[2]);

                if (accounts.ContainsKey(id))
                {
                    double interest = accounts[id].GetInterest(years);
                    Console.WriteLine($"Interest for account ID{id} over {years} year(s): {interest:F2}");
                }
                else
                {
                    Console.WriteLine("Account does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command. Available commands: Create, Deposit {Id} {Amount}, SetInterest {Interest}, GetInterest {Id} {Years}, End");
            }
        }
    }
}