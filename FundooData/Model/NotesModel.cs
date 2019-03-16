using System;
using System.Collections.Generic;
using System.Text;

namespace FundooData.Model
{
    public class NotesModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string TakeANote { get; set; }
        public bool IsPin { get; set; }
        public bool IsArchive { get; set; }
        public bool IsTrash { get; set; }
        public string ColorCode { get; set; }
        public string ImageUrl { get; set; }
        public string Reminder { get; set; }
    }
}
