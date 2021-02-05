using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseworkAC31007Agile.BackEnd.DatabaseModel;
using CourseworkAC31007Agile.BackEnd;

namespace CourseworkAC31007Agile.Pages
{
    public class AccountEditModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Position { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string PasswordConfirm { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var validPermissions = new List<string> { "Lab Manager", "Principal Researcher", "Co-Researcher" };
            this.Username = HttpContext.Session.GetString("targetUsername");
            if (this.Username == null || this.Name == null || this.Password == null){
                return RedirectToPage("AccountEdit");
            }
            if (validPermissions.Contains(this.Position) && this.Password == this.PasswordConfirm)
            {
                using(var db = new DatabaseContext())
                {
                    using var transaction = db.Database.BeginTransaction();
                    db.Users.Find(this.Username).Name = this.Name;
                    db.Users.Find(this.Username).Password = this.Password;
                    db.Users.Find(this.Username).PermissionLevel = this.Position;
                    transaction.Commit();
                    db.SaveChanges();
                    return RedirectToPage("AccountManager");
                }
            }
            return RedirectToPage("AccountEdit");
        }
    }
}
