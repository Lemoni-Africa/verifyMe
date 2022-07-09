using System.Collections.Generic;

namespace VerifyMeIntegration.Dtos.StateResponse
{
    public class GenericCodeResponse
    {
        public string Status { get; set; }
        public List<Data> Data { get; set; }
    }

    public class Data
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
