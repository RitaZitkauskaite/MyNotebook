using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyNotebook.Areas.Identity.Data;
using MyNotebook.Data;
using MyNotebook.Repositories;
using MyNotebook.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyNotebookContextConnection") ?? throw new InvalidOperationException("Connection string 'MyNotebookContextConnection' not found.");

builder.Services.AddDbContext<MyNotebookContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<MyNotebookUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MyNotebookContext>();;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<NotesRepository>();
builder.Services.AddTransient<CategoriesRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
