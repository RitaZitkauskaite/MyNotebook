using Microsoft.EntityFrameworkCore;
using MyNotebook.Data;
using MyNotebook.Model;

namespace MyNotebook.Repositories
{
    public class CategoriesRepository
    {
        private readonly MyNotebookContext _context;

        public CategoriesRepository(MyNotebookContext context)
        {
            _context = context;
        }
        public List<Category> GetCategories()
        {
            return _context.Categories
                .Include(c => c.Notes)
                .ToList();
        }

        public List<Category> GetCategoriesByUserId(string id)
        {
            return _context.Categories.Where(c => c.MyNotebookUserId == id).ToList();
        }

    }
}
