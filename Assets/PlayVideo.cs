using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public List<VideoPlayer> otherPlayers;
    public Sprite NormalImage;
    public Sprite HighlitedImage;
    public bool startNext = false;
    public GameObject NextVideoController;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        //videoPlayer.url = "Assets/Video/00_.webm";
        //rawImage.texture = videoPlayer.texture;
        // videoPlayer.Play();
        videoPlayer.Prepare();
    }

    public void SetNormalImage()
    {
        gameObject.GetComponent<Image>().sprite = NormalImage;
    }

    public void SetHighlitedImage()
    {
        gameObject.GetComponent<Image>().sprite = HighlitedImage;
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying && Input.GetKey(KeyCode.Escape))
        {
            videoPlayer.Stop();
            rawImage.gameObject.SetActive(false);
            videoPlayer.Prepare();
            SetNormalImage();
        }
    }
    public void OnPlayVideo(bool playNext)
    {
        startNext = playNext;
        Debug.Log(gameObject.name + " Onclick ");
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            rawImage.gameObject.SetActive(false);
            videoPlayer.Prepare();
            SetNormalImage();
        }
        else
        {
            foreach (var player in otherPlayers)
            {
                if (player.isPlaying)
                {
                    player.Stop();
                    player.Prepare();
                    player.GetComponentInParent<PlayVideo>().SetNormalImage();
                }
            }
            rawImage.gameObject.SetActive(true);
           // videoPlayer.time = 90;
            videoPlayer.Play();
            SetHighlitedImage();
        }
    }
    void Awake()
    {
        videoPlayer.loopPointReached += EndReached;
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video Stop");
        vp.Stop();
        rawImage.gameObject.SetActive(false);
        vp.Prepare();
        vp.GetComponentInParent<PlayVideo>().SetNormalImage();
        if (startNext)
        {
            startNext = false;
            NextVideoController.GetComponent<FirstButtonPlayVideo>().PlayNextVideo();
        }
    }
}
