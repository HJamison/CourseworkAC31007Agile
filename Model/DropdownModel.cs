using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bind_DropDownList_Core.Model
{
    //Adapted from https://www.aspsnippets.com/Articles/Populating-DropDownList-inside-Razor-Pages-in-ASPNet-Core-MVC.aspx
    public class DropdownModel
    {
        public int Id { get; set; }
        public string title { get; set; }
    }
}
