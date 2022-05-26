using Microsoft.EntityFrameworkCore;
using MyNotebook.Data;
using MyNotebook.Model;

namespace MyNotebook.Repositories
{
    public class NotesRepository
    {
        private readonly MyNotebookContext _context;

        public NotesRepository(MyNotebookContext context)
        {
            _context = context;
        }
        public List<Note> GetNotes()
        {
            return _context.Notes
                .Include(n => n.Category)
                .ToList();
        }

        public List<Note> GetNotesByUserId(string id)
        {
            return _context.Notes
                .Include(note => note.Category)
                .Where(note => note.MyNotebookUserId == id).ToList();
        }
        public Note GetNote(int id)
        {
            return _context.Notes.FirstOrDefault(note => note.Id == id);
        }
        public void DeleteNote(int id)
        {
            var note = _context.Notes.FirstOrDefault(note => note.Id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }
        public void UpdateNote(Note note)
        {
            _context.Entry(note).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void CreateNote(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();
        }

    }
}
