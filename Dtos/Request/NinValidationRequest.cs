using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Request
{
    public class NinValidationRequest
    {
        private string _dob;
        [Required]
        public string Ref { get; set; }

        public string Dob
        {
            get => _dob;
            set => _dob = string.IsNullOrEmpty(value) ? value : Helpers.Helper.FormatDateOfBirthFormatDateOfBirth(value);

        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
