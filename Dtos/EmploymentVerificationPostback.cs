using System;

namespace VerifyMeIntegration.Dtos.EmploymentVerificationPostback
{
    public class EmploymentVerificationPostback : PostbackBase
    {
        public Data data { get; set; }
    }
    public class Applicant
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string marital_status { get; set; }
        public string photo { get; set; }
        public string dob { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
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
        public string employeeStartDate { get; set; }
        public bool rehire { get; set; }
        public DateTime employerRespondedAt { get; set; }
        public Applicant applicant { get; set; }
        public Status status { get; set; }
        public string industry { get; set; }
        public string comment { get; set; }
        public bool verifiedPoc { get; set; }
        public string companyName { get; set; }
        public string employmentType { get; set; }
        public string supervisorName { get; set; }
        public string supervisorTitle { get; set; }
        public string jobBenefits { get; set; }
        public string requestSource { get; set; }
        public bool currentlyEmployed { get; set; }
        public bool employerConsented { get; set; }
        public string attestatorName { get; set; }
        public string attestatorTitle { get; set; }
        public string attestatorContact { get; set; }
        public string companyAddress { get; set; }
        public string compensationRate { get; set; }
        public string salaryRange { get; set; }
        public string supervisorEmail { get; set; }
        public string supervisorPhone { get; set; }
        public bool employeeCurrentlyEmployed { get; set; }
    }
}
