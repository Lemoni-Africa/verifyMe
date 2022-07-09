using AutoMapper;
using Newtonsoft.Json;
using VerifyMeIntegration.Dtos.Request;
using VerifyMeIntegration.Models;


namespace VerifyMeIntegration.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LicenseValidationRequest, LicenseRequestDto>().ReverseMap();
            CreateMap<NinValidationRequest, NinRequestDto>().ReverseMap();
            CreateMap<VotersCardValidationRequest, VotersCardRequestDto>().ReverseMap();
            CreateMap<SubmitAddressVerificationRequest, AddressVerification>().ReverseMap();
            CreateMap<SubmitGuarantorValidationRequest, GuarantorVerification>().ReverseMap();
            CreateMap<SubmitEmploymentHistoryRequest, EmploymentVerification>().ReverseMap();
            CreateMap<SubmitGuarantorValidationRequest, GuarantorVerification>()
                .ForMember(dest => dest.AcceptableIdType, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.AcceptableIdType)));


        }
    }
}
