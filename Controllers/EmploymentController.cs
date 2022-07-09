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
    public class EmploymentController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly ILogger<EmploymentController> _logger;

        public EmploymentController(IHelper helper, ILogger<EmploymentController> logger)
        {
            _helper = helper;
            _logger = logger;
        }

        [HttpPost]
        [Route("verify/employment-history")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> EmploymentHistoryVerification(SubmitEmploymentHistoryRequest request)
        {
            var response = new EmploymentHistoryVerificationFinalResponse();
            try
            {

                response = await _helper.EmploymentHistoryVerification(request);
                if(response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch(Exception ex)
            {
                _logger.LogError($"Employment History Verification Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }
            
        }

        [HttpGet]
        [Route("verify/get-employment-history-by-id/{verificationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetEmploymentHistoryVerificationById(string verificationId)
        {
            var response = new EmploymentHistoryVerificationFinalResponse();
            try
            {
                response = await _helper.GetEmploymentHistoryVerificationById(verificationId);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Employment History Verification By Id Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpGet]
        [Route("verify/get-employment-histories")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetEmploymentHistoryVerifications([FromQuery] Dtos.Response.BusinessResponse.Pagination pagination)
        {
            var response = new EmploymentHistoryListFinalVerificationResponse();
            try
            {
                response = await _helper.GetEmploymentHistoriesVerifications(pagination);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Employment History Verifications Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpDelete]
        [Route("verify/cancel-employment-history-verification/{verificationId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CancelEmploymentHistoryVerification(string verificationId)
        {
            var response = new CancelEmploymentHistoryVerificationFinalResponse();
            try
            {
                response = await _helper.CancelEmploymentHistoryVerification(verificationId);
                if (response.IsSuccessful)
                    return Ok(response);
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Cancel Employment History Verification Exception {JsonConvert.SerializeObject(ex)}");
                response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }


    }
}
