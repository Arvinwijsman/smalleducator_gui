using UnityEngine;
using System.Collections;

public class ImageBehaviour : ILeafBehaviour
{
    private SmallEducator smallEducator;
    protected string url = "https://www.uml-diagrams.org/class-diagrams/class-diagram-domain-overview.png";
    protected GameObject quad;
    protected Vector2 position;
    private Texture2D tex;
    public Texture2D Tex
    {
        get
        {
            return tex;
        }

        set
        {
            tex = value;
        }
    }

    private float timer;

    public ImageBehaviour(SmallEducator smallEducator, string url, GameObject quad, 
        Vector2 position, Texture2D tex, float timer)
    {
        this.smallEducator = smallEducator;
        this.url = url;
        this.quad = quad;
        this.position = position;
        this.Tex = tex;
        this.timer = timer;
    }

    public void cleanUp()
    {
        quad.transform.localScale = new Vector2(1.0f, 1.0f);
        quad.transform.position = new Vector2(1000.0f, 0.0f);
    }

    public virtual void start()
    {
       smallEducator.StartCoroutine(StartLoading(Tex));
    }

    public bool update()
    {
        timer -= Time.fixedDeltaTime;
        return (timer > 0.0f);
    }

    IEnumerator StartLoading(Texture2D text)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            www.LoadImageIntoTexture(Tex);
            quad.GetComponent<Renderer>().material.mainTexture = Tex;
            quad.transform.position = position;
            quad.transform.localScale = new Vector2(9.0f, 9.0f);
        }
    }
}
