using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class ResearchProjects
    {
        public ResearchProjects()
        {
            Questionnaires = new HashSet<Questionnaires>();
            ResearchOwners = new HashSet<ResearchOwners>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }

        public virtual Participation Participation { get; set; }
        public virtual ICollection<Questionnaires> Questionnaires { get; set; }
        public virtual ICollection<ResearchOwners> ResearchOwners { get; set; }
    }
}
