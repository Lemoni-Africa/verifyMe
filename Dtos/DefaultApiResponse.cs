using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos
{
    public class DefaultApiResponse
    {
        public bool IsSuccessful { get; set; }
        public int StatusCode { get; set; }
        public string ResponseJson { get; set; }
    }
}
