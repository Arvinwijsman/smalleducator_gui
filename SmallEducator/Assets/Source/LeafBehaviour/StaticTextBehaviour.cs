using GameLib.System.GUI;
using LeafManupulator;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaticTextBehaviour : LeafBehaviour
{
    private List<string> linesOfText;

    private TextInit textSetting;

    private TextMeshProUGUI textField;

    private Image textfieldBackGround;

    private ExtraTextSettings extraTextSettings;

    private Vector2 position;

    private float timer;

    public StaticTextBehaviour(List<string> linesOfText, TextInit textSetting,
        TextMeshProUGUI textField, Image textfieldBackGround,
        float timer, Vector2 position) : this(linesOfText, textSetting,
            textField, textfieldBackGround, new ExtraTextSettings(),
        timer, position)
    {

    }

    public StaticTextBehaviour(List<string> linesOfText, TextInit textSetting,
        TextMeshProUGUI textField, Image textfieldBackGround, ExtraTextSettings extraTextSettings,
    float timer, Vector2 position)
    {
        this.linesOfText = new List<string>(linesOfText);
        this.textSetting = textSetting;
        this.textField = textField;
        this.textfieldBackGround = textfieldBackGround;
        this.position = position;
        this.timer = timer;
        this.extraTextSettings = extraTextSettings;

        leafManipulators = new List<LeafManipulator>();
        leafManipulators.Add(new FadeIn());
        leafManipulators.Add(new FadeOut());
        leafManipulators.Add(new FlyIn(
            //new Vector2(position.x - 1000.0f, position.y),
            position, 
            1.0f));
        leafManipulators.Add(new FlyOut(
            position,
            //new Vector2(position.x - 1000.0f, position.y),
            1.0f));
        foreach (LeafManipulator manipulator in leafManipulators)
        {
            manipulator.init();
        }
        manipulatorsDone = false;
    }

    public override void start()
    {
        textField.text = "";
        textField.fontSize = extraTextSettings.fontSize;
        textField.rectTransform.localPosition = position;
        foreach (string t in linesOfText)
        {
            textField.text += t;
            textField.text += "\n";
        }
        if (extraTextSettings.HasBackGround)
        {
            textfieldBackGround.transform.localPosition = textField.transform.localPosition;
            textfieldBackGround.rectTransform.sizeDelta = new Vector2(textField.preferredWidth + 6, textField.preferredHeight + 6);
        }
        
        Color color = textField.color;
        color.a = 1.0f;
        textField.color = color;

        color = textfieldBackGround.color;
        color.a = 1.0f;
        textfieldBackGround.color = color;
    }

    public override bool update()
    {
        timer -= Time.fixedDeltaTime;
        if(!manipulatorsDone && timer > 1.0f)
        {
            //fade in = 0
            //fly in - 2
            manipulatorsDone = (leafManipulators[FADE_IN].update() /*& leafManipulators[FLY_IN].update()*/);
            
            leafManipulators[FADE_IN].manipulate(textField);
            leafManipulators[FADE_IN].manipulate(textfieldBackGround);
            /*
            leafManipulators[FLY_IN].manipulate(textField);
            leafManipulators[FLY_IN].manipulate(textfieldBackGround);
            */
        }
        if (!manipulatorsDone && timer <= 0.31f)
        {
            //fade out
            manipulatorsDone = leafManipulators[FADE_OUT].update();
            leafManipulators[FADE_OUT].manipulate(textField);
            leafManipulators[FADE_OUT].manipulate(textfieldBackGround);
            
            /*/fly out
            manipulatorsDone = leafManipulators[FLY_OUT].update();
            leafManipulators[FLY_OUT].manipulate(textField);
            leafManipulators[FLY_OUT].manipulate(textfieldBackGround);
            */
        }
        if (timer > 0.31f && timer < 0.33f)
        {
            manipulatorsDone = false;
        }
        return timer > 0.0f;
    }

    public override void cleanUp()
    {
        textField.text = "";
        textField.transform.position = new Vector2(10000000.0f, 10000000.0f);
        textfieldBackGround.transform.position = new Vector2(10000000.0f, 10000000.0f);
    }
}
