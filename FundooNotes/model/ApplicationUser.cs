// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUser.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes.Model
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// application user class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the profile pic.
        /// </summary>
        /// <value>
        /// The profile pic.
        /// </value>
        public string profilePic { get; set; }
    }
}
