using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facing : MonoBehaviour
{
    public static bool face;
    public static bool face2;
    public void facingRight(bool x)
    {
        if (x)
        {
            face = true;
        }
        else
        {
            face = false;
        }

    }
    public void facingRight2(bool y)
    {
        if (y)
        {
            face2 = true;
        }
        else
        {
            face2 = false;
        }

    }

}
