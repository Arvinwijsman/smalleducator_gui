using System.Collections.Generic;

namespace Source.Models
{
    public class Lesson
    {
        private int id;
        private string title;
        private string subtitle;
        private List<Slide> slides = new List<Slide>();

        public Lesson()
        {
        }

        public Lesson(int id, string title, string subtitle, List<Slide> slides)
        {
            this.id = id;
            this.title = title;
            this.subtitle = subtitle;
            this.slides = slides;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Subtitle
        {
            get { return subtitle; }
            set { subtitle = value; }
        }

        public List<Slide> Slides
        {
            get { return slides; }
            set { slides = value; }
        }
    }
}