using UnityEngine;
using UnityEngine.Video;

public class VideoBehaviour : ILeafBehaviour
{
    private GameObject quad;
    private VideoPlayer videoPlayer;
    private string videoFile;
    private bool isOnlineVideo;
    private Vector2 position;
    private int width;
    private int height;
    private float timer;

    public VideoBehaviour(VideoPlayer videoPlayer, string videoFile, bool isOnlineVideo, Vector2 position, 
        int width, int height, GameObject quad)
    {
        this.videoPlayer = videoPlayer;
        this.videoFile = videoFile;
        this.isOnlineVideo = isOnlineVideo;
        this.position = position;
        this.height = height;
        this.width = width;
        this.quad = quad;
        timer = 0.5f;
    }

    public void start()
    {
        Renderer rend = quad.GetComponent<Renderer>();
        if (rend != null)
        {
            var texture = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32);
            
            rend.material.mainTexture = texture;
            videoPlayer.targetTexture = texture;
        }
        
        quad.transform.position = new Vector3(position.x, position.y, 0.0f);

        videoPlayer.url = videoFile;
        videoPlayer.Play();
    }

    public void cleanUp()
    {
        quad.transform.position = new Vector3(1000.0f, 0.0f, 0.0f);
    }

    public bool update()
    {
        bool videoPlaying = (timer > 5.0f) ? videoPlayer.isPlaying : true;
        timer += Time.fixedDeltaTime;
        return videoPlaying;
    }
}
