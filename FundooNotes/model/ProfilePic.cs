using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.model
{
    public class ProfilePic
    {
        public int id { get; set; }
        public Guid UserId { get; set; }
        public string ImageUrl { get; set; }
    }
}
