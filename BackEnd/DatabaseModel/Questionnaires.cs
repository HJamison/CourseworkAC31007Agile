using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class Questionnaires
    {
        public Questionnaires()
        {
            Answers = new HashSet<Answers>();
            FilledQuestionnaires = new HashSet<FilledQuestionnaires>();
            Questions = new HashSet<Questions>();
            SystemUsabilityScales = new HashSet<SystemUsabilityScales>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Research { get; set; }
        public string Invitation { get; set; }

        public virtual ResearchProjects ResearchNavigation { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<FilledQuestionnaires> FilledQuestionnaires { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<SystemUsabilityScales> SystemUsabilityScales { get; set; }
    }
}
