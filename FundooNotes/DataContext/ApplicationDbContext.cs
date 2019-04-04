// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationDbContext.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooNotes.DataContext
{
    using FundooData.Model;
    using FundooNotes.Model;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// this class is used for creating tables
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext" />
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="T:Microsoft.EntityFrameworkCore.DbContext" />.</param>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the application users.
        /// </summary>
        /// <value>
        /// The application users.
        /// </value>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public DbSet<NotesModel> Notes { get; set; }

        /// <summary>
        /// Gets or sets the labels.
        /// </summary>
        /// <value>
        /// The labels.
        /// </value>
        public DbSet<LabelsModel> labels { get; set; }

        /// <summary>
        /// Gets or sets the notes labels.
        /// </summary>
        /// <value>
        /// The notes labels.
        /// </value>
        public DbSet<NotesLabelTable> notesLabels { get; set; }
    }
}
