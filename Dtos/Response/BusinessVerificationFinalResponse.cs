
using VerifyMeIntegration.Dtos.Response.BusinessResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class BusinessVerificationFinalResponse : DefaultResponse
    {
        public BusinessVerificationResponse BusinessVerificationResponse { get; set; }
        public ValidationErrorResponse ErrorResponse { get; set; }
    }
}
