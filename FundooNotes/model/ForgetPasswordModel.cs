// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgetPasswordModel.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooNotes.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// this class is used for forget password
    /// </summary>
    public class ForgetPasswordModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
