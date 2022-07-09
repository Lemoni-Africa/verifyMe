using VerifyMeIntegration.Dtos.Response.BusinessResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class BusinessesListFinalVerificationResponse : DefaultResponse
    {
        public BuninessesListVerificationResponse BuninessesVerificationResponse { get; set; }
        public ValidationListErrorResponse ErrorResponse { get; set; }
    }
}
