using System;
using System.Collections.Generic;

namespace VerifyMeIntegration.Dtos.Response.GuarantorResponse
{
    public class GuarantorVerificationResponse
    {
        public string Status { get; set; }
        public Data Data { get; set; }
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

    public class Address
    {
        public string formattedAddress { get; set; }
        public string state { get; set; }
        public string lga { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string country { get; set; }
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
        public Address address { get; set; }
        public bool verifyAddress { get; set; }
        public Status status { get; set; }

        private string _completedAt;
        private string _createdAt;
        public string createdAt
        {
            get
            {
                return FormatDate(_createdAt);
            }
            set
            {
                _createdAt = FormatDate(value);
            }
        }

        public string completedAt
        {
            get
            {
                return FormatDate(_completedAt);
            }
            set
            {
                _completedAt = FormatDate(value);
            }
        }



        private string FormatDate(string date)
        {
            if (date.Contains("GMT"))
            {
                int startIndex = date.IndexOf('G');
                Console.WriteLine("startIndex " + startIndex);
                int endIndex = date.Length - startIndex;
                Console.WriteLine("endIndex " + endIndex);
                date = date.Substring(0, startIndex - 1);
                Console.WriteLine(date);
                

            }

            return date;
        }
    }
}
