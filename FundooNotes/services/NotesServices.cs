using FundooData.Model;
using FundooNotes.DataContext;
using FundooNotes.Interfaces;
using FundooNotes.model;
using FundooNotes.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.services
{
    public class NotesServices : INotes
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext context;

        public object ModelState { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        public NotesServices(ApplicationDbContext context)
        {
            //this.userManager = userManager;
            this.context = context;
        }

        
        public void AddNotes(NotesModel notesModel)
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
                tableModel.Reminder = notesModel.Reminder;
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

       
        public IList<GetNotesData> GetNotes(Guid userId)
        {
            try
            {
                var list = new List<NotesModel>();
                var labels = new List<LabelsModel>();
                GetNotesData data = new GetNotesData();
                var notesData = from notes in this.context.Notes 
                                where notes.userId == userId orderby notes.Id descending select notes;
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
                var notesdata = new List<GetNotesData>();
                notesdata.Add(data);
                return notesdata.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public object GetArchiveNotes(Guid userId)
        {

            try
            {
                var list = new List<NotesModel>();
                GetNotesData data = new GetNotesData();
                var notesData = from notes in this.context.Notes where (notes.userId == userId) && (notes.IsArchive == true) && (notes.IsTrash == false) select notes;
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

        public object ReminderNotes(Guid userId)
        {

            try
            {
                var list = new List<NotesModel>();
                GetNotesData data = new GetNotesData(); 
                var notesData = from notes in this.context.Notes where (notes.userId == userId) && (notes.Reminder != null)  select notes;
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

        public List<LabelsModel> GetLabels(Guid UserId)
        {
            try
            {
                var list = new List<LabelsModel>();
                var labels = from t in this.context.labels where t.UserId == UserId select t;
                foreach (var items in labels)
                {
                    list.Add(items);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string UpdateLabels(int id, string newlabel)
        {
            LabelsModel labels = context.labels.Where(t => t.Id == id).FirstOrDefault();
            labels.Labels = newlabel;
            int result = 0;
            try
            {
                result = this.context.SaveChanges();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

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

        public string AddNotesLabel([FromBody]NotesLabelTable model)
        {
            try
            {
                var labelData = from t in context.notesLabels where t.UserId == model.UserId select t;
                foreach (var datas in labelData.ToList())
                {
                    if (datas.NoteId == model.NoteId && datas.LableId == model.LableId)
                    {
                        return false.ToString();
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
                return result.ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

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

        public string AddCollaboratorToNote([FromBody]CollaboratorModel model)
        {
            try
            {
                var data = from t in context.collaborators where t.UserId == model.UserId select t;
                foreach (var datas in data.ToList())
                {
                    if (datas.NoteId == model.NoteId && datas.SharedEmail == model.SharedEmail)
                    {
                        return false.ToString();
                    }
                }

                var newdata = new CollaboratorModel()
                {
                    NoteId = model.NoteId,
                    UserId = model.UserId,
                    SharedEmail = model.SharedEmail
                };

                int result = 0;
                context.collaborators.Add(newdata);
                result = context.SaveChanges();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string RemoveCollaboratorToNote(int id)
        {
            try
            {
                var data = context.collaborators.Where<CollaboratorModel>(t => t.Id == id).FirstOrDefault();
                int result = 0;
                context.collaborators.Remove(data);
                result = context.SaveChanges();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

