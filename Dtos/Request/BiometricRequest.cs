using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VerifyMeIntegration.Helpers;

namespace VerifyMeIntegration.Dtos.Request
{
    public class BiometricRequest
    {
        public string Photo { get; set; }
        public string PhotoBase64 { get; set; }
        public string PhotoUrl { get; set; }
        [Required]
        public string IdType { get; set; }
        [Required]
        public string IdNumber { get; set; }
        public string DateOfBirth { get; set; }
    }
}
