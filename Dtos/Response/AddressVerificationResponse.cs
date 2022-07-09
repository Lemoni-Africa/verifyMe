using System.Collections.Generic;

namespace VerifyMeIntegration.Dtos.Response.AddressResponse
{
    public class AddressVerificationResponse
    {
        public string Status { get; set; }
        public Data Data { get; set; }
    }

  
    public class Neighbor
    {
        public string name { get; set; }
        public string comment { get; set; }
        public string phone { get; set; }
    }

    public class Status
    {
        public string status { get; set; }
        public string subStatus { get; set; }
        public string state { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public Generic.Applicant applicant { get; set; }
        public string createdAt { get; set; }
        public string completedAt { get; set; }
        public string lattitude { get; set; }
        public string longitude { get; set; }
        public List<string> photos { get; set; }
        public Neighbor neighbor { get; set; }
        public Status status { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string lga { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string reference { get; set; }
    }
}
