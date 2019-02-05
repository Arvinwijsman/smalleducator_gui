using GameLib.System.GUI;
using System.Collections.Generic;
using UnityEngine;

public class TextBehaviour : ILeafBehaviour
{
    private TextTyper textTyper;
    private Vector2 position;
    private List<string> linesOfText;

    public TextBehaviour(TextTyper textTyper, List<string> linesOfText,
        Vector2 position)
    {
        this.textTyper = textTyper;
        this.position = position;
        this.linesOfText = linesOfText;
    }

    public void cleanUp()
    {
        textTyper.TextField.text = "";
        textTyper.TextField.transform.position = new Vector2(10000000.0f, 10000000.0f);
    }

    public void start()
    {
        textTyper.TextSetting[0].Text = linesOfText;
        textTyper.TextField.rectTransform.localPosition = position;
        textTyper.TextSettingIndex = 0;
        textTyper.showNextText();
    }

    public bool update()
    {
        return (textTyper.State != TextTyper.TextTyperState.fadeoutDoneIntroductionText);
    }
}
