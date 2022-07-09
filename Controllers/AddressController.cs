using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using VerifyMeIntegration.Dtos.Request;
using VerifyMeIntegration.Dtos.Response;
using VerifyMeIntegration.Dtos.Response.AddressResponse;
using VerifyMeIntegration.Helpers;

namespace VerifyMeIntegration.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IHelper helper, ILogger<AddressController> logger)
        {
            _helper = helper;
            _logger = logger;
        }

        [HttpPost]
        [Route("verify/address")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddressVerification(SubmitAddressVerificationRequest request)
        {
            var response = new AddressVerificationFinalResponse();
            try
            {
                response = await _helper.AddressVerification(request);
                if(response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch(Exception ex)
            {
                _logger.LogError($"Address Verification Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }
            
        }

        [HttpGet]
        [Route("verify/get-address-by-id/{verificationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAddressVerificationById(string verificationId)
        {
            var response = new AddressVerificationFinalResponse();
            try
            {
                response = await _helper.GetAddressVerificationById(verificationId);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Address Verification By Id Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpGet]
        [Route("verify/get-addresses")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAddressVerifications([FromQuery] Pagination pagination)
        {
            var response = new AddressesListFinalVerificationResponse();
            try
            {
                response = await _helper.GetAddressVerifications(pagination);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Address Verifications Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpDelete]
        [Route("verify/cancel-address-verification/{verificationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CancelAddressVerifications(string verificationId)
        {
            var response = new CancelAddressVerificationFinalResponse();
            try
            {
                response = await _helper.CancelAddressVerification(verificationId);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Cancel Address Verification Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpPost]
        [Route("verify/get-address-verification-by-identity")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FetchAddressByIdentity(FetchAddressByIdentityRequest request)
        {
            var response = new AddressVerificationFinalResponse();
            try
            {
                response = await _helper.FetchAddressVerificationByIdentity(request);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Fetch Address By Identity Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }
    }
}
