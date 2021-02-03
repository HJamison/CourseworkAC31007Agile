using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseworkAC31007Agile.BackEnd.DatabaseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
namespace CourseworkAC31007Agile.Pages
{
    public class AccountManagerModel : PageModel
    {
        public void OnGet()
        {
            var users = new List<Users>();
            var usernames = new List<string>();
            var permissions = new List<string>();
            var names = new List<string>();
            using (var db = new DatabaseContext())
            {
                users = db.Users.ToList();
                foreach (var user in users)
                {
                    usernames.Add(user.Username);
                    permissions.Add(user.PermissionLevel);
                    names.Add(user.Name);
                }
            }
        }
    }
}
