using System;
using System.Collections.Generic;
using System.Linq;

namespace SectionB_Question1_Municipality
{
    public class UtilitiesManager
    {
        private List<ServiceRequest> serviceRequests;

        public UtilitiesManager()
        {
            serviceRequests = new List<ServiceRequest>();
        }

        public void AddServiceRequest(ServiceRequest request)
        {
            serviceRequests.Add(request);
            CalculateUrgencyScore(request);
        }

        private void CalculateUrgencyScore(ServiceRequest request)
        {
            double severityFactor = 11 - request.SeverityLevel;
            double priorityFactor = 6 - request.PriorityLevel;
            double timeFactor = 10 / Math.Max(0.5, request.EstimatedResolutionHours);
            request.UrgencyScore = (severityFactor * priorityFactor) + timeFactor;
        }

        public void DisplayPendingRequests()
        {
            var pending = serviceRequests.Where(r => !r.IsProcessed).OrderByDescending(r => r.UrgencyScore).ToList();
            if (pending.Count == 0)
            {
                Console.WriteLine("No pending service requests.");
                return;
            }

            Console.WriteLine("\n===== PENDING SERVICE REQUESTS (by urgency) =====");
            for (int i = 0; i < pending.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {pending[i]}");
            }
        }

        public ServiceRequest? SelectRequestToProcess(int selection)
        {
            var pending = serviceRequests.Where(r => !r.IsProcessed).OrderByDescending(r => r.UrgencyScore).ToList();
            if (selection >= 1 && selection <= pending.Count)
                return pending[selection - 1];
            return null;
        }

        public string ProcessRequest(ServiceRequest request)
        {
            if (request == null || request.IsProcessed)
                return "Invalid or already processed request.";

            request.IsProcessed = true;
            return GenerateReport(request);
        }

        private string GenerateReport(ServiceRequest request)
        {
            return $@"
============================================
           SERVICE REQUEST REPORT
============================================
RESIDENT DETAILS:
  Name:           {request.RequestingResident.Name}
  Address:        {request.RequestingResident.Address}
  Account Number: {request.RequestingResident.AccountNumber}
  Monthly Usage:  {request.RequestingResident.MonthlyUtilityUsage} kWh

SERVICE REQUEST DETAILS:
  Request Type:           {request.RequestType}
  Priority Level (1-5):   {request.PriorityLevel}/5
  Severity Level (1-10):  {request.SeverityLevel}/10
  Estimated Resolution:   {request.EstimatedResolutionHours} hours

URGENCY SCORE: {request.UrgencyScore:F2}
============================================
";
        }

        public void DisplayFinalSummary()
        {
            var processed = serviceRequests.Where(r => r.IsProcessed).ToList();
            var highest = serviceRequests.OrderByDescending(r => r.UrgencyScore).FirstOrDefault();

            Console.WriteLine("\n============================================");
            Console.WriteLine("         FINAL MUNICIPAL SUMMARY");
            Console.WriteLine("============================================");
            Console.WriteLine($"Total Requests:      {serviceRequests.Count}");
            Console.WriteLine($"Processed Requests:  {processed.Count}");
            Console.WriteLine($"Pending Requests:    {serviceRequests.Count - processed.Count}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("RESOLVED REQUESTS:");
            foreach (var req in processed)
            {
                Console.WriteLine($"  - {req.RequestType} (Urgency: {req.UrgencyScore:F2})");
            }

            if (highest != null)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("HIGHEST URGENCY REQUEST:");
                Console.WriteLine($"  Request Type:  {highest.RequestType}");
                Console.WriteLine($"  Urgency Score: {highest.UrgencyScore:F2}");
                Console.WriteLine($"  Resident:      {highest.RequestingResident.Name}");
            }
            Console.WriteLine("============================================\n");
        }

        // Helper method used by Program.cs
        public List<ServiceRequest> GetAllRequests() => serviceRequests;
    }
}