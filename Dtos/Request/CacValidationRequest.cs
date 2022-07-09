using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Request
{
    public class CacValidationRequest
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public int RcNumber { get; set; }
    }
}
