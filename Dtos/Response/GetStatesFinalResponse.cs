using VerifyMeIntegration.Dtos.StateResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class GetStatesFinalResponse : DefaultResponse
    {
        public GenericCodeResponse GetStatesResponse { get; set; }
    }
}
