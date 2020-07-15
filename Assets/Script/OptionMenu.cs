using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumnSlider;
    static float currentFloat = 0f;

    private void Update()
    {
        volumnSlider.value = currentFloat;
    }

    public void SetVolume(float volume) //volume change
    {
        audioMixer.SetFloat("volume",volume);
        currentFloat = volume;
    }

    public void SetFullscreen(bool isFullscreen) //fullscreen change
    {
        Screen.fullScreen = isFullscreen;
    }
}
