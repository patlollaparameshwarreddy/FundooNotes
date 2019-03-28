// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FundooData.Model;
    using FundooNotes.DataContext;
    using FundooNotes.Model;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// this is the controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        public NotesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        [HttpPost]
        public void AddNotes(NotesModel notesModel)
        {
            if (ModelState.IsValid)
            {
                var user = new NotesModel()
                {
                    userId = notesModel.userId,
                    Title = notesModel.Title,
                    TakeANote = notesModel.TakeANote,
                    IsPin = notesModel.IsPin,
                    IsArchive = notesModel.IsArchive,
                    IsTrash = notesModel.IsTrash,
                    ColorCode = notesModel.ColorCode,
                    ImageUrl = notesModel.ImageUrl,
                    Reminder = notesModel.Reminder
                };
                int result = 0;
                try
                {
                    this.context.Notes.Add(user);
                    result = this.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <param name="id">The identifier.</param>
        [HttpPut("notes/{id}")]
        public void UpdateNotes([FromBody] NotesModel notesModel, int id)
        {
            NotesModel tableModel = this.context.Notes.Where<NotesModel>(t => t.Id == id).FirstOrDefault();
            tableModel.Title = notesModel.Title;
            tableModel.TakeANote = notesModel.TakeANote;
            tableModel.IsPin = notesModel.IsPin;
            tableModel.IsArchive = notesModel.IsArchive;
            tableModel.IsTrash = notesModel.IsTrash;
            tableModel.ColorCode = notesModel.ColorCode;
            tableModel.ImageUrl = notesModel.ImageUrl;
            tableModel.Reminder = tableModel.Reminder;
            int result = 0;
            try
            {
                result = this.context.SaveChanges();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete]
        public void DeleteNotes(int id)
        {
            var note = this.context.Notes.Where<NotesModel>(t => t.Id.Equals(id)).First();

            int result = 0;
            try
            {
                this.context.Notes.Remove(note);
                result = this.context.SaveChanges();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>the object</returns>
        [HttpGet]
        public object GetNotes(Guid userId)
        {
            var list = new List<NotesModel>();
            GetNotesData data = new GetNotesData();
            var notesData = from notes in this.context.Notes where notes.userId == userId orderby notes.Id descending select notes;
            foreach (var item in notesData)
            {
                list.Add(item);
            }

            data.notesData = list;
            return data;
        }
    }
}