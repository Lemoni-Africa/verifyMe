using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VerifyMeIntegration.Dtos.Request;
using VerifyMeIntegration.Dtos.Response;
using VerifyMeIntegration.Helpers;

namespace VerifyMeIntegration.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly ILogger<IdentityController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheService;
        private readonly string _environment;

        public IdentityController(IHelper helper, ILogger<IdentityController> logger, IConfiguration configuration,ICacheService cacheService)
        {
            _helper = helper;
            _logger = logger;
            _configuration = configuration;
            _cacheService = cacheService;
            _environment = _configuration.GetSection("AppSettings").GetSection("Environment").Value.ToLower();
        }
        [HttpGet]
        [Route("validate/bvn/{bvn}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> BvnValidation(string bvn)
        {
            _logger.LogInformation($"Executing BVN verification Request for {bvn}");
            var response = new BvnValidationFinalResponse();
            try
            {
                response = await _helper.BvnVerification(bvn);
                if (response.IsSuccessful)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }
        ///<summary>
        ///This endpoint allows client to validate corporate entities
        /// parameter on  type and rcNumber
        /// 
        ///type
        /// Valid company type ranges that we verify:
        /// 1. limited_company: Registered as limited company or
        /// 2. business: Registered as business or
        /// 3. incorprated_trustee: Registered as trust company.
        /// </summary>
        [HttpPost]
        [Route("validate/cac-number")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateCac(CacValidationRequest request)
        {
            _logger.LogInformation($"Executing CAC verification Request for {JsonConvert.SerializeObject(request)}");
            var response = new CacVerificationFinalResponse();
            try
            {
                response = await _helper.CacVerification(request);
                if(response.IsSuccessful)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }
        ///<summary>
        ///This endpoint allows client to validate driver's license
        /// 
        ///"firstname":"John",
        /// "lastname":"Doe",
        /// "phone":"080000000000",
        /// "dob":"04-04-1944". optional
        /// </summary>
        //
        //
        [HttpPost]
        [Route("validate/license-number")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateLicense(LicenseValidationRequest request)
        {
            _logger.LogInformation($"Executing license verification Request for {JsonConvert.SerializeObject(request)}");
            var response = new LicenseValidationFinalResponse();
            try
            {
                response = await _helper.LicenseVerification(request);
                if (response.IsSuccessful)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }

        [HttpPost]
        [Route("validate/identity-biometric2")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateBiometric2(BiometricRequest request)
        {
            //Todo Set acceptable thread hold
            _logger.LogInformation($"Executing Biometric verification Request for {JsonConvert.SerializeObject(request)}");
            var acceptableThreadHold = Convert.ToDouble(_configuration.GetSection("AcceptableMatchThreadHold").Value);
            var acceptableMatchScore = Convert.ToDouble(_configuration.GetSection("AcceptableMatchScore").Value);
            var response = new BiometricValidationFinalResponse();
            try
            {

                var IdNumber = request.IdNumber;
                var oldRequest = _cacheService.Get<BiometricRequest>(IdNumber);
                if (oldRequest != null)
                {
                    var oldResponse = _cacheService.Get<BiometricValidationFinalResponse>(IdNumber+"Res");
                    if (oldResponse != null)
                    {
                        _logger.LogInformation($"Repeat Request for {request.IdNumber}, returning cached response...");
                        return Ok(oldResponse);
                    }

                    if (JsonConvert.SerializeObject(oldRequest) == JsonConvert.SerializeObject(request))
                    {
                        oldResponse = _cacheService.Get<BiometricValidationFinalResponse>(IdNumber + "ResD");
                        if (oldResponse != null)
                        {
                            _logger.LogInformation($"Repeat Request for {request.IdNumber}, returning cached response...");
                            return Ok(oldResponse);
                        }
                    }
                }
                _cacheService.Set<BiometricRequest>(IdNumber, request, 24);
                if (string.IsNullOrEmpty(request.PhotoUrl) && string.IsNullOrEmpty(request.Photo) && string.IsNullOrEmpty(request.PhotoBase64))
                {
                    response.ResponseMessage = "At least one of PhotoUrl or Photo must be passed!!!";
                    return StatusCode(422, response);
                }
                if (!string.IsNullOrEmpty(request.PhotoBase64))
                {
                    _logger.LogInformation("Using Base64");
                    response = await _helper.BiometricVerificationWithBase64(request);
                }else if (!string.IsNullOrEmpty(request.Photo))
                {
                    _logger.LogInformation("Using Image File");
                    response = await _helper.BiometricVerificationWithImage(request);
                }else if (!string.IsNullOrEmpty(request.PhotoUrl))
                {
                    _logger.LogInformation("Using Photo Url");
                    response = await _helper.BiometricVerification(request);
                }

                
                if (response.IsSuccessful)
                {
                    bool dateOfBirthMatched = false;
                    if (!string.IsNullOrEmpty(request.DateOfBirth))
                    {
                        var inputtedDateOfBirth = Helper.ChangeToDateTime(request.DateOfBirth).ToString("dd-MM-yyyy");
                        var date = response.BiometricValidationResponse.Data.Birthdate;
                        var returnedDateOfBirth = Helper.ChangeToDateTime(date).ToString("dd-MM-yyyy");
                        if (inputtedDateOfBirth == returnedDateOfBirth)
                            dateOfBirthMatched = true;
                    }
                    var threadHoldFromApi = response.BiometricValidationResponse.Data.PhotoMatching.MatchingThreshold;
                    var matchScoreFromApi = response.BiometricValidationResponse.Data.PhotoMatching.MatchScore;
                    if (threadHoldFromApi >= acceptableThreadHold && matchScoreFromApi >= acceptableMatchScore && dateOfBirthMatched)
                        response.AcceptableMatch = true;

                    var IdNumberD = IdNumber + "ResD";
                    _cacheService.Set<BiometricValidationFinalResponse>(IdNumberD, response, 24);
                    if (response.AcceptableMatch)
                    {
                        IdNumber += "Res";
                        _cacheService.Set<BiometricValidationFinalResponse>(IdNumber, response, 24);
                    }
                    _logger.LogInformation($"Biometric verification Response for {JsonConvert.SerializeObject(response)}");
                    return Ok(response);
                }

                _logger.LogInformation($"Biometric verification Response for {JsonConvert.SerializeObject(response)}");
                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }


        [HttpPost]
        [Route("validate/identity-biometric")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateBiometric(BiometricRequest request)
        {
            //Todo Set acceptable thread hold
            _logger.LogInformation($"Executing Biometric verification Request for {JsonConvert.SerializeObject(request)}");
            var acceptableThreadHold = Convert.ToDouble(_configuration.GetSection("AcceptableMatchThreadHold").Value);
            var acceptableMatchScore = Convert.ToDouble(_configuration.GetSection("AcceptableMatchScore").Value);
            var response = new BiometricValidationFinalResponse();
            try
            {
                if (string.IsNullOrEmpty(request.PhotoUrl) && string.IsNullOrEmpty(request.Photo) && string.IsNullOrEmpty(request.PhotoBase64))
                {
                    response.ResponseMessage = "At least one of PhotoUrl or Photo must be passed!!!";
                    return StatusCode(422, response);
                }
                if (!string.IsNullOrEmpty(request.PhotoBase64))
                {
                    response = await _helper.BiometricVerificationWithBase64(request);
                }
                if (!string.IsNullOrEmpty(request.Photo))
                {
                    response = await _helper.BiometricVerificationWithImage(request);
                }

                if (!string.IsNullOrEmpty(request.PhotoUrl)) 
                {
                    response = await _helper.BiometricVerification(request);
                }



                if (response.IsSuccessful)
                {
                    var threadHoldFromApi = response.BiometricValidationResponse.Data.PhotoMatching.MatchingThreshold;
                    var matchScoreFromApi = response.BiometricValidationResponse.Data.PhotoMatching.MatchScore;
                    if (threadHoldFromApi >= acceptableThreadHold && matchScoreFromApi >= acceptableMatchScore)
                        response.AcceptableMatch = true;
                    return Ok(response);
                }
                    

                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }

        ///<summary>
        ///This endpoint allows client to validate NIN
        /// 
        ///"firstname":"John",
        /// "lastname":"Doe",
        /// "phone":"080000000000",
        /// "dob":"04-04-1944". optional
        /// </summary>
        //
        //
        [HttpPost]
        [Route("validate/nin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateNin(NinValidationRequest request)
        {
            _logger.LogInformation($"Executing NIN verification Request for {JsonConvert.SerializeObject(request)}");
            var response = new NinValidationFinalResponse();
            try
            {
                response = await _helper.NinVerification(request);
                if (response.IsSuccessful)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }

        ///<summary>
        ///This endpoint allows client to validate NIN
        /// 
        ///"firstname":"John",
        /// "lastname":"Doe",
        /// "phone":"080000000000",
        /// "dob":"04-04-1944". optional
        /// </summary>
        //
        //
        [HttpGet]
        [Route("validate/tin/{tin}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateTin(string tin)
        {
            _logger.LogInformation($"Executing TIN verification Request for {tin}");
            var response = new TinValidationFinalResponse();
            try
            {
                response = await _helper.TinVerification(tin);
                if (response.IsSuccessful)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }

        ///<summary>
        ///This endpoint allows client to validate Voter's Card
        /// 
        ///"firstname":"John",
        /// "lastname":"Doe",
        /// "phone":"080000000000",
        /// "dob":"04-04-1944". optional
        /// </summary>
        //
        //
        [HttpPost]
        [Route("validate/voters-card")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateVotersCard(VotersCardValidationRequest request)
        {
            _logger.LogInformation($"Executing NIN verification Request for {JsonConvert.SerializeObject(request)}");
            var response = new VotersCardValidationFinalResponse();
            try
            {
                response = await _helper.VotersCardVerification(request);
                if (response.IsSuccessful)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }

        [HttpPost]
        [Route("validate/voters-card2")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateVotersCard2(VotersCardValidationRequest request)
        {
            _logger.LogInformation($"Executing NIN verification Request 2 for {JsonConvert.SerializeObject(request)}");
            var response = new IdentityMatchResponse();
            try
            {
                var matchResponse = await _helper.VotersCardVerification(request);
                if (matchResponse.IsSuccessful)
                {
                    var matchFirstname = false;
                    var matchLastname = false;

                    var firstname = matchResponse.VotersCardValidationResponse.data.FirstName;
                    var lastname = matchResponse.VotersCardValidationResponse.data.LastName;
                    if (!string.IsNullOrEmpty(firstname) && request.FirstName.ToLower() == firstname.ToLower())
                        matchFirstname = true;
                    if (!string.IsNullOrEmpty(lastname) && request.LastName.ToLower() == lastname.ToLower())
                        matchLastname = true;
                    if (!matchFirstname && !matchLastname && firstname == request.LastName &&
                        lastname == request.FirstName)
                    {
                        matchFirstname = true;
                        matchLastname = true;
                    }
                    List<string> matchedFields = new List<string>();
                    if (matchLastname)
                        matchedFields.Add("Lastname");
                    if (matchFirstname)
                        matchedFields.Add("Firstname");


                    response.MatchedFields = matchedFields;
                    response.IsSuccessful = true;
                    response.ResponseMessage = matchResponse.ResponseMessage;
                    if ((matchLastname && matchFirstname) || _environment == "test")
                    {
                        response.IsAMatch = true;
                        return Ok(response);
                    }
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }

        [HttpPost]
        [Route("validate/nin2")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateNin2(NinValidationRequest request)
        {
            _logger.LogInformation($"Executing NIN verification Request 2 for {JsonConvert.SerializeObject(request)}");
            var response = new IdentityMatchResponse();
            try
            {

                var matchResponse = await _helper.NinVerification(request);
                if (matchResponse.IsSuccessful)
                {

                    var matchFirstname = false;
                    var matchLastname = false;
                    var matchDateOfBirth = false;

                    var firstname = matchResponse.NinValidationResponse.Data.Firstname;
                    var lastname = matchResponse.NinValidationResponse.Data.Lastname;
                    var dateOfBirth = matchResponse.NinValidationResponse.Data.Birthdate;
                    if (!string.IsNullOrEmpty(firstname) && request.FirstName.ToLower() == firstname.ToLower())
                        matchFirstname = true;
                    if (!string.IsNullOrEmpty(lastname) && request.LastName.ToLower() == lastname.ToLower())
                        matchLastname = true;
                    if (!string.IsNullOrEmpty(dateOfBirth) && request.Dob == dateOfBirth)
                        matchDateOfBirth = true;

                    if (!matchFirstname && !matchLastname && firstname == request.LastName &&
                        lastname == request.FirstName  && matchDateOfBirth)
                    {
                        matchFirstname = true;
                        matchLastname = true;
                    }
                    List<string> matchedFields = new List<string>();
                    if (matchLastname)
                        matchedFields.Add("Lastname");
                    if (matchFirstname)
                        matchedFields.Add("Firstname");
                    if (matchDateOfBirth)
                        matchedFields.Add("DateOfBirth");

                    response.MatchedFields = matchedFields;
                    response.IsSuccessful = true;
                    response.ResponseMessage = matchResponse.ResponseMessage;
                    if ((matchDateOfBirth && matchLastname && matchFirstname) || _environment == "test")
                    {
                        response.IsAMatch = true;
                        return Ok(response);
                    }
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }

        [HttpPost]
        [Route("validate/license-number2")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidateLicense2(LicenseValidationRequest request)
        {
            _logger.LogInformation($"Executing license verification 2 Request for {JsonConvert.SerializeObject(request)}");

            var response = new IdentityMatchResponse();

            try
            {
                var matchResponse = await _helper.LicenseVerification(request);
                if (matchResponse.IsSuccessful)
                {
                    var matchFirstname = false;
                    var matchLastname = false;
                    var matchDateOfBirth = false;

                    var firstname = matchResponse.LicenseValidationResponse.Data.Firstname;
                    var lastname = matchResponse.LicenseValidationResponse.Data.Lastname;
                    var dateOfBirth = matchResponse.LicenseValidationResponse.Data.Birthdate;
                    if (!string.IsNullOrEmpty(firstname) && request.FirstName.ToLower() == firstname.ToLower())
                        matchFirstname = true;
                    if (!string.IsNullOrEmpty(lastname) && request.LastName.ToLower() == lastname.ToLower())
                        matchLastname = true;
                    if (!string.IsNullOrEmpty(dateOfBirth) && request.Dob == dateOfBirth)
                        matchDateOfBirth = true;

                    if (!matchFirstname && !matchLastname && firstname == request.LastName &&
                        lastname == request.FirstName && matchDateOfBirth)
                    {
                        matchFirstname = true;
                        matchLastname = true;
                    }
                    List<string> matchedFileds = new List<string>();
                    if (matchLastname)
                        matchedFileds.Add("Lastname");
                    if (matchFirstname)
                        matchedFileds.Add("Firstname");
                    if (matchDateOfBirth)
                        matchedFileds.Add("DateOfBirth");

                    response.MatchedFields = matchedFileds;
                    response.IsSuccessful = true;
                    response.ResponseMessage = matchResponse.ResponseMessage;
                    if ((matchDateOfBirth && matchLastname && matchFirstname) || _environment == "test")
                    {
                        response.IsAMatch = true;
                        return Ok(response);
                    }
                    return Ok(response);
                }

                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.ResponseMessage = e.Message;
                _logger.LogError(JsonConvert.SerializeObject(e));
                return StatusCode(500, response);
            }

        }
    }
}
