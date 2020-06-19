using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charsIndex : MonoBehaviour
{
    static public int charsSelectedIndex;
    static public int charsSelectedIndex2;

    public void setInd(int x, int y)
    {
        //put static var in a function, store data beyond scenes
        charsSelectedIndex = x;
        charsSelectedIndex2 = y;
    }
}
