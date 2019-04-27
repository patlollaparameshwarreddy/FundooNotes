using FundooData.Model;
using FundooNotes.model;
using FundooNotes.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Interfaces
{
    public interface INotes
    {
        int AddNotes(NotesModel notesModel);
        void UpdateNotes([FromBody] NotesModel notesModel, int id);
        void DeleteNotes(int id);
        IList<GetNotesData> GetNotes(Guid userId);
        object GetArchiveNotes(Guid userId);
        object ReminderNotes(Guid userId);
        void AddLabels([FromBody] LabelsModel newLabel);
        List<LabelsModel> GetLabels(Guid UserId);
        string UpdateLabels(int id, string newlabel);
        void DeleteLabel(int id);
        string AddNotesLabel([FromBody]NotesLabelTable model);
        List<NotesLabelTable> GetNotesLabel(Guid userId);
        void DeleteNotesLabel(int id);
        string AddCollaboratorToNote([FromBody]CollaboratorModel model);
        string RemoveCollaboratorToNote(int id);
        object collaboratorNote(string ReceiverEmail);
        int updateCollaborator(SharedNotes sharedNotes, int id);
        Task<object> checkCollaboratorEmail(string email);
        IList<CollaboratorModel> getNotesCollaborator(Guid userId);
        int AddFirebaseToken([FromBody] PushNotificationModel pushNotification);
        string CheckNotifications(Guid userId);
        string SendNotification(string DeviceToken, string title, string msg);
    }
}
