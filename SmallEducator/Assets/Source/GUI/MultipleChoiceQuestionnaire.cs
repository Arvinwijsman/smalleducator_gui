using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultipleChoiceQuestionnaire : MonoBehaviour
{
    public SmallEducator smallEducator;
    public ToggleGroup toggleGroup;
    //public Text questionField;
    public TextMeshProUGUI questionField;
    public Button submitButton;
    public Image backgroundMultipleChoiceQuestion;
    private ExtraTextSettings extraTextSettings;
    private float currentPosition = 0.0f;
    public float heightBackground = 0.0f;
    public float preferredWidthBackground = 0.0f;
    public float posYBackground = 0.0f;

    private void setItems(bool singleAnswer, string question, List<string> anwsers)
    {
        setQuestion(question);
        setAnwsers(singleAnswer, anwsers);
    }

    private void setQuestion(string question)
    {
        questionField.text = question;
        heightBackground = questionField.preferredHeight;
        preferredWidthBackground = questionField.preferredWidth;
        posYBackground = 20.0f;
    }

    private void setAnwsers(bool singleAnswer, List<string> anwsers)
    {
        addToggles(singleAnswer, anwsers);
        setTogglePositions();
    }

    private void setTogglePositions()
    {
        Toggle[] toggles = gameObject.GetComponentsInChildren<Toggle>();
        if(toggles.Length > 0)
        {
            posYBackground -= 20.0f;
            heightBackground += 20;
        }
        foreach (Toggle toggle in toggles)
        {
            currentPosition += setToggeLocalPosition(toggle, currentPosition);
        }

        setButtonPosition(currentPosition);
    }

    private void setButtonPosition(float currentPosition)
    {
        submitButton.transform.localPosition = new Vector2(0.0f, currentPosition - 15.0f);

        submitButton.onClick.AddListener(delegate {
            submitAnswer();
        });
    }

    private float setToggeLocalPosition(Toggle toggle, float currentPosition)
    {
        toggle.transform.localPosition = new Vector2(0.0f, currentPosition);
        Text text = toggle.GetComponentInChildren<Text>();
        heightBackground += text.preferredHeight;// - (text.preferredHeight % 15.0f);
        posYBackground -= text.preferredHeight;// - (text.preferredHeight % 15.0f);
        Debug.Log("text.preferredHeight " + text.preferredHeight);
        return -text.preferredHeight;
    }

    private void addToggles(bool singleAnswer, List<string> anwsers)
    {
        if (singleAnswer)
        {
            toggleGroup.allowSwitchOff = true;
        }

        foreach (string answer in anwsers)
        {
            addToggle(singleAnswer, answer);
        }
    }
    
    private void addToggle(bool singleAnswer, string answer)
    {
        Toggle t = Instantiate(Resources.Load<Toggle>("Toggle"));

        if (singleAnswer)
        {
            toggleGroup.RegisterToggle(t);
            t.group = toggleGroup;
        }

        t.GetComponentInChildren<Text>().text = answer;
        t.transform.SetParent(gameObject.transform);
        t.interactable = true;
        t.isOn = false;
        preferredWidthBackground = (preferredWidthBackground < 22.0f + t.GetComponentInChildren<Text>().preferredWidth) ?
            22.0f + t.GetComponentInChildren<Text>().preferredWidth : preferredWidthBackground;
    }

    private void removeAnswers()
    {
        Toggle[] toggles = gameObject.GetComponentsInChildren<Toggle>();

        foreach (Toggle toggle in toggles)
        {
            removeAnswer(toggle);
        }

        preferredWidthBackground = 0.0f;
        currentPosition = 0.0f;
        heightBackground = 0.0f;
        posYBackground = 0.0f;
    }

    private void removeAnswer(Toggle toggle)
    {
        toggleGroup.UnregisterToggle(toggle);
        toggle.group = null;
        toggle.transform.SetParent(null, false);
        Destroy(toggle.gameObject);
    }

    public void initialized(bool singleAnswer, string question, List<string> anwsers, ExtraTextSettings extraTextSettings)
    {
        removeAnswers();
        setItems(singleAnswer, question, anwsers);
        this.extraTextSettings = extraTextSettings;
        setBackGround();
    }

    private void setBackGround()
    {
        if (extraTextSettings.HasBackGround)
        {
           backgroundMultipleChoiceQuestion.rectTransform.sizeDelta = new Vector2(preferredWidthBackground + 6,
                heightBackground);
            Debug.Log("heightBackground " + heightBackground);
           backgroundMultipleChoiceQuestion.transform.localPosition = new Vector2(
               questionField.transform.localPosition.x, posYBackground);
        }
    }

    private void submitAnswer()
    {
        Toggle[] toggles = gameObject.GetComponentsInChildren<Toggle>();
        foreach (Toggle t in toggles)
        {
            if (t.isOn)
            {
                Debug.Log(t.GetComponentInChildren<Text>().text);
            }
        }
        smallEducator.questionnaireFinished();
        gameObject.SetActive(false);
    }

    // Use this for initialization
    public void Start()
    {
     //   backgroundMultipleChoiceQuestion = GameObject.FindGameObjectWithTag("BackgroundMultipleChoiceQuestion").GetComponent<Image>();
        smallEducator.questionnaireStarted(this);
    }
}
