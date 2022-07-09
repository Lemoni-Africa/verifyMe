namespace VerifyMeIntegration.Dtos.Response
{
    public class BvnValidationResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}
