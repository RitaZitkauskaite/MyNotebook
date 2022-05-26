using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyNotebook.Model;
using MyNotebook.Repositories;
using MyNotebook.Services;

namespace MyNotebook.Pages.Notes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NotesRepository _repository;
        private readonly UserService _userService;


        public List<Note> Notes { get; set; }

        public IndexModel(NotesRepository repository, UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public void OnGet()
        {
            var userId = _userService.GetUserId();
            Notes = _repository.GetNotesByUserId(userId);
        }
        public IActionResult OnPostDelete(int id)
        {

            var book = _repository.GetNote(id);
            if (book == null)
            {
                return NotFound();
            }
            _repository.DeleteNote(id);
            return RedirectToPage("Index");
        }
    }
}
