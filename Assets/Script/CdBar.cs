using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CdBar : MonoBehaviour
{
    public Slider cdSlider;
    public float maxSlider = 100f;
    public GameObject cdPlayer;

    private void Start()
    {
        cdSlider.maxValue = maxSlider;
        cdSlider.value = maxSlider;
    }
    public void SetMax(float maxSlide)
    {
        cdSlider.maxValue = maxSlide;
        maxSlider = maxSlide;
    }

    public void SetCD(float cd)
    {
        cdSlider.value = cd;
    }

    public void SetDuration(float duration)
    {
        cdSlider.value = duration;
    }
}
