using FundooNotes.DataContext;
using Xunit;

namespace Testing
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {

        }

        public void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Notes.AddRange(
                new FundooData.Model.NotesModel() {
               userId= new System.Guid ("7543a7df-802e-49b8-ae85-e429058afa92"),
                    Id = 160,
            Email= null,
            Title= "HJHJBHJB",
            TakeANote= "GYTFYTYTUYTU",
            IsPin= false,
            IsArchive= false,
            IsTrash= false,
            ColorCode= "rgb(204, 255, 144)",
            ImageUrl= null,
            Reminder= "2019-4-17 8:0"}

            );
            context.SaveChanges();
        }
    }
}
