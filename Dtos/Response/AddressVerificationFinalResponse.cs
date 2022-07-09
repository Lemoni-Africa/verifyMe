
using VerifyMeIntegration.Dtos.Response.AddressResponse;
namespace VerifyMeIntegration.Dtos.Response
{
    public class AddressVerificationFinalResponse : DefaultResponse
    {
        public AddressVerificationResponse AddressVerificationResponse { get; set; }
        public ValidationErrorResponse ErrorResponse { get; set; }
    }
}
