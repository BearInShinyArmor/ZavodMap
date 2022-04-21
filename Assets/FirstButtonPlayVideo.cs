using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FirstButtonPlayVideo : MonoBehaviour
{
    public List<VideoPlayer> otherPlayers;
    public int CurrentPlayerIndex;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayerIndex = 0;
    }

    // Update is called once per frame
    
    public void PlayClick()
    {
        CurrentPlayerIndex = 0;
        otherPlayers[CurrentPlayerIndex].GetComponentInParent<PlayVideo>().OnPlayVideo(true);
    }
    public void PlayNextVideo()
    {
        CurrentPlayerIndex++;
        if (CurrentPlayerIndex < otherPlayers.Count)
        {
            otherPlayers[CurrentPlayerIndex].GetComponentInParent<PlayVideo>().OnPlayVideo(true);
        }
        else
        {
            CurrentPlayerIndex = 0;
        }
    }
}
