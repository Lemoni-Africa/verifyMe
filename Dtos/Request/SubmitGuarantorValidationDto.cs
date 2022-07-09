using System.Collections.Generic;

namespace VerifyMeIntegration.Dtos.Request
{
    public class SubmitGuarantorValidationDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Lga { get; set; }
        public string Landmark { get; set; }
        public List<string> AcceptableIdType { get; set; }
        public bool VerifyAddress { get; set; } = true;
        public Applicant Applicant { get; set; }




        
    }
    public class Applicant
    {
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Dob { get; set; }
        public string Phone { get; set; }
    }
}
