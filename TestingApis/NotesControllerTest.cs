using FundooData.Model;
using FundooNotes.Controllers;
using FundooNotes.DataContext;
using FundooNotes.Interfaces;
using FundooNotes.Model;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System;

namespace Tests
{
    public class NotesControllerTest
    {
        private Mock<INotes> notessRepoMock;
        private NotesController NotesController;
        public NotesControllerTest()
        {
            notessRepoMock = new Mock<INotes>();
            NotesController = new NotesController(notessRepoMock.Object);
        }
        [Test]
        public void Test1()
        {
            Guid userId = new Guid("7543a7df-802e-49b8-ae85-e429058afa92");
            var data = NotesController.GetNotes(userId);
        }
    }
}