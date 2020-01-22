using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Wideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    // Use this for initialization
    void Update()
    {
       PlayVideo();
    }
    void PlayVideo()
    {
        videoPlayer.Prepare();
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
}