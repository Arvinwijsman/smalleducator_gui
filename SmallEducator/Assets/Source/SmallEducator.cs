﻿using System;
using GameLib.System.GUI;
using System.Collections.Generic;
using JetBrains.Annotations;
using Source.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityScript.Macros;

public class SmallEducator : MonoBehaviour
{
    private Component head;
    private IEnumerator<Component> iterator;
    private float timer;
    private bool done;
    private List<Component> activeComponents = new List<Component>();
    private List<Component> removeComponents = new List<Component>();

    public TextMeshProUGUI textFieldOne;
    public TextMeshProUGUI textFieldTwo;
    public Image backgroundTextFieldOne;
    public Image backgroundTextFieldTwo;

    public TextInit textInit;

    public VideoPlayer videoPlayer;
    public GameObject quad;

    private MonoBehaviour currentQuestionnaire;
    private bool isQuestionnaireActive = false;

    private OnlineResourceBehaviour extraResource;
    public Button extraResourceButton;

    public MultipleChoiceQuestionnaire multipleChoiceQuestionnaire;

    private void Reset()
    {
        init();
    }

    private void Awake()
    {
        init();
    }

    // Use this for initialization
    private void Start()
    {
        init();
    }

    private void addLeafWithText(Component head, float minute, float second, ILeafBehaviour behaviour)
    {
        Component textLeaf = new SmallEducatorLeaf(1001, "TextLeaf", minute, second, this, behaviour);
        head.addComponent(textLeaf);
    }

    private TextTyper setTextTyper(TextMeshProUGUI textField)
    {
        var textTyper = textField.GetComponent<TextTyper>();
        textTyper.TextField = textField;
        textTyper.TextSetting = new List<TextInit>();
        textTyper.TextSetting.Add(textInit);
        return textTyper;
    }

    private void init()
    {
        GUI.backgroundColor = Color.blue;
        head = new SmallEducatorComposite(0, "Head", -1.0f);

        TextTyper textTyper = null;
        textFieldOne = GameObject.FindGameObjectWithTag("TextFieldOne").GetComponent<TextMeshProUGUI>();
        textFieldTwo = GameObject.FindGameObjectWithTag("TextFieldTwo").GetComponent<TextMeshProUGUI>();
        backgroundTextFieldOne = GameObject.FindGameObjectWithTag("BackgroundTextFieldOne").GetComponent<Image>();
        backgroundTextFieldTwo = GameObject.FindGameObjectWithTag("BackgroundTextFieldTwo").GetComponent<Image>();
        extraResourceButton = GameObject.FindGameObjectWithTag("ExtraResourceButton").GetComponent<Button>();
        textTyper = setTextTyper(textFieldOne);
        textTyper = setTextTyper(textFieldTwo);

        displayLesson(createWeek2());

        /*/Video
ILeafBehaviour textBehaviour = new VideoBehaviour(videoPlayer,
    "/Users/mjgth/Videos/Dm1hrYJX0AA8b5V.mp4"
    , false,
    //"https://video.twimg.com/tweet_video/DG8HO7UW0AAzsrL.mp4"
    //, true, 
    new Vector2(0, 0), 1024, 1024, quad);
//VideoBehaviour(, new Vector2(0, 0), 400.0f, 400.0f);
*/
        iterator = head.getIterator();
        timer = 0.0f;
        done = false;
    }

    private void displayLesson(Lesson lesson)
    {
        var positionOnTimeLineSecondsTextOne = 0.0f;
        var positionOnTimeLineSeconds = 0.0f;
        var timeOnScreen = 10.0f;

        var listOfLinesTwo = new List<string>();
        var listOfLinesOne = new List<string>();

        var extraTextSettingsTwo = new ExtraTextSettings();
        var extraTextSettingsOne = new ExtraTextSettings();

        //SET Title (part one)
        listOfLinesTwo.Clear();
        listOfLinesTwo.Add(lesson.Title);

        extraTextSettingsTwo.HasBackGround = true;
        extraTextSettingsTwo.fontSize = 40;

        //Static text
        ILeafBehaviour textBehaviour = new StaticTextBehaviour(listOfLinesTwo, textInit, textFieldTwo,
            backgroundTextFieldTwo, extraTextSettingsTwo,
            timeOnScreen, new Vector2(0, 0));
        addLeafWithText(head, Mathf.Floor(positionOnTimeLineSeconds / 60.0f), positionOnTimeLineSeconds % 60.0f,
            textBehaviour);

        //SET Sub title
        listOfLinesOne.Clear();
        listOfLinesOne.Add(lesson.Subtitle);
        extraTextSettingsOne.fontSize = 20;
        extraTextSettingsOne.HasBackGround = true;

        positionOnTimeLineSeconds = setStaticTextBehaviour(textFieldOne, backgroundTextFieldOne, listOfLinesOne,
            extraTextSettingsOne, timeOnScreen, positionOnTimeLineSeconds);

        Debug.Log("got " + lesson.Slides.Count + " amount of slides");

        foreach (var slide in lesson.Slides)
        {
            if (!slide.IsQuestion)
            {
                timeOnScreen = slide.Lines.Count > 4 ? 20.0f : 10.0f;
                extraTextSettingsOne.fontSize = 20;
                extraTextSettingsOne.HasBackGround = true;

                positionOnTimeLineSecondsTextOne = setStaticTextBehaviour(textFieldOne, backgroundTextFieldOne,
                    slide.Lines,
                    extraTextSettingsOne, timeOnScreen, positionOnTimeLineSecondsTextOne);
                Debug.Log("Got non question slide id: " + slide.Id + " with " + slide.Lines.Count + " amount of lines");
            }
            else
            {
                addMultipleChoiceQuestionnaire(slide.Question, positionOnTimeLineSeconds + 1.0f);
                Debug.Log("Got question slide id: " + slide.Id);
            }
        }
    }

    private Lesson createWeek2()
    {
        var lesson = new Lesson {Title = "Welcome to Architecture and Design", Subtitle = "Week 2 - Views"};
        lesson.Slides.Clear();
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
        slide = new Slide();
        slide.Id = ++id;
        slide.Lines.Add("The architecture documentation should communicate the followings:");
        slide.Lines.Add("\t1. A big problem divided into smaller manageables ones.");
        slide.Lines.Add("\t2. Who is working on what and how to work together.");
        slide.Lines.Add("\t3. Provides a vocabulary for talking about a complex ideas.");
        slide.Lines.Add("\t4. The drives of the project.");
        slide.Lines.Add("\t5. Helps with avoiding costly mistakes.");
        slide.Lines.Add("\t6. It enables agility.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("Diagrams with text helps to communicate the architecture.");
        slide.Lines.Add("There are different notations.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("Notations for architecture documentation");
        slide.Lines.Add("The notation for documenting an architecture can be Informal, Semiformal or Formal.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("The informal notation is often used during meetings");
        slide.Lines.Add("or a discussion between software developers.");
        slide.Lines.Add("The diagrams are drawn on a white board or paper.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("The informal notation is great for brainstorming");
        slide.Lines.Add("or for upfront design, but not for documenting an");
        slide.Lines.Add("architecture.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("Don't use the informal notation when documenting the");
        slide.Lines.Add("architecture for the lab assignment.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("The semi-formal notation is often used for design.");
        slide.Lines.Add("It is also used for discussion between software developers.");
        slide.Lines.Add("The diagrams are drawn using the UML notation.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("The semi-formal notation could be used for brainstorming");
        slide.Lines.Add("or for upfront design, but it is mostly used");
        slide.Lines.Add(" for documenting an architecture.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("Use the semi-formal notation when documenting the");
        slide.Lines.Add("architecture for the lab assignment.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("The formal notation is used for design, but these projects");
        slide.Lines.Add("are really large and takes years to development.");
        slide.Lines.Add("The formal notations are architecture description languages.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;
        
        slide.Lines.Add("The formal notation is used for upfront design");
        slide.Lines.Add("and it is used for documenting an architecture.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("Don't use the formal notation when documenting the");
        slide.Lines.Add("architecture for the lab assignment.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("Views");
        slide.Lines.Add("For step 6 we use views to describe the architecture.");
        slide.Lines.Add("First we will look a the views according to the book Software Architecture in Practice,");
        slide.Lines.Add("then view the views according to the book Applying UML and Patterns.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;
        
        slide.Lines.Add("Views");
        slide.Lines.Add("“Thus, views let us divide the multidimensional entity that is a software");
        slide.Lines.Add("architecture into a number of (we hope) interesting and manageable");
        slide.Lines.Add("representations of the system. The concept of views gives us our most");
        slide.Lines.Add("fundamental principle of architecture documentation:\n");
        slide.Lines.Add("Documenting an architecture is a matter of documenting the relevant");
        slide.Lines.Add("views and then adding documentation that applies to more than one view.”\n");
        slide.Lines.Add("- Software Architecture in Practice");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("”Module structures exist at design time.");
        slide.Lines.Add("Module structures live on the file system and stick around");
        slide.Lines.Add("even when the software is not running.”");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("Design time is when program is being modelled and”");
        slide.Lines.Add("it's code is being written.");

        lesson.Slides.Add(slide);
        slide = new Slide();
        slide.Id = ++id;

        slide.Lines.Add("”Component and connector, C&C, structures exist at runtime.");
        slide.Lines.Add("Component and connector structures don’t exist when the");
        slide.Lines.Add("software is not running.”");

        lesson.Slides.Add(slide);

        return lesson;
    }

    private void loadWeek2()
    {
        //SET informal notation (part 2.2.1)
//        Texture2D tex = new Texture2D(600, 374, TextureFormat.DXT1, false);
//        ILeafBehaviour imageBehaviour0001 =
//            new ImageFromResourcesBehaviour(this, "Textures/AaD/UML001", quad, new Vector2(0, 0), tex, 25.0f);
//        addLeafWithText(head, Mathf.Floor(positionOnTimeLineSecondsTextOne / 60.0f),
//            positionOnTimeLineSecondsTextOne % 60.0f, imageBehaviour0001);


        //SET semi-formal notation (part 2.3.1)
//        tex = new Texture2D(1015, 770, TextureFormat.DXT1, false);
//        ILeafBehaviour imageBehaviour0002 =
//            new ImageFromResourcesBehaviour(this, "Textures/AaD/UML002", quad, new Vector2(0, 0), tex, 28.0f);
//        addLeafWithText(head, Mathf.Floor(positionOnTimeLineSecondsTextOne / 60.0f),
//            positionOnTimeLineSecondsTextOne % 60.0f, imageBehaviour0002);
//
//        extraResource = new OnlineResourceBehaviour("https://www.uml-diagrams.org/index-examples.html",
//            extraResourceButton, 28.0f);
//        addLeafWithText(head, Mathf.Floor(positionOnTimeLineSecondsTextOne / 60.0f),
//            positionOnTimeLineSecondsTextOne % 60.0f, extraResource);


//        //SET semi-formal notation (part 2.4.1)
//        //SET informal notation (part 2.2.1)
//        timeOnScreen = 10.0f;
//        tex = new Texture2D(1015, 770, TextureFormat.DXT1, false);
//        ILeafBehaviour imageBehaviour0003 =
//            new ImageFromResourcesBehaviour(this, "Textures/AaD/SpecMS", quad, new Vector2(0, 0), tex, 25.0f);
//        addLeafWithText(head, Mathf.Floor(positionOnTimeLineSecondsTextOne / 60.0f),
//            positionOnTimeLineSecondsTextOne % 60.0f, imageBehaviour0003);


//        //Texture2D 
//
//        tex = new Texture2D(1079, 783, TextureFormat.DXT1, false);
//        ILeafBehaviour imageBehaviour0004 =
//            new ImageFromResourcesBehaviour(this, "Textures/AaD/Views001", quad, new Vector2(0, 0), tex, 25.0f);
//        addLeafWithText(head, Mathf.Floor(positionOnTimeLineSecondsTextOne / 60.0f),
//            positionOnTimeLineSecondsTextOne % 60.0f, imageBehaviour0004);
//
//        extraResource = new OnlineResourceBehaviour("https://www.uml-diagrams.org/", extraResourceButton, 30.0f);
//        addLeafWithText(head, Mathf.Floor(positionOnTimeLineSecondsTextOne / 60.0f),
//            positionOnTimeLineSecondsTextOne % 60.0f, extraResource);
    }

    private void addMultipleChoiceQuestionnaire([NotNull] Question question, float positionOnTimeLine)
    {
        if (question == null) throw new ArgumentNullException("question");
        addMultipleChoiceQuestionnaire(positionOnTimeLine + 1.0f, question.Answers, question.QuestionTitle,
            question.SingleAnswer);
    }

    private void addMultipleChoiceQuestionnaire(float positionOnTimeLine, List<string> anwsers, string question,
        bool singleAnswer)
    {
        ILeafBehaviour choiceResource =
            new MultipleChoiceBehaviour(multipleChoiceQuestionnaire, anwsers, question, singleAnswer);
        addLeafWithText(head, Mathf.Floor(positionOnTimeLine / 60.0f), positionOnTimeLine % 60.0f, choiceResource);
    }

    private float setStaticTextBehaviour(TextMeshProUGUI textField, Image backgroundTextField, List<string> listOfLines,
        ExtraTextSettings extraTextSettings, float timeOnScreen, float positionOnTimeLineSeconds, Vector2 position)
    {
        //Static text
        ILeafBehaviour textBehaviour = new StaticTextBehaviour(listOfLines, textInit, textField,
            backgroundTextField, extraTextSettings,
            timeOnScreen, position);
        addLeafWithText(head, Mathf.Floor(positionOnTimeLineSeconds / 60.0f), positionOnTimeLineSeconds % 60.0f,
            textBehaviour);
        positionOnTimeLineSeconds += timeOnScreen + 0.30f;

        return positionOnTimeLineSeconds;
    }

    private float setStaticTextBehaviour(TextMeshProUGUI textField, Image backgroundTextField, List<string> listOfLines,
        ExtraTextSettings extraTextSettings, float timeOnScreen, float positionOnTimeLineSeconds)
    {
        //Static text
        ILeafBehaviour textBehaviour = new StaticTextBehaviour(listOfLines, textInit, textField,
            backgroundTextField, extraTextSettings,
            timeOnScreen, new Vector2(0, -38));
        addLeafWithText(head, Mathf.Floor(positionOnTimeLineSeconds / 60.0f), positionOnTimeLineSeconds % 60.0f,
            textBehaviour);
        positionOnTimeLineSeconds += timeOnScreen + 0.30f;

        return positionOnTimeLineSeconds;
    }

    public void removeComponent(Component componentToRemove)
    {
        removeComponents.Add(componentToRemove);
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        cleanUpActiveComponents();

        if (!isQuestionnaireActive)
        {
            checkForNewActiveComponent();
            play();
        }
    }

    private void checkForNewActiveComponent()
    {
        //Debug.Log("Current.TimeStamp: " + iterator.Current.TimeStamp + " timer: " + timer);

        if (!done && iterator.Current.TimeStamp <= timer)
        {
            iterator.Current.start();
            activeComponents.Add(iterator.Current);
            done = !iterator.MoveNext();
        }
    }

    private void play()
    {
        foreach (Component component in activeComponents)
        {
            component.doAction();
        }

        timer += Time.fixedDeltaTime;
    }

    private void cleanUpActiveComponents()
    {
        if (removeComponents.Count > 0)
        {
            foreach (Component component in removeComponents)
            {
                activeComponents.Remove(component);
            }

            removeComponents.Clear();
        }
    }

    public void questionnaireStarted(MonoBehaviour questionnaire)
    {
        currentQuestionnaire = questionnaire;
        isQuestionnaireActive = true;
    }

    public void questionnaireFinished()
    {
        currentQuestionnaire = null;
        isQuestionnaireActive = false;
    }

    public void extraResourceOnClick()
    {
        if (extraResource != null)
        {
            extraResource.doOnClick();
        }
    }

    public void questionOnClick()
    {
        Debug.Log("Prompt the question box!!");
    }
}