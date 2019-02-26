

using System;
using System.Collections.Generic;

namespace Source.Models
{
    [Serializable]
    public class Question
    {
        public int id;
        public string questionTitle;
        public List<string> answers = new List<string>();
        public bool singleAnswer;

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