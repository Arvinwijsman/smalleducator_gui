using System.Collections.Generic;
using System.IO;
using Source.Models;
using UnityEngine;
using UnityEngine.Networking;

namespace Source.API
{
    public static class ApiConsumer
    {
        public static Lesson getLesson(int id)
        {
            return JsonUtility.FromJson<Lesson>(getJson());
        }

        //TODO remove temp method until we can fetch from server
        private static string getJson()
        {
            const string file = "./test.json";
            if (File.Exists(file))
            {
                return loadFileAndRead(file);
            }
            else
            {
                System.IO.File.WriteAllText("./test.json", JsonUtility.ToJson(createWeek2()));
                return loadFileAndRead(file);
            }
        }

        //TODO remove temp method until we can fetch from server
        private static string loadFileAndRead(string filename)
        {
            return File.ReadAllText(filename);
        }

        //TODO remove temp method until we can fetch from server
        private static Lesson createWeek2()
        {
            var lesson = new Lesson {Title = "Welcome to Architecture and Design", Subtitle = "Week 2 - Views"};
            var id = 0;
            var slide = new Slide {Id = id, IsQuestion = true};
            var question = new Question();
            question.QuestionTitle =
                "Is dit een hele lange vraag om te beantwoorden zodat we de \ntextfield kunnen testen?\nYes it does!!";
            var answers = new List<string>
            {
                "Yes",
                "No"
            };

            question.Answers = answers;
            slide.Question = question;
            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};
            slide.Lines.Add("The architecture documentation should communicate the followings:");
            slide.Lines.Add("\t1. A big problem divided into smaller manageables ones.");
            slide.Lines.Add("\t2. Who is working on what and how to work together.");
            slide.Lines.Add("\t3. Provides a vocabulary for talking about a complex ideas.");
            slide.Lines.Add("\t4. The drives of the project.");
            slide.Lines.Add("\t5. Helps with avoiding costly mistakes.");
            slide.Lines.Add("\t6. It enables agility.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("Diagrams with text helps to communicate the architecture.");
            slide.Lines.Add("There are different notations.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("Notations for architecture documentation");
            slide.Lines.Add("The notation for documenting an architecture can be Informal, Semiformal or Formal.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("The informal notation is often used during meetings");
            slide.Lines.Add("or a discussion between software developers.");
            slide.Lines.Add("The diagrams are drawn on a white board or paper.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("The informal notation is great for brainstorming");
            slide.Lines.Add("or for upfront design, but not for documenting an");
            slide.Lines.Add("architecture.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("Don't use the informal notation when documenting the");
            slide.Lines.Add("architecture for the lab assignment.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("The semi-formal notation is often used for design.");
            slide.Lines.Add("It is also used for discussion between software developers.");
            slide.Lines.Add("The diagrams are drawn using the UML notation.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("The semi-formal notation could be used for brainstorming");
            slide.Lines.Add("or for upfront design, but it is mostly used");
            slide.Lines.Add(" for documenting an architecture.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("Use the semi-formal notation when documenting the");
            slide.Lines.Add("architecture for the lab assignment.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("The formal notation is used for design, but these projects");
            slide.Lines.Add("are really large and takes years to development.");
            slide.Lines.Add("The formal notations are architecture description languages.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("The formal notation is used for upfront design");
            slide.Lines.Add("and it is used for documenting an architecture.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("Don't use the formal notation when documenting the");
            slide.Lines.Add("architecture for the lab assignment.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("Views");
            slide.Lines.Add("For step 6 we use views to describe the architecture.");
            slide.Lines.Add("First we will look a the views according to the book Software Architecture in Practice,");
            slide.Lines.Add("then view the views according to the book Applying UML and Patterns.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("Views");
            slide.Lines.Add("“Thus, views let us divide the multidimensional entity that is a software");
            slide.Lines.Add("architecture into a number of (we hope) interesting and manageable");
            slide.Lines.Add("representations of the system. The concept of views gives us our most");
            slide.Lines.Add("fundamental principle of architecture documentation:\n");
            slide.Lines.Add("Documenting an architecture is a matter of documenting the relevant");
            slide.Lines.Add("views and then adding documentation that applies to more than one view.”\n");
            slide.Lines.Add("- Software Architecture in Practice");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("”Module structures exist at design time.");
            slide.Lines.Add("Module structures live on the file system and stick around");
            slide.Lines.Add("even when the software is not running.”");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("Design time is when program is being modelled and”");
            slide.Lines.Add("it's code is being written.");

            lesson.Slides.Add(slide);
            slide = new Slide {Id = ++id};

            slide.Lines.Add("”Component and connector, C&C, structures exist at runtime.");
            slide.Lines.Add("Component and connector structures don’t exist when the");
            slide.Lines.Add("software is not running.”");

            lesson.Slides.Add(slide);

            return lesson;
        }
    }
}