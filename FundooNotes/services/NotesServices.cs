using FundooData.Model;
using FundooNotes.DataContext;
using FundooNotes.Interfaces;
using FundooNotes.model;
using FundooNotes.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FundooNotes.services
{
    public class NotesServices : INotes
    {
   
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext context;

        public UserManager<ApplicationUser> userManager { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesServices"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        public NotesServices(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            //this.userManager = userManager;
            this.context = context;
            this.userManager = userManager;
        }

        
        public int AddNotes(NotesModel notesModel)
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
                return result;
                }
                catch (Exception ex)
                {
                throw new Exception(ex.Message);
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

        public async Task<object> checkCollaboratorEmail(string email)
        {
            var data = await this.userManager.FindByEmailAsync(email);
            if (data.Email == email)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public string AddCollaboratorToNote([FromBody]CollaboratorModel model)
        {
            try
            {
                var data = from t in context.collaborators where t.UserId == model.UserId select t;
                foreach (var datas in data.ToList())
                {
                    if (datas.NoteId == model.NoteId && datas.ReceiverEmail == model.ReceiverEmail)
                    {
                        return false.ToString();
                    }
                }

                var newdata = new CollaboratorModel()
                {
                    UserId = model.UserId,
                    NoteId = model.NoteId,
                    SenderEmail = model.SenderEmail,
                    ReceiverEmail = model.ReceiverEmail,

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

        public object collaboratorNote(string ReceiverEmail)
        {
            try
            {
                var colldata = new List<NotesModel>();
                var sharednotes = new List<SharedNotes>();
                var data = from coll in this.context.collaborators where coll.ReceiverEmail == ReceiverEmail select new
                {
                    coll.SenderEmail,
                    coll.NoteId
                };

                foreach (var result in data)
                {
                    var collnotes = from notes in this.context.Notes where notes.Id == result.NoteId select new SharedNotes
                    {
                       noteId = notes.Id,
                       Title = notes.Title,
                       TakeANote = notes.TakeANote,
                       sendermail = result.SenderEmail,
                       IsPin = notes.IsPin,
                       IsArchive = notes.IsArchive,
                       IsTrash = notes.IsTrash,
                       ColorCode = notes.ColorCode,
                       ImageUrl = notes.ImageUrl,
                       position = notes.position
                    };
                  foreach (var collaborator in collnotes)
                    {
                        sharednotes.Add(collaborator);
                    }
                }

                return sharednotes;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int updateCollaborator(SharedNotes sharedNotes, int id)
        {
            try
            {
                NotesModel tableModel = this.context.Notes.Where<NotesModel>(t => t.Id == id).FirstOrDefault();
                tableModel.Title = sharedNotes.Title;
                tableModel.TakeANote = sharedNotes.TakeANote;
                tableModel.IsPin = sharedNotes.IsPin;
                tableModel.IsArchive = sharedNotes.IsArchive;
                tableModel.IsTrash = sharedNotes.IsTrash;
                tableModel.ColorCode = sharedNotes.ColorCode;
                tableModel.ImageUrl = sharedNotes.ImageUrl;
                tableModel.position = sharedNotes.position;

                int result = 0;
                result = this.context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IList<CollaboratorModel> getNotesCollaborator(Guid userId)
        {
            try
            {
                var list = new List<CollaboratorModel>();
                var data = from t in this.context.collaborators where t.UserId == userId select t;
                foreach (var result in data)
                {
                    list.Add(result);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AddFirebaseToken([FromBody] PushNotificationModel pushNotification)
        {
            try
            {
                var data = this.context.pushNotifications.Where(t => t.UserId == pushNotification.UserId).FirstOrDefault();
                if (data == null)
                {
                    var newUser = new PushNotificationModel()
                    {
                        UserId = pushNotification.UserId,
                        PushToken = pushNotification.PushToken
                    };

                    int save = 0;
                    this.context.pushNotifications.Add(newUser);
                    save = this.context.SaveChanges();
                    return save;
                }

                data.PushToken = pushNotification.PushToken;
                int result = 0;
                result = this.context.SaveChanges();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CheckNotifications(Guid userId)
        {
            bool con = true;
                var notesData = from notes in this.context.Notes
                                where notes.userId == userId
                                select notes;
                while(con)
                {
                foreach (var item in notesData)
                {
                    //string hour = item.Reminder.Substring(10, 2);
                    //return DateTime.Now.Hour.ToString();
                    //string min = item.Reminder.Substring(13, 2);
                    ////return min +" " + hour;
                    if (DateTime.Now.Hour == 17 && DateTime.Now.Minute == 58)
                    {
                        var title = item.Title;
                        var msg = item.TakeANote;
                        var token = this.context.pushNotifications.Where(t => t.UserId == userId).FirstOrDefault();
                        return SendNotification(token.PushToken.ToString(), title, msg);
                    }
                }
            }
            return null;
        }

        public string SendNotification(string DeviceToken, string title, string msg)
        {
            string serverKey = "AAAA-JJhvok:APA91bGO-u8qDHB-Ce6gx-lDAo3mqw8up6wWZZ7Ef8RfIKC5W8ZrIDHW5v-CMOKKMVuCjQU5j3-VDUzGtpIrSOiEwI_BGy_bEp-QRoT4own_lUA1uCA2LaTPT_fDMnEYGzAh_eVCSJTb";
            string senderId = "1067607768713";
            string webAddr = "https://fcm.googleapis.com/fcm/send";
            var result = "-1";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
            httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            httpWebRequest.Method = "POST";
            var payload = new
            {
                to = DeviceToken,
                priority = "high",
                content_available = true,
                notification = new
                {
                    body = msg,
                    title = title
                },
            };
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(payload);
                streamWriter.Write(json);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}

