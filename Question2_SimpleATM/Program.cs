using System;
using System.Globalization;

namespace Question2_SimpleATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CTU SIMPLE ATM SYSTEM\n");

            // Get user name
            Console.Write("HI, WHAT IS YOUR NAME? ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"\nWELCOME {name.ToUpper()}!");

            // Get account balance
            double balance = GetPositiveDouble("Enter account balance: ");

            // Get withdrawal amount
            double withdrawal = GetPositiveDouble("Enter withdrawal amount: ");

            // Check sufficient funds
            if (withdrawal > balance)
            {
                Console.WriteLine("\nTransaction declined: Insufficient funds.");
                Console.WriteLine($"Your balance is {balance.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            else
            {
                // Perform withdrawal
                balance -= withdrawal;
                DateTime transactionTime = DateTime.Now;
                string formattedTime = transactionTime.ToString("dd MMM yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-ZA"));

                Console.WriteLine("\nWithdrawal successful!");
                Console.WriteLine($"Updated Balance: {balance.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Transaction Time: {formattedTime}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompts user for a positive double value.
        /// </summary>
        static double GetPositiveDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                {
                    if (value > 0)
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a positive amount.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a numeric value.");
                }
            }
        }
    }
}