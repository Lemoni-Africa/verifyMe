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
    public class GuarantorController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly ILogger<GuarantorController> _logger;

        public GuarantorController(IHelper helper, ILogger<GuarantorController> logger)
        {
            _helper = helper;
            _logger = logger;
        }

        [HttpPost]
        [Route("verify/guarantor")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GuarantorVerification(SubmitGuarantorValidationRequest request)
        {
            var response = new GuarantorVerificationFinalResponse();
            try
            {

                response = await _helper.GuarantorVerification(request);
                if(response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch(Exception ex)
            {
                _logger.LogError($"Guarantor Verification Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }
            
        }

        [HttpGet]
        [Route("verify/get-guarantor-by-id/{verificationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetGuarantorVerificationById(string verificationId)
        {
            var response = new GuarantorVerificationFinalResponse();
            try
            {
                response = await _helper.GetGuarantorVerificationById(verificationId);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Guarantor Verification By Id Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpGet]
        [Route("verify/get-guarantors")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetGuarantorsVerification([FromQuery] Dtos.Response.BusinessResponse.Pagination pagination)
        {
            var response = new GuarantorsListFinalVerificationResponse();
            try
            {
                response = await _helper.GetGuarantorsVerifications(pagination);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Guarantors Verifications Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpDelete]
        [Route("verify/cancel-guarantor-verification/{verificationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CancelGuarantorVerifications(string verificationId)
        {
            var response = new CancelGuarantorVerificationFinalResponse();
            try
            {
                response = await _helper.CancelGuarantorVerification(verificationId);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Cancel Guarantor Verification Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }


    }
}
