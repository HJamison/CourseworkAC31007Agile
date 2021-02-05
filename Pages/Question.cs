using System.Collections.Generic;

namespace CourseworkAC31007Agile
{
    public class Question
    {
        public string questionText { get; set; }

        public List<Answers> questionAnswer { get; set; }

        public Question()
        {
            this.questionText = null;
            this.questionAnswer = new List<Answers>();
        }
        public Question(string qText)
        {
            this.questionText = qText;
            this.questionAnswer = new List<Answers>();
        }
       
    }
}
