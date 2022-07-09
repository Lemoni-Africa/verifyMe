using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response.VotersCardValidationResponse
{
    public class VotersCardValidationResponse
    {
        public string Status { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string Fullname { get; set; }
        public string Vin { get; set; }
        public string Vender { get; set; }
        public string Occupation { get; set; }
        public string PollingUnitCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
