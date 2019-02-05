using UnityEngine;
using UnityEngine.UI;

public class OnlineResourceBehaviour : ILeafBehaviour
{
    private string url;
    private Button extraResourceButton;
    private float timer;

    public OnlineResourceBehaviour(string url, Button extraResourceButton, float timer)
    {
        this.url = url;
        this.extraResourceButton = extraResourceButton;
        this.timer = timer;
    }

    public void cleanUp()
    {
        extraResourceButton.transform.position = new Vector2(10000000.0f, 10000000.0f);
    }

    public void start()
    {
        extraResourceButton.transform.position = new Vector2(950, 70.0f);
    }

    public bool update()
    {
        timer -= Time.fixedDeltaTime;       

        return timer > 0.0f;
    }

    public void doOnClick()
    {
        Application.OpenURL(url);
    }

}
