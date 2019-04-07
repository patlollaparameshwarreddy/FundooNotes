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
            try
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
            var note = this.context.Notes.Where<NotesModel>(t => t.Id.Equals(id)).FirstOrDefault();

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
            try
            {
                var list = new List<NotesModel>();
                var labels = new List<LabelsModel>();
                GetNotesData data = new GetNotesData();
                var notesData = from notes in this.context.Notes where notes.userId == userId orderby notes.Id descending select notes;
                foreach (var item in notesData)
                {
                    list.Add(item);
                }
                var Label = from t in context.labels where t.UserId == userId select t;
                foreach (var lbl in Label)
                {
                    labels.Add(lbl);
                }

                data.notesData = list;
                data.labelsData = labels;
                return data;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        [HttpGet("archive")]
        public object GetArchiveNotes(Guid userId)
        {

            try
            {
                var list = new List<NotesModel>();
                GetNotesData data = new GetNotesData();
                var notesData = from notes in this.context.Notes where (notes.userId == userId) && (notes.IsArchive == true) && (notes.IsTrash == false)  select notes;
                foreach (var item in notesData)
                {
                    list.Add(item);
                }

                data.notesData = list;
                return data;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Route("labels")]
        public void AddLabels([FromBody] LabelsModel newLabel)
        {
            var label = new LabelsModel()
            {
                UserId = newLabel.UserId,
                Labels = newLabel.Labels
            };
            int result = 0;
            try
            {
                this.context.labels.Add(label);
                result = this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                 ex.ToString();
            }
        }

        [HttpGet]
        [Route("labels")]
        public object GetLabels(Guid UserId)
        {
            try
            {
                var list = new List<LabelsModel>();
                GetNotesData data = new GetNotesData();
                var labels = from t in this.context.labels where t.UserId == UserId select t;
                foreach (var items in labels)
                {
                    list.Add(items);
                }

                return list;
            }
            catch(Exception ex)
            {
               return ex.Message.ToString();
            }
           
        }

        [HttpPut]
        [Route("label/{id}")]
        public string  UpdateLabels([FromBody] LabelsModel labelsModel, int id)
        {
            LabelsModel labels = context.labels.Where(t => t.Id == id).FirstOrDefault();
            labels.Labels = labelsModel.Labels;
            int result = 0;
            try
            {
                result = this.context.SaveChanges();
                return result.ToString();
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [HttpDelete ]
        [Route("label/{id}")]
        public void DeleteLabel(int id)
        {
            LabelsModel label = context.labels.Where(t => t.Id == id).FirstOrDefault();
            int result = 0;
            try
            {
                this.context.labels.Remove(label);
                result = context.SaveChanges();
            }
            catch (Exception ex)
            {
               ex.Message.ToString();
            }
        }

        [HttpPost]
        [Route("NotesLabel")]
        public bool AddNotesLabel([FromBody]NotesLabelTable model)
        {
            var labelData = from t in context.notesLabels where t.UserId == model.UserId select t;
            foreach(var datas in labelData.ToList())
            {
                if(datas.NoteId == model.NoteId && datas.LableId == model.LableId)
                {
                    return false;
                }
            }

            var data = new NotesLabelTable
            {
                LableId = model.LableId,
                NoteId = model.NoteId,
                UserId = model.UserId
            };
            int result = 0;
            context.notesLabels.Add(data);
            result = context.SaveChanges();
            return true;
        }

        [HttpGet]
        [Route("noteslabel")]
        public List<NotesLabelTable> GetNotesLabel(Guid userId)
        {
            var list = new List<NotesLabelTable>();
            var Labeldata = from t in context.notesLabels where t.UserId == userId select t;
            try
            {
                foreach (var data in Labeldata)
                {
                    list.Add(data);
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return list;
        }

        [HttpDelete]
        [Route("noteslabel")]
        public void DeleteNotesLabel(int id)
        {
            var label = context.notesLabels.Where<NotesLabelTable>(t => t.Id == id).First();
            int result = 0;
            try
            {
                context.notesLabels.Remove(label);
                result = context.SaveChanges();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}
