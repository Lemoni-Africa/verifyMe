using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class TinValidationFinalResponse : DefaultResponse
    {
        public TinValidationResponse.TinValidationResponse TinValidationResponse { get; set; }
        public ValidationErrorResponse ErrorResponse { get; set; }
    }
}
