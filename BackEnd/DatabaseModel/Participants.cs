using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class Participants
    {
        public Participants()
        {
            Answers = new HashSet<Answers>();
            FilledQuestionnaires = new HashSet<FilledQuestionnaires>();
            Participation = new HashSet<Participation>();
        }

        public int Id { get; set; }

        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<FilledQuestionnaires> FilledQuestionnaires { get; set; }
        public virtual ICollection<Participation> Participation { get; set; }
    }
}
