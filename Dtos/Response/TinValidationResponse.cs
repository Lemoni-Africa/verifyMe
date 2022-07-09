using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response.TinValidationResponse
{
    public class TinValidationResponse
    {
        public string Status { get; set; }
        public Data data { get; set; }

    }

    public class Data
    {
        public string Tin { get; set; }
        public string TaxpayerName { get; set; }
        public string CacRegNo { get; set; }
        public string EntityType { get; set; }
        public string Jittin { get; set; }
        public string TaxOffice { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
