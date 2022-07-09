using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response.LicenseValidationResponse
{
    public class LicenseValidationResponse
    {
        public string Status { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public FieldMatches FieldMatches { get; set; }
        public string LicenseNo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IssuedDate { get; set; }
        public string ExpiryDate { get; set; }
        public string StateOfIssue { get; set; }
        public string Gender { get; set; }
        public string Birthdate { get; set; }
        public string Photo { get; set; }
    }

    public class FieldMatches
    {
        public bool Firsname { get; set; }
        public bool Lastname { get; set; }
        public bool Dob { get; set; }
    }
}
