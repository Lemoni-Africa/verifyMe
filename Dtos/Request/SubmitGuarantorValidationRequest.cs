using System.Collections.Generic;

namespace VerifyMeIntegration.Dtos.Request
{
    public class SubmitGuarantorValidationRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string Landmark { get; set; }
        public List<string> AcceptableIdType { get; set; }


        public string ApplicantIdType { get; set; }
        public string ApplicantIdNumber { get; set; }
        public string ApplicantFirstname { get; set; }
        public string ApplicantLastname { get; set; }
        public string ApplicantDob { get; set; }
        public string ApplicantPhone { get; set; }
    }
}
