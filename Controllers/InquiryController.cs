using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VerifyMeIntegration.Dtos.Request;
using VerifyMeIntegration.Dtos.Response;
using VerifyMeIntegration.Helpers;

namespace VerifyMeIntegration.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly ILogger<InquiryController> _logger;

        public InquiryController(IHelper helper, ILogger<InquiryController> logger)
        {
            _helper = helper;
            _logger = logger;
        }
        ///<summary>
        ///This endpoint allows client to  get all countries
        ///</summary>
        ///<remarks>
        /// Sample Url /countries
        ///</remarks>
        [HttpGet]
        [Route("countries")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCountries()
        {
            _logger.LogInformation("Executing Get Countries Request ");
            var response = new GetCountriesFinalResponse();
            try
            {
                response = await _helper.GetCountries();
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
        ///This endpoint allows client to Get States by country id
        /// </summary>
        /// /// <param name="countryId"></param>
        /// <returns></returns>
        ///<remarks>
        /// Sample Url country/states/{countryId}
        ///</remarks>
        [HttpGet]
        [Route("country/states/{countryId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStatesByCountry(string countryId)
        {
            _logger.LogInformation("Executing Get States By Country");
            var response = new GetStatesFinalResponse();
            try
            {
                response = await _helper.GetStatesByCountry(countryId);
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
        ///This endpoint allows client to  get all Local Governments by state
        ///</summary>
        /// /// <param name="stateId"></param>
        /// <returns></returns>
        ///<remarks>
        /// Sample Url state/lgas/{stateId}
        ///</remarks>
        [HttpGet]
        [Route("state/lgas/{stateId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetLgasByState(string stateId)
        {
            _logger.LogInformation($"Executing Get Local Governments By State");
            var response = new GetLgaFinalResponse();
            try
            {
                response = await _helper.GetLgasByState(stateId);
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


    }
}
