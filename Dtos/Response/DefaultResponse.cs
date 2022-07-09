using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class DefaultResponse
    {
        public bool IsSuccessful { get; set; } = false;
        public string ResponseMessage { get; set; }
    }
}
