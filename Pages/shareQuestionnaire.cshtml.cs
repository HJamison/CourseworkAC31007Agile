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
    public class shareQuestionnaireModel : PageModel
    {
        public void OnGet()
        {
            var questionnaireList = new List<Questionnaires>();
            var questionnaireTitle = new List<string>();
            var questionnaireID = new List<int>();
            using (var db = new DatabaseContext())
            {
                questionnaireList = db.Questionnaires.ToList();
                foreach (var user in questionnaireList)
                {
                    questionnaireTitle.Add(user.Title);
                    questionnaireID.Add(user.Id);
                }
            }
        }
    }
}
