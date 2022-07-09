using VerifyMeIntegration.Dtos.StateResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class GetCountriesFinalResponse : DefaultResponse
    {
        public GenericCodeResponse GetCountriesResponse { get; set; }
    }
}
