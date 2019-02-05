using UnityEngine;

public class ImageFromResourcesBehaviour : ImageBehaviour
{
    public ImageFromResourcesBehaviour(SmallEducator smallEducator, string path, GameObject quad, Vector2 position, Texture2D tex, float timer) : base(smallEducator, path, quad, position, tex, timer)
    {
    }

    public override void start()
    {
        Tex = Resources.Load<Texture2D>(url);
        quad.GetComponent<Renderer>().material.mainTexture = Tex;
        quad.transform.position = position;
        quad.transform.localScale = new Vector2(9.0f, 9.0f);
    }
}
