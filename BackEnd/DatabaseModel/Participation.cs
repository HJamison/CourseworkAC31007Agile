using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class Participation
    {
        public int? Participant { get; set; }
        public int Project { get; set; }

        public virtual Participants ParticipantNavigation { get; set; }
        public virtual ResearchProjects ProjectNavigation { get; set; }
    }
}
