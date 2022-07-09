using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VerifyMeIntegration.Models;

namespace VerifyMeIntegration.Data.Repo
{
    public class DataRepository : IDataRepository
    {
        private readonly VerifyMeDataContext _context;


        public DataRepository(VerifyMeDataContext context)
        {
            _context = context;
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

       /* public async Task<List<AddressVerification>> GetAllAddressVerifications(TransactionFilter filter)
        {
            var transactions = _context.AddressVerification.OrderByDescending(x => x.CreatedAt).AsQueryable();

            if (!string.IsNullOrEmpty(filter.SolId))
            {
                transactions = transactions.Where(x => x.SolId == filter.SolId);
            }
            if (!string.IsNullOrEmpty(filter.InitiatorEmpId))
            {
                transactions = transactions.Where(x => x.EnteredBy == filter.InitiatorEmpId);
            }
            if (!string.IsNullOrEmpty(filter.Posted))
            {
                transactions = transactions.Where(x => x.Posted == filter.Posted);
            }
            if (!string.IsNullOrEmpty(filter.ApproverEmpId))
            {
                transactions = transactions.Where(x => x.ApprovedBy == filter.ApproverEmpId);
            }
            if (!string.IsNullOrEmpty(filter.TransactionId))
            {
                transactions = transactions.Where(x => x.TransactionId == filter.TransactionId);
            }
            if (filter.TransactionDate != null)
            {
                transactions = transactions.Where(x => x.TransactionDate == filter.TransactionDate);
            }
            if (!string.IsNullOrEmpty(filter.TransactionId))
            {
                transactions = transactions.Where(x => x.TransactionId == filter.TransactionId);
            }
            if (!string.IsNullOrEmpty(filter.TransactionType))
            {
                transactions = transactions.Where(x => x.TransactionType == filter.TransactionType);
            }

            return await transactions.ToListAsync();
        }*/


        public async Task<bool> StoreAddressVerificationDetails(AddressVerification model)
        {
            await _context.AddressVerification.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateAddressVerificationStatus(int addressId, string status, string completionDate, string postBackJson)
        {
            var model = await  _context.AddressVerification.Where(x => x.AddressVerificationId == addressId)
                .FirstOrDefaultAsync();
            if (model == null)
                return;
            model.CompletedAt = completionDate;
            model.Status = status;
            model.PostBackJson = postBackJson;
            model.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();

        }

        public async Task<bool> StoreIdentityVerificationDetails(IdentityVerification model)
        {
            await _context.IdentityVerification.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IdentityVerification> CheckAndGetIdentityVerified(string idType, string idReference)
        {
            return await _context.IdentityVerification.Where(x => x.IdType == idType).Where(x => x.IdReference == idReference)
                .Where(x => x.Status.ToLower() == "success")
                .FirstOrDefaultAsync();
        }

        public async Task<bool> StoreGuarantorDetails(GuarantorVerification model)
        {
            await _context.GuarantorVerification.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateGuarantorsVerificationStatus(int verificationId, string status, string statusState, string completionDate, string postBackJson)
        {
            var model = await _context.GuarantorVerification.Where(x => x.GuarantorsVerificationId == verificationId)
                .FirstOrDefaultAsync();
            if (model == null)
                return;
            model.CompletedAt = completionDate;
            model.Status = status;
            model.StatusState = statusState;
            model.PostBackJson = postBackJson;
            model.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();

        }

        public async Task<bool> StoreEmploymentHistoryDetails(EmploymentVerification model)
        {
            await _context.EmploymentVerification.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateEmploymentHistoryVerificationStatus(int verificationId, string status, string statusState, string postBackJson)
        {
            var model = await _context.EmploymentVerification.Where(x => x.EmploymentVerificationId == verificationId)
                .FirstOrDefaultAsync();
            if (model == null)
                return;
            model.Status = status;
            model.StatusState = statusState;
            model.PostBackJson = postBackJson;
            model.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();

        }

        public async Task AddApiCall(string resource, string callStatus, string apiUrl, double price)
        {
            var model = new ApiCalls
            {
                ApiUrl = apiUrl,
                CallCost = price,
                CallStatus = callStatus,
                ResourceName = resource
            };

            await _context.ApiCalls.AddAsync(model);
            await _context.SaveChangesAsync();
        }


    }
}