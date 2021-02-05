using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseworkAC31007Agile.BackEnd.DatabaseModel;
using CourseworkAC31007Agile.BackEnd;
using Microsoft.AspNetCore.Http;

namespace CourseworkAC31007Agile.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISession session;

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IHttpContextAccessor HttpContextAccessor)
        {
            this.session = HttpContextAccessor.HttpContext.Session;
        }

        public void OnGet()
        {

        }

        public UserPer userPersistance = new UserPer();



        public IActionResult OnPost()
        {
            var users = new List<Users>();
            var usernames = new List<string>();
            var passwords = new List<string>();
            var permissions = new List<string>();
            var names = new List<string>();
            using (var db = new DatabaseContext())
            {
                users = db.Users.ToList();

        
                 foreach (var user in users)
                {
                    usernames.Add(user.Username);
                    passwords.Add(user.Password);
                    permissions.Add(user.PermissionLevel);
                    names.Add(user.Name);
                }

            }
            this.Username = Username;
            this.Password = Password;
            if(usernames.Contains(Username))
            {
                int index = usernames.FindIndex(a => a.Contains(Username));
                if(Password == passwords[index])
                {
                    string permission = permissions[index];
                    string name = names[index];
                    this.session.SetString("Username", Username);
                    this.session.SetString("Password", Password);
                    this.session.SetString("Permission", permission);
                    this.session.SetString("Name", name);
                    switch (permission)
                    {
                        case "Principal Researcher":
                            return RedirectToPage("PrincipalResearcherAccount");
                        case "Co-Researcher":
                            return RedirectToPage("Co-researcher");
                        case "Lab Manager":
                            return RedirectToPage("LabManagerAccount");
                        default:
                            return RedirectToPage("index");
                    }
                }
            }
            return RedirectToPage("Index");
        }
    }
}
