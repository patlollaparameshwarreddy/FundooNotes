using FundooData.Model;
using FundooNotes.Interfaces;
using FundooNotes.model;
using FundooNotes.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotesApiTesting.NotesTesting
{
   public  class FakeNotesService : INotes
    {
        private readonly List<NotesModel> notesModel;


        public string AddCollaboratorToNote([FromBody] CollaboratorModel model)
        {
            throw new NotImplementedException();
        }

        public void AddLabels([FromBody] LabelsModel newLabel)
        {
            throw new NotImplementedException();
        }

        public void AddNotes(NotesModel notesModel)
        {
            notesModel = new NotesModel()
            {
                 userId = new Guid("7543a7df-802e-49b8-ae85-e429058afa92"),
                Email = null,
                Title = "hjgfh",
                TakeANote= "fhfghfg",
                IsPin= false,
                IsArchive= false,
                IsTrash= true,
                ColorCode= null,
                ImageUrl= null,
                Reminder= null,
            };
        }

        public string AddNotesLabel([FromBody] NotesLabelTable model)
        {
            throw new NotImplementedException();
        }

        public void DeleteLabel(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteNotes(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteNotesLabel(int id)
        {
            throw new NotImplementedException();
        }

        public object GetArchiveNotes(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<LabelsModel> GetLabels(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public IList<GetNotesData> GetNotes(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<NotesLabelTable> GetNotesLabel(Guid userId)
        {
            throw new NotImplementedException();
        }

        public object ReminderNotes(Guid userId)
        {
            throw new NotImplementedException();
        }

        public string RemoveCollaboratorToNote(int id)
        {
            throw new NotImplementedException();
        }

        public string UpdateLabels(int id, string newlabel)
        {
            throw new NotImplementedException();
        }

        public void UpdateNotes([FromBody] NotesModel notesModel, int id)
        {
            throw new NotImplementedException();
        }

        //Task<object> INotes.ShareCollaborator(CollaboratorModel model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
