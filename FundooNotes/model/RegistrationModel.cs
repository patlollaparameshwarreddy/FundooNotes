using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.model
{
    public class RegistrationModel
    {
        [Required]
        public string firstName { get; set; }

        
        public string lastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string emailId { get; set; }

        [Required]
        public string password { get; set; }
    }
}
