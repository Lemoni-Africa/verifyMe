using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class NinValidationFinalResponse : DefaultResponse
    {
        public NinValidationResponse.NinValidationResponse NinValidationResponse { get; set; }

        public ValidationErrorResponse ErrorResponse { get; set; }
    }
}
