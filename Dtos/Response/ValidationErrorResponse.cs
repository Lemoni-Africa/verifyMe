using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class ValidationErrorResponse
    {
        public int ? StatusCode { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
