using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VerifyMeIntegration.Dtos.Request
{
    public class VotersCardRequestDto
    {
        public string Dob
        {
            get ;
            set;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
