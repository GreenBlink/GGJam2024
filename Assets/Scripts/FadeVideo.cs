using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class FadeVideo : MonoBehaviour
{

    public float fadeSpeed = 1f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        Debug.Log(videoPlayer.targetCameraAlpha);
        while (videoPlayer.targetCameraAlpha <= 1)
        {
            videoPlayer.targetCameraAlpha -= fadeSpeed * Time.deltaTime;
            Debug.Log(videoPlayer.targetCameraAlpha);
            yield return null;
        }
    }
        

}
