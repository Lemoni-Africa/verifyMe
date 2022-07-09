using System;
using System.Collections.Generic;

namespace VerifyMeIntegration.Dtos.Response.EmploymentResponse
{
    public class EmploymentHistoryVerificationResponse
    {
        public string Status { get; set; }
        public Data Data { get; set; }
    }


    public class Applicant
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
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
        public string employerName { get; set; }
        public string employerPhone { get; set; }
        public string employerEmail { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string title { get; set; }
        public Applicant applicant { get; set; }
        public Status status { get; set; }
        public bool currentlyEmployed { get; set; }
    }
}
