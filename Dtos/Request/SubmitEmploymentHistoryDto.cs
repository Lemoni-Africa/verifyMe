namespace VerifyMeIntegration.Dtos.EmploymentRequest
{
    public class SubmitEmploymentHistoryDto
    {
        public Applicant Applicant { get; set; }
        public string EmployerName { get; set; }
        public string EmployerEmail { get; set; }
        public string EmployerPhone { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string JobTitle { get; set; }
        public bool CurrentlyEmployed { get; set; }
        public string ContactPersonName { get; set; }
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
