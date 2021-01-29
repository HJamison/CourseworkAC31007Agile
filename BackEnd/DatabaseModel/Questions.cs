using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public int Questionnaire { get; set; }
        public string Choices { get; set; }
        public short OrderInQuestionnaire { get; set; }
        public byte? OrderInSus { get; set; }
        public int? SusId { get; set; }

        public virtual Questionnaires QuestionnaireNavigation { get; set; }
        public virtual QuestionTypes TypeNavigation { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
    }
}
