using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VerifyMeIntegration.Data.Repo;
using VerifyMeIntegration.Dtos;
using VerifyMeIntegration.Dtos.AddressPostback;
using VerifyMeIntegration.Dtos.BusinessDto;
using VerifyMeIntegration.Dtos.EmploymentRequest;
using VerifyMeIntegration.Dtos.EmploymentVerificationPostback;
using VerifyMeIntegration.Dtos.Request;
using VerifyMeIntegration.Dtos.RequestDto;
using VerifyMeIntegration.Dtos.Response;
using VerifyMeIntegration.Dtos.Response.AddressResponse;
using VerifyMeIntegration.Dtos.Response.BiometricValidationResponse;
using VerifyMeIntegration.Dtos.Response.Business;
using VerifyMeIntegration.Dtos.Response.BusinessResponse;
using VerifyMeIntegration.Dtos.Response.EmploymentResponse;
using VerifyMeIntegration.Dtos.Response.GuarantorResponse;
using VerifyMeIntegration.Dtos.Response.LicenseValidationResponse;
using VerifyMeIntegration.Dtos.Response.NinValidationResponse;
using VerifyMeIntegration.Dtos.Response.TinValidationResponse;
using VerifyMeIntegration.Dtos.Response.VotersCardValidationResponse;
using VerifyMeIntegration.Dtos.StateResponse;
using VerifyMeIntegration.Models;

namespace VerifyMeIntegration.Helpers
{
    public class Helper : IHelper
    {
  
        private readonly IMapper _mapper;
        private readonly ILogger<Helper> _logger;
        private readonly IConfiguration _configuration;
        private readonly IDataRepository _repository;
        private readonly string _apiPublicKey;
        private readonly string _apiSecret;
        private readonly string _verifyMeBaseUrl;
        private readonly string _verifyCacUrl;
        private  string _verifyLicenseUrl;
        private readonly string _verifyBiometricUrl;
        private  string _verifyNinUrl;
        private  string _verifyTinUrl;
        private  string _verifyVotersCardUrl;


        private readonly string _verifyAddressUrl;
        private  string _getAddressVerificationByIdUrl;
        private  string _getAddressesVerificationUrl;
        private  string _cancelAddressVerificationUrl;
        private readonly string _fetchAddressByIdentityEndpoints;

        private readonly string _verifyBusinessUrl;
        private  string _getBusinessVerificationByIdUrl;
        private  string _getBusinessesVerificationUrl;
        private  string _cancelBusinessVerificationUrl;

        private readonly string _verifyGuarantorUrl;
        private  string _getGuarantorVerificationByIdUrl;
        private  string _getGuarantorsVerificationUrl;
        private  string _cancelGuarantorVerificationUrl;

        private readonly string _verifyEmploymentHistoryUrl;
        private  string _getEmploymentHistoryVerificationByIdUrl;
        private  string _getEmploymentsHistoryVerificationUrl;
        private  string _cancelEmploymentHistoryVerificationUrl;

        private string _getCountriesUrl;
        private string _getStatesByCountryUrl;
        private string _getLgasByStateUrl;
        private string _secondBaseUrl;
        private string _verifyBvnUrl;
        private PricingList _pricingList = null;

        public Helper(IMapper mapper,  ILogger<Helper> logger, IConfiguration configuration, IDataRepository repository, IOptions<PricingList> options)
        {

            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _apiSecret = _configuration.GetSection("ApiSecret").Value;
            _apiPublicKey = _configuration.GetSection("ApiPublicKey").Value;
            _verifyMeBaseUrl = _configuration.GetSection("ServiceUrls").GetSection("VerifyMeBaseUrl").Value;
            _secondBaseUrl = _configuration.GetSection("ServiceUrls").GetSection("SecondBaseUrl").Value;
            _pricingList = options.Value;

            //Identity
            _verifyCacUrl = _configuration.GetSection("ServiceUrls").GetSection("Identity").GetSection("VerifyCacUrl").Value;
            _verifyLicenseUrl = _configuration.GetSection("ServiceUrls").GetSection("Identity").GetSection("VerifyLicenseUrl").Value;
            _verifyBiometricUrl = _configuration.GetSection("ServiceUrls").GetSection("Identity").GetSection("VerifyBioMetricUrl").Value;
            _verifyNinUrl = _configuration.GetSection("ServiceUrls").GetSection("Identity").GetSection("VerifyNinUrl").Value;
            _verifyTinUrl = _configuration.GetSection("ServiceUrls").GetSection("Identity").GetSection("VerifyTinUrl").Value;
            _verifyVotersCardUrl = _configuration.GetSection("ServiceUrls").GetSection("Identity").GetSection("VerifyVotersIdUrl").Value;
            _verifyBvnUrl = _configuration.GetSection("ServiceUrls").GetSection("Identity").GetSection("VerifyBvnUrl").Value;

            //Address
            _verifyAddressUrl = _configuration.GetSection("ServiceUrls").GetSection("Address").GetSection("VerifyAddressUrl").Value;
            _getAddressVerificationByIdUrl = _configuration.GetSection("ServiceUrls").GetSection("Address").GetSection("GetAddressVerificationByIdUrl").Value;
            _getAddressesVerificationUrl = _configuration.GetSection("ServiceUrls").GetSection("Address").GetSection("GetAddressesVerificationUrl").Value;
            _cancelAddressVerificationUrl = _configuration.GetSection("ServiceUrls").GetSection("Address").GetSection("CancelAddressVerificationUrl").Value;
            _fetchAddressByIdentityEndpoints = _configuration.GetSection("ServiceUrls").GetSection("Address").GetSection("FetchAddressByIdentityEndpoints").Value;


             //Business
            _verifyBusinessUrl = _configuration.GetSection("ServiceUrls").GetSection("Business").GetSection("VerifyBusinessUrl").Value;
            _getBusinessVerificationByIdUrl = _configuration.GetSection("ServiceUrls").GetSection("Business").GetSection("GetBusinessVerificationByIdUrl").Value;
            _getBusinessesVerificationUrl = _configuration.GetSection("ServiceUrls").GetSection("Business").GetSection("GetBusinessesVerificationUrl").Value;
            _cancelBusinessVerificationUrl = _configuration.GetSection("ServiceUrls").GetSection("Business").GetSection("CancelBusinessVerificationUrl").Value;

            //Guarantor
            _verifyGuarantorUrl = _configuration.GetSection("ServiceUrls").GetSection("Guarantor").GetSection("VerifyGuarantorUrl").Value;
            _getGuarantorVerificationByIdUrl = _configuration.GetSection("ServiceUrls").GetSection("Guarantor").GetSection("GetGuarantorVerificationByIdUrl").Value;
            _getGuarantorsVerificationUrl = _configuration.GetSection("ServiceUrls").GetSection("Guarantor").GetSection("GetGuarantorsVerificationUrl").Value;
            _cancelGuarantorVerificationUrl = _configuration.GetSection("ServiceUrls").GetSection("Guarantor").GetSection("CancelGuarantorVerificationUrl").Value;

            //Employment History
            _verifyEmploymentHistoryUrl = _configuration.GetSection("ServiceUrls").GetSection("Employment").GetSection("VerifyEmploymentHistoryUrl").Value;
            _getEmploymentHistoryVerificationByIdUrl = _configuration.GetSection("ServiceUrls").GetSection("Employment").GetSection("GetEmploymentHistoryVerificationByIdUrl").Value;
            _getEmploymentsHistoryVerificationUrl = _configuration.GetSection("ServiceUrls").GetSection("Employment").GetSection("GetEmploymentsHistoryVerificationUrl").Value;
            _cancelEmploymentHistoryVerificationUrl = _configuration.GetSection("ServiceUrls").GetSection("Employment").GetSection("CancelEmploymentHistoryVerificationUrl").Value;

            //Inquries
            _getCountriesUrl = _configuration.GetSection("ServiceUrls").GetSection("Inquiries").GetSection("GetCountries").Value;
            _getStatesByCountryUrl = _configuration.GetSection("ServiceUrls").GetSection("Inquiries").GetSection("StatesByCountry").Value;
            _getLgasByStateUrl = _configuration.GetSection("ServiceUrls").GetSection("Inquiries").GetSection("LocalGovernmentsByState").Value;

        }

        public static DateTime ChangeToDateTime(string dateString)
        {
            if (dateString != null)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime newDate = DateTime.ParseExact(dateString, new string[] { "dd/MM/yyyy hh:mm:ss tt", "dd-MM-yyyy hh:mm:ss tt", "MM/dd/yyyy hh:mm:ss tt", "M/dd/yyyy hh:mm:ss tt", "M-dd-yyyy hh:mm:ss tt",  "yyyy/MM/dd hh:mm:ss tt", "yyyy-MM-dd hh:mm:ss tt",
                    "d/M/yyyy h:m:s tt", "dd-MM-yyyy h:m:s tt", "d/M/yyyy h:m:s tt", "M/d/yyyy h:m:s tt", "M-dd-yyyy hh:mm:ss tt",  "yyyy/MM/dd hh:mm:ss tt", "yyyy-MM-dd hh:mm:ss tt",
                    "yyyy-MM-dd HH:mm:ss", "dd-MM-yyyy HH:mm:ss",  "dd/MM/yyyy HH:mm:ss", "yyyy-MM-ddTHH:mm:ss.fff", "dd/MM/yyyyTHH:mm:ss", "dd-MM-yyyyTHH:mm:ss", "dd.MM.yyyy", "dd/MM/yyyy", "dd-MM-yyyy", "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "yyyy-dd-MM", "dd-MM-yy", "yy-MM-dd", "dd-MMM-yy", "yy-MMM-dd" }, provider, DateTimeStyles.None);
                return newDate;
            }
            return DateTime.Now;
        }

        public static string FormatDateOfBirthFormatDateOfBirth(string stringDate)
        {
            var newDate = ChangeToDateTime(stringDate);
            var FIDate = newDate.ToString("dd-MM-yyyy") ;

            return FIDate;

        }

        public static string FormatDateOfBirth2(string stringDate)
        {
            var newDate = ChangeToDateTime(stringDate);
            var FIDate = newDate.ToString("yyyy-MM-dd");

            return FIDate;

        }

        public bool IsBase64(string base64String)
        {
            if (base64String.Replace(" ", "").Length % 4 != 0)
            {
                return false;
            }

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (FormatException)
            {
                // Handle the exception
            }
            return false;
        }

        public Image ConvertBase64ToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms)
                    ;
            }
            return image;
        }


        public async Task<DefaultApiResponse> CallRestApi(string baseUrl, string apiUrl, HttpContent content, string secret, string method = "get")
        {
            var response = new DefaultApiResponse();
            //
            try
            {
                using var client = new HttpClient();

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(secret))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + secret);
                }
                //
                _logger.LogInformation(JsonConvert.SerializeObject(client));
                HttpResponseMessage httpResponse;
                switch (method.ToLower())
                {
                    case "post":
                        httpResponse =  await  client.PostAsync(apiUrl, content);
                        break;
                    case "delete":
                        httpResponse = await client.DeleteAsync(apiUrl);
                        break;
                    case "put":
                        httpResponse = await client.PutAsync(apiUrl, content);
                        break;
                    case "patch":
                        httpResponse = await client.PatchAsync(apiUrl, content);
                        break;
                    default:
                        httpResponse = await  client.GetAsync(apiUrl);
                        break;
                }
                response.StatusCode = (int)httpResponse.StatusCode;
                response.ResponseJson = httpResponse.Content.ReadAsStringAsync().Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    response.IsSuccessful = true;
                    
                }
                _logger.LogInformation($"API Call Response {JsonConvert.SerializeObject(response)}");
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(JsonConvert.SerializeObject(e));
                response.StatusCode = 500;
                response.ResponseJson = e.Message;
                return response;
            }

        }

        private StringContent CreateContent(object requestObject)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string content = JsonConvert.SerializeObject(requestObject, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });



            return new StringContent(content, Encoding.UTF8, "application/json");
        }

        public async Task<BvnValidationFinalResponse> BvnVerification(string bvn)
        {
            var response = new BvnValidationFinalResponse();
            //Check if verification for NIN has been done before 
            var verifiedCac = await GetVerifiedIdentity(bvn, "BVN");
            if (verifiedCac != null)
            {
                response.IsSuccessful = true;
                response.ValidationResponse = JsonConvert.DeserializeObject<BvnValidationResponse>(verifiedCac.ResponseJson);
                await _repository.AddApiCall("BVN", "Successful", "", _pricingList.Bvn);
                return response;
            }

            _verifyBvnUrl = _verifyBvnUrl.Replace(":ref", bvn);

            _logger.LogInformation("Calling Verify Me API for BVN Validation");
            var apiResponse = await CallRestApi(_secondBaseUrl, _verifyBvnUrl, null, "", "GET");
            //Create Identity validation instance for persistence 
            var model = new IdentityVerification
            {
                IdReference = bvn,
                Type = "BVN",
                IdType = "BVN"

            };
            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"BVN Validation Successful for {bvn}");
                response.ValidationResponse =
                    JsonConvert.DeserializeObject<BvnValidationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"BVN Validation Successful for {bvn}";
                model.Status = response?.ValidationResponse?.ResponseCode == "00" ? "Success" : "Failed";
                model.ResponseJson = apiResponse.ResponseJson;
                await _repository.AddApiCall("BVN", "Successful", "", _pricingList.Bvn);

            }
            else
            {
                _logger.LogInformation($"BVN Validation Failed for {bvn}");
                response.ResponseMessage = "BVN Validation Failed";
                await _repository.AddApiCall("BVN", "Successful", "", _pricingList.Bvn);

            }

            await _repository.StoreIdentityVerificationDetails(model);

            return response;
        }

        public async Task<CacVerificationFinalResponse> CacVerification(CacValidationRequest request)
        {
            var response = new CacVerificationFinalResponse();
            //Check if verification for NIN has been done before 
            var verifiedCac = await GetVerifiedIdentity(request.RcNumber.ToString(), "CAC");
            if (verifiedCac != null)
            {
                response.IsSuccessful = true;
                response.CacVerificationResponse = JsonConvert.DeserializeObject<CacVerificationResponse>(verifiedCac.ResponseJson);
                return response;
            }

            StringContent content = CreateContent(request);
            
            _logger.LogInformation("Calling Verify Me API for CAC Validation");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyCacUrl, content, _apiSecret, "POST");
            //Create Identity validation instance for persistence 
            var model = new IdentityVerification
            {
                IdReference = request.RcNumber.ToString(),
                Type = request.Type,
                RequestJson = JsonConvert.SerializeObject(request),
                IdType = "CAC"
                
            };
            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"CAC Validation Successful for {request.RcNumber}");
                response.CacVerificationResponse =
                    JsonConvert.DeserializeObject<CacVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"CAC Validation Successful for {request.RcNumber}";
                model.Status = response.CacVerificationResponse?.Status.ToLower();
                model.ResponseJson = apiResponse.ResponseJson;

            }
            else
            {
                _logger.LogInformation($"CAC Validation Failed for {request.RcNumber}");
                response.ErrorResponse = JsonConvert.DeserializeObject<CacErrorResponse>(apiResponse.ResponseJson);
                
            }

            await _repository.StoreIdentityVerificationDetails(model);

            return response;
        }

        public async Task<LicenseValidationFinalResponse> LicenseVerification(LicenseValidationRequest request)
        {
            var response = new LicenseValidationFinalResponse();
            //Check if verification for NIN has been done before 
            var verifiedLicense = await GetVerifiedIdentity(request.Ref, "License");
            if (verifiedLicense != null)
            {
                //Todo Check if the license is expired
                response.IsSuccessful = true;
                response.LicenseValidationResponse = JsonConvert.DeserializeObject<LicenseValidationResponse>(verifiedLicense.ResponseJson);
                return response;
            }
            var requestBody = new
            {
                firstname = request.FirstName,
                lastname = request.LastName,
                dob = request.Dob
            };


            StringContent content = CreateContent(requestBody);
            
            _logger.LogInformation("Calling Verify Me API for License Validation");
            _verifyLicenseUrl = _verifyLicenseUrl.Replace(":ref", request.Ref);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyLicenseUrl, content, _apiSecret, "POST");

            var model = new IdentityVerification
            {
                IdReference = request.Ref,
                RequestJson = JsonConvert.SerializeObject(request),
                IdType = "License",
                Firstname = request.FirstName,
                Lastname = request.LastName,
                Dob = request.Dob

            };

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"License Validation Successful for {request.Ref}");
                response.LicenseValidationResponse =
                    JsonConvert.DeserializeObject<LicenseValidationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"License Validation Successful for {request.Ref}";
                model.Status = response.LicenseValidationResponse?.Status.ToLower();
                model.ResponseJson = apiResponse.ResponseJson;
                model.ExpiryDate = response.LicenseValidationResponse?.Data.ExpiryDate == null ? null : Computation.MyChangeToDateTime(response.LicenseValidationResponse?.Data.ExpiryDate);
            }
            else
            {
                _logger.LogInformation($"License Validation Failed for {request.Ref}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);

            }
            await _repository.StoreIdentityVerificationDetails(model);
            return response;
        }

        public async Task<BiometricValidationFinalResponse> BiometricVerification(BiometricRequest request)
        {
            var requestBody = new
            {
                idNumber = request.IdNumber,
                photoUrl = request.PhotoUrl,
                idType = request.IdType
            };
            StringContent content = CreateContent(requestBody);
            var response = new BiometricValidationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Biometric Verification with Photo Url");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyBiometricUrl, content, _apiSecret, "POST");

            var model = new IdentityVerification
            {
                IdReference = request.IdNumber,
                RequestJson = JsonConvert.SerializeObject(request),
                IdType = request.IdType,
                Firstname = "Biometric",
                Lastname = "Verification"

            };

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Biometric Validation Successful for {request.IdNumber}");
                response.BiometricValidationResponse =
                    JsonConvert.DeserializeObject<BiometricValidationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"Biometric Validation Successful for {request.IdNumber}";
                model.Status = response.BiometricValidationResponse?.Status.ToLower();
                model.ResponseJson = apiResponse.ResponseJson;
                await _repository.AddApiCall("BVNBiometric", "Successful", "", _pricingList.BvnBiometric);

            }
            else
            {
                _logger.LogInformation($"Biometric Validation Failed for {request.IdNumber}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationListErrorResponse>(apiResponse.ResponseJson);
                await _repository.AddApiCall("BVNBiometric", "Successful", "", _pricingList.BvnBiometric);

            }
            await _repository.StoreIdentityVerificationDetails(model);

            return response;
        }

        public async Task<BiometricValidationFinalResponse> BiometricVerificationWithBase64(BiometricRequest request)
        {
            var requestBody = new
            {
                idNumber = request.IdNumber,
                photoBase64 = request.PhotoBase64,
                idType = request.IdType
            };
            StringContent content = CreateContent(requestBody);
            var response = new BiometricValidationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Biometric Verification with Base64 Encoded Image");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyBiometricUrl, content, _apiSecret, "POST");

            var model = new IdentityVerification
            {
                IdReference = request.IdNumber,
                RequestJson = JsonConvert.SerializeObject(request),
                IdType = request.IdType,
                Firstname = "Biometric",
                Lastname = "Verification"

            };

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Biometric Validation Successful for {request.IdNumber}");
                response.BiometricValidationResponse =
                    JsonConvert.DeserializeObject<BiometricValidationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"Biometric Validation Successful for {request.IdNumber}";
                model.Status = response.BiometricValidationResponse?.Status.ToLower();
                model.ResponseJson = apiResponse.ResponseJson;
                await _repository.AddApiCall("BVNBiometric", "Successful", "", _pricingList.BvnBiometric);
            }
            else
            {
                try
                {
                    _logger.LogInformation($"Biometric Validation Failed for {request.IdNumber}");
                    response.ErrorResponse =
                        JsonConvert.DeserializeObject<ValidationListErrorResponse>(apiResponse.ResponseJson);
                }
                catch (Exception exception)
                {
                    var errorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);
                    var errorList = new ValidationListErrorResponse();
                    errorList.Code = errorResponse.Code;
                    errorList.StatusCode = errorResponse.StatusCode;
                    errorList.Message = new List<string> {errorResponse.Message};
                    response.ErrorResponse = errorList;
                }

                await _repository.AddApiCall("BVNBiometric", "Failed", "", _pricingList.BvnBiometric);
            }
            await _repository.StoreIdentityVerificationDetails(model);

            return response;
        }

        public async Task<BiometricValidationFinalResponse> BiometricVerificationWithImage(BiometricRequest request)
        {
            var response = new BiometricValidationFinalResponse();
            var photo = ConvertBase64ToImage(request.Photo);
            var requestBody = new
            {
                idNumber = request.IdNumber,
                photo = photo,
                idType = request.IdType
            };
            StringContent content = CreateContent(requestBody);

            _logger.LogInformation("Calling Verify Me API for Biometric Verification with Image File");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyBiometricUrl, content, _apiSecret, "POST");

            var model = new IdentityVerification
            {
                IdReference = request.IdNumber,
                RequestJson = JsonConvert.SerializeObject(request),
                IdType = request.IdType,
                Firstname = "Biometric",
                Lastname = "Verification"

            };

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Biometric Validation Successful for {request.IdNumber}");
                response.BiometricValidationResponse =
                    JsonConvert.DeserializeObject<BiometricValidationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"Biometric Validation Successful for {request.IdNumber}";
                model.Status = response.BiometricValidationResponse?.Status.ToLower();
                model.ResponseJson = apiResponse.ResponseJson;
            }
            else
            {
                _logger.LogInformation($"Biometric  Validation Failed for {request.IdNumber}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationListErrorResponse>(apiResponse.ResponseJson);

            }
            /*await using (var memoryStream = new MemoryStream())
            {
                await request.Photo.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    
                }
            }*/

            await _repository.StoreIdentityVerificationDetails(model);
            return response;
        }

        public async Task<NinValidationFinalResponse> NinVerification(NinValidationRequest request)
        {
            var response = new NinValidationFinalResponse();
            //Check if verification for NIN has been done before 
            var verifiedNin = await GetVerifiedIdentity(request.Ref, "NIN");
            if (verifiedNin != null)
            {
                response.IsSuccessful = true;
                response.NinValidationResponse =  JsonConvert.DeserializeObject<NinValidationResponse>(verifiedNin.ResponseJson);
                await _repository.AddApiCall("NIN", "Successful", "", _pricingList.Nin);
                return response;
            }
            var requestBody = new
            {
                firstname = request.FirstName,
                lastname = request.LastName,
                dob = request.Dob
            };
            StringContent content = CreateContent(requestBody);
            
            _logger.LogInformation("Calling Verify Me API for NIN Validation");
            _verifyNinUrl = _verifyNinUrl.Replace(":ref", request.Ref);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyNinUrl, content, _apiSecret, "POST");

            var model = new IdentityVerification
            {
                IdReference = request.Ref,
                RequestJson = JsonConvert.SerializeObject(request),
                IdType = "NIN",
                Firstname = request.FirstName,
                Lastname = request.LastName,
                Dob = request.Dob

            };

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"NIN Validation Successful for {request.Ref}");
                response.NinValidationResponse =
                    JsonConvert.DeserializeObject<NinValidationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"NIN Validation Successful for {request.Ref}";
                model.Status = response.NinValidationResponse?.Status.ToLower();
                model.ResponseJson = apiResponse.ResponseJson;
                model.ExpiryDate = response.NinValidationResponse?.Data.ExpiryDate == null ? null : Computation.MyChangeToDateTime(response.NinValidationResponse?.Data.ExpiryDate);
                await _repository.AddApiCall("NIN", "Successful", "", _pricingList.Nin);
            }
            else
            {
                _logger.LogInformation($"NIN Validation Failed for {request.Ref}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);
                await _repository.AddApiCall("NIN", "Failed", "", _pricingList.Nin);

            }
            await _repository.StoreIdentityVerificationDetails(model);
            return response;
            }

        public async Task<TinValidationFinalResponse> TinVerification(string tin)
        {
 
            var response = new TinValidationFinalResponse();
            var verifiedTin = await  GetVerifiedIdentity(tin, "TIN");
            if (verifiedTin != null)
            {
                response.IsSuccessful = true;
                response.TinValidationResponse = JsonConvert.DeserializeObject<TinValidationResponse>(verifiedTin.ResponseJson);
                return response;
            }
            _logger.LogInformation("Calling Verify Me API for TIN Validation");
            _verifyTinUrl = _verifyTinUrl.Replace(":ref", tin);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyTinUrl, null, _apiSecret);

            var model = new IdentityVerification
            {
                IdReference = tin,
                IdType = "TIN"
            };

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"TIN Validation Successful for {tin}");
                response.TinValidationResponse =
                    JsonConvert.DeserializeObject<TinValidationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"TIN Validation Successful for {tin}";
                model.Status = response.TinValidationResponse?.Status.ToLower();
                model.ResponseJson = apiResponse.ResponseJson;
            }
            else
            {
                _logger.LogInformation($"TIN Validation Failed for {tin}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);

            }
            await _repository.StoreIdentityVerificationDetails(model);
            return response;
        }

        public async Task<VotersCardValidationFinalResponse> VotersCardVerification(VotersCardValidationRequest request)
        {
            var response = new VotersCardValidationFinalResponse();
            var verifiedVotersCard = await GetVerifiedIdentity(request.Ref, "VTC");
            if (verifiedVotersCard != null)
            {
                response.IsSuccessful = true;
                response.VotersCardValidationResponse = JsonConvert.DeserializeObject<VotersCardValidationResponse>(verifiedVotersCard.ResponseJson);
                await _repository.AddApiCall("VTC", "Successful", "", _pricingList.Vin);
                return response;
            }
            var requestBody = new
            {
                firstname = request.FirstName,
                lastname = request.LastName,
                dob = request.Dob
            };
            StringContent content = CreateContent(requestBody);
            
            _logger.LogInformation("Calling Verify Me API for Voter's Card Validation");
            _verifyVotersCardUrl = _verifyVotersCardUrl.Replace(":ref", request.Ref);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyVotersCardUrl, content, _apiSecret, "POST");

            var model = new IdentityVerification
            {
                IdReference = request.Ref,
                RequestJson = JsonConvert.SerializeObject(request),
                IdType = "VTC",
                Firstname = request.FirstName,
                Lastname = request.LastName,
                Dob = request.Dob

            };

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Voter's Card Validation Successful for {request.Ref}");
                response.VotersCardValidationResponse =
                    JsonConvert.DeserializeObject<VotersCardValidationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"Voter's Card Validation Successful for {request.Ref}";
                model.Status = response.VotersCardValidationResponse?.Status.ToLower();
                model.ResponseJson = apiResponse.ResponseJson;

                await _repository.AddApiCall("VTC", "Successful", "", _pricingList.Vin);
            }
            else
            {
                _logger.LogInformation($"Voter's Card Validation Failed for {request.Ref}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);
                await _repository.AddApiCall("VTC", "Failed", "", _pricingList.Vin);

            }
            await _repository.StoreIdentityVerificationDetails(model);
            return response;
        }


        public async Task<AddressVerificationFinalResponse> AddressVerification(SubmitAddressVerificationRequest request)
        {

            var applicantDto = new Dtos.RequestDto.Applicant
            {
                Dob = request.Dob,
                Firstname = request.Firstname,
                IdNumber = request.IdNumber,
                IdType = request.IdType,
                Lastname = request.Lastname,
                Phone = request.Phone,     
            };
            var requestDto = new SubmitAddressVerificationDto
            {
                Landmark = request.Landmark,
                Lga = request.Lga,
                State = request.State,
                Street = request.Street,
                Applicant = applicantDto
            };
            StringContent content = CreateContent(requestDto);
            var response = new AddressVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Address Validation");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyAddressUrl, content, _apiSecret, "POST");

            _logger.LogInformation("Preparing data model for persistence...");
            var model = _mapper.Map<AddressVerification>(request);
            model.RequestJson = JsonConvert.SerializeObject(requestDto);
            model.ResponseJson = apiResponse.ResponseJson;

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Submit Address Validation Successful for {request.IdNumber}");
                response.AddressVerificationResponse =
                    JsonConvert.DeserializeObject<AddressVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = response?.AddressVerificationResponse?.Status;
                model.AddressVerificationId = response.AddressVerificationResponse?.Data.id;
                model.Status = response?.AddressVerificationResponse?.Status;
            }
            else
            {
                _logger.LogInformation($"Submit Address Validation Failed for {request.IdNumber}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);
                response.ResponseMessage = response?.ErrorResponse?.Status;
            }

            _logger.LogInformation("Storing Request on the Database...");
            if(await _repository.StoreAddressVerificationDetails(model))
                _logger.LogInformation("Request stored on the Database successfully...");



            return response;
        }

        public async Task<AddressVerificationFinalResponse> GetAddressVerificationById(string verificationId)
        {

            var response = new AddressVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Get Address Verification By Id");
            _getAddressVerificationByIdUrl = _getAddressVerificationByIdUrl.Replace(":id", verificationId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getAddressVerificationByIdUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Address Verification By Id Successful for {verificationId}");
                response.AddressVerificationResponse =
                    JsonConvert.DeserializeObject<AddressVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = response.AddressVerificationResponse?.Status;
            }
            else
            {
                _logger.LogInformation($"Get Address Verification By Id Failed for {verificationId}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);
                response.ResponseMessage = response.ErrorResponse?.Status;

            }

            return response;
        }

        public async Task<AddressesListFinalVerificationResponse> GetAddressVerifications(Dtos.Response.AddressResponse.Pagination pagination)
        {
            if (pagination.limit != 0 && pagination.offset != 0)
            {
                _getAddressesVerificationUrl = _getAddressesVerificationUrl + $"?limt={pagination.limit}&offset={pagination.offset}";
            }
            else if (pagination.limit != 0)
            {
                _getAddressesVerificationUrl = _getAddressesVerificationUrl + $"?limt={pagination.limit}";
            }
            else if (pagination.offset != 0)
            {
                _getAddressesVerificationUrl = _getAddressesVerificationUrl + $"?offset={pagination.offset}";
            }
            var response = new AddressesListFinalVerificationResponse();
            _logger.LogInformation("Calling Verify Me API for Get Address Verifications");
            
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getAddressesVerificationUrl, null, _apiSecret);
            
            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Address Verification By Id Successful for {_getAddressesVerificationUrl}");
                response.AddressVerificationsResponse =
                    JsonConvert.DeserializeObject<AddressesListVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage= $"Get Address Verification By Id Successful for {_getAddressesVerificationUrl}";

            }
            else
            {
                _logger.LogInformation($"Get Address Verification By Id Failed for {_getAddressesVerificationUrl}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationListErrorResponse>(apiResponse.ResponseJson);

            }

            return response;
        }

        public async Task<CancelAddressVerificationFinalResponse> CancelAddressVerification(string verificationId)
        {

            var response = new CancelAddressVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Delete Address Verification");
            _cancelAddressVerificationUrl = _cancelAddressVerificationUrl.Replace(":id", verificationId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _cancelAddressVerificationUrl, null, _apiSecret, "DELETE");

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Delete Address Verification Successful for {verificationId}");
                response.CancelAddressVerificationResponse =
                    JsonConvert.DeserializeObject<CancelAddressVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"Delete Address Verification Successful for {verificationId}";
            }
            else
            {
                _logger.LogInformation($"Delete Address Verification Failed for {verificationId}");
                response.ResponseMessage = apiResponse.ResponseJson;

            }

            return response;
        }

        public async Task<AddressVerificationFinalResponse> FetchAddressVerificationByIdentity(FetchAddressByIdentityRequest request)
        {

            //Todo Store Request on the database
            StringContent content = CreateContent(request);
            var response = new AddressVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Address Validation");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _fetchAddressByIdentityEndpoints, content, _apiSecret, "POST");

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Fetch Address Verification By Identity Successful for {request.IdNumber}");
                response.AddressVerificationResponse =
                    JsonConvert.DeserializeObject<AddressVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"Fetch Address Verification By Identity Successful for {request.IdNumber}";
            }
            else
            {
                _logger.LogInformation($"Fetch Address Verification By Identity Failed for {request.IdNumber}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);

            }

            return response;
        }


        public async Task<DefaultResponse> UpdateAddressVerification(AddressVerificationPostback request, string verifyMeSignature)
        {
            var response = new DefaultResponse();
            string jsonString = JsonConvert.SerializeObject(request);
            _logger.LogInformation($"Address Verification Postback {jsonString}");
            //Update post back on the database

            if(Computation.ValidateWebHookSignature(jsonString, verifyMeSignature, _apiSecret))
            {
                //Valid Signature
                var addressId = request.data.id;
                var status = request.data.status.status;
                var completionDate = request.data.completedAt;
                await _repository.UpdateAddressVerificationStatus(addressId, status, completionDate, jsonString);
                response.IsSuccessful = true;
                response.ResponseMessage = "Successful";
            }
            else
            {
                response.IsSuccessful = false;
                response.ResponseMessage = "Invalid Signature";
            }



            return response;
        }

        public async Task<BusinessVerificationFinalResponse> BusinessVerification(SubmitBusinessVerificationRequest request)
        {

            //Todo Store Request on the database
            var applicantDto = new Dtos.BusinessDto.Applicant
            {
                Dob = request.Dob,
                Firstname = request.Firstname,
                IdNumber = request.IdNumber,
                IdType = request.IdType,
                Lastname = request.Lastname,
                Phone = request.Phone,
            };
            var requestDto = new SubmitBusinessVerificationDto
            {
                
                Lga = request.Lga,
                State = request.State,
                Street = request.Street,
                Applicant = applicantDto,
                CanContactPoc = request.CanContactPoc,
                City = request.City,
                BusinessName = request.BusinessName,
                RcNumber = request.RcNumber,
                BusinessType = request.BusinessType,
            };
            StringContent content = CreateContent(requestDto);
            var response = new BusinessVerificationFinalResponse();
            _logger.LogInformation($"Business Verification Request {JsonConvert.SerializeObject(requestDto)}");
            _logger.LogInformation("Calling Verify Me API for Business Validation");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyBusinessUrl, content, _apiSecret, "POST");

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Submit Business Validation Successful for {request.IdNumber}");
                response.BusinessVerificationResponse =
                    JsonConvert.DeserializeObject<BusinessVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = response.BusinessVerificationResponse?.Status;
            }
            else
            {
                _logger.LogInformation($"Submit Business Validation Failed for {request.IdNumber}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);
                response.ResponseMessage = response.ErrorResponse?.Status;
            }



            return response;
        }


        public async Task<BusinessVerificationFinalResponse> GetBusinessVerificationById(string verificationId)
        {

            var response = new BusinessVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Get Business Verification By Id");
            _getBusinessVerificationByIdUrl = _getBusinessVerificationByIdUrl.Replace(":id", verificationId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getBusinessVerificationByIdUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Business Verification By Id Successful for {verificationId}");
                response.BusinessVerificationResponse =
                    JsonConvert.DeserializeObject<BusinessVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = response.BusinessVerificationResponse?.Status;
            }
            else
            {
                _logger.LogInformation($"Get Business Verification By Id Failed for {verificationId}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);
                response.ResponseMessage = response.ErrorResponse?.Status;

            }

            return response;
        }

        public async Task<BusinessesListFinalVerificationResponse> GetBusinessesVerifications(Dtos.Response.BusinessResponse.Pagination pagination)
        {
            if (pagination.limit != 0 && pagination.offset != 0)
            {
                _getBusinessesVerificationUrl = _getBusinessesVerificationUrl + $"?limt={pagination.limit}&offset={pagination.offset}";
            }
            else if (pagination.limit != 0)
            {
                _getBusinessesVerificationUrl = _getBusinessesVerificationUrl + $"?limt={pagination.limit}";
            }
            else if (pagination.offset != 0)
            {
                _getBusinessesVerificationUrl = _getBusinessesVerificationUrl + $"?offset={pagination.offset}";
            }
            var response = new BusinessesListFinalVerificationResponse();
            _logger.LogInformation("Calling Verify Me API for Get Buninesses Verifications");

            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getBusinessesVerificationUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Buninesses Verification Successful for {_getBusinessesVerificationUrl}");
                response.BuninessesVerificationResponse =
                    JsonConvert.DeserializeObject<BuninessesListVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;

            }
            else
            {
                _logger.LogInformation($"Get Buninesses Verification Failed for {_getAddressesVerificationUrl}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationListErrorResponse>(apiResponse.ResponseJson);

            }

            return response;
        }

        public async Task<CancelBusinessVerificationFinalResponse> CancelBusinessVerification(string verificationId)
        {

            var response = new CancelBusinessVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Delete Business Verification");
            _cancelBusinessVerificationUrl = _cancelBusinessVerificationUrl.Replace(":id", verificationId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _cancelBusinessVerificationUrl, null, _apiSecret, "DELETE");

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Delete Business Verification Successful for {verificationId}");
                response.CancelBusinessVerificationResponse =
                    JsonConvert.DeserializeObject<CancelBusinessVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"Delete Business Verification Successful for {verificationId}";
            }
            else
            {
                _logger.LogInformation($"Delete Business Verification Failed for {verificationId}");
                response.ResponseMessage = apiResponse.ResponseJson;

            }

            return response;
        }

        public async Task<GuarantorVerificationFinalResponse> GuarantorVerification(SubmitGuarantorValidationRequest request)
        {

            var applicantDto = new Dtos.Request.Applicant
            {
                Dob = request.ApplicantDob,
                Firstname = request.ApplicantLastname,
                IdNumber = request.ApplicantIdNumber,
                IdType = request.ApplicantIdType,
                Lastname = request.ApplicantLastname,
                Phone = request.ApplicantPhone,
            };
            var requestDto = new SubmitGuarantorValidationDto
            {

                Lga = request.Lga,
                State = request.State,
                Street = request.Street,
                Applicant = applicantDto,
                AcceptableIdType = request.AcceptableIdType,
                Email = request.Email,
                Firstname = request.Firstname,
                Landmark = request.Landmark,
                Lastname = request.Lastname,
                Phone = request.Phone,
          
            };
            StringContent content = CreateContent(requestDto);
            var response = new GuarantorVerificationFinalResponse();
            var requestString = JsonConvert.SerializeObject(requestDto);
        _logger.LogInformation($"Guarantor Verification Request {requestString}");
            _logger.LogInformation("Calling Verify Me API for Business Validation");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyGuarantorUrl, content, _apiSecret, "POST");

            _logger.LogInformation("Preparing Database model for persistence...");
            var model = _mapper.Map<GuarantorVerification>(request);
            model.ResponseJson = apiResponse.ResponseJson;
            model.RequestJson = requestString;


            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Submit Guarantor Validation Successful for {request.ApplicantIdNumber}");
                response.GuarantorVerificationResponse =
                    JsonConvert.DeserializeObject<GuarantorVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = response.GuarantorVerificationResponse?.Status;
                model.Status = response.GuarantorVerificationResponse?.Status;
                model.GuarantorsVerificationId = response.GuarantorVerificationResponse?.Data.id;
            }
            else
            {
                _logger.LogInformation($"Submit Guarantor Validation Failed for {request.ApplicantIdNumber}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationListErrorResponse>(apiResponse.ResponseJson);
            }

            await _repository.StoreGuarantorDetails(model);
            _logger.LogInformation("Database persistence completed...");

            return response;
        }

        public async Task<GuarantorVerificationFinalResponse> GetGuarantorVerificationById(string verificationId)
        {

            var response = new GuarantorVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Get Guarantor Verification By Id");
            _getGuarantorVerificationByIdUrl = _getGuarantorVerificationByIdUrl.Replace(":id", verificationId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getGuarantorVerificationByIdUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Guarantor Verification By Id Successful for {verificationId}");
                response.GuarantorVerificationResponse =
                    JsonConvert.DeserializeObject<GuarantorVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = response.GuarantorVerificationResponse?.Status;
            }
            else
            {
                _logger.LogInformation($"Get Guarantor Verification By Id Failed for {verificationId}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationListErrorResponse>(apiResponse.ResponseJson);

            }

            return response;
        }

        public async Task<GuarantorsListFinalVerificationResponse> GetGuarantorsVerifications(Dtos.Response.BusinessResponse.Pagination pagination)
        {
            if (pagination.limit != 0 && pagination.offset != 0)
            {
                _getGuarantorsVerificationUrl = _getGuarantorsVerificationUrl + $"?limt={pagination.limit}&offset={pagination.offset}";
            }
            else if (pagination.limit != 0)
            {
                _getGuarantorsVerificationUrl = _getGuarantorsVerificationUrl + $"?limt={pagination.limit}";
            }
            else if (pagination.offset != 0)
            {
                _getGuarantorsVerificationUrl = _getGuarantorsVerificationUrl + $"?offset={pagination.offset}";
            }
            var response = new GuarantorsListFinalVerificationResponse();
            _logger.LogInformation("Calling Verify Me API for Get Guarantors Verifications");

            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getGuarantorsVerificationUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Guarantors Verification Successful for {_getGuarantorsVerificationUrl}");
                response.GuarantorsVerificationResponse =
                    JsonConvert.DeserializeObject<GuarantorsListVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;

            }
            else
            {
                _logger.LogInformation($"Get Guarantors Verification Failed for {_getAddressesVerificationUrl}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);

            }

            return response;
        }

        public async Task<CancelGuarantorVerificationFinalResponse> CancelGuarantorVerification(string verificationId)
        {

            var response = new CancelGuarantorVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Delete Guarantor Verification");
            _cancelBusinessVerificationUrl = _cancelBusinessVerificationUrl.Replace(":id", verificationId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _cancelBusinessVerificationUrl, null, _apiSecret, "DELETE");

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Delete Guarantor Verification Successful for {verificationId}");
                response.CancelGuarantorVerificationResponse =
                    JsonConvert.DeserializeObject<CancelBusinessVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"Delete Guarantor Verification Successful for {verificationId}";
            }
            else
            {
                _logger.LogInformation($"Delete Guarantor Verification Failed for {verificationId}");
                response.ResponseMessage = apiResponse.ResponseJson;

            }

            return response;
        }

        public async Task<DefaultResponse> UpdateGuarantorVerification(GuarantorVerificationPostback request, string verifyMeSignature)
        {
            var response = new DefaultResponse();
            string jsonString = JsonConvert.SerializeObject(request);
            _logger.LogInformation($"Guarantors Verification Post Back {jsonString}");
            //Update post back on the database

            if (Computation.ValidateWebHookSignature(jsonString, verifyMeSignature, _apiSecret))
            {
                //Valid Signature
                var verificationId = request.data.id;
                var status = request.data.status.status;
                var completionDate = request.data.completedAt;
                var statusState = request.data.status.state;
                await _repository.UpdateGuarantorsVerificationStatus(verificationId, status, statusState,completionDate, jsonString);
                response.IsSuccessful = true;
                response.ResponseMessage = "Successful";
            }
            else
            {
                response.IsSuccessful = false;
                response.ResponseMessage = "Invalid Signature";
            }



            return response;
        }

        public async Task<EmploymentHistoryVerificationFinalResponse> EmploymentHistoryVerification(SubmitEmploymentHistoryRequest request)
        {

            var applicantDto = new Dtos.EmploymentRequest.Applicant
            {
                Dob = request.ApplicantDob,
                Firstname = request.ApplicantLastname,
                IdNumber = request.ApplicantIdNumber,
                IdType = request.ApplicantIdType,
                Lastname = request.ApplicantLastname,
                Phone = request.ApplicantPhone,
            };
            var requestDto = new SubmitEmploymentHistoryDto()
            {
                Applicant = applicantDto,
                ContactPersonName = request.ContactPersonName,
                CurrentlyEmployed = request.CurrentlyEmployed,
                EmployerEmail = request.EmployerEmail,
                EmployerName = request.EmployerName,
                EmployerPhone = request.EmployerPhone,
                EndDate = request.EndDate,
                JobTitle = request.JobTitle,
                StartDate = request.StartDate

            };
            StringContent content = CreateContent(requestDto);
            var response = new EmploymentHistoryVerificationFinalResponse();
            string jsonString = JsonConvert.SerializeObject(requestDto);
            _logger.LogInformation($"Employment History Verification Request {jsonString}");
            _logger.LogInformation("Calling Verify Me API for Employment History Validation");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _verifyEmploymentHistoryUrl, content, _apiSecret, "POST");

            _logger.LogInformation("Preparing Database model for persistence...");
            var model = _mapper.Map<EmploymentVerification>(request);
            model.RequestJson = jsonString;
            model.ResponseJson = apiResponse.ResponseJson;
            
            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Submit Employment History Validation Successful for {request.ApplicantIdNumber}");
                response.EmploymentHistoryVerificationResponse =
                    JsonConvert.DeserializeObject<EmploymentHistoryVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = response.EmploymentHistoryVerificationResponse?.Status;
                model.Status = response.EmploymentHistoryVerificationResponse?.Status;
                model.EmploymentVerificationId = response.EmploymentHistoryVerificationResponse?.Data.id;
            }
            else
            {
                _logger.LogInformation($"Submit Employment History Validation Failed for {request.ApplicantIdNumber}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationListErrorResponse>(apiResponse.ResponseJson);
            }

            await _repository.StoreEmploymentHistoryDetails(model);
            _logger.LogInformation("Database persistence completed...");

            return response;
        }

        public async Task<EmploymentHistoryVerificationFinalResponse> GetEmploymentHistoryVerificationById(string verificationId)
        {

            var response = new EmploymentHistoryVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Get Employment History Verification By Id");
            _getEmploymentHistoryVerificationByIdUrl = _getEmploymentHistoryVerificationByIdUrl.Replace(":id", verificationId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getEmploymentHistoryVerificationByIdUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Employment History Verification By Id Successful for {verificationId}");
                response.EmploymentHistoryVerificationResponse =
                    JsonConvert.DeserializeObject<EmploymentHistoryVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = response.EmploymentHistoryVerificationResponse?.Status;
            }
            else
            {
                _logger.LogInformation($"Get Employment History Verification By Id Failed for {verificationId}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationListErrorResponse>(apiResponse.ResponseJson);

            }

            return response;
        }

        public async Task<CancelEmploymentHistoryVerificationFinalResponse> CancelEmploymentHistoryVerification(string verificationId)
        {

            var response = new CancelEmploymentHistoryVerificationFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Delete Employment History Verification");
            _cancelBusinessVerificationUrl = _cancelBusinessVerificationUrl.Replace(":id", verificationId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _cancelBusinessVerificationUrl, null, _apiSecret, "DELETE");

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Delete Employment History Verification Successful for {verificationId}");
                response.CancelEmploymentHistoryVerificationResponse =
                    JsonConvert.DeserializeObject<CancelBusinessVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;
                response.ResponseMessage = $"Delete Employment History Verification Successful for {verificationId}";
            }
            else
            {
                _logger.LogInformation($"Delete Employment History Verification Failed for {verificationId}");
                response.ResponseMessage = apiResponse.ResponseJson;

            }

            return response;
        }

        public async Task<EmploymentHistoryListFinalVerificationResponse> GetEmploymentHistoriesVerifications(Dtos.Response.BusinessResponse.Pagination pagination)
        {
            if (pagination.limit != 0 && pagination.offset != 0)
            {
                _getEmploymentsHistoryVerificationUrl = _getEmploymentsHistoryVerificationUrl + $"?limt={pagination.limit}&offset={pagination.offset}";
            }
            else if (pagination.limit != 0)
            {
                _getEmploymentsHistoryVerificationUrl = _getEmploymentsHistoryVerificationUrl + $"?limt={pagination.limit}";
            }
            else if (pagination.offset != 0)
            {
                _getEmploymentsHistoryVerificationUrl = _getEmploymentsHistoryVerificationUrl + $"?offset={pagination.offset}";
            }
            var response = new EmploymentHistoryListFinalVerificationResponse();
            _logger.LogInformation("Calling Verify Me API for Get Employment Histories Verifications");

            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getEmploymentsHistoryVerificationUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Employment Histories Verification Successful for {_getGuarantorsVerificationUrl}");
                response.EmploymentHistoryVerificationResponse =
                    JsonConvert.DeserializeObject<EmploymentHistoryListVerificationResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;

            }
            else
            {
                _logger.LogInformation($"Get Employment Histories Verification Failed for {_getAddressesVerificationUrl}");
                response.ErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(apiResponse.ResponseJson);

            }

            return response;
        }

        public async Task<DefaultResponse> UpdateEmploymentHistoryVerification(EmploymentVerificationPostback request, string verifyMeSignature)
        {
            var response = new DefaultResponse();
            string jsonString = JsonConvert.SerializeObject(request);
            _logger.LogInformation($"Employment Verification Postback {jsonString}");
            //Update post back on the database

            if (Computation.ValidateWebHookSignature(jsonString, verifyMeSignature, _apiSecret))
            {
                //Valid Signature
                var addressId = request.data.id;
                var status = request.data.status.status;
                var statusState = request.data.status.state;
                await _repository.UpdateEmploymentHistoryVerificationStatus(addressId, status, statusState, jsonString);
                response.IsSuccessful = true;
                response.ResponseMessage = "Successful";
            }
            else
            {
                response.IsSuccessful = false;
                response.ResponseMessage = "Invalid Signature";
            }



            return response;
        }
        public async Task<GetStatesFinalResponse> GetStatesByCountry(string countryId)
        {

            var response = new GetStatesFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Get States By Country");
            _getStatesByCountryUrl = _getStatesByCountryUrl.Replace(":id", countryId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getStatesByCountryUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get States By Country Successful for {_getStatesByCountryUrl}");
                response.GetStatesResponse =
                    JsonConvert.DeserializeObject<GenericCodeResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;

            }
            else
            {
                _logger.LogInformation($"Get States By Country Failed for {_getStatesByCountryUrl}");

            }

            return response;
        }
        public async Task<GetLgaFinalResponse> GetLgasByState(string stateId)
        {

            var response = new GetLgaFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Get Local Governments By State");
            _getLgasByStateUrl = _getLgasByStateUrl.Replace(":id", stateId);
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getLgasByStateUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Local Governments By State Successful for {_getLgasByStateUrl}");
                response.GetLgasResponse =
                    JsonConvert.DeserializeObject<GenericCodeResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;

            }
            else
            {
                _logger.LogInformation($"Get Local Governments By State Failed for {_getLgasByStateUrl}");

            }

            return response;
        }

        public async Task<GetCountriesFinalResponse> GetCountries()
        {

            var response = new GetCountriesFinalResponse();
            _logger.LogInformation("Calling Verify Me API for Get Countries");
            var apiResponse = await CallRestApi(_verifyMeBaseUrl, _getCountriesUrl, null, _apiSecret);

            if (apiResponse.IsSuccessful)
            {
                _logger.LogInformation($"Get Countries Successful for {_getCountriesUrl}");
                response.GetCountriesResponse =
                    JsonConvert.DeserializeObject<GenericCodeResponse>(apiResponse.ResponseJson);
                response.IsSuccessful = true;

            }
            else
            {
                _logger.LogInformation($"Get Countries Failed for {_getCountriesUrl}");

            }

            return response;
        }

        private async Task <IdentityVerification> GetVerifiedIdentity(string idRef, string idType)
        {
           return await _repository.CheckAndGetIdentityVerified( idType, idRef);
        }


    }

}



