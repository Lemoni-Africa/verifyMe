
using VerifyMeIntegration.Dtos.Response.BusinessResponse;
using VerifyMeIntegration.Dtos.Response.GuarantorResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class GuarantorVerificationFinalResponse : DefaultResponse
    {
        public GuarantorVerificationResponse GuarantorVerificationResponse { get; set; }
        public ValidationListErrorResponse ErrorResponse { get; set; }
    }
}
