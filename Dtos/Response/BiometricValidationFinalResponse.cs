using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class BiometricValidationFinalResponse : DefaultResponse
    {
        public BiometricValidationResponse.BiometricValidationResponse BiometricValidationResponse { get; set; }
        public bool AcceptableMatch { get; set; } = false;
        public ValidationListErrorResponse ErrorResponse { get; set; }

    }
}
