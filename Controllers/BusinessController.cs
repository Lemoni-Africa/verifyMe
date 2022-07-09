using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using VerifyMeIntegration.Dtos.Request;
using VerifyMeIntegration.Dtos.Response;
using VerifyMeIntegration.Helpers;

namespace VerifyMeIntegration.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly ILogger<BusinessController> _logger;

        public BusinessController(IHelper helper, ILogger<BusinessController> logger)
        {
            _helper = helper;
            _logger = logger;
        }

        [HttpPost]
        [Route("verify/business")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> BusinessVerification(SubmitBusinessVerificationRequest request)
        {
            var response = new BusinessVerificationFinalResponse();
            try
            {

                response = await _helper.BusinessVerification(request);
                if(response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch(Exception ex)
            {
                _logger.LogError($"Business Verification Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }
            
        }

        [HttpGet]
        [Route("verify/get-business-by-id/{verificationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetBusinessVerificationById(string verificationId)
        {
            var response = new BusinessVerificationFinalResponse();
            try
            {
                response = await _helper.GetBusinessVerificationById(verificationId);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Business Verification By Id Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpGet]
        [Route("verify/get-businesses")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetBusinessesVerification([FromQuery] Dtos.Response.BusinessResponse.Pagination pagination)
        {
            var response = new BusinessesListFinalVerificationResponse();
            try
            {
                response = await _helper.GetBusinessesVerifications(pagination);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Business Verifications Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpDelete]
        [Route("verify/cancel-business-verification/{verificationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CancelBusinessVerifications(string verificationId)
        {
            var response = new CancelBusinessVerificationFinalResponse();
            try
            {
                response = await _helper.CancelBusinessVerification(verificationId);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Cancel Busniess Verification Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }


    }
}
