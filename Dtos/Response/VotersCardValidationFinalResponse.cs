using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class VotersCardValidationFinalResponse : DefaultResponse
    {
        public VotersCardValidationResponse.VotersCardValidationResponse VotersCardValidationResponse { get; set; }
        public ValidationErrorResponse ErrorResponse { get; set; }
    }
}
