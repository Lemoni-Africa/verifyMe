namespace VerifyMeIntegration.Dtos.Request
{
    public class SubmitEmploymentHistoryRequest
    {
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
        public string ContactPersonName { get; set; }
       

    }


}
