using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using VerifyMeIntegration.Dtos;
using VerifyMeIntegration.Dtos.AddressPostback;
using VerifyMeIntegration.Dtos.EmploymentVerificationPostback;
using VerifyMeIntegration.Dtos.Response;
using VerifyMeIntegration.Helpers;

namespace VerifyMeIntegration.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly ILogger<AddressController> _logger;

        public WebhookController(IHelper helper, ILogger<AddressController> logger)
        {
            _helper = helper;
            _logger = logger;
        }

        [HttpPost]
        [Route("webhook/verify-address")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddressVerificationWebhook([FromBody] AddressVerificationPostback request)
        {
            var verifyMeSignature = Request.Headers["x-verifyme-signature"].ToString();
            var response = new DefaultResponse();
            try
            {
                response = await _helper.UpdateAddressVerification(request, verifyMeSignature);                   
                    
                return Ok();
                

            }
            catch (Exception ex)
            {

                _logger.LogError($"Address Verification Exception {JsonConvert.SerializeObject(ex)}");
                //response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpPost]
        [Route("webhook/verification-post-back")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> VerificationWebhook([FromBody] Newtonsoft.Json.Linq.JObject jObject)
        {
            var verifyMeSignature = Request.Headers["x-verifyme-signature"].ToString();
            var response = new DefaultResponse();
            try
            {
                string jsonString = jObject.ToString();
                var data = JsonConvert.DeserializeObject<AddressVerificationPostback>(jsonString);
                string type = data.type.ToLower();
                if (type == "guarantor")
                {
                    var guarantorData = JsonConvert.DeserializeObject<GuarantorVerificationPostback>(jsonString);
                    response = await _helper.UpdateGuarantorVerification(guarantorData, verifyMeSignature);
                }
                else if (type == "address")
                {
                    response = await _helper.UpdateAddressVerification(data, verifyMeSignature);
                }
                else if (type == "employment")
                {
                    var employmentData = JsonConvert.DeserializeObject<EmploymentVerificationPostback>(jsonString);
                    response = await _helper.UpdateEmploymentHistoryVerification(employmentData, verifyMeSignature);
                }
                else if (type == "property")
                {   

                }


                return Ok();


            }
            catch (Exception ex)
            {

                _logger.LogError($"Address Verification Exception {JsonConvert.SerializeObject(ex)}");
                //response.ResponseMessage = ex.Message;
                return StatusCode(500, response);
            }

        }
    }
}
