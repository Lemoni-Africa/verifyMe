using System;

namespace VerifyMeIntegration.Models
{
    public class IdentityVerification : BaseModel
    {
        public string IdType { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Dob { get; set; }
        public string IdReference { get; set; }
        public string Type { get; set; }
        public DateTime ? ExpiryDate { get; set; }


    }
}
