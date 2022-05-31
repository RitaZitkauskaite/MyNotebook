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
        public List<Note> GetNotesByUserId(string id, string title = null, string categoryTitle = null)
        {
            var notes = _context.Notes
                .Include(note  => note.Category)
                .Where(note => note.MyNotebookUserId == id)
                .Select(note => note);
            if (!string.IsNullOrEmpty(title))
            {
                notes = notes.Where(note => note.Title.Contains(title) || note.Content.Contains(title) || note.Category.Title.Contains(title)) ;
            }

            if (!string.IsNullOrEmpty(categoryTitle))
            {
                notes = notes.Where(note => note.Category.Id.ToString() == categoryTitle);
            }
            return notes.ToList();
        }
        public List<Note> GetNotesByUserId(string id)
        {
            return _context.Notes
                .Include(note => note.Category)
                .Where(note => note.MyNotebookUserId == id).ToList();
        }

        public Note GetNote(int id)
        {
            return _context.Notes.Include(c => c.Category).FirstOrDefault(note => note.Id == id);
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
        public void CreateNote(Note note, string id)
        {
            
            note.MyNotebookUserId = id;
            _context.Notes.Add(note);
            _context.SaveChanges();
        }
        public List<string> GetCategoriesNames(string id)
        {
            return (List<string>)_context.Notes
                .Include(note => note.Category)
                .Where(c => c.MyNotebookUserId == id)
                .Select(c => c.Category.Title)
                .Distinct().ToList();
        }
    }
}
