
using VerifyMeIntegration.Dtos.Response.BusinessResponse;
using VerifyMeIntegration.Dtos.Response.EmploymentResponse;
using VerifyMeIntegration.Dtos.Response.GuarantorResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class EmploymentHistoryVerificationFinalResponse : DefaultResponse
    {
        public EmploymentHistoryVerificationResponse EmploymentHistoryVerificationResponse { get; set; }
        public ValidationListErrorResponse ErrorResponse { get; set; }
    }
}
