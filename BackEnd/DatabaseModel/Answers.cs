using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class Answers
    {
        public int Id { get; set; }
        public int? Question { get; set; }
        public int? Participant { get; set; }
        public string Answer { get; set; }
        public int? Questionnaire { get; set; }

        public virtual Participants ParticipantNavigation { get; set; }
        public virtual Questions QuestionNavigation { get; set; }
        public virtual Questionnaires QuestionnaireNavigation { get; set; }
    }
}
