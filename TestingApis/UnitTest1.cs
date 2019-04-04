using FundooData.Model;
using FundooNotes.Controllers;
using FundooNotes.DataContext;
using FundooNotes.Model;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private readonly NotesController notesController;

        public Tests(NotesController notesController)
        {
            this.notesController = notesController;
        }
        [Test]
        public void Test1()
        {
            ////var mock = new Mock<ApplicationDbContext, UserManager<ApplicationUser>>();
            ////mock.Setup(p => p.GetNameById(1)).Returns("Jignesh");
            //notesController.AddNotes( notes);
            Assert.Pass();
        }
    }
}