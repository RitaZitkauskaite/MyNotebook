using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyNotebook.Areas.Identity.Data;
using MyNotebook.Model;

namespace MyNotebook.Data;

public class MyNotebookContext : IdentityDbContext<MyNotebookUser>
{
    public MyNotebookContext(DbContextOptions<MyNotebookContext> options)
        : base(options)
    {
    }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
