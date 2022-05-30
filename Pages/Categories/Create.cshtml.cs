using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyNotebook.Data;
using MyNotebook.Model;
using MyNotebook.Pages.Notes;
using MyNotebook.Repositories;
using MyNotebook.Services;

namespace MyNotebook.Pages.Categories
{
    [Authorize]
    public class CreateModel : CategorySelectModel
    {
        private readonly CategoriesRepository _repository;
       
        private readonly UserService _userService;
        

        [BindProperty]
        public Category Category{ get; set; }

        public CreateModel(CategoriesRepository repository, UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var userId = _userService.GetUserId();
                _repository.CreateCategory(Category, userId);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
