using FundooData.Model;
using FundooNotes.Controllers;
using FundooNotes.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing.ControllerTest
{
    public class NotesControllerTesting
    {
        [Fact]
        public void AddNotesTesting()
        {
            var service = new Mock<INotes>();
            var controller = new NotesController(service.Object);
            var notes = new NotesModel()
            {
                userId = System.Guid.NewGuid(),
                Id = 2,
                Title = "first",
                TakeANote = "test",
                IsArchive = false,
                IsPin = true
            };
            var data = controller.AddNotes(notes);
            Assert.NotNull(data);
        }

    }
}
