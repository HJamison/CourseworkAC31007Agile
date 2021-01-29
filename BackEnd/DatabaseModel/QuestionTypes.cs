using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class QuestionTypes
    {
        public QuestionTypes()
        {
            Questions = new HashSet<Questions>();
        }

        public string QuestionType { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
    }
}
