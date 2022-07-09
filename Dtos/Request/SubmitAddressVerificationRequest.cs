namespace VerifyMeIntegration.Dtos.Request
{
    public class SubmitAddressVerificationRequest
    {
        public string Street { get; set; }
        public string Lga { get; set; }
        public string State { get; set; }
        public string Landmark { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Dob { get; set; }
    }



}
