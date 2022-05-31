using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyNotebook.Data;
using MyNotebook.Services;

namespace MyNotebook.Pages.Notes
{
    public class CategorySelectModel : PageModel
    {
        public SelectList CategoriesNames { get; set; }

        public void GenerateCategoriesDropDownList(string id, MyNotebookContext context, object selectedCategory = null)
        {
            var categoriesQuery = context.Categories

                .Where(c => c.MyNotebookUserId == id)
                .OrderBy(c => c.Title);


            CategoriesNames = new SelectList(categoriesQuery.AsNoTracking(), "Id", "Title", selectedCategory);

        }
    }
}
