using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Request
{
    public class VotersCardValidationRequest
    {
        private string _dob;
        [Required]
        public string Ref { get; set; }
        [Required]
        public string Dob
        {
            get => _dob;
            set => _dob =  Helpers.Helper.FormatDateOfBirth2(value);

        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
