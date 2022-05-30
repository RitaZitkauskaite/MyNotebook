using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyNotebook.Data;

namespace MyNotebook.Services
{
    public class CategoryListing : PageModel
    {
        private readonly UserService _userService;
        public SelectList CategoriesNames { get; set; }

        public void GenerateCategoriesDropDownList(MyNotebookContext context, object selectedCategory = null)
        {
             var userId = _userService.GetUserId();
            var categoriesQuery = context.Categories
                .Where(c => c.MyNotebookUserId == userId)
                .OrderBy(c => c.Title);
           

            CategoriesNames = new SelectList(categoriesQuery.AsNoTracking(), "Id", "Title", selectedCategory);

        }
    }
}

 
