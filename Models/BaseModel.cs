using System;

namespace VerifyMeIntegration.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string RequestJson { get; set; }
        public string ResponseJson { get; set; }

        public string ApplicationId { get; set; }
        public string Status { get; set; }

        public string InitiatedBy { get; set; } = "System";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
