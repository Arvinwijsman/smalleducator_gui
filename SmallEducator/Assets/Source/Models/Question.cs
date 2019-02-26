

using System.Collections.Generic;

namespace Source.Models
{
    public class Question
    {
        private int id;
        private string questionTitle;
        private List<string> answers = new List<string>();
        private bool singleAnswer;

        public Question()
        {
        }

        public Question(int id, string questionTitle, List<string> answers, bool singleAnswer)
        {
            this.id = id;
            this.questionTitle = questionTitle;
            this.answers = answers;
            this.singleAnswer = singleAnswer;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string QuestionTitle
        {
            get { return questionTitle; }
            set { questionTitle = value; }
        }

        public List<string> Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        public bool SingleAnswer
        {
            get { return singleAnswer; }
            set { singleAnswer = value; }
        }
    }
}