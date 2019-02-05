using UnityEngine;
using UnityEngine.UI;

//http://answers.unity3d.com/questions/654836/unity2d-sprite-fade-in-and-out.html

namespace LeafManupulator.Effect
{
    public class AlphaFade
    {
        public static int FADE_NONE = 0;
        public static int FADE_IN = 1;
        public static int FADE_OUT = 2;

        private float fade;

        public float Fade { get { return fade; } set { fade = value; } }

        private float fadeSpeed = 0.0f;

        public float FadeSpeed { get { return fadeSpeed; } set { fadeSpeed = value; } }

        private float fadeTime = 0.30f;

        public float FadeTime { get { return fadeTime; } set { fadeTime = value; } }

        private int fadeState = 0;

        public int FadeState { get { return fadeState; } set { fadeState = value; } }

        public AlphaFade()
        {
            fadeState = FADE_NONE;
        }

        public Color repeateFading(Color old)
        {
            Color currentColor = getFaded(old);

            fadeState = (currentColor.a <= 0.001f) ? fadeState = FADE_IN : 
                (currentColor.a >= 0.980f) ? fadeState = FADE_OUT : FADE_NONE;

            return currentColor;
        }

        public Color getFaded(Color old)
        {
            Color color = old;

            color.a =   (fadeState == FADE_IN) ? Mathf.SmoothDamp(color.a, 1.0f, ref fadeSpeed, fadeTime) : 
                        (fadeState == FADE_OUT) ? color.a = Mathf.SmoothDamp(color.a, 0.0f, ref fadeSpeed, fadeTime) : color.a;

            return color;
        }        
    }
}