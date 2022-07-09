using System.Collections.Generic;

namespace VerifyMeIntegration.Dtos.Response
{
    public class IdentityMatchResponse
    {
        public bool IsSuccessful { get; set; } = false;
        public bool IsAMatch { get; set; } = false;
        public List <string> MatchedFields { get; set; }
        public string ResponseMessage { get; set; }
    }
}
