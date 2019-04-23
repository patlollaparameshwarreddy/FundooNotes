using System;
using System.Collections.Generic;
using System.Text;

namespace FundooData.Model
{
   public class SharedNotes
   {
        public int noteId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the take a note.
        /// </summary>
        /// <value>
        /// The take a note.
        /// </value>
        public string TakeANote { get; set; }

        public string sendermail { get; set; }
    }
}
