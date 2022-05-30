using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyNotebook.Model;
using MyNotebook.Repositories;
using MyNotebook.Services;

namespace MyNotebook.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly UserService _userService;
        private readonly CategoriesRepository _categoriesRepository;
        private readonly NotesRepository _notesRepository;

        public List<Category> Categories { get; set; }
        public List<Note> Notes { get; set; }

      /*  [BindProperty(SupportsGet = true)]
        public string SearchInputTitle { get; set; } // Search*/

        public IndexModel(ILogger<IndexModel> logger, CategoriesRepository categoriesRepository, NotesRepository notesRepository, UserService userService)
        {
            _logger = logger;
            _categoriesRepository = categoriesRepository;
            _notesRepository = notesRepository;
            _userService = userService;
        }

        public void OnGet()
        {
            var userId = _userService.GetUserId();
            Notes = _notesRepository.GetNotesByUserId(userId);
            Categories = _categoriesRepository.GetCategoriesByUserId(userId);
        }
    }
}