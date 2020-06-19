using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundPrefab : MonoBehaviour
{
    float soundTime;
    void Start()
    {
        soundTime = 3f;
    }

    void Update()
    {
        soundTime -= 1 * Time.deltaTime;
        if (soundTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
