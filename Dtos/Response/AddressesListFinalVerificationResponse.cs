using VerifyMeIntegration.Dtos.Response.AddressResponse;

namespace VerifyMeIntegration.Dtos.Response
{
    public class AddressesListFinalVerificationResponse : DefaultResponse
    {
        public AddressesListVerificationResponse AddressVerificationsResponse { get; set; }
        public ValidationListErrorResponse ErrorResponse { get; set; }
    }
}
