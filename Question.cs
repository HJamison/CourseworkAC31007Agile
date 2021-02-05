using System.Collections.Generic;

namespace CreateQuestionaireAppBlazor
{
    public class Question
    {
        public string question { get; set; }
        public List<string> answers { get; set; }

        public Question(string question, List<string> answers)
        {
            this.question = question;
            this.answers = answers;
        }
        public Question()
        {
            this.question = null;
            this.answers = null;
        }
        public void addAnswerToList(string value)
        {
            this.answers.Add(value);

        }

    }
}
