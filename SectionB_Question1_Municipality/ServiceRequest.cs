using System;

namespace SectionB_Question1_Municipality
{
    public class ServiceRequest
    {
        public Resident RequestingResident { get; set; }
        public string RequestType { get; set; }
        public int PriorityLevel { get; set; }      // 1 to 5 (1 = highest priority)
        public int SeverityLevel { get; set; }      // 1 to 10 (1 = most severe)
        public double EstimatedResolutionHours { get; set; }
        public bool IsProcessed { get; set; }
        public double UrgencyScore { get; set; }

        public ServiceRequest(Resident resident, string requestType, int priority, int severity, double hours)
        {
            RequestingResident = resident;
            RequestType = requestType;
            PriorityLevel = priority;
            SeverityLevel = severity;
            EstimatedResolutionHours = hours;
            IsProcessed = false;
            UrgencyScore = 0;
        }

        public override string ToString()
        {
            return $"Type: {RequestType} | Priority: {PriorityLevel}/5 | Severity: {SeverityLevel}/10 | Hours: {EstimatedResolutionHours} | Urgency: {UrgencyScore:F2}";
        }
    }
}