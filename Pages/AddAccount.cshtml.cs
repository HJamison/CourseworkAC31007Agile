using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseworkAC31007Agile.BackEnd.DatabaseModel;
using CourseworkAC31007Agile.BackEnd;

namespace CourseworkAC31007Agile.Pages
{
    public class AddAccountModel : PageModel
    {

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Position { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            using (var db = new DatabaseContext())
            {
                //Get a list of usernames to check for duplicates before adding to DB
                var userList = db.Users.ToList();
                var usernameList = new List<string>();
                var validPermissions = new List<string> {"Lab Manager","Principal Researcher","Co-Researcher" };
                foreach (var userRecord in userList)
                {
                    usernameList.Add(userRecord.Username);
                }
                if (usernameList.Contains(this.Username))
                {
                    return RedirectToPage("AddAccount");
                }
                if (!validPermissions.Contains(this.Position))
                {
                    return RedirectToPage("AddAccount");
                }
                using var transaction = db.Database.BeginTransaction();
                Users user = new Users();
                user.Username = this.Username;
                user.Password = this.Password;
                user.Name = this.Name;
                user.PermissionLevel = this.Position;
                db.Users.Add(user);
                transaction.Commit();
                db.SaveChanges();
                return RedirectToPage("AccountManager");
            }
        }
    }
}
