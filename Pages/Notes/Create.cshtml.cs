using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyNotebook.Data;
using MyNotebook.Model;
using MyNotebook.Repositories;
using MyNotebook.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace MyNotebook.Pages.Notes
{
    [Authorize]
    public class CreateModel : CategorySelectModel
    {
        private readonly NotesRepository _repository;
        private readonly MyNotebookContext _context;
        private readonly UserService _userService;
        //public SelectList CategoriesNames { get; set; }
        [BindProperty]
        public Note Note { get; set; }
       // [BindProperty(SupportsGet = true)]
       // public string SelectedCategorysName { get; set; }

        public CreateModel(NotesRepository repository, MyNotebookContext context, UserService userService)
        {
            _repository = repository;
            _context = context;
            _userService = userService;
        }
        
        public IActionResult OnGet()
        {
            var userId = _userService.GetUserId();
            GenerateCategoriesDropDownList(userId, _context);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/
            if (Note.Title == null && Note.Category.Id == 0)
            {
                return Page();
            }
            var userId = _userService.GetUserId();
            _repository.CreateNote(Note, userId);
            return RedirectToPage("Index");
            /*  var emptyBook = new Book();
            var tryUpdate = await TryUpdateModelAsync<Book>
                (emptyBook,"book",s => s.Id, s => s.AuthorId, s=> s.Content );

            if (tryUpdate)
            {
                _booksRepository.CreateBook(emptyBook);
                return RedirectToPage("index");
            }
            return Page();*/

        }
        /*public void GenerateCategoriesDropDownList(MyNotebookContext context, object selectedCategory = null)
        {
            var categoriesQuery = context.Categories.OrderBy(a => a.Title);
            CategoriesNames = new SelectList(categoriesQuery.AsNoTracking(), "Id", "Name", selectedCategory);

        }*/
    }
}
