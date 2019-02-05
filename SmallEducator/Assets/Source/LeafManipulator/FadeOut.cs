using LeafManupulator.Effect;

namespace LeafManupulator
{
    public class FadeOut : FadeIn
    {
        public override void init()
        {
            base.init();
            color.a = 1;
            fader.FadeState = AlphaFade.FADE_OUT;
            doneValue = 0.0f;
        }

        public override void reset()
        {
            base.reset();
            color.a = 1;
        }
    }
}