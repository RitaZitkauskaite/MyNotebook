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
    }
}
