using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyNotebook.Data;
using MyNotebook.Model;
using MyNotebook.Repositories;
using MyNotebook.Services;

namespace MyNotebook.Pages.Notes
{
    [Authorize]
    public class IndexModel : CategorySelectModel
    {
        private readonly NotesRepository _repository;
        private readonly CategoriesRepository _categoriesRepository;
        private readonly UserService _userService;
        private readonly MyNotebookContext _context;
       
        public List<Note> Notes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchInputTitle { get; set; } // Search
        [BindProperty(SupportsGet = true)]
        public string SelectedCategorysName { get; set; }

        public IndexModel(NotesRepository repository, UserService userService, CategoriesRepository categoriesRepository, MyNotebookContext context)
        {
            _repository = repository;
            _userService = userService;
            _categoriesRepository = categoriesRepository;
            _context = context;
        }

        public IActionResult OnGet()
        {
            var userId = _userService.GetUserId();
            var categories = _categoriesRepository.GetCategoriesByUserId(userId);
            CategoriesNames = new SelectList(categories);
            Notes = _repository.GetNotesByUserId(userId, SearchInputTitle, SelectedCategorysName);
            GenerateCategoriesDropDownList(userId,_context);
            return Page();

        }
        public async Task<IActionResult> OnPost()
        {

            return RedirectToPage("Index");
        }
        public IActionResult OnPostDelete(int id)
        {

            var note = _repository.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }
            _repository.DeleteNote(id);
            return RedirectToPage("Index");
        }
    }
}
