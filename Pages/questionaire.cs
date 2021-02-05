using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseworkAC31007Agile
{
    public class Questionaire
    {
        public string questionaireName { get; set; }
        public string id { get; set; }
        public List<Question> questions;
      
        public Questionaire()
        {
            this.questionaireName = null;
            this.id = null;
            this.questions = new List<Question>();
        }

        public Questionaire(string questionaireName ,string id, List<Question> questions)
        {
            this.questionaireName = questionaireName;
            this.id = id;
            this.questions = questions;
        }
    }
}
