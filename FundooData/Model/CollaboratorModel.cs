using FundooData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.model
{
    public class CollaboratorModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int NoteId { get; set; }
        public string SharedEmail { get; set; }
        public NotesModel notesModel { get; set; }
    }
}
