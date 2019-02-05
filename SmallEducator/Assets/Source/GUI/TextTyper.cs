using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace GameLib.System.GUI
{
    public class TextTyper : MonoBehaviour
    {
        public enum TextTyperState
        {
            introductionText,
            fadeoutIntroductionText,
            fadeoutDoneIntroductionText,
            endSceneText
        };

        private List<TextInit> textSetting;

        public List<TextInit> TextSetting
        {
            get { return textSetting; }
            set { textSetting = value; }
        }

        private int textSettingIndex;

        public int TextSettingIndex
        {
            get { return textSettingIndex; }
            set { textSettingIndex = value; }
        }

        private TextInit currectTextSetting;

        public TextInit CurrectTextSetting
        {
            get { return currectTextSetting; }
            set { currectTextSetting = value; }
        }

        private TextMeshProUGUI textField;

        public TextMeshProUGUI TextField
        {
            get { return textField; }
            set { textField = value; }
        }

        private TextTyperState state;

        public TextTyperState State
        {
            get { return state; }
            set { state = value; }
        }

        // Use this for initialization
        private void Start()
        {
            init();
        }

        private void init()
        {
            resetTextField();
            ///////showNextText();
        }

        private void resetTextField()
        {
            Color color = textField.color;
            color.a = 1.0f;
            textField.color = color;
            textField.text = "";
        }

        public void showGameOver()
        {
            resetTextField();
            textSettingIndex = textSetting.Count - 1;
            state = TextTyperState.introductionText;
            currectTextSetting = textSetting[textSettingIndex];
            currectTextSetting.CurrectText = 0;
            textField.text = "";
            textSettingIndex++;
            StartCoroutine(TypeText(currectTextSetting.Text[currectTextSetting.CurrectText]));
        }

        public void showNextText()
        {
            resetTextField();

            state = TextTyperState.introductionText;
            currectTextSetting = textSetting[textSettingIndex];
            currectTextSetting.CurrectText = 0;
            textField.text = "";
            textSettingIndex++;
            StartCoroutine(TypeText(currectTextSetting.Text[currectTextSetting.CurrectText]));
        }

        public void fadeOutText()
        {
            state = TextTyperState.fadeoutIntroductionText;

            StartCoroutine(FadeText());
        }

        IEnumerator FadeText()
        {
            yield return new WaitForSeconds(1.0f);

            Color color = textField.color;
                
            for (color.a = 1.0f; color.a > 0.0f; color.a -= 0.04f)
            {
                textField.color = color;
                yield return 0;
                yield return new WaitForSeconds(currectTextSetting.LetterPause / 50.0f);
            }

            state = TextTyperState.fadeoutDoneIntroductionText;
        }

        IEnumerator TypeText(string message)
        {
            if (state == TextTyperState.introductionText)
            {
                foreach (char letter in message.ToCharArray())
                {
                    textField.text += letter;

                    if (state != TextTyperState.introductionText)
                    {
                        break;
                    }
                    yield return 0;
                    yield return new WaitForSeconds(currectTextSetting.LetterPause);
                }

                if (currectTextSetting.CurrectText < 2 && currectTextSetting.CurrectText < (currectTextSetting.Text.Count -1))
                {
                    textField.text += "\n";
                    currectTextSetting.CurrectText++;
                    StartCoroutine(TypeText(currectTextSetting.Text[currectTextSetting.CurrectText]));
                }
                else
                {
                    yield return new WaitForSeconds(10.0f);
                    fadeOutText();
                }
            }
        }

        public void showEndText(int textId)
        {
            textField.text = "";
            Color color = textField.color;
            color.a = 1.0f;
            textField.color = color;
            currectTextSetting.CurrectText = textId;
            StartCoroutine(TypeTextTwo(currectTextSetting.EndOfSceneText[currectTextSetting.CurrectText]));
        }

        IEnumerator TypeTextTwo(string message)
        {
            foreach (char letter in message.ToCharArray())
            {
                textField.text += letter;

                yield return 0;
                yield return new WaitForSeconds(currectTextSetting.LetterPause);
            }
        }
    }
}