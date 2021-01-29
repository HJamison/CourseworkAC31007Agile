using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class ResearchOwners
    {
        public short Id { get; set; }
        public int? ResearchProject { get; set; }
        public string Researcher { get; set; }

        public virtual ResearchProjects ResearchProjectNavigation { get; set; }
        public virtual Users ResearcherNavigation { get; set; }
    }
}
