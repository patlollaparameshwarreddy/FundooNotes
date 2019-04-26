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
    using System.Threading.Tasks;
    using FundooData.Model;
    using FundooNotes.DataContext;
    using FundooNotes.Interfaces;
    using FundooNotes.model;
    using FundooNotes.Model;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// this is the controller class
    /// </summary>D:\FundooNotes\FundooNotes\Interfaces\INotes.cs
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
       
        public INotes Notes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        public NotesController(INotes notes)
        {
            Notes = notes;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        [HttpPost]
        public int AddNotes(NotesModel notesModel)
        {

           return Notes.AddNotes(notesModel);
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <param name="id">The identifier.</param>
        [HttpPut("notes/{id}")]
        public void UpdateNotes([FromBody] NotesModel notesModel, int id)
        {           
            Notes.UpdateNotes(notesModel, id);
        }

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete]
        public void DeleteNotes(int id)
        {
            Notes.DeleteNotes(id);
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>the object</returns>
        [HttpGet]
        public IActionResult GetNotes(Guid userId)
        {           
            return Ok( Notes.GetNotes(userId));
        }

        [HttpGet("archive")]
        public object GetArchiveNotes(Guid userId)
        {

           return Notes.GetArchiveNotes(userId);
        }

        [HttpGet("reminder")]
        public object ReminderNotes(Guid userId)
        {

            return Notes.ReminderNotes(userId);
        }

        [HttpPost]
        [Route("labels")]
        public void AddLabels([FromBody] LabelsModel newLabel)
        {
            Notes.AddLabels(newLabel);
        }

        [HttpGet]
        [Route("labels")]
        public List<LabelsModel> GetLabels(Guid UserId)
        {
           return Notes.GetLabels(UserId);
           
        }

        [HttpPut]
        [Route("label/{id}")]
        public string  UpdateLabels(int id,string newlabel)
        {
           return Notes.UpdateLabels(id, newlabel);
        }

        [HttpDelete ]
        [Route("label/{id}")]
        public void DeleteLabel(int id)
        {
            Notes.DeleteLabel(id);
        }

        [HttpPost]
        [Route("NotesLabel")]
        public string AddNotesLabel([FromBody]NotesLabelTable model)
        {
            return Notes.AddNotesLabel(model);

        }

        [HttpGet]
        [Route("noteslabel")]
        public List<NotesLabelTable> GetNotesLabel(Guid userId)
        {
           return Notes.GetNotesLabel(userId);
        }

        [HttpDelete]
        [Route("noteslabel")]
        public void DeleteNotesLabel(int id)
        {
            Notes.DeleteNotesLabel(id);
        }

        [HttpGet]
        [Route("collaboratordata/{userId}")]
        public IList<CollaboratorModel> getNotesCollaborator(Guid userId)
        {
            return Notes.getNotesCollaborator(userId);
        }

        [HttpPost]
        [Route("collaborator")]
        public string AddCollaboratorToNote([FromBody]CollaboratorModel model)
        {
            return Notes.AddCollaboratorToNote(model);
        }

        [HttpDelete]
        [Route("collaborator")]
        public string DeleteCollaboratorToNote(int id)
        {
            return Notes.RemoveCollaboratorToNote(id);
        }

        [HttpGet]
        [Route("collaboratornotes/{email}")]
        public object collaboratorNote(string email)
        {
            return Notes.collaboratorNote(email);
        }

        [HttpPut]
        [Route("collaboratornotes/{id}")]
        public int updateCollaborator(SharedNotes sharedNotes, int id)
        {
            return Notes.updateCollaborator(sharedNotes, id);
        }

        [HttpGet]
        [Route("collaborator/{email}")]
        public Task<object> checkCollaboratorEmail(string email)
        {
            return Notes.checkCollaboratorEmail(email);
        }

        [HttpPut]
        [Route("notification")]
        public int AddFirebaseToken([FromBody] PushNotificationModel pushNotification)
        {
             return Notes.AddFirebaseToken(pushNotification);
        }
    }
}
