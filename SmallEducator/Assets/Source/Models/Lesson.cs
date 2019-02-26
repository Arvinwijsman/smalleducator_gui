using System;
using System.Collections.Generic;

namespace Source.Models
{
    [Serializable]
    public class Lesson
    {
        public int id;
        public string title;
        public string subtitle;
        public List<Slide> slides = new List<Slide>();

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