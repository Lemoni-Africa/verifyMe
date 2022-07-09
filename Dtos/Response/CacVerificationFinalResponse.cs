using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class CacVerificationFinalResponse : DefaultResponse
    {
        public CacVerificationResponse CacVerificationResponse { get; set; }
        public CacErrorResponse ErrorResponse { get; set; }

    }
}
