using UnityEngine;
using System;
using System.Collections.Generic;

namespace GameLib.System.GUI
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameLib/TextInit", order = 2)]
    [Serializable]
    public class TextInit : ScriptableObject
    {
        protected float letterPause;

        public float LetterPause
        {
            get { return letterPause; }
            set { letterPause = value; }
        }

        protected int currectText;

        public int CurrectText
        {
            get { return currectText; }
            set { currectText = value; }
        }

        protected List<String> text;

        public List<String> Text
        {
            get { return text; }
            set { text = value; }
        }

        protected List<String> endOfSceneText;

        public List<String> EndOfSceneText
        {
            get { return endOfSceneText; }
            set { endOfSceneText = value; }
        }

        protected float minWidth = 390;

        public float MinWidth
        {
            get { return minWidth; }
            set { minWidth = value; }
        }

        protected float minHeight = 90;

        public float MinHeight
        {
            get { return minHeight; }
            set { minHeight = value; }
        }
    }
}

