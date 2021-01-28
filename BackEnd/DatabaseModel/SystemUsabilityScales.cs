using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class SystemUsabilityScales
    {
        public SystemUsabilityScales()
        {
            Questions = new HashSet<Questions>();
        }

        public int Id { get; set; }
        public int? Questionnaire { get; set; }

        public virtual Questionnaires QuestionnaireNavigation { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
