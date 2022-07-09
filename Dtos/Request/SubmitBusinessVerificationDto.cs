using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace VerifyMeIntegration.Dtos.BusinessDto
{
    public class SubmitBusinessVerificationDto
    {
        public string Street { get; set; }
        public string Lga { get; set; }
        public string State { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public string RcNumber { get; set; }
        public string City { get; set; }
        public string CanContactPoc { get; set; }
        public Applicant Applicant { get; set; }
    }
    public class Applicant
    {
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Dob { get; set; }
    }


}
