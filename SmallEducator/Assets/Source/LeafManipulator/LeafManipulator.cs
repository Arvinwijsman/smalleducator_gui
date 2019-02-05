using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeafManupulator
{
    public abstract class LeafManipulator
    {
        protected Color color;

        public abstract void init();
        public abstract bool update();
        public abstract void reset();

        public virtual void manipulate(Image image)
        {
            color.r = image.color.r;
            color.g = image.color.g;
            color.b = image.color.b;
            image.color = color;
        }

        public virtual void manipulate(TextMeshProUGUI textField)
        {
            color.r = textField.color.r;
            color.g = textField.color.g;
            color.b = textField.color.b;
            textField.color = color;
        }
    }
}