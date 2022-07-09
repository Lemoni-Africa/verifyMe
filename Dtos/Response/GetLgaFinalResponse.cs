using VerifyMeIntegration.Dtos.StateResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class GetLgaFinalResponse : DefaultResponse
    {
        public GenericCodeResponse GetLgasResponse { get; set; }
    }
}
