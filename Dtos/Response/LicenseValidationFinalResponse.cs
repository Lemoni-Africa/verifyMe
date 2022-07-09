using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class LicenseValidationFinalResponse :DefaultResponse
    {
        public LicenseValidationResponse.LicenseValidationResponse LicenseValidationResponse { get; set; }

        public ValidationErrorResponse ErrorResponse { get; set; }
    }
}
