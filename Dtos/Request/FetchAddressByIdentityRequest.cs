namespace VerifyMeIntegration.Dtos.Request
{
    public class FetchAddressByIdentityRequest
    {
        public string MaxAddressAge { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string IdNumber { get; set; }
        public string IdType { get; set; }
    }
}
