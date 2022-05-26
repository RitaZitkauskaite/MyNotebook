using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyNotebook.Model;

namespace MyNotebook.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MyNotebookUser class
public class MyNotebookUser : IdentityUser
{
    public List<Note> Notes { get; set; } = new List<Note>();
    public List<Category> Categories { get; set; }  = new List<Category>();
}

