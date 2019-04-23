using FundooData.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.model
{
    public class CollaboratorModel
    {
       
        public int Id { get; set; }


        public Guid UserId { get; set; }


        public int NoteId { get; set; }

     
        [EmailAddress]
        public string SenderEmail { get; set; }

       
        [EmailAddress]
        public string ReceiverEmail { get; set; }
    }
}
