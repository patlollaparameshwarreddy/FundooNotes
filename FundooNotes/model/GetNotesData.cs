using FundooData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Model
{
    public class GetNotesData
    {
        /// <summary>
        /// Gets or sets the notes data.
        /// </summary>
        /// <value>
        /// The notes data.
        /// </value>
        public List<NotesModel> notesData { get; set; }

        /// <summary>
        /// Gets or sets the labels models.
        /// </summary>
        /// <value>
        /// The labels models.
        /// </value>
        public List<LabelsModel> labelsData { get; set; }
    }
}
