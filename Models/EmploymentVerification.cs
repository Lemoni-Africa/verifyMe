using System;
using VerifyMeIntegration.Dtos;

namespace VerifyMeIntegration.Models
{
    public class EmploymentVerification  : BaseModel
    {
        public int ? EmploymentVerificationId { get; set; }
        public string ApplicantIdType { get; set; }
        public string ApplicantIdNumber { get; set; }
        public string ApplicantFirstname { get; set; }
        public string ApplicantLastname { get; set; }
        public string ApplicantDob { get; set; }
        public string ApplicantPhone { get; set; }

        public string EmployerName { get; set; }
        public string EmployerEmail { get; set; }
        public string EmployerPhone { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string JobTitle { get; set; }
        public bool CurrentlyEmployed { get; set; }
        public string StatusState { get; set; }
        public string CompletedAt { get; set; }
        public string PostBackJson { get; set; }
        public string ContactPersonName { get; set; }
    }

    
}
