using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    private void Awake()
    {
        if(PauseMenu.isBgm == false)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
