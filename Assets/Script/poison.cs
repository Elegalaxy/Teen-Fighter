
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
    //this script is for storing ability stat change
    public static bool isPoisoned = false;
    public static bool isChaos = false;
    public static Dictionary<int, bool> chaosStarter = new Dictionary<int, bool>();
    public static bool bleed = false;

    public static float dmgAmplify = 1;
}
