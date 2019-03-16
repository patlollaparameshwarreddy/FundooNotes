namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FundooData.Model;
    using FundooNotes.DataContext;
    using FundooNotes.model;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        public NotesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        [Route("addnotes")]
        public void AddNotes([FromBody] NotesModel notesModel)
        {
            if(ModelState.IsValid)
            {
                var user = new NotesModel()
                {
                    Title = notesModel.Title,
                    TakeANote = notesModel.TakeANote
                };
                int result = 0;
                try
                {
                    _context.notes.Add(user);
                    result = _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        [HttpPost]
        [Route("updatenotes/{id}")]
        public void UpdateNotes([FromBody] NotesModel notesModel,string id)
        {
            NotesModel tableModel = _context.notes.Where<NotesModel>(t => t.Id.Equals(id)).First();
            tableModel.Title = notesModel.Title;
            tableModel.TakeANote = notesModel.TakeANote;
            tableModel.IsPin = notesModel.IsPin;
            tableModel.IsArchive = notesModel.IsArchive;
            tableModel.IsTrash = notesModel.IsTrash;
            tableModel.ColorCode = notesModel.ColorCode;
            tableModel.ImageUrl = notesModel.ImageUrl;
            tableModel.Reminder = tableModel.Reminder;
            int result = 0;
            try
            {
                result = _context.SaveChanges();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        [HttpDelete("DeleteNotes/{ID}")]
        public void DeleteNotes(string id)
        {
            var note = _context.notes.Where<NotesModel>(t => t.Id.Equals(id)).First();

            int result = 0;
            try
            {
                _context.notes.Remove(note);
                result = _context.SaveChanges();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}