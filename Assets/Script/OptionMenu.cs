using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume) //volume change
    {
        audioMixer.SetFloat("volume",volume);
    }

    public void SetFullscreen(bool isFullscreen) //fullscreen change
    {
        Screen.fullScreen = isFullscreen;
    }
}
