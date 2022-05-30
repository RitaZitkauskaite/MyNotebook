using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyNotebook.Model;
using MyNotebook.Repositories;
using MyNotebook.Services;

namespace MyNotebook.Pages.Categories
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private readonly CategoriesRepository _repository;
        private readonly UserService _userService;

        public List<Category> Categories { get; set; } 
        public IndexModel(CategoriesRepository repository, UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        
        public void OnGet()
        {
            var userId = _userService.GetUserId();
            Categories = _repository.GetCategoriesByUserId(userId);
        }
        
        public IActionResult OnPostDelete(int id)
        {
            var category = _repository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(id);
            return RedirectToPage("Index");
        }

        /*public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Category.Title == null && Category.Id == 0)
            {
                return Page();
            }
            _repository.CreateCategory(Category);
            return RedirectToPage("Index");

        }*/
    }
}
