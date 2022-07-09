using VerifyMeIntegration.Dtos.Response.BusinessResponse;
using VerifyMeIntegration.Dtos.Response.GuarantorResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class GuarantorsListFinalVerificationResponse : DefaultResponse
    {
        public GuarantorsListVerificationResponse GuarantorsVerificationResponse { get; set; }
        public ValidationErrorResponse ErrorResponse { get; set; }
    }
}
