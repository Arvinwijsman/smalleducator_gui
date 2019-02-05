using LeafManupulator.Effect;
using TMPro;
using UnityEngine;

namespace LeafManupulator
{
    public class FadeIn : LeafManipulator
    {
        protected AlphaFade fader;
        protected float doneValue = 1.0f;
        
        public override void init()
        {
            color = Color.red;
            color.a = 0;
            fader = new AlphaFade();
            fader.FadeState = AlphaFade.FADE_IN;
        }

        public override void reset()
        {
            color = Color.red;
            color.a = 0;
        }

        public override bool update()
        {
            color = fader.getFaded(color);
            return color.a == doneValue;
        }
    }
}