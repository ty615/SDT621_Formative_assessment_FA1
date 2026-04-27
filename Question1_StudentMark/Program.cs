using System;
using System.Globalization;

namespace Question1_StudentMark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1 - Student Marks");
            Console.WriteLine();

            // Prompt for student name
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine() ?? string.Empty;

            // Get three marks with validation
            double mark1 = GetValidMark("Enter mark for Subject 1: ");
            double mark2 = GetValidMark("Enter mark for Subject 2: ");
            double mark3 = GetValidMark("Enter mark for Subject 3: ");

            // Calculations
            double totalMarks = mark1 + mark2 + mark3;
            double averageMarks = totalMarks / 3;

            // PASS/FAIL decision
            string result = (averageMarks >= 50) ? "PASS" : "FAIL";

            // Get current timestamp
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("dd MMM yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-ZA"));

            // Display results (using comma as decimal separator)
            Console.WriteLine("\n==== STUDENT RESULTS ====");
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine($"Total Marks: {totalMarks}");
            Console.WriteLine($"Average Marks: {averageMarks.ToString("0.0", CultureInfo.GetCultureInfo("en-ZA"))}");
            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"Result Issued At: {formattedDate}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompts user for a mark, validates numeric input and range 0-100.
        /// </summary>
        static double GetValidMark(string prompt)
        {
            double mark;
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input! Please enter a numeric value.");
                    continue;
                }

                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out mark))
                {
                    if (mark >= 0 && mark <= 100)
                    {
                        return mark;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Marks must be between 0 and 100. Please try again.");
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

