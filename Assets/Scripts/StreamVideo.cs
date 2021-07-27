using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    private GameObject currentPlayer=null;
    public VideoClip FemaleVideoClip;
    public GameObject interfacedecul;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            StartCoroutine(PlayVideo());
        }  
    }

    public void restartVideoStream()
    {
        StartCoroutine(PlayVideo());
    }

    public void WomenVideo()
    {
        videoPlayer.clip = FemaleVideoClip;
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    { 
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        //audioSource.Play();
    }

    public void stopVideo()
    {
        videoPlayer.Stop();
        //interfacedecul.SetActive(false);
    }
}
