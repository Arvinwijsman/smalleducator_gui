
using System.Collections.Generic;

namespace Source.Models
{
    public class Slide
    {
        private int id;
        private List<string> lines = new List<string>();
        private bool isQuestion;
        private Question question;

        public Slide()
        {
        }

        public Slide(int id, List<string> lines, bool isQuestion, Question question)
        {
            this.id = id;
            this.lines = lines;
            this.isQuestion = isQuestion;
            this.question = question;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<string> Lines
        {
            get { return lines; }
            set { lines = value; }
        }

        public bool IsQuestion
        {
            get { return isQuestion; }
            set { isQuestion = value; }
        }

        public Question Question
        {
            get { return question; }
            set { question = value; }
        }
    }
}