using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyNotebook.Data;
using MyNotebook.Model;
using MyNotebook.Repositories;
using MyNotebook.Services;

namespace MyNotebook.Pages.Notes
{
    public class EditModel : CategorySelectModel
    {
        private readonly NotesRepository _repository;
        private readonly CategoriesRepository _categoriesRepository;
        private readonly MyNotebookContext _context;
        private readonly UserService _userService;
        //public SelectList MyCategoryNames { get; set; }

        public EditModel(NotesRepository repository, MyNotebookContext context, UserService userService, CategoriesRepository categoriesRepository)
        {
            _repository = repository;
            _context = context;
            _userService = userService;
            _categoriesRepository = categoriesRepository;
        }
        [BindProperty]
        public Note Note { get; set; }

        public IActionResult OnGet(int id)
        {
            var userId = _userService.GetUserId();
            Note = _repository.GetNote(id);
            var categories = _categoriesRepository.GetCategoriesByUserId(userId);
            CategoriesNames = new SelectList(categories);
            GenerateCategoriesDropDownList(userId,_context);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            /* if (!ModelState.IsValid)
             {
                 return Page();
             }   */
            if(Note.Title == null || Note.CategoryId == 0)
            {
                return Page();  
            }

            var noteFromDb = _repository.GetNote(Note.Id);

            noteFromDb.Title = Note.Title;
            //noteFromDb.Category = Note.Category; 
            noteFromDb.CategoryId = Note.CategoryId;
            noteFromDb.Content = Note.Content;
            _repository.UpdateNote(noteFromDb);
            return RedirectToPage("Index");

            /*var tryUpdate = await TryUpdateModelAsync<Book>
                (bookFromDb, "book",
                s => s.Id,
                s => s.AuthorId,
                s => s.Title,
                s => s.Content);*/


            /* if (tryUpdate)
             {
                 _booksRepository.UpdateBook(bookFromDb);
                 return RedirectToPage("Index");
             }
             GenerateAuthorsDropDownList(_context, bookFromDb.AuthorId);
             return Page();*/




            /*    bookFromDb.Title = Book.Title;
                bookFromDb.Content = Book.Content;
                _booksRepository.UpdateBook(bookFromDb);
                return RedirectToPage("Index");
            }
            return RedirectToPage();*/
        }
      
    }
}
