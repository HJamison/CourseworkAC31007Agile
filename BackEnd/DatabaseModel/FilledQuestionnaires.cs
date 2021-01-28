using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class FilledQuestionnaires
    {
        public int Questionnaire { get; set; }
        public int Participant { get; set; }

        public virtual Participants ParticipantNavigation { get; set; }
        public virtual Questionnaires QuestionnaireNavigation { get; set; }
    }
}
