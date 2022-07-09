using System.Collections.Generic;
using System.Threading.Tasks;
using VerifyMeIntegration.Models;

namespace VerifyMeIntegration.Data.Repo
{
    public interface IDataRepository
    {
        void Delete<T>(T entity) where T : class;
        void add<T>(T entity) where T : class;
        Task<bool> SaveAll();

        Task<bool> StoreAddressVerificationDetails(AddressVerification model);

        Task UpdateAddressVerificationStatus(int addressId, string status, string completionDate, string postBackJson);

        Task<bool> StoreIdentityVerificationDetails(IdentityVerification model);

        Task<IdentityVerification> CheckAndGetIdentityVerified(string idType, string idReference);

        Task<bool> StoreGuarantorDetails(GuarantorVerification model);

        Task UpdateGuarantorsVerificationStatus(int verificationId, string status, string statusState, string completionDate, string postBackJson);

        Task<bool> StoreEmploymentHistoryDetails(EmploymentVerification model);

        Task UpdateEmploymentHistoryVerificationStatus(int verificationId, string status, string completionDate, string postBackJson);

        Task AddApiCall(string resource, string callStatus, string apiUrl, double price);
    }
}