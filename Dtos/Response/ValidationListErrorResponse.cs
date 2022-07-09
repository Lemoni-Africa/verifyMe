using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class ValidationListErrorResponse
    {
        public int ? StatusCode { get; set; }
        public string Code { get; set; }
        public List<string> Message { get; set; }
    }
}
