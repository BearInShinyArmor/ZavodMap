using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnimationEnd : MonoBehaviour
{
    public RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        GetComponent<UnityEngine.Video.VideoPlayer>().loopPointReached += EndReached;
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video Stop");
        vp.Stop();
        
        rawImage.gameObject.SetActive(false);
        vp.Prepare();
        vp.GetComponentInParent<PlayVideo>().SetNormalImage();
    }

}
