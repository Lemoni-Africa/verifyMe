using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Response.BiometricValidationResponse
{
    public class BiometricValidationResponse
    {
        public string Status { get; set; }
        public Data Data { get; set; }
    }

    public class PhotoMatching
    {
        public bool Match { get; set; }
        public double MatchScore { get; set; }
        public int MatchingThreshold { get; set; }
        public int MaxScore { get; set; }
    }

    public class Data
    {
        public string Bvn { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Birthdate { get; set; }
        public string Nationality { get; set; }
        public string Photo { get; set; }
        public PhotoMatching PhotoMatching { get; set; }
    }
}
