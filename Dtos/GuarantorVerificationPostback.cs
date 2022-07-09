using System.Collections.Generic;

namespace VerifyMeIntegration.Dtos
{
    public class GuarantorVerificationPostback : PostbackBase
    {
        public Data data { get; set; }
    }

    public class Applicant
    {
        public string idType { get; set; }
        public string idNumber { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string birthdate { get; set; }
        public string photo { get; set; }
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
        public Applicant applicant { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public List<string> acceptableIdType { get; set; }
        public string identityType { get; set; }
        public string identityNumber { get; set; }
        public string identityPhoto { get; set; }
        public string relationship { get; set; }
        public string relationshipLength { get; set; }
        public string comment { get; set; }
        public bool address { get; set; }
        public bool verifyAddress { get; set; }
        public Status status { get; set; }
        public string createdAt { get; set; }
        public string completedAt { get; set; }
    }
}
