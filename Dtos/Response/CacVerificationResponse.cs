using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class CacVerificationResponse
    {
        public string Status { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public string RcNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string BranchAddress { get; set; }
        public string CompanyEmail { get; set; }
        public string City { get; set; }
        public string Classification { get; set; }
        public string HeadOfficeAddress { get; set; }
        public string Lga { get; set; }
        public int Affiliates { get; set; }
        public string ShareCapital { get; set; }
        public string ShareCapitalInWords { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
    }
}
