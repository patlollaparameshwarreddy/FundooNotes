using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.model
{
    public class ResetPasswordModel
    {

        [Required(ErrorMessage = "* Mendatory Field", AllowEmptyStrings = false)]
        [EmailAddress]
        [Display(Name = "Email Address: ")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required(ErrorMessage = "* Mendatory Field", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Password must contain minimum 6 characters")]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
    }
}
