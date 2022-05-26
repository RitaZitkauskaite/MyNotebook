using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyNotebook.Data;

namespace MyNotebook.Pages.Notebook
{
    public class CategorySelectModel : PageModel
    {
       /* public SelectList CategoriesNames { get; set; }

        public void GenerateCategoriesDropDownList(MyNotebookContext context, object selectedCategory = null)
        {
            var categoriesQuery = context.Categories.OrderBy(a => a.Title);
            CategoriesNames = new SelectList(categoriesQuery.AsNoTracking(), "Id", "Title", selectedCategory);

        }*/
    }
}
