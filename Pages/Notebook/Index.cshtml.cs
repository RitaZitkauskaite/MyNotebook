using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyNotebook.Model;
using MyNotebook.Repositories;
using MyNotebook.Services;


namespace MyNotebook.Pages.Notebook
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserService _userService;
        private readonly CategoriesRepository _categoriesRepository;
        private readonly NotesRepository _notesRepository;

        public SelectList CategoriesList { get; set; }
        public List<Category> Categories { get; set; }
        public List<Note> Notes { get; set; }

        public IndexModel(UserService userService, CategoriesRepository categoriesRepository, NotesRepository notesRepository)
        {
            _userService = userService;
            _categoriesRepository = categoriesRepository;
            _notesRepository = notesRepository;
        }


        public IActionResult OnGet()
        {
            var userId = _userService.GetUserId();
            Notes = _notesRepository.GetNotesByUserId(userId);
            Categories = _categoriesRepository.GetCategoriesByUserId(userId);
            
            return Page();
            
        }
    }
}
