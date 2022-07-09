using System;
using System.Collections.Generic;

namespace VerifyMeIntegration.Models
{
    public class GuarantorVerification : BaseModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string Landmark { get; set; }
        public string AcceptableIdType { get; set; }


        public string ApplicantIdType { get; set; }
        public string ApplicantIdNumber { get; set; }
        public string ApplicantFirstname { get; set; }
        public string ApplicantLastname { get; set; }
        public string ApplicantDob { get; set; }
        public string ApplicantPhone { get; set; }
        public string StatusState { get; set; }

        public int? GuarantorsVerificationId { get; set; }
        public string CompletedAt { get; set; }

        public string PostBackJson { get; set; }

    }
}
