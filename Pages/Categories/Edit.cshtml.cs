using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyNotebook.Model;
using MyNotebook.Repositories;

namespace MyNotebook.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly CategoriesRepository _repository;

        public EditModel(CategoriesRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _repository.GetCategory(id);
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var categoryFromDb = _repository.GetCategory(Category.Id);
                categoryFromDb.Title = Category.Title;
                categoryFromDb.Description = Category.Description;
                _repository.UpdateCategory(categoryFromDb);
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
