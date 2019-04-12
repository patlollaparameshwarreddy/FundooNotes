using FundooData.Model;
using FundooNotes.model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Interfaces
{
    public interface INotes
    {
        void AddNotes(NotesModel notesModel);
        void UpdateNotes([FromBody] NotesModel notesModel, int id);
        void DeleteNotes(int id);
        object GetNotes(Guid userId);
        object GetArchiveNotes(Guid userId);
        object ReminderNotes(Guid userId);
        void AddLabels([FromBody] LabelsModel newLabel);
        object GetLabels(Guid UserId);
        string UpdateLabels(int id, string newlabel);
        void DeleteLabel(int id);
        string AddNotesLabel([FromBody]NotesLabelTable model);
        List<NotesLabelTable> GetNotesLabel(Guid userId);
        void DeleteNotesLabel(int id);
        string AddCollaboratorToNote([FromBody]CollaboratorModel model);
    }
}
