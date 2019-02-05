using System.Collections.Generic;

public class MultipleChoiceBehaviour : ILeafBehaviour
{
    private MultipleChoiceQuestionnaire multipleChoiceQuestionnaire;
    private List<string> anwsers;
    private string question;
    private bool singleAnswer;

    public MultipleChoiceBehaviour(MultipleChoiceQuestionnaire multipleChoiceQuestionnaire, List<string> anwsers, string question, bool singleAnswer)
    {
        this.multipleChoiceQuestionnaire = multipleChoiceQuestionnaire;
        this.anwsers = anwsers;
        this.question = question;
        this.singleAnswer = singleAnswer;
    }

    public void cleanUp()
    {
    }

    public void start()
    {
        ExtraTextSettings extraTextSettings = new ExtraTextSettings();
        extraTextSettings.HasBackGround = true;
        multipleChoiceQuestionnaire.gameObject.transform.position = new UnityEngine.Vector3(512.0f, 384.0f, 0.0f);
        multipleChoiceQuestionnaire.Start();
        multipleChoiceQuestionnaire.gameObject.SetActive(true);
        multipleChoiceQuestionnaire.initialized(singleAnswer, question, anwsers, extraTextSettings);
    }

    public bool update()
    {
        return false;
    }
}
