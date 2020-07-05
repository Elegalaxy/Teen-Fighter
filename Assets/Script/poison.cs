
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
    //this script is for storing ability stat change
    public static bool isPoisoned;
    public static bool isChaos;

    public static float dmgAmplify;
    private void Start()
    {
        isPoisoned = false;
        isChaos = false;
        dmgAmplify = 1;
    }
}
