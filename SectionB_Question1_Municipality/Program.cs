using System;
using System.Collections.Generic;

namespace SectionB_Question1_Municipality
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== EMFULENI MUNICIPALITY SERVICE MANAGEMENT SYSTEM =====");
            Console.WriteLine();

            List<Resident> residents = new List<Resident>();
            UtilitiesManager manager = new UtilitiesManager();

            // 1. Capture residents
            Console.Write("Enter number of residents: ");
            int residentCount = GetValidInt(1, 100);

            for (int i = 0; i < residentCount; i++)
            {
                Console.WriteLine($"\n--- Resident {i + 1} ---");
                Console.Write("Name: ");
                string name = Console.ReadLine() ?? string.Empty;
                Console.Write("Address: ");
                string address = Console.ReadLine() ?? string.Empty;
                Console.Write("Account Number: ");
                string account = Console.ReadLine() ?? string.Empty;
                Console.Write("Monthly Utility Usage (kWh): ");
                double usage = GetValidDouble(0, 10000);
                residents.Add(new Resident(name, address, account, usage));
            }

            // 2. Capture service requests
            Console.Write("\nEnter number of service requests: ");
            int requestCount = GetValidInt(1, 100);

            for (int i = 0; i < requestCount; i++)
            {
                Console.WriteLine($"\n--- Service Request {i + 1} ---");
                // Select resident
                Console.WriteLine("Select resident for this request:");
                for (int j = 0; j < residents.Count; j++)
                    Console.WriteLine($"[{j + 1}] {residents[j].Name}");
                int residentIndex = GetValidInt(1, residents.Count) - 1;
                Resident selected = residents[residentIndex];

                Console.Write("Request Type (e.g., Water Leak, Power Outage): ");
                string reqType = Console.ReadLine() ?? string.Empty;
                Console.Write("Priority Level (1-5, 1=Highest): ");
                int priority = GetValidInt(1, 5);
                Console.Write("Severity Level (1-10, 1=Most Severe): ");
                int severity = GetValidInt(1, 10);
                Console.Write("Estimated Resolution Hours: ");
                double hours = GetValidDouble(0.5, 72);

                manager.AddServiceRequest(new ServiceRequest(selected, reqType, priority, severity, hours));
            }

            // 3. Interactive processing
            while (true)
            {
                manager.DisplayPendingRequests();
                var pending = manager.GetAllRequests().FindAll(r => !r.IsProcessed);
                if (pending.Count == 0)
                {
                    Console.WriteLine("\nAll requests have been processed!");
                    break;
                }

                Console.Write("\nEnter request number to process (or 0 to finish): ");
                int choice = GetValidInt(0, pending.Count);
                if (choice == 0) break;

                ServiceRequest selectedReq = manager.SelectRequestToProcess(choice);
                if (selectedReq != null)
                {
                    string report = manager.ProcessRequest(selectedReq);
                    Console.WriteLine(report);
                    Console.WriteLine("\nRequest processed successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }

            // 4. Final summary
            manager.DisplayFinalSummary();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Helper to get integer within range
        static int GetValidInt(int min, int max)
        {
            int val;
            while (true)
            {
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out val) && val >= min && val <= max)
                    return val;
                Console.Write($"Invalid. Enter number between {min} and {max}: ");
            }
        }

        static double GetValidDouble(double min, double max)
        {
            double val;
            while (true)
            {
                string input = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(input, out val) && val >= min && val <= max)
                    return val;
                Console.Write($"Invalid. Enter number between {min} and {max}: ");
            }
        }
    }
}