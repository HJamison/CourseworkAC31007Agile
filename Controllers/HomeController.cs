using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Bind_DropDownList_Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseworkAC31007Agile.Controllers
{
    //Adapted from https://www.aspsnippets.com/Articles/Populating-DropDownList-inside-Razor-Pages-in-ASPNet-Core-MVC.aspx
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<DropdownModel> dropdownTable = PopulateDropdown();
            return View(new SelectList(dropdownTable, "Id", "title"));
        }

        [HttpPost]
        public IActionResult Index(string Id, string title)
        {
            ViewBag.Message = "title: " + title;
            ViewBag.Message += "\\nId: " + Id;
            return View();
        }

        private static List<DropdownModel> PopulateDropdown()
        {
            string constr = @"Data Source=agile-coursework-server.database.windows.net;Initial Catalog=StorageForTheB;integrated security=true";
            List<DropdownModel> dropdownTable = new List<DropdownModel>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT title, Id FROM Questionnaires";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            dropdownTable.Add(new DropdownModel
                            {
                                title = sdr["title"].ToString(),
                                Id = Convert.ToInt32(sdr["Id"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return dropdownTable;
        }
    }
}
