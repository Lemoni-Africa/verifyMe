using VerifyMeIntegration.Dtos.Response.BusinessResponse;
using VerifyMeIntegration.Dtos.Response.EmploymentResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class EmploymentHistoryListFinalVerificationResponse : DefaultResponse
    {
        public EmploymentHistoryListVerificationResponse EmploymentHistoryVerificationResponse { get; set; }
        public ValidationErrorResponse ErrorResponse { get; set; }
    }
}
