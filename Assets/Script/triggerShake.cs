using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerShake : MonoBehaviour
{
    public GameObject cam;

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            StopAllCoroutines();
        }
    }
    public void triggerShak()
    {
        StartCoroutine(cam.GetComponent<CameraShake>().Shake(0.25f, 0.5f));
    }
}
