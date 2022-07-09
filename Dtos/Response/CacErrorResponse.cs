using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response
{
    public class CacErrorResponse
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public List<Message> Message { get; set; }
    }

    public class Target
    {
        public int RcNumber { get; set; }
        public string Type { get; set; }
    }

    public class Constraints
    {
        public string Matches { get; set; }
    }

    public class Message
    {
        public Target Target { get; set; }
        public string Value { get; set; }
        public string Property { get; set; }
        public List<string> Children { get; set; }
        public Constraints Constraints { get; set; }
    }

}
