using Microsoft.EntityFrameworkCore;
using MyNotebook.Data;
using MyNotebook.Model;
using MyNotebook.Services;

namespace MyNotebook.Repositories
{
    public class CategoriesRepository
    {
        private readonly MyNotebookContext _context;
        private readonly UserService _userService;

        public CategoriesRepository(MyNotebookContext context)
        {
            _context = context;
        }
       /* public List<Category> GetCategories()
        {
            return _context.Categories
                .Include(c => c.Notes)
                .ToList();
        }*/

        public List<Category> GetCategoriesByUserId(string id)
        {
            return _context.Categories.Include(c => c.Notes).Where(c => c.MyNotebookUserId == id).ToList();
        }


        public Category GetCategory(int id)
        {
            return _context.Categories.Include(c => c.Notes).FirstOrDefault(c => c.Id == id);
        }
        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Include(c => c.Notes).FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public void UpdateCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void CreateCategory(Category category, string id)
        {
            category.MyNotebookUserId = id;
            _context.Add(category);
            _context.SaveChanges();
        }
        
    }
}
