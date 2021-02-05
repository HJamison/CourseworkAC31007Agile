using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseworkAC31007Agile.BackEnd.DatabaseModel;
using CourseworkAC31007Agile.BackEnd;
using Microsoft.AspNetCore.Http;

namespace CourseworkAC31007Agile.Pages
{
    public class RemoveAccountModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost(string data)
        {
            if(data == "cancel")
            {
                RedirectToPage("AccountManager");
            }
            else
            {
                using (var db = new DatabaseContext())
                {
                    string username = HttpContext.Session.GetString("targetUsername");
                    using var transaction = db.Database.BeginTransaction();
                    db.Users.Remove(db.Users.Find(username));
                    transaction.Commit();
                    db.SaveChanges();
                }
                RedirectToPage("AccountManager");
            }
        }
    }
}
