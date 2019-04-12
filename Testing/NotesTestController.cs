using FundooNotes.DataContext;
using FundooNotes.services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    class NotesTestController
    {
        private NotesServices notesServices;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=(localDB)\\LocalDbdemo; Database=BlogDb; Trusted_Connection=True; MultipleActiveResultSets=true";
        static NotesTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public NotesTestController()
        {
            var context = new ApplicationDbContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            notesServices = new NotesServices(context);

        }
    }
}
