using System.Net.Http;
using System.Threading.Tasks;
using VerifyMeIntegration.Dtos;
using VerifyMeIntegration.Dtos.AddressPostback;
using VerifyMeIntegration.Dtos.EmploymentVerificationPostback;
using VerifyMeIntegration.Dtos.Request;
using VerifyMeIntegration.Dtos.Response;
using VerifyMeIntegration.Dtos.Response.AddressResponse;

namespace VerifyMeIntegration.Helpers
{
    public interface IHelper
    {
        Task<DefaultApiResponse> CallRestApi(string baseUrl, string apiUrl, HttpContent content, string secret, string method = "get");

        Task<BvnValidationFinalResponse> BvnVerification(string bvn);
        Task<CacVerificationFinalResponse> CacVerification(CacValidationRequest request);
        Task<LicenseValidationFinalResponse> LicenseVerification(LicenseValidationRequest request);
        Task<BiometricValidationFinalResponse> BiometricVerification(BiometricRequest request);
        Task<BiometricValidationFinalResponse> BiometricVerificationWithImage(BiometricRequest request);
        Task<BiometricValidationFinalResponse> BiometricVerificationWithBase64(BiometricRequest request);
        Task<NinValidationFinalResponse> NinVerification(NinValidationRequest request);
        Task<TinValidationFinalResponse> TinVerification(string tin);

        Task<VotersCardValidationFinalResponse> VotersCardVerification(VotersCardValidationRequest request);

        Task<AddressVerificationFinalResponse> AddressVerification(SubmitAddressVerificationRequest request);

        Task<AddressVerificationFinalResponse> GetAddressVerificationById(string verificationId);

        Task<AddressesListFinalVerificationResponse> GetAddressVerifications(Pagination pagination);

        Task<CancelAddressVerificationFinalResponse> CancelAddressVerification(string verificationId);

        Task<AddressVerificationFinalResponse> FetchAddressVerificationByIdentity(FetchAddressByIdentityRequest request);

        Task<DefaultResponse> UpdateAddressVerification(AddressVerificationPostback request, string verifyMeSignature);

        Task<BusinessVerificationFinalResponse> BusinessVerification(SubmitBusinessVerificationRequest request);

        Task<BusinessVerificationFinalResponse> GetBusinessVerificationById(string verificationId);

        Task<BusinessesListFinalVerificationResponse> GetBusinessesVerifications(Dtos.Response.BusinessResponse.Pagination pagination);

        Task<CancelBusinessVerificationFinalResponse> CancelBusinessVerification(string verificationId);

        Task<GuarantorVerificationFinalResponse> GuarantorVerification(SubmitGuarantorValidationRequest request);

        Task<GuarantorVerificationFinalResponse> GetGuarantorVerificationById(string verificationId);

        Task<GuarantorsListFinalVerificationResponse> GetGuarantorsVerifications(
            Dtos.Response.BusinessResponse.Pagination pagination);

        Task<CancelGuarantorVerificationFinalResponse> CancelGuarantorVerification(string verificationId);

        Task<DefaultResponse> UpdateGuarantorVerification(GuarantorVerificationPostback request,
            string verifyMeSignature);
        Task<EmploymentHistoryVerificationFinalResponse> EmploymentHistoryVerification(SubmitEmploymentHistoryRequest request);

        Task<EmploymentHistoryVerificationFinalResponse> GetEmploymentHistoryVerificationById(string verificationId);

        Task<CancelEmploymentHistoryVerificationFinalResponse> CancelEmploymentHistoryVerification(
            string verificationId);

        Task<EmploymentHistoryListFinalVerificationResponse> GetEmploymentHistoriesVerifications(
            Dtos.Response.BusinessResponse.Pagination pagination);

        Task<DefaultResponse> UpdateEmploymentHistoryVerification(EmploymentVerificationPostback request,
            string verifyMeSignature);
        Task<GetCountriesFinalResponse> GetCountries();
        Task<GetLgaFinalResponse> GetLgasByState(string stateId);
        Task<GetStatesFinalResponse> GetStatesByCountry(string countryId);
    }
}