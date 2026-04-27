using System;

namespace SectionB_Question2_HomeAffairs
{
    public class CitizenProfile
    {
        public string FullName { get; set; }
        public string IDNumber { get; set; }
        public int Age { get; private set; }
        public string CitizenshipStatus { get; set; }

        public CitizenProfile(string fullName, string idNumber, string citizenshipStatus)
        {
            FullName = fullName;
            IDNumber = idNumber;
            CitizenshipStatus = citizenshipStatus;
            Age = CalculateAge(idNumber);
        }

        private int CalculateAge(string idNumber)
        {
            if (string.IsNullOrEmpty(idNumber) || idNumber.Length < 6)
                return 0;

            try
            {
                // Extract YYMMDD from first 6 digits
                string yyStr = idNumber.Substring(0, 2);
                string mmStr = idNumber.Substring(2, 2);
                string ddStr = idNumber.Substring(4, 2);

                int yy = int.Parse(yyStr);
                int mm = int.Parse(mmStr);
                int dd = int.Parse(ddStr);

                // Determine century: if yy <= current year's last two digits, assume 2000s, else 1900s
                int currentYear = DateTime.Now.Year;
                int currentYY = currentYear % 100;
                int century = (yy <= currentYY) ? 2000 : 1900;
                int birthYear = century + yy;

                DateTime birthDate;
                try
                {
                    birthDate = new DateTime(birthYear, mm, dd);
                }
                catch
                {
                    return 0; // invalid date
                }

                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Year;
                if (birthDate > today.AddYears(-age)) age--;
                return age;
            }
            catch
            {
                return 0;
            }
        }

        public string ValidateID()
        {
            // 1. Exactly 13 digits
            if (IDNumber.Length != 13)
                return "INVALID: ID number must contain exactly 13 digits.";

            // 2. All numeric
            foreach (char c in IDNumber)
                if (!char.IsDigit(c))
                    return "INVALID: ID number must contain only numeric digits.";

            // 3. Age check (must be between 0 and 120)
            if (Age <= 0 || Age > 120)
                return $"INVALID: Could not calculate a valid age from ID number. Calculated age: {Age}";

            return $"VALID: ID number format is correct. Citizen is {Age} years old.";
        }

        public string GenerateProfileSummary(string validationResult, DateTime processingTime)
        {
            return $@"===========================================
       DIGITAL CITIZEN PROFILE
===========================================
Full Name:        {FullName}
ID Number:        {IDNumber}
Age:              {Age} years
Citizenship:      {CitizenshipStatus}
-------------------------------------------
Validation Result: {validationResult}
Processed At:     {processingTime:yyyy-MM-dd HH:mm:ss}
===========================================";
        }
    }
}