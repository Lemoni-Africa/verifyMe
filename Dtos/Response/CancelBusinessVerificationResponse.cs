namespace VerifyMeIntegration.Dtos.Response.Business
{
    public class CancelBusinessVerificationResponse
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public bool isOk { get; set; }
    }

}
