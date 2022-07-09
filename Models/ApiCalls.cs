using System;

namespace VerifyMeIntegration.Models
{
    public class ApiCalls
    {
        public int Id { get; set; }
        public string ApiUrl { get; set; }
        public string ResourceName { get; set; }
        public string CallStatus { get; set; }
        public double CallCost { get; set; }
        public DateTime CallTime { get; set; }
    }
}
