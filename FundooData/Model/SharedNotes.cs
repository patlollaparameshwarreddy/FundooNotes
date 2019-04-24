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

        /// <summary>
        /// Gets or sets the sendermail.
        /// </summary>
        /// <value>
        /// The sendermail.
        /// </value>
        public string sendermail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is pin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is pin; otherwise, <c>false</c>.
        /// </value>
        public bool IsPin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is archive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is archive; otherwise, <c>false</c>.
        /// </value>
        public bool IsArchive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is trash.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is trash; otherwise, <c>false</c>.
        /// </value>
        public bool IsTrash { get; set; }

        /// <summary>
        /// Gets or sets the color code.
        /// </summary>
        /// <value>
        /// The color code.
        /// </value>
        public string ColorCode { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public int position { get; set; }
    }
}
